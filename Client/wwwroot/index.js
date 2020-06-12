window.state = {
    save: function (key, str) {
        localStorage[key] = str;
    },
    load: function (key) {
        return localStorage[key];
    }
};

function log(message) {
    console.log(message);
}