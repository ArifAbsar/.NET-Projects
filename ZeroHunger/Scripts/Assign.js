$(".Assign").click(function (event) {
    event.preventDefault(); // Prevent the default form submission
    var collectId = $(this).closest("tr").find("input[name='collectId']").val(); // Retrieve collectId
    var selectedEmployee = $("#selectedEmployeeHidden").val(); // Retrieve selected employee

    $.ajax({
        type: "POST",
        url: Admin/Assign,
        data: { collectId: collectId, selectedEmployee: selectedEmployee }, // Pass both collectId and selectedEmployee
        success: function (response) {
            if (response.success) {
                alert("Assignment successful");
            } else {
                alert("Assignment failed");
            }
        },
        error: function () {
            alert("Error occurred while processing the assignment");
        }
    });
});

