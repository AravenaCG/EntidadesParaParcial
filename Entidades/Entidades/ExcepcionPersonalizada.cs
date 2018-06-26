using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExcepcionPersonalizada : ApplicationException
    {


        private string mensaje = "";
        private DateTime momento;
        private string causa;


        public ExcepcionPersonalizada(string message, string causa, DateTime momento, Exception innerException)
             : base(message, innerException)
        {
            this.mensaje = message;
            this.causa = causa;
            this.momento = momento;

        }

        public ExcepcionPersonalizada(string message, Exception innerException)
            : base(message, innerException)
        {



        }

        public DateTime Momento { get { return momento; } set { this.momento = value; } }
        public string Causa { get { return this.causa; } set { this.causa = value; } }
        public string Mensaje{ get { return string.Format("Mensaje de la Excepcion {0}", this.mensaje); } set { this.mensaje = value; } }
        //public override string Message
        //{
        //    get
        //    {
        //        return string.Format("Mensaje de la Excepcion {0}", this.mensaje);
        //    }


        //}
        
        //En el metodo que puede fallar se crea instancia de la excepcion,
       // en el programa al momento del try se cathchea la excepcion propia.  




        //catch (Exception e)
        //   {

        //       Console.WriteLine("Excepcion en el metodo: {0}", e.TargetSite);
        //       Console.WriteLine("Con el msj de Error: {0}",e.Message);
        //       Console.WriteLine("Fuente:{0}",e.Source);
        //       Console.WriteLine("Clase Origen: {0}",e.TargetSite.MemberType);
        //       Console.WriteLine("Stack:{0}",e.StackTrace);

        //   }

        ////agregar data personalizada a la Excepcion
        ////
        //ExcepcionPersonalizada ex = new ExcepcionPersonalizada();
        //ex.Data.Add("");
        //throw ex;
    }
}
