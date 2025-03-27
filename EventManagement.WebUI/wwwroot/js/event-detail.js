function GetEventUpdateModalBody(id) {
    $.ajax({
        async: false,
        url: "/Home/_EventUpdate?id=" + id,
        success: function (result) {
            $("#EventUpdateModalBody").html(result);
            $("#EventUpdateModal").modal("show");
        }
    });
}

function EventUpdatePost() {
    var sendData = new FormData(document.querySelector('#EventUpdateModalBody'))
    $.ajax({
        type: "Post",
        contentType: false,
        processData: false,
        data: sendData,
        async: false,
        url: "/Home/_EventUpdate",
        success: function (result) {
            $("#EventUpdateModal").modal("hide");
            Swal.fire({
                icon: 'success',
                title: 'Kaydedildi',
                showConfirmButton: false,
                timer: 1500,
            });
            setTimeout(function () {
                location.reload();
            }, 1500);
        },
        error: function (result) {
            if (result.status == 422) {
                $("#EventUpdateModalBody").html(result.responseText);
            }
            else {
                Swal.fire({
                    icon: 'error',
                    title: 'Hata!',
                    text: 'Sistem Hatası!',
                    confirmButtonText: 'Kapat',
                    confirmButtonColor: '#d33',
                    customClass: {
                        popup: 'rounded-0',
                    }
                });
            }
        }
    });
}
function GetEventParticipiantsModalBody(id) {
    $.ajax({
        async: false,
        url: "/Home/_EventParticipiantsEdit?id=" + id,
        success: function (result) {
            $("#EventParticipiantsModalBody").html(result);
            $("#EventParticipiantsModal").modal("show");
        }
    });
}

function EventParticipiantsPost() {
    var sendData = new FormData(document.querySelector('#EventParticipiantsModalBody'))
    $.ajax({
        type: "Post",
        contentType: false,
        processData: false,
        data: sendData,
        async: false,
        url: "/Home/_EventParticipiantsEdit",
        success: function (result) {
            $("#EventParticipiantsModal").modal("hide");
            Swal.fire({
                icon: 'success',
                title: 'Kaydedildi',
                showConfirmButton: false,
                timer: 1500,
            });
            setTimeout(function () {
                location.reload();
            }, 1500);
        },
        error: function (result) {
            if (result.status == 422) {
                $("#EventParticipiantsModalBody").html(result.responseText);
            }
            else {
                Swal.fire({
                    icon: 'error',
                    title: 'Hata!',
                    text: 'Sistem Hatası!',
                    confirmButtonText: 'Kapat',
                    confirmButtonColor: '#d33',
                    customClass: {
                        popup: 'rounded-0',
                    }
                });
            }
        }
    });
}