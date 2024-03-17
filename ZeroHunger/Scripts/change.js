$(document).ready(function () {
    // Add event listener to the dropdown list
    $('#employeeDropdown').change(function () {
        // Get the selected value of the dropdown list
        var selectedValue = $(this).val();

        // Update the value of the hidden input field
        $('#selectedEmployeeHidden').val(selectedValue);
    });
});