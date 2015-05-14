                
function selectApplication() {
    var id = $("#selectApplication").val();
    if (id > 0) {
        $.post("/Feature/_Features/" + id, function(data) {
            $("#features").html(data);
        });

        $.post("/Configuration/_ConfigurationSettings/" + id, function(data) {
            $("#configuration").html(data);           
        });
    }
}        

function createApplicationSuccess() {
    selectApplication();
    $("#selectApplication").change(function () {
        selectApplication();
    });
}

$(document).ready(function() {
    $("#selectApplication").change(function () {
        selectApplication();
    });

    // auto modal stuff
    $('body').on('click', '.modal-link', function (e) {
        e.preventDefault();
        $(this).attr('data-target', '#modal-container');
        $(this).attr('data-toggle', 'modal');
    });
    // Attach listener to .modal-close-btn's so that when the button is pressed the modal dialog disappears
    $('body').on('click', '.modal-close-btn', function () {
        $('#modal-container').modal('hide');
    });
    //clear modal cache, so that new content can be loaded
    $('#modal-container').on('hidden.bs.modal', function () {
        $(this).removeData('bs.modal');
    });
});

