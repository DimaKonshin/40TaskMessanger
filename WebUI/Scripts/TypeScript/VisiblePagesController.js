var VisiblePagesController = /** @class */ (function () {
    function VisiblePagesController() {
    }
    VisiblePagesController.HideAll = function () {
        $("#CreateCategoryForm").hide();
        $("#GreetingPage").hide();
    };
    VisiblePagesController.ShowFormCreateCategory = function () {
        VisiblePagesController.HideAll();
        if ($("#CreateCategoryForm").is(":hidden")) {
            $("#CreateCategoryForm").show();
        }
    };
    VisiblePagesController.ShowGreetingPage = function () {
        VisiblePagesController.HideAll();
        if ($("#GreetingPage").is(":hidden")) {
            $("#GreetingPage").show();
        }
    };
    return VisiblePagesController;
}());
var ClicksByBtnsController = /** @class */ (function () {
    function ClicksByBtnsController() {
    }
    ClicksByBtnsController.ObserveAllButtons = function () {
        this.ClickCreateCategoryBtn();
        this.ClickShowGreetingPageBtn();
    };
    ClicksByBtnsController.ClickCreateCategoryBtn = function () {
        $("#CreateCategoryBtn").on("click", function () { VisiblePagesController.ShowFormCreateCategory(); });
    };
    ClicksByBtnsController.ClickShowGreetingPageBtn = function () {
        $("#ShowGreetingPageBtn").on("click", function () { VisiblePagesController.ShowGreetingPage(); });
    };
    return ClicksByBtnsController;
}());
//# sourceMappingURL=VisiblePagesController.js.map