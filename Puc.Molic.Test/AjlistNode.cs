using Puc.Molic.Model;
using System;
using System.Collections.Generic;
using Xunit;
namespace Puc.Molic.Test
{

	public class TestGraph
    {


		[Fact]
		public void TestMainX_V2()
		{
			// 6 implies the number of nodes in graph

			List<int> list = new List<int>() { 0, 1, 2 };


			var g = new GraphV2(list);
			// Connect node with an edge
			// First and second parameter indicate node index
			g.addEdge(0, 1);
			g.addEdge(1, 2);
			g.addEdge(2, 1);



			// Print graph element
			g.printGraph();
			// Source 1
			// Destination 4
			g.allPath(0, 1);
		}



	}
}
