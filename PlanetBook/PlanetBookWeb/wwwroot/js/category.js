var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Category/GetAll"
        },
        "columns": [
            { "data": "name", "width": "80%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Category/Upsert/${data}" class="btn btn-info text-white" style="cursor: pointer">
                                    <i class="bi bi-pencil-square"></i>
                                </a>
                                <a onclick=Delete("/Admin/Category/Delete/${data}") class="btn btn-secondary text-white" style="cursor: pointer">
                                    <i class="bi bi-trash"></i>
                                </a>
                            </div>
                           `
                        ;
                }, "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Bạn chắn chắn muốn xóa?",
        text: "Bạn sẽ không thể khôi phục lại dữ liệu!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}