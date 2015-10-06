namespace _09.Dir_to_XML_with_XmlWriter
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo rootDir = new DirectoryInfo("..\\..\\");

            string fileName = "../../../09.directories.xml";
            Encoding encoding = Encoding.GetEncoding("utf-8");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directories");

                WalkDirectoryTree(writer, rootDir);

                writer.WriteEndDocument();
            }

        }

        static void WalkDirectoryTree(XmlTextWriter writer, DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", root.Name);

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                //log.Add(e.Message);
            }

            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("name", fi.Name);
                    writer.WriteAttributeString("extension", fi.Extension);
                    writer.WriteEndElement();
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(writer, dirInfo);
                }

            }

            writer.WriteEndElement();
        }
    }
}
