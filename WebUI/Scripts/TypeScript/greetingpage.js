/// <reference path="../@types/jquery/index.d.ts" />
var GreetingPage = /** @class */ (function () {
    function GreetingPage() {
    }
    GreetingPage.ClickMoreBtn = function () {
        return $("#getmore").click(function () { GreetingPage.GetMore(); });
    };
    GreetingPage.GetMore = function () {
        $("#getmore").text("Loading...");
        var link = this.GetLink();
        this.GetRequest(link, "GET");
    };
    GreetingPage.GetCategory = function () {
        return $(".category span strong").text();
    };
    GreetingPage.GetName = function () {
        return $(".name span strong").text();
    };
    GreetingPage.GetLink = function () {
        return "/api/Events/" + this.GetCategory() + "/" + this.GetName() + "/" + $("#siteEvents .row").length + "/";
    };
    GreetingPage.GetRequest = function (link, typeRequest) {
        $.ajax({
            url: link,
            type: typeRequest,
            success: function (data) {
                this.GetSuccess(data);
            }.bind(this)
        });
    };
    GreetingPage.GetSuccess = function (data) {
        this.ShowListOfMessage(data.List);
        this.ChooseMore(data.Msg);
    };
    GreetingPage.ShowListOfMessage = function (data) {
        for (var _i = 0, data_1 = data; _i < data_1.length; _i++) {
            var item = data_1[_i];
            var date = item.Date;
            var str = '<div class = "row">' +
                '<div class="col-md-2 col-md-offset-1 s2-column1">' +
                '<h2>' + item.TaskName + '</h2>' +
                '<span>' + item.Name + '</span>' +
                '<span>' + date.toLocaleString() + '</span></div>' +
                '<div class = "col-md-8 s2-column2">' +
                '<p>' + item.Description + '</p></div></div>';
            $("#siteEvents").append(str);
        }
    };
    GreetingPage.ChooseMore = function (msg) {
        $("#getmore").text(msg);
        var checkMore = $("#getmore").text().toString();
        if (checkMore == "There are no more events") {
            $("#getmore").off("click");
            $("#getmore").css("cursor", "text");
        }
    };
    GreetingPage.ClickByCategoryItem = function () {
        $(".categories li a").click(function (event) {
            $(".categories li a").removeClass("selected");
            $(event.target).addClass("selected");
            var category = $(event.target).text();
            $(".category span strong").text(category);
            if ($("#siteEvents .row").length > 0) {
                $("#siteEvents").text("");
            }
            $("#getmore").off("click");
            $("#getmore").on("click", function () { GreetingPage.GetMore(); });
            $("#getmore").css("cursor", "pointer");
            GreetingPage.GetMore();
        });
    };
    GreetingPage.ClickByNameItem = function () {
        $(".names li a").click(function (event) {
            $(".names li a").removeClass("selected");
            $(event.target).addClass("selected");
            var name = $(event.target).text();
            $(".name span strong").text(name);
            if ($("#siteEvents .row").length > 0) {
                $("#siteEvents").text("");
            }
            $("#getmore").off("click");
            $("#getmore").on("click", function () { GreetingPage.GetMore(); });
            $("#getmore").css("cursor", "pointer");
            GreetingPage.GetMore();
        });
    };
    GreetingPage.ClickByBtnInformation = function () {
        $(".btn-information").click(function () {
            if ($(".s1").is(":hidden")) {
                $(".s1").show("slow");
                $(".btn-information").text("hide");
                if (window.matchMedia('(max-width: 480px)').matches) {
                    $(".s2").css("top", "160px");
                    $("footer").css("margin-top", "160px");
                }
                else if (window.matchMedia('(max-width: 768px)').matches) {
                    $(".s2").css("top", "160px");
                    $("footer").css("margin-top", "160px");
                }
            }
            else {
                $(".s1").hide("slow");
                $(".btn-information").text("show");
                if (window.matchMedia('(max-width: 480px)').matches) {
                    $(".s2").css("top", "50px");
                    $("footer").css("margin-top", "50px");
                }
                else if (window.matchMedia('(max-width: 768px)').matches) {
                    $(".s2").css("top", "50px");
                    $("footer").css("margin-top", "50px");
                }
            }
        });
    };
    GreetingPage.ClickByHideShowBtnInformation = function () {
        if ($(".s1").is(":hidden")) {
            if (window.matchMedia('(min-width: 768px)').matches) {
                $("footer").css("margin-top", "0px");
            }
            else if (window.matchMedia('(max-width: 768px)').matches) {
                $(".s2").css("top", "50px");
                $("footer").css("margin-top", "50px");
            }
            else if (window.matchMedia('(max-width: 480px)').matches) {
                $(".s2").css("top", "50px");
                $("footer").css("margin-top", "50px");
            }
        }
        else {
            if (window.matchMedia('(min-width: 768px)').matches) {
                $("footer").css("margin-top", "0px");
            }
            else if (window.matchMedia('(max-width: 768px)').matches) {
                $(".s2").css("top", "160px");
                $("footer").css("margin-top", "160px");
            }
            else if (window.matchMedia('(max-width: 480px)').matches) {
                $(".s2").css("top", "160px");
                $("footer").css("margin-top", "160px");
            }
        }
    };
    GreetingPage.ResizeWindow = function () {
        $(window).resize(function () {
            GreetingPage.ClickByHideShowBtnInformation();
        });
    };
    GreetingPage.Start = function () {
        this.ClickMoreBtn();
        this.ClickByCategoryItem();
        this.ClickByNameItem();
        this.ClickByBtnInformation();
        this.ResizeWindow();
        this.GetMore();
    };
    return GreetingPage;
}());
var TaskVM = /** @class */ (function () {
    function TaskVM() {
    }
    return TaskVM;
}());
var EventMsg = /** @class */ (function () {
    function EventMsg() {
        this.Msg = "More";
    }
    return EventMsg;
}());
//# sourceMappingURL=greetingpage.js.map