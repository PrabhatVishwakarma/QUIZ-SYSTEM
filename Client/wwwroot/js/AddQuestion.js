function resetForm(formSelector) {
    document.querySelector(formSelector).reset();
}

window.localStorageInterop = {
    getUserId: function () {
        return localStorage.getItem("userId");
    }
}