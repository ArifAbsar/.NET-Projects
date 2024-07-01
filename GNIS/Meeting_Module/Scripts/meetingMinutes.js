$(document).ready(function () {
    $('input[name="customerType"]').change(function () {
        loadCustomerNames($(this).val());
    });

    // Initial load 
    loadCustomerNames('Corporate');

    function loadCustomerNames(type) {
        let url = (type === 'Corporate') ? '/Home/GetCorporateCustomers' : '/Home/GetIndividualCustomers';
        $.get(url, function (data) {
            console.log('Customer Data:', data); // Debugging 
            let options = '<option value="">Select Customer</option>';
            data.forEach(function (customer) {
                let name = type === 'Corporate' ? customer.Corporate_Customer_Name : customer.Customer_Name;
                options += `<option value="${customer.Id}">${name}</option>`;
            });
            $('#customerName').html(options);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.error("Error fetching data: ", textStatus, errorThrown);
        });
    }

    function loadProductServices() {
        $.get('/Home/GetProductServices', function (data) {
            console.log('Product Services Data:', data);
            let options = '<option value="">Select Product/Service</option>';
            data.forEach(function (productService) {
                options += `<option value="${productService.id}" data-unit="${productService.unit}">${productService.Prod_Name}</option>`;
            });
            $('#productService').html(options);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.error("Error fetching data: ", textStatus, errorThrown);
        });

        $('#productService').change(function () {
            let unit = $(this).find(':selected').data('unit');
            $('#unit').val(unit);
        });
    }

    // Load Products
    loadProductServices();

    function updateSerialNumbers() {
        $('#productServiceTable tr').each(function (index) {
            $(this).find('td:first').text(index + 1);
        });
    }

    function addProductService() {
        let productServiceId = $('#productService').val();
        let productServiceName = $('#productService option:selected').text();
        let quantity = $('#quantity').val();
        let unit = $('#unit').val();
        let slNo = $('#productServiceTable tr').length;

        let newRow = `
            <tr>
                <td>${slNo}</td>
                <td class="prod-name" data-id="${productServiceId}">${productServiceName}</td>
                <td class="quantity">${quantity}</td>
                <td class="unit">${unit}</td>
                <td><button type="button" class="btn btn-warning btn-edit">Edit</button></td>
                <td><button type="button" class="btn btn-danger btn-delete">Delete</button></td>
            </tr>
        `;
        $('#productServiceTable').append(newRow);
        $('#noRecordsRow').remove(); // Remove "No matching records found" 
        updateSerialNumbers();
    }

    function saveMeetingMinutes() {
        let meetingDate = $('#meetingDate').val();
        let meetingTime = $('#meetingTime').val();

        // Default date and time if not provided
        if (!meetingDate) {
            meetingDate = new Date().toISOString().split('T')[0]; // Default to today's date
        }
        if (!meetingTime) {
            meetingTime = '00:00'; // Default to midnight
        }

        let meetingData = {
            CustomerType: $('input[name="customerType"]:checked').val(),
            CustomerId: $('#customerName').val(),
            MeetingDate: meetingDate,  // Ensure the key name matches with the controller
            MeetingTime: meetingTime,  // Ensure the key name matches with the controller
            MeetingPlace: $('#meetingPlace').val(),
            AttendsFromClientSide: $('#clientSide').val(),
            AttendsFromHostSide: $('#hostSide').val(),
            ProductsServices: []
        };

        $('#productServiceTable tr').each(function () {
            let row = $(this);
            let productService = {
                ProductServiceId: row.find('.prod-name').data('id'),
                Quantity: row.find('.quantity').text(),
                Unit: row.find('.unit').text()
            };
            meetingData.ProductsServices.push(productService);
        });

        console.log('Meeting Data:', meetingData); // Debugging

        $.ajax({
            url: '/Home/SaveMeetingMinutes',
            type: 'POST',
            data: JSON.stringify(meetingData),
            contentType: 'application/json',
            success: function (response) {
                if (response.success) {
                    alert('Meeting minutes saved successfully');
                } else {
                    alert('Error saving meeting minutes: ' + response.message);
                }
            },
            error: function (error) {
                alert('Error saving meeting minutes: ' + error.responseText);
            }
        });
    }

    $('#addProductService').click(function () {
        addProductService();
    });

    $('#saveMeetingMinutes').click(function () {
        saveMeetingMinutes();
    });

    $('#productServiceTable').on('click', '.btn-edit', function (event) {
        event.preventDefault(); // Prevent form submission
        let row = $(this).closest('tr');
        editProductService(row);
    });

    $('#productServiceTable').on('click', '.btn-save', function (event) {
        event.preventDefault(); // Prevent form submission
        let row = $(this).closest('tr');
        saveEditedProductService(row);
    });

    $('#productServiceTable').on('click', '.btn-delete', function (event) {
        event.preventDefault(); // Prevent form submission
        let row = $(this).closest('tr');
        deleteProductService(row);
    });
});
