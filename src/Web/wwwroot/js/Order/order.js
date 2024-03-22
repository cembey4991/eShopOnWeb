var Page = {
    Details: function (orderNumber) {
        $("#order-modal").html("");
        $.ajax({
            type: "GET",
            url: "/Admin/OrderDetail",
            data:{ orderNumber:orderNumber},
            success: function (res) {
                $("#order-modal").html(res);
            $("#order-modal-div").modal("show");
            }
        });
    }


}
$(document).ready(function () {
    $("#tblOrder").DataTable({
        "dom": 'tip',
        "processing": true,
        "select": true,
        "info": true,
        "retrieve": false,
        "order": false,
        "ajax": {
            "url": "/Admin/GetAllOrders",
            "type": "GET",
            "datatype": "json",
            "dataSrc":function(json){
                
                return json;
            },
            "error": function (xhr, error, code) {          
                
            }
        },
    "columns": [    
        { "data": "email", "autoWidth": true ,
        render: function (data, type, row, meta) {
          
            return data;
        }
    },     
        { "data": "orderDate", "autoWidth": true ,
            render: function (data, type, row, meta) {
                data = Common.ConvertUtcDate(data);
                return data;
            }
        },
        { "data": "total", "autoWidth": true ,
        render: function (data, type, row, meta) {
          
            return data;
        }
          },
          
        { "data": "status", "autoWidth": true ,
        render: function (data, type, row, meta) {
          
            return data;
        }
          },

        { "data": "", "width": "10%", "className":"text-center",  "orderable" : false,
            render: function (data, type, row, meta) {
                
                return `<a class="btn btn-primary" onclick=Page.Details(${row.orderNumber});>Detay</a>`;          
            }
        },
       
    ]
    });    
}); 



