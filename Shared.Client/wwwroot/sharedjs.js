
function ModalFunction(id) {
    var modalElement = document.getElementById(id);
    var modal = new bootstrap.Modal(modalElement);
    modal.show();
}
function ModalFunctionClose(id) {
    var modalElement = document.getElementById(id);
    var modal = bootstrap.Modal.getInstance(modalElement);
    if (modal) {
        modal.hide();
    }
}

window.blazorCulture = {
    get: () => localStorage['BlazorCulture'],
    set: (value) => localStorage['BlazorCulture'] = value
};


