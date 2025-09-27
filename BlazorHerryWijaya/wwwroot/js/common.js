//function showConfirmationModal() {
//    bootstrap.Modal.getOrCreateInstance(document.getElementById('bsConfirmationModal')).show();
//}
//function hideConfirmationModal() {
//    bootstrap.Modal.getOrCreateInstance(document.getElementById('bsConfirmationModal')).hide();
//}

window.DataTableInterop = {
    init: function (tableId) {
        $('#' + tableId).DataTable();
    },
    //destroy: function (tableId) {
    //    if ($.fn.DataTable.isDataTable('#' + tableId)) {
    //        $('#' + tableId).DataTable().destroy();
    //    }
    //}
};
