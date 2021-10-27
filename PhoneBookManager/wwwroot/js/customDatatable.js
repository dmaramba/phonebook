$(document).ready(function () {
    $("#phoneBookDatatable").DataTable({
        "processing": true,
        "serverSide": false,
        "filter": true,
        "lengthChange": false,
        "pageLength": 50,
        "language": {
            "emptyTable": "No records"
        },
        "ajax": {
            "url": "/PhoneBook/GetContacts",
            "type": "GET",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        },
            { "targets": [3],"orderable": false }
        ],
        "columns": [
            { "data": "id", "name": "ID", "autoWidth": true },  
            { "data": "name", "name": "Name", "autoWidth": true },
            { "data": "phoneNumber", "name": "PhoneNumber", "autoWidth": true },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-danger' onclick=DeleteEntry('" + row.id + "'); >Delete</a>";
                }
            }
        ]
    });
});  