﻿$(document).ready(function () {
    $('#Emprestimos').DataTable({
        language: {
            "decimal":        "",
            "emptyTable":     "No data available in table",
            "info":           "Mostrando _START_ de _END_ ...",
            "infoEmpty":      "Showing 0 to 0 of 0 entries",
            "infoFiltered":   "(filtered from _MAX_ total entries)",
            "infoPostFix":    "",
            "thousands":      ",",
            "lengthMenu":     "Mostrar _MENU_ linhas",
            "loadingRecords": "Loading...",
            "processing":     "",
            "search":         "Procurar:",
            "zeroRecords":    "No matching records found",
            "paginate": {
                "first":      "Primeiro",
                "last":       "Último",
                "next":       "Próximo",
                "previous":   "Anterior"
            },
            "aria": {
                "orderable":  "Order by this column",
                "orderableReverse": "Reverse order this column"
            }
        }
    });

    setTimeout(()=> {
        $(".alert").fadeOut("slow", () => {
            $(this).alert("close");
        })
    }, 3500)
})