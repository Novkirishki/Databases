namespace _05.Extract_songs_with_XmlReader
{
    using System;
    using System.Xml;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Song titles in the catalog:");
            using (XmlReader reader = XmlReader.Create("../../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
