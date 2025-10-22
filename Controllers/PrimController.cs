using Prim_Kruskal_Web.Models;
using System;
using System.Web.Mvc;

namespace Prim_Kruskal_Web.Controllers
{
    public class PrimController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RunPrim()
        {
            try
            {
                var graph = db.LoadGraph();
                if (graph == null || graph.Nodes.Count == 0)
                    return Content("Không có dữ liệu trong đồ thị.");

                var mstEdges = Prim.FindMST(graph); // phần này cần có class Prim.cs
                var result = new MSTResult(graph, mstEdges);

                // Trả về view mô phỏng chung
                return View("~/Views/Home/MoPhong.cshtml", result);
            }
            catch (Exception ex)
            {
                return Content("Lỗi khi chạy Prim: " + ex.Message);
            }
        }
    }
}
