namespace _08.XmlReader_and_XmlWriter
{
    using System;
    using System.Text;
    using System.Xml;

    class Program
    {
        static void Main(string[] args)
        {
            bool hasToCloseAlbum = false;

            string fileName = "../../../08.albums.xml";
            Encoding encoding = Encoding.GetEncoding("utf-8");

            using (XmlReader reader = XmlReader.Create("../../../catalog.xml"))
            {
                using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");

                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "name"))
                        {
                            if(hasToCloseAlbum)
                            {
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                            }

                            writer.WriteStartElement("album");
                            writer.WriteElementString("title", reader.ReadElementString());
                            writer.WriteStartElement("songs");
                            hasToCloseAlbum = true;
                        }

                        if((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                        {
                            writer.WriteElementString("title", reader.ReadElementString());
                        }
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }

            Console.WriteLine("Albums saved in albums.xml");
        }
    }
}
