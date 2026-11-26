using Microsoft.AspNetCore.Mvc;
using MVCDemo01.Models;

namespace MVCDemo01.Controllers
{
    //[Route("Prod")] // BaseURL/Prod/JsonAction -> Attribute Routing
    public class ProductsController : Controller
    {

        #region Actions

        //[HttpGet] // By Default The Method is GET
        // To Access This Method -> BaseURL(https://localhost:7032)/Products/Test
        // Change The String to Content Result to return HTML Page
        //public string Test()
        //{
        //    return "Hello From Test";
        //}

        // Special Return Types For MVC Controller Methods (Special Return Types) AS:
        // Response -> 
        // [Status Code , Content Type(Default Text/Plain) , Content Itself]


        // =======================================================================


        //[HttpGet]
        //public ContentResult Test()
        //{
        //    //ContentResult result = new ContentResult();
        //    //result.ContentType = "text/html"; // The Default Content Type is text/plain, I Want to Change it to text/html  
        //    //result.Content = $"Hello From Test</br> Bye";
        //    ////result.StatusCode = 700; // The Status Code is Range From 100 to 599, I Want to Change it to 700
        //    //result.StatusCode= StatusCodes.Status200OK; // Status200OK Is the Default
        //    //return result;
        //    //// In ContentResult Method, I Have The Control In Every Thing I Want To Change.

        //    // There Are Helper Methods For Every Return Type.
        //    // Helper Method For ContentResult :
        //    return Content(content: "Hello From Test<br> Bye", contentType: "text/html");

        // =======================================================================

        //[HttpGet]
        //public IActionResult Test() // IActionResult Is The Base Class For All Return Types , And Action Result Implement IActionResult Interface Indirectly.
        //{
        //    //ContentResult result = new ContentResult();
        //    //result.ContentType = "text/html"; // The Default Content Type is text/plain, I Want to Change it to text/html  
        //    //result.Content = $"Hello From Test</br> Bye";
        //    ////result.StatusCode = 700; // The Status Code is Range From 100 to 599, I Want to Change it to 700
        //    //result.StatusCode= StatusCodes.Status200OK; // Status200OK Is the Default
        //    //return result;
        //    //// In ContentResult Method, I Have The Control In Every Thing I Want To Change.

        //    // There Are Helper Methods For Every Return Type.
        //    // Helper Method For ContentResult :
        //    if (true)
        //    {
        //        return Content(content: "Hello From Test<br> Bye", contentType: "text/html");
        //    }
        //    else
        //        return NotFound();

        // =======================================================================

        // Master Action [Index]   = The Dafault Route For The Controller Is Index Action Method
        // To Access This Method -> BaseURL/Products
        //                    OR -> BaseURL/Products/Index

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();  // Gives Exception 
        //}


        // BaseURL/Products/GetProducts

        //[HttpGet]
        //// We Must Create Product File in Models Folder To Return Data From This Method.
        //public IActionResult GetProducts()  // JasonResult -> Return Type Is Used To Return Data In JSON Format
        //{
        //    var Products = new List<Product>()
        //    {
        //        new Product() { Id = 1, Name = "Mobile" },
        //        new Product() { Id = 2, Name = "Laptop" },
        //    };
        //    return Json(Products); // Json() Is Helper Method For JsonResult Return Type
        //}

        // =======================================================================

        //[NonAction]
        //public IActionResult Test() // This Method Will Not Appear In The URL Bec It Hides A Public Methods
        //{
        //    return Content("Hello From Test");
        //}

        // =======================================================================

        // Make Action That Take The Products By ID
        // BaseURL/Products/GetProductById/10

        //public IActionResult GetProductById(int id)
        //{
        //    if (id < 0)
        //        return BadRequest(); // Return Status Code 400 Bad Request
        //    else if (id == 0)  // Redirect The Page Of The Index
        //        //return RedirectToAction("GetProducts");
        //        return RedirectToAction(nameof(GetProducts));
        //    else if (id > 10)
        //        return NotFound(); // Return Status Code 404 Not Found
        //    else 
        //        return Json(new Product() { Id = id, Name = "Taplet" }); // Return Status Code 200 OK)

        //}

        // =======================================================================

        // Make Action The Redirect To URL
        // BaseURL/Products/RedirectAction
        //[HttpGet]
        //public IActionResult RedirectAction()
        //{
        //    return Redirect("https://www.facebook.com/");  // Take From Me URL And Redirect To Another URL
        //}

        // But RedierctToAction() Is Used To Redirect To Another Action Method In The Same Controller Or Another Controller

        #endregion

        #region Routing

        //[HttpGet("Json")] // BaseURL/Prod/Json -> Attribute Routing = Another Way For Attribute Routing
        ////[HttpGet]
        //// BaseURL/Products/JsonAction -> Convetial Routing
        //public IActionResult JsonAction()
        //{
        //    return Json("Hello From Json Action");
        //}

        #endregion

        #region Model Binding

        // Actions -> Parameters [Simple Data (AS: int Id, string Name, etc.) , Complex Data (User Defined Data Types) , Collections Data (Arrays Or Lists)]

        #region Simple Data

        //[HttpGet] // By Default The Method is GET
        //          // BaseURL/Products/GetById/10/20 -> That's Wrong URL Because The Default Route Is {controller}/{action}/{id?}


        //// BaseURL/Products/GetById/10?anotherId=20 -> That's Right URL Because The Default Route Is {controller}/{action}/{id?}
        //// BaseURL/Products/GetById?id=10&anotherId=20 
        ////             -> The First Parameter Will Be From The Route Data And The Second Parameter Will Be From The Query String 
        //public IActionResult GetById([FromQuery] int id, [FromQuery(Name ="Id2")] int anotherId)
        //{
        //    return Json(new { Id = id, AnotherId = anotherId });
        //}

        #endregion

        #region Complex Data
        //[HttpGet]
        //// BaseURL/Products/Search?Term=Mobile&MinPrice=1000&Page=2
        //// OR Another Way
        //// BaseURL/Products/Search?filter.Term=Mobile&filter.MinPrice=1000&filter.Page=2
        //public IActionResult Search(ProductFilter filter)
        //{
        //    return Content("Search Is Completed");
        //}


        #endregion

        #region Collections Data
        //[HttpGet]
        //// BaseURL/Products/GetByIds?ids=10&ids=20&ids=30
        //public IActionResult GetByIds( int[] ids)
        //{
        //    return Json(new { Ids = ids });
        //}


        #endregion

        #endregion

    }
}

