# A-corporate-website-
Developed Over Asp.net MVC And Sql


## ASP.NET MVC Architecture
Here, you will learn an overview of MVC architecture.

The MVC architectural pattern has existed for a long time in software engineering. All most all the languages use MVC with slight variation, but conceptually it remains the same.

Let's understand the MVC architecture supported in ASP.NET.

MVC stands for Model, View, and Controller. MVC separates an application into three components - Model, View, and Controller.

## Model
Model represents the shape of the data. A class in C# is used to describe a model. Model objects store data retrieved from the database.

## Model represents the data.

## View
View in MVC is a user interface. View display model data to the user and also enables them to modify them. View in ASP.NET MVC is HTML, CSS, and some special syntax (Razor syntax) that makes it easy to communicate with the model and the controller.

## View is the User Interface.

## Controller
The controller handles the user request. Typically, the user uses the view and raises an HTTP request, which will be handled by the controller. The controller processes the request and returns the appropriate view as a response.

## Controller is the request handler.

The following figure illustrates the interaction between Model, View, and Controller.

### Setup ###
- ASP.NET Web Application for Visual C#
- Leave	**Create directory for solution** unchecked.
- Create new **Git repository** checked.
- Select Empty template.
- Select **MVC** for **Add folders and core references for**.

### Adding a Controller ###
- Right click `Controllers` folder in the project > Add > Class
- Filename for a controller class must end in **Controller** so Visual Studio can distinguish controllers from regular classes.
- Our controller must inherit from the MVC controller base class and include using `System.Web.Mvc`
- Controller must be public so its accessible.
- See Controller/ComicBooksController.cs

### Adding Action Method ###
- Methods need to be public so its accessible.
- http://localhost:62466/ComicBooks/Detail via **ComicBooksController.cs**
- http://localhost:62466/Sarn/Test via **Sarn.Controller.cs**
```csharp
    public class ComicBooksController : Controller
    {
        public string Detail()
        {
            return "Hello";
        }
    }
```
- URL routing is controller/action
- `ContentResult`, `ViewResult`, and `RedirectResult` are a type of action result type.
- Had to modify the return type to `ActionResult`.  In order to find out that was the correct type to return that works for both `ContentResult` and `RedirectResult` you can hover over those types and click on F12 (to view the code) or ALT+F12 (to peek the code).

### Adding View ###
- In **View** folder right click Add > MVC 5 View Page (Razor) to add a view or right click on a controller method.
- You may need to create a folder for each controller and have the view be inside that folder. See **View/ComicBooks/Detail.cshtml**
- **Razor** is a view language allowing you to create views by combining C# and HMTL.
- For Razor, you can edit without having to recompile.
- `ViewBag` is an object built into MVC that allows you to pass data from a controller to a view.  See **Controller/ComicBooksController.cs**
- Using a dynamic type like `ViewBag` you don't get intellisense in the view when developing using Razor.  See **strongly typed view below**
- ViewBag variables are not case-sensitive.

### Add Third Party Files ###
- Once you add it in the root of the project, you'll need to click on the [Show All Files](https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwjvn9X558HYAhUvYt8KHXnrBUkQjRwIBw&url=http%3A%2F%2Fwww.global-webnet.com%2Fblog%2Fpost%2F2012%2F08%2F21%2FCpp-WhereAreFolders-Filters.aspx&psig=AOvVaw11JibuGpt8y1jSgXByPHSd&ust=1515275683427298) icon to see it in Visual Studios
```csharp
//generates a link in Razor
@Html.ActionLink("Comic Book Gallery", "Index", "ComicBooks", new { area = "" }, new { @class = "navbar-brand" })
```
### Adding Data Model ###
- Data modeling is the noun in a website
- Models > ComicBooks.cs
```csharp
ViewBag.artists = new string[]
{
    "Script: Dan Slott",
    "Pencils: Humberto Ramos",
    "Inks: Victor Olazaba",
    "Colors: Edgar Delgado",
    "Letters: Chris Eliopoulos"
};
```
- Since the data in artists appears to be the artist and a role, we can break this down into an artist model 
```csharp
    // strongly typed view - by putting object into the view vs. ViewBag.ComicBook = comicBook;
    return View(comicBook);  // will automatically look in the views folder
```
- Instead of using the `ViewBag` method, you can make comicBook be a **strongly typed view**.  To make the view strongly typed, go to the view and add `@model ComicBookGallery.Models.ComicBook`.  See **Details.cshtml**.
- Doing it this way allows the intellisense to work.
```csharp
// sometimes you need to wrap a Razor statement in parenthesis
@(Model.Favorite ? "Yes" : "No")
```
- By typing in `foreach` and then hitting tab twice triggers a prebuilt Visual Studio codesnippet generating
```csharp
foreach (var item in collection)
{

}
```
- CTRL + ; = search project.
- **constructor** can not have a return value and shares the same name as the class name.

```csharp
// allow nullable
public ActionResult Detail(int? id)
```

### Debugger ###
- F11 - Step Into
- F10 - Step Over
- Shift + F11 - Step Out
