/// <reference path="greetingpage.ts" />
var Program = /** @class */ (function () {
    function Program() {
    }
    Program.Main = function () {
        GreetingPage.Start();
        VisiblePagesController.HideAll();
        ClicksByBtnsController.ObserveAllButtons();
        GreetingPage.GetMore();
    };
    return Program;
}());
//# sourceMappingURL=app.js.map