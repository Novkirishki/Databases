namespace _12.Extract_album_prices_with_LINQ
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load("../../../catalog.xml");

            var albumsOlderThanFiveYears =
                from album in xmlDoc.Descendants("album")
                where int.Parse(album.Element("year").Value) <= (DateTime.Now.Year - 5)
                select album;

            Console.WriteLine("Albums older than 5 years:");

            foreach (var album in albumsOlderThanFiveYears)
            {
                var albumName = album.Element("name").Value;
                var year = album.Element("year").Value;
                var price = album.Element("price").Value;

                Console.WriteLine($"{albumName} - {year} - {price}$");
            }
        }
    }
}
