using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;

namespace TESTXML
{
   public class XMLHelper <T>
    {
       XmlSerializer mySerializer ;
       String ClassName;
       String BaseDirectory;
       
       public XMLHelper()
       {
           mySerializer = new XmlSerializer(typeof(T));
           BaseDirectory = "";
       }

       public XMLHelper(String myBaseDirectory)
       {
           mySerializer = new XmlSerializer(typeof(T));
           BaseDirectory = myBaseDirectory;
       }

       public String FileName(T myObj)
       {
           ClassName = myObj.GetType().Name;
           return BaseDirectory + "\\" + ClassName + ".xml";           
       }

       public void Save(T myObj)
        {
            TextWriter myWriter = new StreamWriter(FileName(myObj));
            mySerializer.Serialize(myWriter, myObj);
            myWriter.Close();
        }

        public T Load(T myObj)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(T));
            TextReader myReader = new StreamReader(FileName(myObj));
            T NewObject = (T)mySerializer.Deserialize(myReader);
            myReader.Close();
            return NewObject;
        }
        
    }
}
