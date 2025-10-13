using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prim_Kruskal_Web.Models
{
    public class CompareResult
    {

        public Graph Graph { get; set; } // toàn bộ đồ thị (nodes + edges)
        public List<Edge> KruskalEdges { get; set; } // kết quả MST từ Kruskal
        public long KruskalTime { get; set; } // ms
        public double KruskalCost { get; set; } // tổng trọng số

        // Những trường Prim để giữ chỗ —Phần Uyên Ngô nhé
        public List<Edge> PrimEdges { get; set; }
        public long PrimTime { get; set; }
        public double PrimCost { get; set; }
    

}
}