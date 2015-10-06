namespace _06.Extract_songs_with_XDocument_and_LINQ
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load("../../../catalog.xml");

            var songTitles =
                from songs in xmlDoc.Descendants("title")
                select songs.Value;

            foreach(var title in songTitles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
