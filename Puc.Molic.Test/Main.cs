using Puc.Molic.Model;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Puc.Molic.Test
{
    public class Main
    {

        //public Diagram GetDiagram()
        //{
        //    //Diagram

        //    Diagram diagram = new Diagram();

        //    diagram.Name = "Sistema Bancário";
        //    diagram.Id = 1;
        //    diagram.CreationDate = System.DateTime.Now;
        //    diagram.LastSaved = System.DateTime.Now;

        //    //Nodes

        //    Node node1 = new Node()
        //    {
        //        Id = 1,
        //        Type = Consts.ElementType.Opening,
        //        Geometry = new Geometry()
        //        {
        //            PositionX = 210,
        //            PositionY = 100
        //        }
        //    };

        //    Node node2 = new Node()
        //    {
        //        Id = 2,
        //        Type = Consts.ElementType.Scene,
        //        Topic = "Identificar conta bancária",
        //        Geometry = new Geometry()
        //        {
        //            PositionX = 210,
        //            PositionY = 300
        //        },
        //        Dialogs = new List<Dialog>()
        //        {
        //            new Dialog()
        //            {
        //                Subject = "informar conta",
        //                Signs = new List<Sign>()
        //                {
        //                    new Sign()
        //                    {
        //                        Type = "d+u",
        //                        Value = "agência"
        //                    },
        //                    new Sign()
        //                    {
        //                        Type = "d+u",
        //                        Value = "conta"
        //                    }
        //                }
        //            },
        //            new Dialog()
        //            {
        //                Subject = "informar senha",
        //                Signs = new List<Sign>()
        //                {
        //                    new Sign()
        //                    {
        //                        Type = "d+u",
        //                        Value = "senha"
        //                    }
        //                }
        //            }
        //        }
        //    };


        //    Node node3 = new Node()
        //    {
        //        Id = 3,
        //        Type = Consts.ElementType.SystemProcess,
        //        Comment = "(processando identificação da conta bancária)",
        //        Geometry = new Geometry()
        //        {
        //            PositionX = 210,
        //            PositionY = 500
        //        }
        //    };


        //    Node node4 = new Node()
        //    {
        //        Id = 4,
        //        Type = Consts.ElementType.Scene,
        //        Comment = "Consultar produtos e serviços para correntistas",
        //        Geometry = new Geometry()
        //        {
        //            PositionX = 210,
        //            PositionY = 600
        //        },
        //        Dialogs = new List<Dialog>()
        //        {
        //            new Dialog()
        //            {
        //                Subject = "lembrar conta",
        //                Signs = new List<Sign>()
        //                {
        //                    new Sign()
        //                    {
        //                        Type = "d",
        //                        Value = "agência"
        //                    },
        //                    new Sign()
        //                    {
        //                        Type = "d",
        //                        Value = "conta"
        //                    }
        //                }
        //            },
        //            new Dialog()
        //            {
        //                Subject = "ver saldo abreviado",
        //                Pressup = new Pressup()
        //                {
        //                    Value = "a maioria dos usrs consulta o saldo assim que entra na conta"
        //                },
        //                Signs = new List<Sign>()
        //                {
        //                    new Sign()
        //                    {
        //                        Type = "d",
        //                        Value = "saldo"
        //                    }
        //                }
        //            },
        //            new Dialog()
        //            {
        //                Subject = "ver produtos e serviços",
        //                Signs = new List<Sign>()
        //                {
        //                    new Sign()
        //                    {
        //                        Type = "d",
        //                        Value = "seguro, câmbio, empréstimo, ..."
        //                    }
        //                }
        //            }
        //        }
        //    };


        //    Node node5 = new Node()
        //    {
        //        Id = 5,
        //        Type = Consts.ElementType.TopicChange,
        //        Geometry = new Geometry()
        //        {
        //            PositionX = 300,
        //            PositionY = 500
        //        },
        //        Precond = new Precond()
        //        {
        //            Conditions = new List<Condition>()
        //            {
        //                new Condition("session.conta_identificada == T")
        //            }
        //        }
        //    };

        //    Node node6 = new Node()
        //    {
        //        Id = 6,
        //        Type = Consts.ElementType.Scene,
        //        Topic = "Consultar saldo",
        //        Geometry = new Geometry()
        //        {
        //            PositionX = 300,
        //            PositionY = 600
        //        },
        //        Dialogs = new List<Dialog>()
        //        {
        //            new Dialog()
        //            {
        //                Subject = "lembrar conta",
        //                Ref = "4"
        //            },
        //            new Dialog()
        //            {
        //                Subject = "ver saldo",
        //                Signs = new List<Sign>()
        //                {
        //                    new Sign()
        //                    {
        //                        Type = "d",
        //                        Value = "saldo"
        //                    },
        //                     new Sign()
        //                    {
        //                        Type = "d",
        //                        Value = "limite de crédito"
        //                    }
        //                }
        //            }
        //        }
        //    };

        //    Node node998 = new Node()
        //    {
        //        Id = 998,
        //        Type = Consts.ElementType.TopicChange,
        //        Geometry = new Geometry()
        //        {
        //            PositionX = 400,
        //            PositionY = 500
        //        }
        //    };

        //    Node node999 = new Node()
        //    {
        //        Id = 999,
        //        Type = Consts.ElementType.Closing,
        //        Geometry = new Geometry()
        //        {
        //            PositionX = 450,
        //            PositionY = 500
        //        }
        //    };


        //    Edge edge1 = new Edge()
        //    {
        //        Id = 1,
        //        Type = Consts.ElementType.TurnGiving,
        //        SourceId = 1,
        //        TargetId = 2,
        //        Utterance = new Utterance()
        //        {
        //            Issuer = "u",
        //            Value = "sistema do banco"
        //        }
        //    };

        //    Edge edge2 = new Edge()
        //    {
        //        Id = 2,
        //        Type = Consts.ElementType.TurnGiving,
        //        SourceId = 2,
        //        TargetId = 3,
        //        Utterance = new Utterance()
        //        {
        //            Issuer = "u",
        //            Value = "identificar conta"
        //        }
        //    };

        //    Edge edge3 = new Edge()
        //    {
        //        Id = 3,
        //        Type = Consts.ElementType.BreakdownRecovery,
        //        SourceId = 3,
        //        TargetId = 2,
        //        Utterance = new Utterance()
        //        {
        //            Issuer = "d",
        //            Value = "agência, conta ou senha inválida"
        //        }
        //    };


        //    Edge edge4 = new Edge()
        //    {
        //        Id = 4,
        //        Type = Consts.ElementType.TurnGiving,
        //        SourceId = 3,
        //        TargetId = 4,
        //        Precond = new Precond()
        //        {
        //            Conditions = new List<Condition>()
        //             {
        //                 new Condition("o banco lucra muito com produtos e serviços")
        //             }
        //        },
        //        Effect = new Effect()
        //        {
        //            Variables = new List<Variable>()
        //            {
        //                new Variable()
        //                {
        //                    Name = "conta_identificada",
        //                    Scope = "session",
        //                    Type = Consts.VariableType.Boolean,
        //                    Value = "true"
        //                }
        //            }
        //        }
        //    };


        //    Edge edge5 = new Edge()
        //    {
        //        Id = 5,
        //        Type = Consts.ElementType.TurnGiving,
        //        SourceId = 5,
        //        TargetId = 6,
        //        Utterance = new Utterance()
        //        {
        //            Issuer = "u",
        //            Value = "o banco lucra muito com produtos e serviços"
        //        }
        //    };

        //    Edge edge6 = new Edge()
        //    {
        //        Id = 6,
        //        Type = Consts.ElementType.TurnGiving,
        //        SourceId = 5,
        //        TargetId = 4,
        //        Utterance = new Utterance()
        //        {
        //            Issuer = "u",
        //            Value = "consultar produtos e serviços"
        //        }
        //    };

        //    Edge edge7 = new Edge()
        //    {
        //        Id = 7,
        //        Type = Consts.ElementType.TurnGiving,
        //        SourceId = 998,
        //        TargetId = 999,
        //        Utterance = new Utterance()
        //        {
        //            Issuer = "u",
        //            Value = "sair"
        //        }
        //    };



        //    diagram.Nodes.Add(node1);
        //    diagram.Nodes.Add(node2);
        //    diagram.Nodes.Add(node3);
        //    diagram.Nodes.Add(node4);
        //    diagram.Nodes.Add(node5);
        //    diagram.Nodes.Add(node6);

        //    diagram.Edges.Add(edge1);
        //    diagram.Edges.Add(edge2);
        //    diagram.Edges.Add(edge3);
        //    diagram.Edges.Add(edge4);
        //    diagram.Edges.Add(edge5);
        //    diagram.Edges.Add(edge6);
        //    diagram.Edges.Add(edge7);

        //    return diagram;
        //}

        [Fact]
        public void TestDiagram()
        {
            DiagramFlow flow = new DiagramFlow();   
            var diagram = flow.GetDiagram();
            TransformationHelper transformationHelper = new TransformationHelper();
            string xml = transformationHelper.ToXML(diagram);

        }


        [Fact]
        public void TestGetAllPaths()
        {
            DiagramFlow flow = new DiagramFlow();
            var diagram = flow.GetDiagram();
            var graph = GetGraph(diagram);

        }

        private Graph GetGraph(Diagram diagram)
        {
            // 6 implies the number of nodes in graph
            var g = new Graph(diagram.Nodes.Count);
            // Connect node with an edge
            // First and second parameter indicate node index

            foreach (var edge in diagram.Edges)
            {
                int idSource = edge.SourceId - 1;
                int idTarget = edge.TargetId - 1;
                g.addEdge(idSource, idTarget);
            }

            return g;

            //g.addEdge(0, 4);
            //g.addEdge(0, 3);
            //g.addEdge(1, 0);
            //g.addEdge(1, 2);
            //g.addEdge(1, 4);
            //g.addEdge(2, 4);
            //g.addEdge(2, 5);
            //g.addEdge(3, 4);
            //g.addEdge(5, 4);
            //// Print graph element
            //g.printGraph();
            //// Source 1
            //// Destination 4
            //g.allPath(1, 4);

        }

        public void GetAllPaths(Diagram diagram, Node startNode, Node endNode)
        {
            List<Diagram> diagramList = new List<Diagram>();
            diagram.Nodes.Add(startNode);

            var outEdges = diagram.Edges.Where(x => x.Id == startNode.Id).ToList();

            foreach (var edge in outEdges)
            {
                Diagram path = new Diagram();
                path.Nodes.Add(startNode);
             

            }

        }


        //IEnumerable<Path> FindAllPaths(Node from, Node to)
        //{
        //    Queue<Tuple<Node, List<Node>>> nodes = new Queue<Tuple<Node, List<Node>>>();
        //    nodes.Enqueue(new Tuple<Node, List<Node>>(from, new List<Node>()));
        //    List<Path> paths = new List<Path>();

        //    while (nodes.Any())
        //    {
        //        var current = nodes.Dequeue();
        //        Node currentNode = current.Item1;

        //        if (current.Item2.Contains(currentNode))
        //        {
        //            continue;
        //        }

        //        current.Item2.Add(currentNode);

        //        if (currentNode == to)
        //        {
        //            paths.Add(new Path(current.Item2));
        //            continue;
        //        }

        //        foreach (var edge in current.Item1.Edges)
        //        {
        //            nodes.Enqueue(new Tuple<Node, List<Node>>(edge.Target, new List<Node>(current.Item2)));
        //        }
        //    }

        //    return paths;
        //}
    }
}