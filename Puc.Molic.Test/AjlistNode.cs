using Puc.Molic.Model;
using System;
using System.Collections.Generic;
using Xunit;
namespace Puc.Molic.Test
{
	// Include namespace system


    /*
Csharp program for 
Print all path between given vertices in a directed graph
*/
	public class TestGraph
    {
		[Fact]
		public void TestMainX()
		{
			// 6 implies the number of nodes in graph
			var g = new Graph(6);
			// Connect node with an edge
			// First and second parameter indicate node index
			g.addEdge(0, 4);
			g.addEdge(0, 3);
			g.addEdge(1, 0);
			g.addEdge(1, 2);
			g.addEdge(1, 4);
			
			g.addEdge(3, 4);
			g.addEdge(5, 4);

			g.addEdge(2, 1);
			g.addEdge(2, 4);
			g.addEdge(2, 5);
			g.addEdge(2, 0);
			g.addEdge(2, 3);
			// Print graph element
			g.printGraph();
			// Source 1
			// Destination 4
			g.allPath(2, 4);
		}

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




		[Fact]
		public void Compare()
		{
			var g = new Graph(6);
			// Connect node with an edge
			// First and second parameter indicate node index
			g.addEdge(0, 4);
			g.addEdge(0, 3);
			g.addEdge(1, 0);
			g.addEdge(1, 2);
			g.addEdge(1, 4);

			g.addEdge(3, 4);
			g.addEdge(5, 4);
			
			
			g.addEdge(2, 1);
			g.addEdge(2, 4);
			g.addEdge(2, 5);
			g.addEdge(2, 0);
			g.addEdge(2, 3);
			// Print graph element
			// Source 1
			// Destination 4

			g.addEdge(5, 4);
			g.addEdge(4, 5);



			g.allPath(2, 4);




			// 6 implies the number of nodes in graph

			List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5 };


			var gV2 = new GraphV2(list);
			// Connect node with an edge
			// First and second parameter indicate node index
			gV2.addEdge(0, 4);
			gV2.addEdge(0, 3);
			gV2.addEdge(1, 0);
			gV2.addEdge(1, 2);
			gV2.addEdge(1, 4);

			gV2.addEdge(3, 4);
			gV2.addEdge(5, 4);

			gV2.addEdge(2, 1);
			gV2.addEdge(2, 4);
			gV2.addEdge(2, 5);
			gV2.addEdge(2, 0);
			gV2.addEdge(2, 3);

			// Print graph element
			gV2.addEdge(5, 4);
			gV2.addEdge(4, 5);


			// Source 1
			// Destination 4
			gV2.allPath(2, 4);


			Assert.Equal(g.Paths.ToArray(), gV2.Paths.ToArray());
		}
	}
}
