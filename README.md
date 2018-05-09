# TaskMessage

* Тех. задание https://github.com/DimaKonshin/40TaskMessanger/blob/master/DocumentationTaskMessanger/0Task.pdf
* UML диаграмма - https://github.com/DimaKonshin/40TaskMessanger/blob/master/DocumentationTaskMessanger/6UML.xps
* DB diagram - https://github.com/DimaKonshin/40TaskMessanger/blob/master/DocumentationTaskMessanger/5DataBase.pdf
* DB files - https://github.com/DimaKonshin/40TaskMessanger/tree/master/WebUI/App_Data
* Scripts - https://github.com/DimaKonshin/40TaskMessanger/tree/master/WebUI/Scripts/TypeScript

## Comments about stack of technologies and other technicue solutions
* IDE: Visual Studio 2017 
* Database Management System: MS SQL Server
* Technologies: C#, ASP.NET MVC 5 + Web Api, Entity Framework 6, Ajax, JQuery, Bootstrap

###Note:
* Entity Framework : LazyLoadingEnabled = false;
* Pattern is implemented Generic Repository
* The implementation of the Repository pattern and the DbContext instance are embedded with Ninject

###The solution consists of two projects: 
* Class library         - Domain. 
* ASP.NET MVC5 + WebApi - WebUI.