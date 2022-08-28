using System.Xml.Serialization;

namespace Puc.Molic.Model
{
	public class Diagram
	{
		[XmlAttribute]
		public int Id { get; set; }
		[XmlAttribute]
		public string Name { get; set; }
		[XmlAttribute]
		public DateTime CreationDate { get; set; }
		[XmlAttribute]
		public DateTime LastSaved { get; set; }

		public List<Node> Nodes { get; set; }
		public List<Edge> Edges { get; set; }

		[XmlAttribute]
		public string FileName { get; set; }
		public Diagram()
		{
			Nodes = new List<Node>();
			Edges = new List<Edge>();
		}
	}

	public class Node
	{
		[XmlAttribute]
		public int Id { get; set; }
		[XmlAttribute]
		public string Type { get; set; }
		[XmlAttribute]
		public string Comment { get; set; }
		[XmlAttribute]
		public string Topic { get; set; }
		public Geometry Geometry { get; set; }
		public List<Dialog> Dialogs { get; set; }
		public Precond Precond { get; set; }

		public Node()
		{
			Geometry = new Geometry();
			Dialogs = new List<Dialog>();
			Precond = new Precond();
		}
	}

	public class Edge
	{
		[XmlAttribute]
		public int Id { get; set; }
		[XmlAttribute]
		public string Type { get; set; }
		[XmlAttribute]
		public int SourceId { get; set; }
		[XmlAttribute]
		public int TargetId { get; set; }
		public Utterance Utterance { get; set; }
		public Precond Precond { get; set; }

		public Pressup Pressup { get; set; }

		public Effect Effect { get; set; }

		public Edge()
		{
			Utterance = new Utterance();
			Precond = new Precond();
			Effect = new Effect();
		}
	}

	public class Geometry
	{

		public int PositionX { get; set; }
		public int PositionY { get; set; }
	}

	public class Dialog
	{
		[XmlAttribute]
		public string Subject { get; set; }
		[XmlAttribute]
		public string Ref { get; set; }

		public Pressup Pressup { get; set; }
		public List<Sign> Signs { get; set; }

		public Dialog()
		{
			Signs = new List<Sign>();
		}

	}

	public class Sign
	{
		[XmlAttribute]
		public string Type { get; set; }
		[XmlText]
		public string Value { get; set; }

	}

	public class Condition
	{
		[XmlText]
		public string Value { get; set; }

		public Condition()
		{
		}

		public Condition(string value)
		{
			Value = value;
		}

	}

	public class Precond
	{
		public List<Condition> Conditions { get; set; }
	}

	public class Pressup
	{
		[XmlText]
		public string Value { get; set; }
	}

	public class Effect
	{
		public List<Variable> Variables { get; set; }

		public Effect()
		{
			Variables = new List<Variable>();
		}
	}

	public class Variable
	{
		[XmlAttribute]
		public string Name { get; set; }
		[XmlAttribute]
		public string Type { get; set; }
		[XmlAttribute]
		public string Scope { get; set; }
		[XmlText]
		public string Value { get; set; }

	}


	public class Utterance
	{
		[XmlAttribute]
		public string Issuer { get; set; }
		[XmlText]
		public string Value { get; set; }

	}



	///-----------------------------------
	///




}