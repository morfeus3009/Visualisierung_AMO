using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace Visualisierung
{
    class Parameter
    {
        //Initialisierung
        string erg = "";

        /// <summary>
        /// Einzelnen Knoten aus XML lesen mit 2 Hauptknoten
        /// </summary>
        /// <param name="filename">Name der XML-Datei</param>
        /// <param name="defintion1">Name des ersten (Haupt)-Knoten</param>
        /// <param name="definition2">Name des zweiten (Haupt)-Knoten</param>
        /// <param name="typ">Name des dritten Knoten</param>
        /// <param name="art">Name des vierten Knoten</param>
        /// <returns></returns>
        public string ReadXmlSingleNode(string filename, string defintion1, string definition2, string typ, string art)
        {
            erg = null;
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(filename);

                var content = document.SelectSingleNode(defintion1 + "/" + definition2 + "/" + typ + "/" + art);
                erg = content.FirstChild.InnerText;
            }
            catch (Exception e)
            {
                if (erg == null)
                    return erg;
                MessageBox.Show("Fehler beim Lesen der XML-Datei:\n" + e.Message + "\n\nEs wurde kein Eintrag zu >>" + art + "<< gefunden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return erg;
        }

        /// <summary>
        /// Einzelnen Knoten aus XML auslesen mit 1 Hauptknoten
        /// </summary>
        /// <param name="filename">Name der XML-Datei</param>
        /// <param name="defintion">Name des ersten (Haupt)-Knoten</param>
        /// <param name="typ">Name des zweiten Knoten</param>
        /// <param name="art">Name des dritten Knoten</param>
        /// <returns></returns>
        public string ReadXmlSingleNode(string filename, string defintion, string typ, string art)
        {

            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(filename);

                var content = document.SelectSingleNode(defintion + "/" + typ + "/" + art);
                erg = content.FirstChild.InnerText;
            }
            catch (Exception e)
            {
                MessageBox.Show("Fehler beim Lesen der XML-Datei:\n" + e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                erg = "";
            }
            return erg;
        }
    }
}
