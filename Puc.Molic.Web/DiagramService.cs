using Puc.Molic.Model;

namespace Puc.Molic.Web
{
    public class DiagramService
    {
        public List<Diagram> ObterCaminhosDeDiagrama(int startNodeId, int endNodeId)
        {
            DiagramFlow diagramFlow = new DiagramFlow();
            var diagram = diagramFlow.GetDiagram();
            List<Diagram> subDiagrams = new List<Diagram>();
            List<string> paths = ObterCaminhos(startNodeId, endNodeId);
            int subDiagramId = 1;
            foreach (var stringPath in paths)
            {
                Diagram subDiagram = new Diagram();
                subDiagram.Id = subDiagramId;
                subDiagram.Name = stringPath;

                List<string> list = stringPath.Split(',').ToList();

                foreach (var idStr in list)
                {
                    int id = Convert.ToInt32(idStr);
                    Node node = diagram.Nodes.Where(x => x.Id == id).First();

                    subDiagram.Nodes.Add(node);
                }

                List<Edge> edges = diagram.Edges.Where(x => subDiagram.Nodes.Select(y=>y.Id).Contains(x.SourceId) && subDiagram.Nodes.Select(y => y.Id).Contains(x.TargetId)).ToList();


                subDiagram.Edges = edges;

                subDiagrams.Add(subDiagram);
                subDiagramId++;
            }
            return subDiagrams;
        }

        public List<string> ObterCaminhos(int startNodeId, int endNodeId)
        {
            DiagramFlow diagramFlow = new DiagramFlow();
            DiagramGraph g = diagramFlow.GetGraphV2(diagramFlow.GetDiagram());

            g.allPath(startNodeId, endNodeId);

            return g.Paths.OrderBy(x => x.Length).ToList();

        }

        internal Diagram GetDiagram()
        {
            DiagramFlow diagramFlow = new DiagramFlow();
            return diagramFlow.GetDiagram();
        }
    }
}
