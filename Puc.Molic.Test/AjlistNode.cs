using Puc.Molic.Model;
using System;
using System.Collections.Generic;
using Xunit;
namespace Puc.Molic.Test
{

	public class TestGraph
    {

		//testing paths
		[Fact]
		public void TestMainX_V2()
		{

			List<int> list = new List<int>() { 0, 1, 2 };


			var g = new DiagramGraph(list);
			// Connect node with an edge
			// First and second parameter indicate node index
			g.addEdge(0, 1);
			g.addEdge(1, 2);
			g.addEdge(2, 1);



			// Print graph element
			g.printGraph();

			g.allPath(0, 1);
		}



	}
}
