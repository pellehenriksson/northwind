var Northwind = Northwind || {};

Northwind.Message = function (container) {
    this.container = container;
};

Northwind.Message.prototype = function () {

    var showSuccess = function (message) {
        var html = buildHtml("alert-success", message);
        attachToContainer(this, html);
    };

    var showError = function (message) {
        var html = buildHtml("alert-error", message);
        attachToContainer(this, html);
    };

    var attachToContainer = function (obj, html) {
        var c = $("#" + obj.container);
        var a = $(html);
        c.append(a);
        a.delay(2000).fadeOut("slow", function () { $(this).remove(); });
    };

    var buildHtml = function (type, message) {
        return "<div class='alert alert-block " + type + " fade in' data-alert><button type='button' class='close' data-dismiss='alert'>×</button><p> " + message + " </p></div>";
    };

    return {
        showError: showError,
        showSuccess: showSuccess
    };
}();

