using Puc.Molic.Model;

namespace Puc.Molic.Web.Models
{
    //view model for the main Molic page
    public class FlowModel
    {
        public Diagram Diagram { get; set; }

        public int ElementoInicial { get; set; }

        public int ElementoFinal { get; set; }

        public List<Diagram> DiagramPaths { get; set; }

        public FlowModel()
        {
            DiagramPaths = new List<Diagram>();
        }
    }
}
