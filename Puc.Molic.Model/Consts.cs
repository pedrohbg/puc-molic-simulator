using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.Molic.Model
{
    public class Consts
    {
        //Diagram element types (nodes and edges)
        public class ElementType
        {
            public const string Opening = "Opening";
            public const string Scene = "Scene";
            public const string SystemProcess = "SystemProcess";
            public const string TopicChange = "TopicChange";
            public const string Closing = "Closing";
            public const string TurnGiving = "TurnGiving";
            public const string BreakdownRecovery = "BreakdownRecovery";
        }
        //Molic variable types
        public class VariableType
        {
            public static string Boolean = "boolean";
        }
    }
}
