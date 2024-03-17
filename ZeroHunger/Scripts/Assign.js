$(".Assign").click(function (event) {
    event.preventDefault(); // Prevent the default form submission
    var collectId = $(this).closest("tr").find("input[name='collectId']").val(); // Retrieve collectId
    

    $.ajax({
        type: "POST",
        url: Admin/Assign,
        data: { collectId: collectId }, // Pass both collectId and selectedEmployee
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

