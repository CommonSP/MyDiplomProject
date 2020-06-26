$(document).ready(function () {
    var $data = {}
    $("#navigate-item-user, #user-image").click(function () {
        $("#user-profil").toggle();
        $('#user-information-edit').find('input').each(function () {
            $data[this.name] = $(this).val();
        });
    });
    $("#user-profil").mouseup(function (e) { 
        var div = $("#user-information");
        if (!div.is(e.target) 
            && div.has(e.target).length === 0) { 
            $("#user-profil").toggle();
            exitProfil();
        }
    });
    $("#exit").click(function () {
        $("#user-profil").toggle();
        exitProfil();
    });
    $("#user-edit").click(function () {
       
        $(".right-side input").removeAttr("disabled"); 
        $(".user-buttons").show();
    });
    $(document).on('click', '#cancellation',function () {
        $('#user-information-edit').find('input').each(function () {
           $(this).val($data[this.name]);
        });
        $(".right-side input").attr("disabled", true);
        $(".user-buttons").hide();
    });
    $(document).on('click', '#submitEdit', function () {
        $('#user-information-edit').find('input').each(function () {
            $data[this.name] = $(this).val();
        });
        $('#navigate-item-user-p').replaceWith(function () {
            return '<p id="navigate-item-user-p">' + $data["FirstName"] + ' '+$data["LastName"] +'</p>';
        });
    });
    $('.add-group').click(function () {
        
        $('.right-message').load('/Message/AddGroup');
    });
    $(document).on('click', '.add-group-cancellation', function () {

        $('.right-message').load('/Message/Messages');
    });
    function exitProfil() {
        $('#user-information-edit').find('input').each(function () {
            $(this).val($data[this.name]);
        });
        $(".right-side input").attr("disabled", true);
        $(".user-buttons").hide();
    }
    $(document).on('click', '.groups-item', function () {
        
        var id = $(this)[0].dataset.id
        id = encodeURIComponent(id);
        $('.right-message').load('/Message/AddUserInGroup?id='+id);
    });
    $(document).on('click', '.message-item', function () {

        var id = $(this)[0].dataset.id
        
        id = encodeURIComponent(id);
        $('.right-message').load('/Message/MessagesUser?groupName=' + id);
        $('.groups').load(('/Message/MessagesLeft?groupName=' + id))
    });

    $(document).on('click', '.groupsleft', function () {

        var id = $(this)[0].dataset.id

        id = encodeURIComponent(id);
        $('.right-message').load('/Message/MessagesUser?groupName=' + id);
        $('.groups').load(('/Message/MessagesLeft?groupName=' + id))
    });
    
    

});
