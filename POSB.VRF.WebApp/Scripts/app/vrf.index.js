function error_handler(e) {
    if (e.errors) {
        var message = "Errors:\n";
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function () {
                    message += this + "\n";
                });
            }
        });
        alert(message);
    }
}



function onRowBound(e) {
    //$(".k-grid-Edit").find("span").removeClass();
    //$(".k-grid-Delete").find("span").removeClass();
    var grid = $("#CCUGrid").data("kendoGrid");
    var gridData = grid.dataSource.view();
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].ColorCode == 'Yellow') {
            $("#CCUGrid tr.k-alt").removeClass("k-alt");
            grid.table.find("tr[data-uid='" + gridData[i].uid + "']").addClass("yellow-row");
        } else if (gridData[i].ColorCode == 'Red') {
            $("#CCUGrid tr.k-alt").removeClass("k-alt");
            grid.table.find("tr[data-uid='" + gridData[i].uid + "']").addClass("red-row");
        } else {

        }
    }
}
