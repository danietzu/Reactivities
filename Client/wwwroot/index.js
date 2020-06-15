window.state = {
    save: function (key, str) {
        localStorage[key] = str;
    },
    load: function (key) {
        return localStorage[key];
    },
    remove: function (key) {
        localStorage.removeItem(key);
    }
};

function log(message) {
    console.log(message);
}

function showModal() {
    $('.ui.modal').modal('show');
}

function showDropdown() {
    $('.ui.dropdown').dropdown();
}