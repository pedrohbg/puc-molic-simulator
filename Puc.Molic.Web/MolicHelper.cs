using Puc.Molic.Model;
using System.Text;

namespace Puc.Molic.Web
{
    //Helper class with HTML helper methods for the diagram presentation
    //Author: Pedro Henrique Bof Gerico
    public class MolicHelper
    {
        //get edge information
        public static string GetEdgeDescription(Edge edge)
        {
            StringBuilder sb = new StringBuilder();

            //building Utterance string for turngiving and breakdown recovery
            if (edge.Utterance != null && !string.IsNullOrWhiteSpace(edge.Utterance.Issuer) && !string.IsNullOrWhiteSpace(edge.Utterance.Value))
            {
                string utterance = $"{edge.Utterance.Issuer}: {edge.Utterance.Value}";
                if (sb.ToString().Length > 0)
                {
                    sb.Append("<br />");
                }
                sb.Append(utterance);
            }

            //building Precond strings for turngiving and breakdown recovery
            if (edge.Precond?.Conditions != null && edge.Precond.Conditions.Any())
            {
                string precond = $"precond: (";
                foreach (var item in edge.Precond.Conditions)
                {
                    precond += item.Value;
                }
                precond += ")";
                if (sb.ToString().Length > 0)
                {
                    sb.Append("<br />");
                }
                sb.Append(precond);
            }
            //building Pressup strings for turngiving and breakdown recovery
            if (edge.Pressup != null && !string.IsNullOrWhiteSpace(edge.Pressup.Value))
            {
                if (sb.ToString().Length > 0)
                {
                    sb.Append("<br />");
                }
                sb.Append(edge.Pressup.Value);
            }

            return sb.ToString();
        }

        //get formatted node information (scene) 
        public static string GetNodeDescription(Node node)
        {
            StringBuilder sb = new StringBuilder();

            //building strings of dialogs
            if (node.Dialogs != null && node.Dialogs.Any())
            {
                List<string> dialogStrings = new List<string>();
                foreach (var item in node.Dialogs)
                {
                    string dialog = $"[";
                    dialog += $"{item.Subject}:";

                    List<string> signStrings = new List<string>();
                    foreach (var sign in item.Signs)
                    {
                         signStrings.Add($"{sign.Type}:{sign.Value}");
                    }
                    dialog += string.Join("<br />", signStrings);
                    dialog += "]";

                    dialogStrings.Add(dialog);
                }
                sb.Append(string.Join("<br />", dialogStrings));

               
            }
            //building strings of precond
            if (node.Precond?.Conditions != null && node.Precond.Conditions.Any())
            {
                string precond = $"precond: (";
                foreach (var item in node.Precond.Conditions)
                {
                    precond += item.Value;
                }
                precond += ")";
                if (sb.ToString().Length > 0)
                {
                    sb.Append("<br />");
                }
                sb.Append(precond);
            }

            return sb.ToString();
        }

        //get structured option for the select box
        public static string GetNodeTitleForSelectionBox(Node node)
        {
            
            string title = string.Format("{0} - {1}", node.Id, node.Type);

            if (!string.IsNullOrWhiteSpace(node.Topic))
            {
                title += " - " + node.Topic;
            }


            if (node.Type == Consts.ElementType.TopicChange)
            {
                if (node.Precond?.Conditions != null && node.Precond.Conditions.Any())
                {
                    string precond = $"precond: (";
                    foreach (var item in node.Precond.Conditions)
                    {
                        precond += item.Value;
                    }
                    precond += ")";

                    title += " - " + precond;
                }
            }
            return title;
        }
    }
}
