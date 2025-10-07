using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prim_Kruskal_Web.Controllers
{
    public class KruskalController : Controller
    {
        // GET: Kruskal: gọi giải thuật kruskal từ service, trả về kết quả
        public ActionResult Index()
        {
            return View();
        }
    }
}