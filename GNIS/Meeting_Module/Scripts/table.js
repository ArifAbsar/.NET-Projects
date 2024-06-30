$(document).ready(function () {
    // Load Customer Names based on Customer Type
    $('input[name="customerType"]').change(function () {
        loadCustomerNames($(this).val());
    });

    // Initially load corporate customer names since it's checked by default
    loadCustomerNames('Corporate');

    function loadCustomerNames(type) {
        let url = (type === 'Corporate') ? '/Home/GetCorporateCustomers' : '/Home/GetIndividualCustomers';
        $.get(url, function (data) {
            let options = '';
            data.forEach(function (customer) {
                options += `<option value="${customer.Id}">${customer.Name}</option>`;
            });
            $('#customerName').html(options);
        });
    }

    function loadProductServices() {
        $.get('/Home/GetProductServices', function (data) {
            let options = '';
            data.forEach(function (productService) {
                options += `<option value="${productService.Id}" data-unit="${productService.Unit}">${productService.Name}</option>`;
            });
            $('#productService').html(options);
        });

        $('#productService').change(function () {
            let unit = $(this).find(':selected').data('unit');
            $('#unit').val(unit);
        });
    }

    // Load Products/Services on document ready
    loadProductServices();

    function addProductService() {
        let productServiceId = $('#productService').val();
        let productServiceName = $('#productService option:selected').text();
        let quantity = $('#quantity').val();
        let unit = $('#unit').val();
        let slNo = $('#productServiceTable tr').length + 1;

        let newRow = `
            <tr>
                <td>${slNo}</td>
                <td>${productServiceName}</td>
                <td>${quantity}</td>
                <td>${unit}</td>
                <td><button class="btn btn-warning btn-edit">Edit</button></td>
                <td><button class="btn btn-danger btn-delete">Delete</button></td>
            </tr>
        `;
        $('#productServiceTable').append(newRow);
    }

    function saveMeetingMinutes() {
        let meetingData = {
            CustomerType: $('input[name="customerType"]:checked').val(),
            CustomerId: $('#customerName').val(),
            Date: $('#meetingDate').val(),
            Time: $('#meetingTime').val(),
            MeetingPlace: $('#meetingPlace').val(),
            AttendsFromClientSide: $('#clientSide').val(),
            AttendsFromHostSide: $('#hostSide').val(),
            ProductsServices: []
        };

        $('#productServiceTable tr').each(function () {
            let row = $(this);
            let productService = {
                ProductServiceId: row.find('td:eq(1)').data('id'),
                Quantity: row.find('td:eq(2)').text(),
                Unit: row.find('td:eq(3)').text()
            };
            meetingData.ProductsServices.push(productService);
        });

        $.ajax({
            url: '/Home/SaveMeetingMinutes',
            type: 'POST',
            data: JSON.stringify(meetingData),
            contentType: 'application/json',
            success: function (response) {
                alert('Meeting minutes saved successfully');
            },
            error: function (error) {
                alert('Error saving meeting minutes');
            }
        });
    }

    // Bind the add button click event
    $('#addProductService').click(function () {
        addProductService();
    });

    // Bind the save button click event
    $('#saveMeetingMinutes').click(function () {
        saveMeetingMinutes();
    });
});
