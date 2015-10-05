namespace _11.Extract_album_prices_with_Xpath
{
    using System;
    using System.Xml;

    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            string xPathQuery = "/catalogue/album[year <= 2010]";

            XmlNodeList albumsList = doc.SelectNodes(xPathQuery);

            Console.WriteLine("Albums older than 5 years:");

            foreach (XmlNode node in albumsList)
            {
                var albumName = node["name"].InnerText;
                var year = node["year"].InnerText;
                var price = node["price"].InnerText;

                Console.WriteLine($"{albumName} - {year} - {price}$");
            }
        }
    }
}
