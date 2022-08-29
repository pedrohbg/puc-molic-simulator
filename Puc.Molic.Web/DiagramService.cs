using Puc.Molic.Model;

namespace Puc.Molic.Web
{
    public class DiagramService
    {
        //get all possible diagram paths and create subdiagrams
        public List<Diagram> GetDiagramPaths(Diagram diagram, int startNodeId, int endNodeId)
        {
            DiagramFlow diagramFlow = new DiagramFlow();
            
            List<Diagram> subDiagrams = new List<Diagram>();
            List<string> paths = GetPaths(diagram, startNodeId, endNodeId);
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

        //get all possible diagram paths by ids
        public List<string> GetPaths(Diagram diagram, int startNodeId, int endNodeId)
        {
            DiagramFlow diagramFlow = new DiagramFlow();
            DiagramGraph g = diagramFlow.GetGraphV2(diagram);

            g.allPath(startNodeId, endNodeId);

            return g.Paths.OrderBy(x => x.Length).ToList();

        }
    }
}
