namespace _04.Delete_albums_with_DOM_parser
{
    using System;
    using System.Xml;

    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlElement root = doc.DocumentElement;

            foreach (XmlNode node in root.ChildNodes)
            {
                var price = double.Parse(node["price"].InnerText);

                if (price > 20)
                {
                    root.RemoveChild(node);
                }
            }

            Console.WriteLine("Catalog with albums cheaper than 20 is created with name 04.catalog.xml");
            doc.Save("../../../04.catalog.xml");
        }
    }
}
