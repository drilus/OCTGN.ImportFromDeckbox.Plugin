using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTGN.ImportFromDeckbox.OCTGN
{
    public class CreateDeckFile
    {
        public static void WriteFile(
            string fileName,
            IEnumerable<CardData> cards)
        {
            var document = new StringBuilder();
            document.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>");
            document.AppendFormat("<deck game=\"{0}\">", cards.ElementAt(0).GameId);
            document.AppendLine(); 
            document.Append("\t<section name=\"Deck\">");
            document.AppendLine();

            foreach (var item in cards)
            {
                document.AppendFormat(
                    "\t\t<card qty=\"{1}\" id=\"{0}\">{2}</card>",
                    item.GameId,
                    item.Count,
                    item.Name);

                document.AppendLine();
            }

            document.AppendLine("\t</section>");
            document.Append("</deck>");

            File.WriteAllText(fileName, document.ToString(), Encoding.UTF8);
        }
    }
}
