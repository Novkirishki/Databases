using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace _16.XSD_validation
{
    class Program
    {
        static void Main(string[] args)
        {
            var xdoc = XDocument.Load("../../../catalog.xml");
            var xdoc2 = XDocument.Load("../../../invalid_catalog.xml");
            var schema = new XmlSchemaSet();
            schema.Add("", "../../../16.catalog_schema.xsd");

            try
            {
                xdoc.Validate(schema, null);

                Console.WriteLine("The xml is valid");
            }
            catch (XmlSchemaValidationException e)
            {
                Console.WriteLine("The xml is not valid: {0}", e.Message);
            }

            try
            {
                xdoc2.Validate(schema, null);

                Console.WriteLine("The xml is valid");
            }
            catch (XmlSchemaValidationException e)
            {
                Console.WriteLine("The xml is not valid: {0}", e.Message);
            }
        }
    }
}
