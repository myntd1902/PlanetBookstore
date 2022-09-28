var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/User/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "company.name", "width": "20%" },
            { "data": "role", "width": "15%" },
            {
                "data": {
                    id: "id", lockoutEnd: "lockoutEnd"
                },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today)
                    {
                        return `<div class="text-center">
                                    <a onclick=LockUnlock('${data.id}') class="btn btn-info text-white" style="cursor: pointer">
                                        <i class="bi bi-unlock"></i>
                                    </a>
                                </div>`;
                    }
                    else
                    {
                        return `<div class="text-center">
                                    <a onclick=LockUnlock('${data.id}') class="btn btn-secondary text-white" style="cursor: pointer">
                                        <i class="bi bi-lock"></i>
                                    </a>
                                </div>`;
                    }
                }, "width": "20%"
            }
        ]
    });
}

function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
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