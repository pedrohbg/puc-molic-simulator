using Puc.Molic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Molic
{
    public class DiagramFlow
    {

        public GraphV2 GetGraphV2(Diagram diagram)
        {
            List<int> list = new List<int>();
            foreach (var edge in diagram.Edges)
            {
                list.Add(edge.Id);
                //g.addEdge(idSource, idTarget);
            }

            //List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5 };

            // 6 implies the number of nodes in graph
            var g = new GraphV2(list);

            foreach (var edge in diagram.Edges)
            {
                g.addEdge(edge.SourceId, edge.TargetId);
            }

            // Connect node with an edge
            // First and second parameter indicate node index



            return g;

        }


        public Diagram GetDiagram()
        {

            //Diagram

            Diagram diagram = new Diagram();

            diagram.Name = "Sistema Bancário";
            diagram.Id = 1;
            diagram.CreationDate = System.DateTime.Now;
            diagram.LastSaved = System.DateTime.Now;

            //Nodes

            Node node1 = new Node()
            {
                Id = 1,
                Type = Consts.ElementType.Opening,
                Geometry = new Geometry()
                {
                    PositionX = 210,
                    PositionY = 100
                }
            };

            //Identificar conta bancária
            Node node2 = new Node()
            {
                Id = 2,
                Type = Consts.ElementType.Scene,
                Topic = "Identificar conta bancária",
                Geometry = new Geometry()
                {
                    PositionX = 210,
                    PositionY = 300
                },
                Dialogs = new List<Dialog>()
                {
                    new Dialog()
                    {
                        Subject = "informar conta",
                        Signs = new List<Sign>()
                        {
                            new Sign()
                            {
                                Type = "d+u",
                                Value = "agência"
                            },
                            new Sign()
                            {
                                Type = "d+u",
                                Value = "conta"
                            }
                        }
                    },
                    new Dialog()
                    {
                        Subject = "informar senha",
                        Signs = new List<Sign>()
                        {
                            new Sign()
                            {
                                Type = "d+u",
                                Value = "senha"
                            }
                        }
                    }
                }
            };

            //(processando identificação da conta bancária)
            Node node3 = new Node()
            {
                Id = 3,
                Type = Consts.ElementType.SystemProcess,
                Comment = "(processando identificação da conta bancária)",
                Geometry = new Geometry()
                {
                    PositionX = 210,
                    PositionY = 500
                }
            };

            //"Consultar produtos e serviços para correntistas
            Node node4 = new Node()
            {
                Id = 4,
                Type = Consts.ElementType.Scene,
                Comment = "Consultar produtos e serviços para correntistas",
                Geometry = new Geometry()
                {
                    PositionX = 210,
                    PositionY = 600
                },
                Dialogs = new List<Dialog>()
                {
                    new Dialog()
                    {
                        Subject = "lembrar conta",
                        Signs = new List<Sign>()
                        {
                            new Sign()
                            {
                                Type = "d",
                                Value = "agência"
                            },
                            new Sign()
                            {
                                Type = "d",
                                Value = "conta"
                            }
                        }
                    },
                    new Dialog()
                    {
                        Subject = "ver saldo abreviado",
                        Pressup = new Pressup()
                        {
                            Value = "a maioria dos usrs consulta o saldo assim que entra na conta"
                        },
                        Signs = new List<Sign>()
                        {
                            new Sign()
                            {
                                Type = "d",
                                Value = "saldo"
                            }
                        }
                    },
                    new Dialog()
                    {
                        Subject = "ver produtos e serviços",
                        Signs = new List<Sign>()
                        {
                            new Sign()
                            {
                                Type = "d",
                                Value = "seguro, câmbio, empréstimo, ..."
                            }
                        }
                    }
                }
            };

            //session.conta_identificada == True
            Node node5 = new Node()
            {
                Id = 5,
                Type = Consts.ElementType.TopicChange,
                Geometry = new Geometry()
                {
                    PositionX = 300,
                    PositionY = 500
                },
                Precond = new Precond()
                {
                    Conditions = new List<Condition>()
                    {
                        new Condition("session.conta_identificada == True")
                    }
                }
            };

            //Consultar saldo
            Node node6 = new Node()
            {
                Id = 6,
                Type = Consts.ElementType.Scene,
                Topic = "Consultar saldo",
                Geometry = new Geometry()
                {
                    PositionX = 300,
                    PositionY = 600
                },
                Dialogs = new List<Dialog>()
                {
                    new Dialog()
                    {
                        Subject = "lembrar conta",
                        Ref = "4"
                    },
                    new Dialog()
                    {
                        Subject = "ver saldo",
                        Signs = new List<Sign>()
                        {
                            new Sign()
                            {
                                Type = "d",
                                Value = "saldo"
                            },
                             new Sign()
                            {
                                Type = "d",
                                Value = "limite de crédito"
                            }
                        }
                    }
                }
            };


            //Consultar extrato do periodo <Per>
            Node node7 = new Node()
            {
                Id = 7,
                Type = Consts.ElementType.Scene,
                Topic = "Consultar extrato do periodo <Per>",
                Geometry = new Geometry()
                {
                    PositionX = 300,
                    PositionY = 600
                },
                Dialogs = new List<Dialog>()
                {
                    new Dialog()
                    {
                        Subject = "lembrar conta"

                    },
                    new Dialog()
                    {
                        Subject = "informar periodo (default = Per)",
                        Signs = new List<Sign>()
                        {
                            new Sign()
                            {
                                Type = "d + u",
                                Value = "datas de inicio e fim"
                            }
                        }

                    },
                    new Dialog()
                    {
                        Subject = "ver extrato",
                        Signs = new List<Sign>()
                        {
                            new Sign()
                            {
                                Type = "d",
                                Value = "transacoes"
                            }
                        }
                    }
                }
            };


            //Modificar periodo do extrato
            Node node8 = new Node()
            {
                Id = 8,
                Type = Consts.ElementType.Scene,
                Topic = "Modificar periodo do extrato",
                Geometry = new Geometry()
                {
                    PositionX = 300,
                    PositionY = 600
                },
                Dialogs = new List<Dialog>()
                {
                    new Dialog()
                    {
                        Subject = "lembrar conta"

                    },
                    new Dialog()
                    {
                        Subject = "informar periodo",
                        Signs = new List<Sign>()
                        {
                            new Sign()
                            {
                                Type = "d + u",
                                Value = "datas de inicio e fim"
                            },
                             new Sign()
                            {
                                Type = "d + u",
                                Value = "ultimos N dias"
                            },
                            new Sign()
                            {
                                Type = "d + u",
                                Value = "ultimas N transacoes"
                            }
                        }

                    },
                    new Dialog()
                    {
                        Subject = "configurar periodo default",
                        Signs = new List<Sign>()
                        {
                            new Sign()
                            {
                                Type = "d+u",
                                Value = "modificar default (sim/nao)"
                            }
                        }
                    }
                }
            };


            //(processando modificacao do periodo)
            Node node9 = new Node()
            {
                Id = 9,
                Type = Consts.ElementType.SystemProcess,
                Comment = "(processando modificacao do periodo)",
                Geometry = new Geometry()
                {
                    PositionX = 210,
                    PositionY = 500
                }
            };






            //sistema do banco
            Edge edge1 = new Edge()
            {
                Id = 1,
                Type = Consts.ElementType.TurnGiving,
                SourceId = 1,
                TargetId = 2,
                Utterance = new Utterance()
                {
                    Issuer = "u",
                    Value = "sistema do banco"
                }
            };

            //identificar conta"
            Edge edge2 = new Edge()
            {
                Id = 2,
                Type = Consts.ElementType.TurnGiving,
                SourceId = 2,
                TargetId = 3,
                Utterance = new Utterance()
                {
                    Issuer = "u",
                    Value = "identificar conta"
                }
            };

            //agência, conta ou senha inválida
            Edge edge3 = new Edge()
            {
                Id = 3,
                Type = Consts.ElementType.BreakdownRecovery,
                SourceId = 3,
                TargetId = 2,
                Utterance = new Utterance()
                {
                    Issuer = "d",
                    Value = "agência, conta ou senha inválida"
                }
            };

            //o banco lucra muito com produtos e serviços
            Edge edge4 = new Edge()
            {
                Id = 4,
                Type = Consts.ElementType.TurnGiving,
                SourceId = 3,
                TargetId = 4,
                Precond = new Precond()
                {
                    Conditions = new List<Condition>()
                     {
                         new Condition("o banco lucra muito com produtos e serviços")
                     }
                },
                Effect = new Effect()
                {
                    Variables = new List<Variable>()
                    {
                        new Variable()
                        {
                            Name = "conta_identificada",
                            Scope = "session",
                            Type = Consts.VariableType.Boolean,
                            Value = "true"
                        }
                    }
                }
            };

            //o banco lucra muito com produtos e serviços
            Edge edge5 = new Edge()
            {
                Id = 5,
                Type = Consts.ElementType.TurnGiving,
                SourceId = 5,
                TargetId = 6,
                Utterance = new Utterance()
                {
                    Issuer = "u",
                    Value = "consultar saldo"
                }
            };

            //consultar produtos e serviços"
            Edge edge6 = new Edge()
            {
                Id = 6,
                Type = Consts.ElementType.TurnGiving,
                SourceId = 4,
                TargetId = 5,
                Utterance = new Utterance()
                {
                    Issuer = "u",
                    Value = "consultar produtos e serviços"
                }
            };

            //consultar produtos e serviços"
            Edge edge7 = new Edge()
            {
                Id = 7,
                Type = Consts.ElementType.TurnGiving,
                SourceId = 5,
                TargetId = 7,
                Utterance = new Utterance()
                {
                    Issuer = "u",
                    Value = "consultar extrato pressup: a maioria dos usrs consulta a ultima semana (Per = conta.periodo OR ultimos 7 dias)"
                }
            };


            //pressup: qualquer surpresa no saldo leva o usr a consultar o extrato u:consultar extrato
            Edge edge8 = new Edge()
            {
                Id = 8,
                Type = Consts.ElementType.TurnGiving,
                SourceId = 6,
                TargetId = 7,
                Pressup = new Pressup()
                {
                    Value = "qualquer surpresa no saldo leva o usr a consultar o extrato"

                },
                Utterance = new Utterance()
                {
                    Issuer = "u",
                    Value = "consultar extrato"
                }
            };


            //modificar periodo
            Edge edge9 = new Edge()
            {
                Id = 9,
                Type = Consts.ElementType.TurnGiving,
                SourceId = 7,
                TargetId = 8,
                Utterance = new Utterance()
                {
                    Issuer = "u",
                    Value = "modificar periodo"
                }
            };

            //cancelar
            Edge edge10 = new Edge()
            {
                Id = 10,
                Type = Consts.ElementType.BreakdownRecovery,
                SourceId = 8,
                TargetId = 7,
                Utterance = new Utterance()
                {
                    Issuer = "u",
                    Value = "cancelar"
                }
            };



            //Efetivar Per como novo periodo
            Edge edge11 = new Edge()
            {
                Id = 11,
                Type = Consts.ElementType.TurnGiving,
                SourceId = 8,
                TargetId = 9,
                Utterance = new Utterance()
                {
                    Issuer = "u",
                    Value = "Efetivar Per como novo periodo"
                }
            };


            //Efetivar Per como novo periodo
            Edge edge12 = new Edge()
            {
                Id = 12,
                Type = Consts.ElementType.TurnGiving,
                SourceId = 9,
                TargetId = 7,
                Precond = new Precond()
                {
                    Conditions = new List<Condition>()
                    {
                        new Condition()
                        {
                            Value = "modificar default == sim"
                        },
                        new Condition()
                        {
                            Value = "modificar default == nao"
                        }

                    }
                },
                Effect = new Effect()
                {
                    Variables = new List<Variable>()
                    {
                        new Variable()
                        {
                            Name = "conta_periodo",
                            Value = "Per"
                        }
                    }
                }
            };


            //Efetivar Per como novo periodo
            Edge edge13 = new Edge()
            {
                Id = 13,
                Type = Consts.ElementType.BreakdownRecovery,
                SourceId = 9,
                TargetId = 8,
                Utterance = new Utterance()
                {
                    Issuer = "d",
                    Value = "data inicio posterior a data fim"
                }
            };

            diagram.Nodes.Add(node1);
            diagram.Nodes.Add(node2);
            diagram.Nodes.Add(node3);
            diagram.Nodes.Add(node4);
            diagram.Nodes.Add(node5);
            diagram.Nodes.Add(node6);
            diagram.Nodes.Add(node7);
            diagram.Nodes.Add(node8);
            diagram.Nodes.Add(node9);



            diagram.Edges.Add(edge1);
            diagram.Edges.Add(edge2);
            diagram.Edges.Add(edge3);
            diagram.Edges.Add(edge4);
            diagram.Edges.Add(edge5);
            diagram.Edges.Add(edge6);
            diagram.Edges.Add(edge7);
            diagram.Edges.Add(edge8);
            diagram.Edges.Add(edge9);
            diagram.Edges.Add(edge10);
            diagram.Edges.Add(edge11);
            diagram.Edges.Add(edge12);
            diagram.Edges.Add(edge13);


            return diagram;
        }
    }
}
