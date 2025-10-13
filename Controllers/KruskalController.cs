using Prim_Kruskal_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prim_Kruskal_Web.Models;

namespace Prim_Kruskal_Web.Controllers
{
    public class KruskalController : Controller
    {
        
        // GET: Kruskal: gọi giải thuật kruskal từ service, trả về kết quả
        
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()

        {
            var graphs = db.LoadGraph();
            return View(graphs);
        }

        public ActionResult RunKruskal()
        {
            try
            {
                var graph = db.LoadGraph();
                if (graph == null || graph.Nodes.Count == 0)
                    return Content("khong co du lieu trong do thi.");

                var mst = Kruskal.FindMST(graph);
                return View("Result", mst);
            }
            catch (Exception ex)
            {
                return Content("Loi khi chay Kruskal: " + ex.Message);
            }
        }


        public ActionResult Compare()
        {
            var graph = db.LoadGraph();
            if (graph == null) return Content("Không có dữ liệu đồ thị.");

            // Thời gian Kruskal
            var sw = System.Diagnostics.Stopwatch.StartNew();
            var mstKruskal = Kruskal.FindMST(graph);
            sw.Stop();

            var result = new CompareResult
            {
                Graph = graph,
                KruskalEdges = mstKruskal,
                KruskalTime = sw.ElapsedMilliseconds,
                KruskalCost = mstKruskal.Sum(e => e.Weight),

                // Keep placeholders for Prim - nhóm bạn sẽ gán sau merge
                PrimEdges = null,
                PrimTime = 0,
                PrimCost = 0
            };

            return View(result);
        }


    }

    
}