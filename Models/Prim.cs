using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prim_Kruskal_Web.Models
{
    public class Prim
    {
        public static List<Edge> FindMST(Graph graph, int startNodeId)
        {
            var mst = new List<Edge>(); // danh sách cạnh kết quả
            var visited = new HashSet<int>(); // tập các đỉnh đã được chọn
            var availableEdges = new List<Edge>(); // các cạnh có thể chọn

            // Bắt đầu từ đỉnh đầu tiên
            var startNode = graph.Nodes.FirstOrDefault(n => n.Id == startNodeId);
            if (startNode == null) return mst;

            visited.Add(startNode.Id);

            // Lặp cho đến khi chọn đủ n-1 cạnh
            while (visited.Count < graph.Nodes.Count)
            {
                // Thêm tất cả các cạnh nối từ đỉnh đã thăm
                availableEdges = graph.Edges
                    .Where(e => (visited.Contains(e.Src.Id) && !visited.Contains(e.Destination.Id)) ||
                                (visited.Contains(e.Destination.Id) && !visited.Contains(e.Src.Id)))
                    .OrderBy(e => e.Weight)
                    .ToList();

                if (availableEdges.Count == 0)
                    break; // đồ thị không liên thông

                // Chọn cạnh nhỏ nhất
                var edge = availableEdges.First();

                mst.Add(edge);

                // Thêm đỉnh mới vào visited
                if (!visited.Contains(edge.Src.Id))
                    visited.Add(edge.Src.Id);
                if (!visited.Contains(edge.Destination.Id))
                    visited.Add(edge.Destination.Id);
            }

            return mst;
        }

        internal static object FindMST(Graph graph, string startNode)
        {
            throw new NotImplementedException();
        }
    }
}

