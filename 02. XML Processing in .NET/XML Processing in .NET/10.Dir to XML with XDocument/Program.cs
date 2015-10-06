namespace _10.Dir_to_XML_with_XDocument
{
    using System;
    using System.IO;
    using System.Xml;

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo rootDir = new DirectoryInfo("..\\..\\");

            XmlDocument doc = new XmlDocument();

            XmlElement rootElement = doc.CreateElement("directories");

            WalkDirectoryTree(doc, rootElement, rootDir);

            doc.AppendChild(rootElement);

            doc.Save("../../../10.directories.xml");
        }

        static void WalkDirectoryTree(XmlDocument doc, XmlElement rootElement, DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            XmlElement dir = doc.CreateElement("dir");
            XmlAttribute name = doc.CreateAttribute("name");
            name.Value = root.Name;
            dir.Attributes.Append(name);

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
                    XmlElement file = doc.CreateElement("file");
                    XmlAttribute fileName = doc.CreateAttribute("name");
                    XmlAttribute fileExtension = doc.CreateAttribute("extension");
                    fileName.Value = fi.Name;
                    fileExtension.Value = fi.Extension;
                    file.Attributes.Append(fileName);
                    file.Attributes.Append(fileExtension);
                    dir.AppendChild(file);
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(doc, dir, dirInfo);
                }

            }

            rootElement.AppendChild(dir);
        }
    }
}
