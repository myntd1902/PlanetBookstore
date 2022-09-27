var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Company/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "streetAddress", "width": "20%" },
            { "data": "city", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            {
                "data": "isAuthorizedCompany",
                "render": function (data) {
                    if (data) {
                        return `<input type="checkbox" disable checked />`
                    }
                    else {
                        return `<input type="checkbox" disable />`
                    }
                },
                "width": "15%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Company/Upsert/${data}" class="btn btn-info text-white" style="cursor: pointer">
                                    <i class="bi bi-pencil-square"></i>
                                </a>
                                <a onclick=Delete("/Admin/Company/Delete/${data}") class="btn btn-secondary text-white" style="cursor: pointer">
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