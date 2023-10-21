// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* Handlers */

$(document).ready(function () {
    $('#table-registro').DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registro",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total regiistros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registro por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Procurar por ",
            "oPaginate": {
                "sNext": 'Proximo',
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": "Ordenar colunas de forma ascendente",
                "sSortDescending": "Ordenar colunas de forma descendente"
            }
        }
    });

});