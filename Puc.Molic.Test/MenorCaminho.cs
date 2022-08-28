using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Puc.Molic.Test
{
    public class MenorCaminho
    {
        [Fact]
        public void Test()
        {
            NodeTest a = new NodeTest("A");
            NodeTest b = new NodeTest("B");
            NodeTest c = new NodeTest("C");
            NodeTest d = new NodeTest("D");
            NodeTest e = new NodeTest("E");

            a.Edges.Add(new EdgeTest(5, b));
            a.Edges.Add(new EdgeTest(7, e));
            a.Edges.Add(new EdgeTest(5, d));
            b.Edges.Add(new EdgeTest(4, c));
            c.Edges.Add(new EdgeTest(2, e));
            c.Edges.Add(new EdgeTest(8, d));
            d.Edges.Add(new EdgeTest(8, c));
            d.Edges.Add(new EdgeTest(6, e));
            e.Edges.Add(new EdgeTest(3, b));

           var queue = FindAllPaths(a, e);

        }

       
        public Queue<QueueItem> FindAllPaths(NodeTest startNodeTest, NodeTest endNodeTest)
        {
            var queue = new Queue<QueueItem>();
            queue.Enqueue(new QueueItem(startNodeTest, new List<EdgeTest>()));
            while (queue.Count > 0)
            {
                var currentItem = queue.Dequeue();
                foreach (var edge in currentItem.Node.Edges)
                {
                    if (!currentItem.Visited.Contains(edge))
                    {
                        List<EdgeTest> visited = new List<EdgeTest>(currentItem.Visited);
                        visited.Add(edge);
                        if (edge.TargetNode == endNodeTest)
                        {
                            // visited.Count is the path length
                            // visited.Sum(e => e.Weight) is the total weight
                        }
                        else
                        {
                            queue.Enqueue(new QueueItem(edge.TargetNode, visited));
                        }
                    }
                }
            }
            return queue;
        }

        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            var result = new List<IList<int>>();
            var queue = new Queue<List<int>>();

            queue.Enqueue(new List<int> { 0 });

            while (queue.Count > 0)
            {
                var currentPath = queue.Dequeue();
                var currentNode = currentPath[currentPath.Count - 1];

                if (currentNode == graph.Length - 1)
                {
                    result.Add(currentPath);
                }
                else
                {
                    foreach (var child in graph[currentNode])
                    {
                        currentPath.Add(child);
                        queue.Enqueue(new List<int>(currentPath));
                        currentPath.RemoveAt(currentPath.Count - 1);
                    }
                }
            }
            return result;
        }


    }

    public class QueueItem
    {

        public NodeTest Node { get; private set; }
        public List<EdgeTest> Visited { get; private set; }

        public QueueItem(NodeTest node, List<EdgeTest> visited)
        {
            Node = node;
            Visited = visited;
        }

    }

    public class NodeTest
    {
        public string Name { get; set; }

        public List<EdgeTest> Edges = new List<EdgeTest>();
        public NodeTest(string name)
        {
            Name = name;
        }
    }

    public class EdgeTest
    {
        public NodeTest TargetNode { get; set; }

        public int Id { get; set; }

        public EdgeTest(int id, NodeTest targetNode)
        {
            TargetNode = targetNode;    
        }

    }
}
