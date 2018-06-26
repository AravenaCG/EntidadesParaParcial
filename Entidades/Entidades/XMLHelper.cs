using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace Entidades
{
    public class XMLHelper<T>
    {


        XmlSerializer mySerializer;
        String ClassName;
        String BaseDirectory;
        #region RobadodeInternechi
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
#endregion
        #region Serializadores Propios de a 1 objeto 
        //obj debe ser [Serializable]
        public static string SerealizarBinario(Object obj,string path)
        {
            string result = "";
            try
            {
                if (obj != null)
                {
                    //Selecionamos el Formateador
                    BinaryFormatter formateador = new BinaryFormatter();

                    //Se crea el Stream
                    Stream miStram = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                    if (miStram != null)
                    {
                        //Serealizanding
                        formateador.Serialize(miStram, obj);

                        miStram.Close();
                        result = "Se realizo correctamente";
                    }
                }
                else
                {
                    result = "Error al serealizar";
                    Exception e = new Exception();
                    throw new ExcepcionPersonalizada(result,"Desconocida",DateTime.Now, e);
                }
            }
            catch (ExcepcionPersonalizada e)
            {

                Console.WriteLine("Excepcion en el metodo: {0}", e.TargetSite);
                Console.WriteLine("Con el msj de Error: {0}", e.Message);
                Console.WriteLine("Fuente:{0}", e.Source);
                Console.WriteLine("Clase Origen: {0}", e.TargetSite.MemberType);
                Console.WriteLine("Stack:{0}", e.StackTrace);

            }
            return result;
        }


        //obj debe ser [Serializable]
        public static object DesSerealizadorBinario<P>(ref P obj, string path)
        {
            
            string result = "";
            try
            {
                if (obj != null)
                {
                    //Selecionamos el Formateador
                    BinaryFormatter formateador = new BinaryFormatter();

                    //Se crea el Stream
                    Stream miStram = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);

                    if (miStram != null)
                    {
                        //Deserializanding
                         obj = (P)formateador.Deserialize(miStram);

                        miStram.Close();
                        result = "Se deserealizo correctamente";
                    }
                }
                else
                {
                    result = "Error al deserealizar";
                    Exception e = new Exception();
                    throw new ExcepcionPersonalizada(result, "Desconocida", DateTime.Now, e);
                }
            }
            catch (ExcepcionPersonalizada e)
            {

                Console.WriteLine("Excepcion en el metodo: {0}", e.TargetSite);
                Console.WriteLine("Con el msj de Error: {0}", e.Message);
                Console.WriteLine("Fuente:{0}", e.Source);
                Console.WriteLine("Clase Origen: {0}", e.TargetSite.MemberType);
                Console.WriteLine("Stack:{0}", e.StackTrace);

            }
            return obj;
        }


        //Para XML el objeto debe ser [Serializable],public, con Propiedades para sus campos y con constructor por defecto sin paramentros

        public static void XMLSerealizador<P>(string path, P obj )
        {
            Console.WriteLine("-----Serializacion XML-----");

            System.Xml.Serialization.XmlSerializer formateador = new XmlSerializer(typeof(P));
            Stream miStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);

            formateador.Serialize(miStream, obj);

            miStream.Close();

        }

        public static void XMLDeSerealizador<P>(string path, ref P obj)
        {
            Console.WriteLine("-----Desserializacion XML-----");

            System.Xml.Serialization.XmlSerializer formateador = new XmlSerializer(typeof(P));
            Stream miStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);

            obj = (P)formateador.Deserialize(miStream);

            miStream.Close();

        }

        #endregion

        #region Archivos

        //La clase no necesita ser [Serializable]
        public static void EscribirArchivo<P>(string path, P obj)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);

            BinaryWriter writer = new BinaryWriter(fs);

            //aca van las Propiedades de la clase que se quieren escribir u otros campos o variables
            //Para la lectura tiene que tenenr el mismo orden
            writer.Write(obj.ToString());

            fs.Close();

        }

        public static void LeerArchivo<P>(string path, ref P obj)
        {
            FileStream fs = new FileStream(path, FileMode.Open,FileAccess.Read, FileShare.None);

            BinaryReader reader = new BinaryReader(fs);

            //Crear auxiliares de los campos y segun el contenido igualar al reader
            //  obj = reader.ReadString();
            string texto;
            texto = reader.ReadString();

            fs.Close();

        }
        #endregion
    }
}
