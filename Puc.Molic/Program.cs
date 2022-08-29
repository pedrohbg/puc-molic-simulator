
using Puc.Molic.Model;

namespace Puc.Molic 
{        
    //test paths from diagram with Windows Console Application
    //Author: Pedro Henrique Bof Gerico
    internal class Program
    {

        static void Main(string[] args)
        {
            DiagramFlow p = new DiagramFlow();

            DiagramGraph g = p.GetGraphV2(p.GetDiagram());

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