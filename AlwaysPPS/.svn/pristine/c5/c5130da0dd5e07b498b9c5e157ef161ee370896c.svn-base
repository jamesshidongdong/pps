//Helper js for the application

var app = app || {};

(function () {

    app.Notification = (function () {
        ///<summary>notification popup (proxy class), has dependency with toastr.js</summary>

        var checkAndHandleMessageFromHeader = function(request) {
            var msg = app.Base64.decode(request.getResponseHeader('X-Message'));
            if (msg) {
                var title = app.Base64.decode(request.getResponseHeader('X-Message-Title'));
                displayNotification(msg, title, request.getResponseHeader('X-Message-Type'));
            }
        };

        var displayNotification = function (message, title, messageType) {            
            toastr[messageType](message, title);
        };

        return {
            warning: function (message, title) {
                toastr.warning(message, title);
            },
            success: function (message, title) {
                toastr.success(message, title);
            },
            error: function (message, title) {
                toastr.error(message, title);
            },
            info: function (message, title) {
                toastr.info(message, title);
            },
            handleAjaxNotification : function() {
                $(document).ajaxSuccess(function (event, request) {                    
                    checkAndHandleMessageFromHeader(request);
                }).ajaxError(function (event, request) {                    
                    checkAndHandleMessageFromHeader(request);
                    //displayNotification(request.responseText,'', "error");
                });
            },
            generic: function(msgStatus, message, title) {
                if (msgStatus) {
                    switch (msgStatus) {
                    case "2":
                        this.error(message, title);
                    case"1":
                    default:
                        this.success(message, title);
                        break;;
                    }
                }
            }
        };
    }());

    
    app.ajaxHelper = (function () {
        ///<summary>Ajax helper class</summary>
        return {
            /*ajaxValidationCallBack: function (message) {
                if (message) {
                    app.Notification.warning(message);
                }
            },
            ajaxSuccessCallBack: function (redirectUrl) {
                if (redirectUrl) {
                    location.href = redirectUrl; //redirect to given URL
                } else {
                    location.reload(); //refresh the page
                }
            },            
            ajaxFailedCallBack: function (message) {
                app.Notification.error(message);
            },
            ajaxFailureCallBack: function () {
                app.Notification.error('Error after performing an AJAX call.');
            },*/
            ajaxReturnCallBack: function(returnMessage, successCallback, errorCallback) {
                if (returnMessage) {
                    var r = returnMessage;
                    if (r.Status == "ok") {
                        successCallback();
                    }
                    else if (r.Status == "fail") {
                        errorCallback();
                    }
                }
                return false;
            }
        };
    }());


    app.Base64 = (function () {
        ///<summary>has dependency with base64.js</summary>
        return {
            encode: function (message) {
                if(message)
                    return Base64.encode(message);
            },
            decode: function (message) {
                if(message)
                    return Base64.decode(message);
            }
        };
    }());

})();

//Loading
function loade() {
    $("body").append("<div class=\"ui-widget-overlay loading\"></div><div class=\"loadeImg\"><img src=\"/Content/images/w_loader.gif\" ></div>");
}
function loadeStop() {
    $(".loading").remove();
    $(".loadeImg").remove();
}
//初始化
function windowing() {
    $("#slideArea").animate({
        left: 220,
        width: $("body").outerWidth(true) - 220,
    }, "1000");
}
//滑动
function slide(menuW, menuName, contentId, _this) {
    if ($("." + menuName).is(':visible')) {
        $("#" + contentId).animate({
            left: 0
        }, "1000", function () {
            var bodyW = $("body").outerWidth(true);
            var contentW = bodyW - menuW;
            $("." + menuName).addClass('displayN');
            $(_this).addClass('iconB-chevron-right').removeClass("iconB-chevron-left");
            $("#" + contentId).width(bodyW);
        });
    } else {
        $("." + menuName).removeClass("displayN");
        $("#" + contentId).animate({
            left: 220
        }, "1000", function () {
            var bodyW = $("body").outerWidth(true);
            var contentW = bodyW - menuW;
            $(_this).addClass('iconB-chevron-left').removeClass("iconB-chevron-right");
            $("#" + contentId).width(contentW);
        });

    }
}
//自动高度全屏
function structure(headH, menuW, menuName, contentId) {
    //var bodyH = $("body").height();
    var bodyH = document.documentElement.clientHeight;
    if (document.documentElement.scrollHeight) {
        bodyH = document.documentElement.scrollHeight;
    }
    var contentH = $("#" + contentId).outerHeight(true);
    if (bodyH > contentH) {
        var menuH = bodyH - headH;
        $(".wrapper").height(menuH);
        $(".contentWrapper").height(menuH);
    } else {
        $(".wrapper").height(contentH);
        $(".contentWrapper").height(contentH);
    }
}
