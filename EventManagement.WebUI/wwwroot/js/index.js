$(document).ready(function () {
    if (isTransactionCompleted)
        TransactionCompleted();
});

function DeleteEvent(id) {
    Swal.fire({
        title: 'Silmek istediğinize emin misiniz?',
        text: "Bu öğe silinecektir. Bu işlemi geri alamazsınız.",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: 'Evet Sil',
        cancelButtonText: `Kapat`,
        confirmButtonColor: '#d33',
        customClass: {
            popup: 'rounded-0',
            confirmButton: "btn-flat"
        }
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                async: false,
                url: "/Home/DeleteEvent?id=" + id,
                success: function (result) {
                    window.location.href = '/Home/CompleteTransaction?route=Index'
                },
                error: function (result) {
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
            });
        }
    })
}