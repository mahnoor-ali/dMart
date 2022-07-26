using Microsoft.AspNetCore.Mvc;

namespace DMART.Controllers
{
    public class SearchController : Controller
    {
        public ViewResult searchResult()
        {
            //list of objects here.. to return to view
            return View("searchResult");
        }
    }
}
