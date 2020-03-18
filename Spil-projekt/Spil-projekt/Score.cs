using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Spil_projekt
{
    [XmlRoot(ElementName = "scores")]
    public class Highscores
    {
        public List<Score> Scores { get; set; }

        private static string m_path = "";

        public static Highscores ScoreReader(string path)
        {
            m_path = path;
            XmlSerializer serializer = new XmlSerializer(typeof(Highscores));
            StreamReader reader = new StreamReader(path);
            Highscores m_sys = (Highscores)serializer.Deserialize(reader);
            reader.Close();
            return m_sys;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Highscores));
            StreamWriter writer = new StreamWriter(m_path);
            serializer.Serialize(writer, this);
            writer.Close();
        }
    }

    public class Score
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "points")]
        public string Points { get; set; }

    }
}
