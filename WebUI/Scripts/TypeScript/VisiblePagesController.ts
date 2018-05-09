class VisiblePagesController {

    static HideAll() {
        $("#CreateCategoryForm").hide();
        $("#GreetingPage").hide();
    }

    static ShowFormCreateCategory() { 
        VisiblePagesController.HideAll();
        if ($("#CreateCategoryForm").is(":hidden")) {
            $("#CreateCategoryForm").show();
        }
    }

    static ShowGreetingPage() {
        VisiblePagesController.HideAll();
        if ($("#GreetingPage").is(":hidden")) {
            $("#GreetingPage").show();
        }
    }
}

class ClicksByBtnsController {

    static ObserveAllButtons() {
        this.ClickCreateCategoryBtn();
        this.ClickShowGreetingPageBtn();
    }

    static ClickCreateCategoryBtn() {  
        $("#CreateCategoryBtn").on("click", () => { VisiblePagesController.ShowFormCreateCategory(); })
    }

    static ClickShowGreetingPageBtn() {
        
        $("#ShowGreetingPageBtn").on("click", () => { VisiblePagesController.ShowGreetingPage(); })
    }

}