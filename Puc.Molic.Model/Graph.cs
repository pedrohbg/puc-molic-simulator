using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Molic.Model
{


	public class Graph
	{
		// Number of Vertices
		public List<string> Paths { get; set; }
		public int size { get; set; }
		public Vertices[] node { get; set; }
		public Graph(int size)
		{
			Paths = new List<string>();
			// Set value
			this.size = size;
			this.node = new Vertices[size];
			this.setData();
		}
		// Set initial node value
		public void setData()
		{
			if (this.size <= 0)
			{
				Console.WriteLine("\nEmpty Graph");
			}
			else
			{
				for (var index = 0; index < this.size; index++)
				{
					// Set initial node value
					this.node[index] = new Vertices(index);
				}
			}
		}
		public void connection(int start, int last)
		{
			// Safe connection
			var edge = new AjlistNode(last);
			if (this.node[start].next == null)
			{
				this.node[start].next = edge;
			}
			else
			{
				// Add edge at the end
				this.node[start].last.next = edge;
			}
			// Get last edge 
			this.node[start].last = edge;
		}
		//  Handling the request of adding new edge
		public void addEdge(int start, int last)
		{
			if (start >= 0 && start < this.size &&
				last >= 0 && last < this.size && this.size > 0)
			{
				this.connection(start, last);
			}
			else
			{
				// When invalid nodes
				Console.WriteLine("\nHere Something Wrong");
			}
		}
		public void printGraph()
		{
			// Print graph ajlist Node value
			for (var index = 0; index < this.size; ++index)
			{
				Console.Write("\nAdjacency list of vertex " + Convert.ToString(index + 1) + " :");
				var edge = this.node[index].next;
				while (edge != null)
				{
					// Display graph node 
					Console.Write("  " + this.node[edge.Id].data);
					// Visit to next edge
					edge = edge.next;
				}
			}
		}
		public void findPath(int start, int last,
							 String path, bool[] visit)
		{
			if (start >= this.size || last >= this.size ||
				start < 0 || last < 0 || this.size <= 0)
			{
				return;
			}
			if (visit[start] == true)
			{
				// When have already visited
				return;
			}
			if (start == last)
			{
				// Display result
				Paths.Add(path);
				Console.WriteLine("(" + path + ")");
			}
			// Here modified the value of visited node
			visit[start] = true;
			// This is used to iterate nodes edges
			var edge = this.node[start].next;
			while (edge != null)
			{
				this.findPath(edge.Id, last, path + "," + edge.Id, visit);
				// Visit to next edge
				edge = edge.next;
			}
			// Reset the value of visited node status
			visit[start] = false;
		}
		// Print all paths between two vertices in directed graph
		public void allPath(int start, int last)
		{
			if (this.size <= 0)
			{
				return;
			}
			// Use to track node
			bool[] visit = new bool[this.size];
			bool[] visitedEdges = new bool[this.size];
			// Set initial value
			for (var i = 0; i < this.size; i++)
			{
				visit[i] = false;
			}
			Console.WriteLine("\nResult : ");
			this.findPath(start, last, start.ToString(), visit);
		}

	}

	public class AjlistNode
	{
		// Vertices node key
		public int Id;

		public AjlistNode next;

		public AjlistNode(int id)
		{
			// Set value of node key
			this.Id = id;
			this.next = null;
		}
	}
	public class Vertices
	{
		public int data;
		public AjlistNode next;
		public AjlistNode last;
		public Vertices(int data)
		{
			this.data = data;
			this.next = null;
			this.last = null;
		}
	}
}
