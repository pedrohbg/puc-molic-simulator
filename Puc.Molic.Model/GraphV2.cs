using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Molic.Model
{


	public class GraphV2
	{
		// Number of Vertices
		public List<string> Paths { get; set; }
		
		public List<VerticesV2> Nodes { get; set; }
		public GraphV2(List<int> nodeIds)
		{
			Paths = new List<string>();

			Nodes = new List<VerticesV2>();
			foreach (int nodeId in nodeIds)
            {
				VerticesV2 node = new VerticesV2(nodeId);
				Nodes.Add(node);
			}
		}

		public VerticesV2 GetNodeById(int id)
        {
			return Nodes.Where(x => x.Id == id).FirstOrDefault();
		}

		public VisitedNode GetVisitedNodeById(List<VisitedNode> visitedNodeList, int id)
		{
			return visitedNodeList.Where(x => x.Id == id).FirstOrDefault();
		}
		public void Connection(int startId, int last)
		{
			// Safe connection
			var edge = new VerticesV2(last);

			var nodeStart = this.Nodes.Where(x => x.Id == startId).FirstOrDefault();

			if (nodeStart?.Next == null)
			{
                nodeStart.Next = edge;
			}
			else
			{
				// Add edge at the end
				nodeStart.Last.Next = edge;
			}
			// Get last edge 
			nodeStart.Last = edge;
		}
		//  Handling the request of adding new edge
		public void addEdge(int startId, int lastId)
		{

			Connection(startId, lastId);
			
		}
		public void printGraph()
		{
			// Print graph ajlist Node value
			foreach (var node in Nodes)
			{
				Console.Write("\nAdjacency list of vertex " + Convert.ToString(node.Id) + " :");
				var edge = node.Next;
				while (edge != null)
				{

					// Visit to next edge
					edge = edge.Next;
				}
			}
		}
		public void findPath(int start, int last,
							 String path, List<VisitedNode> visitedList)
		{

			if (GetVisitedNodeById(visitedList, start).VisitedTwice == true)
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
            if (GetVisitedNodeById(visitedList, start).Visited == false)
            {
				GetVisitedNodeById(visitedList, start).Visited = true;
			}
            else
            {
				GetVisitedNodeById(visitedList, start).VisitedTwice = true;
			}

			// This is used to iterate nodes edges
			var edge = GetNodeById(start).Next;
			while (edge != null)
			{
				this.findPath(edge.Id, last, path + "," + edge.Id, visitedList);
				// Visit to next edge
				edge = edge.Next;
			}
			// Reset the value of visited node status
			GetVisitedNodeById(visitedList, start).VisitedTwice = false;

		}

		public void allPath(int start, int last)
		{


			var visitedNodeList = new List<VisitedNode>();
			foreach (var node in Nodes)
			{
				VisitedNode visitedNode = new VisitedNode(node.Id);
				visitedNodeList.Add(visitedNode);
			}

			this.findPath(start, last, start.ToString(), visitedNodeList);
		}

	}

	public class AjlistNodeV2
	{
		// Vertices node key
		public int Id;

		public AjlistNodeV2 next;

		public AjlistNodeV2(int id)
		{
			// Set value of node key
			this.Id = id;
			this.next = null;
		}
	}
	public class VerticesV2
	{
		public int Id;
		//public int data;
		public VerticesV2 Next;
		public VerticesV2 Last;
		public VerticesV2(int id)
		{
			Id = id;
			//this.data = data;
			this.Next = null;
			this.Last = null;
		}
	}

	public class VisitedNode
	{
		public int Id;
		public bool Visited;
		public bool VisitedTwice;

		public VisitedNode(int id)
        {
            Id = id;
        }
    }
}
