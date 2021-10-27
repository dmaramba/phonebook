

$("#btnSubmit").on("click", function () {
    if (!$("#contact_name").val().trim()) {
        toastr.error("Please enter contact name.", "PhoneBook Manager");
        return;
    }
    if (!$("#phone_number").val().trim()) {
        toastr.error("Please enter contact number.", "PhoneBook Manager");
        return;
    }

    if (!ValidatePhone($("#phone_number").val())) {
        toastr.error("Please enter valid phone number.", "PhoneBook Manager");
        return;
    }

    $("error_message").html('');
    $("error_message").hide();
    var dataArr = {};
    dataArr['Name'] = $('#contact_name').val().trim();
    dataArr['PhoneNumber'] = $('#phone_number').val().trim();
    $.ajax({
        url: '/PhoneBook/CreatePhoneBookEntry',
        type: 'POST',
        data: dataArr,
        dataType: 'json',

        success: function (data) {
            if (data.success === true) {
                toastr.clear();
                toastr.info("Phone book entry created.", "PhoneBook Manager");
                $('#phoneBookDatatable').DataTable().ajax.reload();
                $("#contact_name").val('');
                $("#phone_number").val('');
                $('.close').click();
            }
            else {
                toastr.clear();
                $("error_message").html(data.data);
                $("error_message").show();
                toastr.error(data.data, "PhoneBook Manager");
            }
        },
        error: function (ex) {
            toastr.clear();
            $("error_message").html(ex);
            $("error_message").show();
            toastr.error("Error occure while trying to save.", "PhoneBook Manager");
        }
    });
});


function ValidatePhone(number) {
    var regexPattern = new RegExp(/^[0-9-+]+$/);    
    return regexPattern.test(number);
} 

function DeleteEntry(entryId) {
    if (confirm('Delete phone book entry?')) {
        var dataArr = {};
        dataArr['Id'] = entryId;
        console.log(dataArr);
        $.ajax({
            url: '/PhoneBook/DeletePhoneBookEntry',
            type: 'POST',
            data: dataArr,
            dataType: 'json',

            success: function (data) {
                if (data.success === true) {
                    toastr.clear();
                    toastr.info("Phone book entry deleted.", "PhoneBook Manager");
                    $('#phoneBookDatatable').DataTable().ajax.reload();
                }
                else {
                    toastr.clear();
                    toastr.error("Error occure while trying to save. ", "PhoneBook Manager");
                }
            },
            error: function (ex) {
                toastr.clear();
                toastr.error("Error occure while trying to save.", "PhoneBook Manager");
            }
        });
    }
}