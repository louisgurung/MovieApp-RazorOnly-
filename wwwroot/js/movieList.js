var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({    //table id here
        "ajax": {
            "url": "/api/Movie",
            "type": "GET",
            "datatype":"json"
        },
        "columns": [
            { "data": "name", "width": "25%" },       //all in lowercase; while editing, this is redirecting to edit.cshtml and that works from razorcs.cshtml
            { "data": "writer", "width": "25%" },        //in case of delete a local function is made, passed url with id
            { "data": "imdb", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                    <a href="/MovieList/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer;width=100px;'>
                     Edit</a>
                     &nbsp;
                    <a class='btn btn-danger text-white' style = 'cursor:pointer;width=100px;' onclick=Delete('/api/movie?id='+${data})>
                            Delete</a >
                     </div >`;
                },"width":"25%"
            }

        ],
        "language": {
            "emptyTable":"no data found"
        },
        "width":"100%"
    })
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons:true,   //this shows cancel option too
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