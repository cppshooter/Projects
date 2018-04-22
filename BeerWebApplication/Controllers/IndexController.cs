using System.Web.Mvc;
using BeerWebApplication.Class;
using BeerWebApplication.Business;
using System;

namespace BeerWebApplication.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View("Index");
        }
        // GET: Index
        public ActionResult Details(string id)
        {
            BusinessManager bm = new BusinessManager();
            BeerDetail beerDetail = bm.FetchBeerDetail(id);
            return View(beerDetail);
        }
        /// <summary>
        /// Fetch list of beers and format data according to JqGrid requirement
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public JsonResult FetchData(SearchGrid search)
        {
            try
            {
                BusinessManager bm = new BusinessManager();
                BeerList beerlist = bm.FetchBeerList(search);
                var jsonData = new
                {
                    total = beerlist.numberOfPages,
                    page = beerlist.currentPage,
                    records = beerlist.totalResults,
                    rows = beerlist.data
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json("{Message :" + ex.Message + "}", JsonRequestBehavior.AllowGet);
            }
        }


    }
}