namespace _02.Extract_artists_with_DOM_parser
{
    using System;
    using System.Collections;
    using System.Xml;

    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlElement root = doc.DocumentElement;

            foreach(XmlNode node in root.ChildNodes)
            {
                var artist = node["artist"].InnerText;

                if(hashtable.ContainsKey(artist))
                {
                    int numberOfAlbums = (int)hashtable[artist];
                    hashtable[artist] = numberOfAlbums + 1;
                }
                else
                {
                    hashtable[artist] = 1;
                }               
            }

            foreach (DictionaryEntry pair in hashtable)
            {
                Console.WriteLine("{0} has {1} albums", pair.Key, pair.Value);
            }
        }
    }
}
