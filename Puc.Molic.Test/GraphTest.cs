using Puc.Molic.Model;
using System;
using System.Collections.Generic;
using Xunit;
namespace Puc.Molic.Test
{
	//Testing graph algorithm
	//Author: Pedro Henrique Bof Gerico
	public class TestGraph
    {

		//testing paths
		[Fact]
		public void TestPathAlgorithm1()
		{
			//create node list
			List<int> list = new List<int>() { 0, 1, 2 };


			var g = new DiagramGraph(list);
			// Connect node with an edge
			// First and second parameter indicate node index
			g.addEdge(0, 1);
			g.addEdge(1, 2);
			g.addEdge(2, 1);



			// Print graph element
			g.printGraph();

			//Execute path algorithm
			g.allPath(0, 1);

			Assert.True(g.Paths.Contains("0,1,2,1"));
			Assert.True(g.Paths.Contains("0,1"));
		}

		//testing paths
		[Fact]
		public void TestPathAlgorithm2()
		{
			//create node list
			List<int> list = new List<int>() { 0, 1, 2 };


			var g = new DiagramGraph(list);
			// Connect node with an edge
			// First and second parameter indicate node index
			g.addEdge(0, 2);
			



			// Print graph element
			g.printGraph();

			//Execute path algorithm
			g.allPath(0, 2);

			Assert.True(g.Paths.Contains("0,2"));
		}

		[Fact]
		public void TestPathAlgorithm3()
		{
			//create node list
			List<int> list = new List<int>() { 0, 1, 2, 3, 4 };


			var g = new DiagramGraph(list);
			// Connect node with an edge
			// First and second parameter indicate node index
			g.addEdge(0, 1);
			g.addEdge(1, 2);
			g.addEdge(2, 3);
			g.addEdge(3, 4);


			// Print graph element
			g.printGraph();

			//Execute path algorithm
			g.allPath(0, 4);

			Assert.True(g.Paths.Contains("0,1,2,3,4"));
		}

		[Fact]
		public void TestPathAlgorithm4()
		{
			//create node list
			List<int> list = new List<int>() { 0, 1, 2, 3, 4 };


			var g = new DiagramGraph(list);
			// Connect node with an edge
			// First and second parameter indicate node index
			g.addEdge(0, 1);
			g.addEdge(1, 2);
			g.addEdge(2, 3);
			g.addEdge(3, 4);
			g.addEdge(0, 4);

			// Print graph element
			g.printGraph();

			//Execute path algorithm
			g.allPath(0, 4);

			Assert.True(g.Paths.Contains("0,4"));
			Assert.True(g.Paths.Contains("0,1,2,3,4"));
		}

	}
}
