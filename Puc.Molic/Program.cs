
using Puc.Molic.Model;

namespace Puc.Molic // Note: actual namespace depends on the project name.
{

    internal class Program
    {
        static void Main(string[] args)
        {
            DiagramFlow p = new DiagramFlow();

            Graph g = p.GetGraph(p.GetDiagram());

            g.printGraph();
            g.allPath(0, 8);

            foreach (var item in g.Paths)
            {
                Console.WriteLine("path:" +item);
            }
            Console.ReadLine();

        }

    }

}