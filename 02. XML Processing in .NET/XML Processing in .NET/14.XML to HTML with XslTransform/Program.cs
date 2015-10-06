namespace _14.XML_to_HTML_with_XslTransform
{
    using System.Xml.Xsl;

    class Program
    {
        static void Main(string[] args)
        {
            //Create the XslTransform object.
            XslTransform xslt = new XslTransform();

            //Load the stylesheet.
            xslt.Load("../../../13.catalog.xslt");

            //Transform the file.
            xslt.Transform("../../../catalog.xml", "../../../14.catalog.html");
        }
    }
}
