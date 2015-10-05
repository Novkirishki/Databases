namespace _07.Txt_to_XML
{
    using System.Xml;
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader("../../../personInfo.txt");

            XmlDocument doc = new XmlDocument();

            XmlElement person = doc.CreateElement("person");

            XmlElement personName = doc.CreateElement("name");
            personName.InnerText = file.ReadLine();
            person.AppendChild(personName);

            XmlElement personAddr = doc.CreateElement("address");
            personAddr.InnerText = file.ReadLine();
            person.AppendChild(personAddr);

            XmlElement personPhone = doc.CreateElement("phone");
            personPhone.InnerText = file.ReadLine();
            person.AppendChild(personPhone);

            doc.AppendChild(person);

            file.Close();

            Console.WriteLine("Person information save in xml 07.person.xml");
            doc.Save("../../../07.person.xml");
        }
    }
}
