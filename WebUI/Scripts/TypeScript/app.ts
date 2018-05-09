/// <reference path="greetingpage.ts" />

class Program {
    static Main(): void {
        GreetingPage.Start();
        VisiblePagesController.HideAll();
        ClicksByBtnsController.ObserveAllButtons();
        GreetingPage.GetMore();
    }
}

