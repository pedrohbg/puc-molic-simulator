using Puc.Molic.Model;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Puc.Molic.Test
{
    public class Main
    {


        [Fact]
        public void TestDiagram()
        {
            DiagramFlow flow = new DiagramFlow();   
            var diagram = flow.GetDiagram();
            TransformationHelper transformationHelper = new TransformationHelper();
            string xml = transformationHelper.ToXML(diagram);

        }


        [Fact]
        public void TestGetAllPaths()
        {
            DiagramFlow flow = new DiagramFlow();
            var diagram = flow.GetDiagram();
            var graph = GetGraph(diagram);

        }

        private Graph GetGraph(Diagram diagram)
        {
            // 6 implies the number of nodes in graph
            var g = new Graph(diagram.Nodes.Count);
            // Connect node with an edge
            // First and second parameter indicate node index

            foreach (var edge in diagram.Edges)
            {
                int idSource = edge.SourceId - 1;
                int idTarget = edge.TargetId - 1;
                g.addEdge(idSource, idTarget);
            }

            return g;



        }

        public void GetAllPaths(Diagram diagram, Node startNode, Node endNode)
        {
            List<Diagram> diagramList = new List<Diagram>();
            diagram.Nodes.Add(startNode);

            var outEdges = diagram.Edges.Where(x => x.Id == startNode.Id).ToList();

            foreach (var edge in outEdges)
            {
                Diagram path = new Diagram();
                path.Nodes.Add(startNode);
             

            }

        }


    }
}