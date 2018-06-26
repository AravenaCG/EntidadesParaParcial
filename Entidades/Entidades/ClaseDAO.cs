using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Entidades
{
    public class ClaseDAO
    {
        #region Atributos
        private static SqlConnection _conexion;
        private static SqlCommand _comando;
        
        #endregion

       

        #region Constructores
        static ClaseDAO()
        {
            
            
            ClaseDAO._conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
            
            ClaseDAO._comando = new SqlCommand();
          
            ClaseDAO._comando.CommandType = System.Data.CommandType.Text;
            
            ClaseDAO._comando.Connection = ClaseDAO._conexion;
        }
        #endregion

        #region Métodos

        #region Getters

        
        public static List<T> ObtenerListaElementos()
        {
            bool TodoOk = false;
            List<T> elementos = null;

            try
            {
                // LE PASO LA INSTRUCCION SQL
                ClaseDAO._comando.CommandText = "SELECT id,legajo,salario,puestoJerarquico,nombre,apellido FROM Empleados";

                // ABRO LA CONEXION A LA BD
                ClaseDAO._conexion.Open();

                // EJECUTO EL COMMAND                 
                SqlDataReader oDr = ClaseDAO._comando.ExecuteReader();

                // MIENTRAS TENGA REGISTROS...
                while (oDr.Read())
                {
                    // ACCEDO POR NOMBRE
                    //Empleado.EPuestoJerarquico puesto;
                    //if (!Enum.TryParse<Empleado.EPuestoJerarquico>(oDr["puestoJerarquico"].ToString(), out puesto))
                    //{
                    //    puesto = Empleado.EPuestoJerarquico.Sistemas;
                    //}
                   // elementos.Add(new Empleado(int.Parse(oDr["id"].ToString()), oDr["nombre"].ToString(), oDr["apellido"].ToString(), oDr["legajo"].ToString(), puesto, int.Parse(oDr["salario"].ToString())));
                }

                //CIERRO EL DATAREADER
                oDr.Close();

                TodoOk = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (TodoOk)
                    ClaseDAO._conexion.Close();
            }
            return elementos;
        }
        //public static T Obtener( T e)
        //{
        //    bool TodoOk = false;
        //    T e = null;

        //    try
        //    {
        //        // LE PASO LA INSTRUCCION SQL
        //        ClaseDAO._comando.CommandText = "SELECT id,legajo,salario,puestoJerarquico,nombre,apellido FROM Empleados WHERE id = " + e.ID;

        //        // ABRO LA CONEXION A LA BD
        //        ClaseDAO._conexion.Open();

        //        // EJECUTO EL COMMAND                 
        //        SqlDataReader oDr = ClaseDAO._comando.ExecuteReader();

        //        // MIENTRAS TENGA REGISTROS...
        //        if (oDr.Read())
        //        {
        //            // ACCEDO POR NOMBRE
        //            e.EPuestoJerarquico puesto;
        //            if (!Enum.TryParse<Empleado.EPuestoJerarquico>(oDr["puestoJerarquico"].ToString(), out puesto))
        //            {
        //                puesto = Empleado.EPuestoJerarquico.Sistemas;
        //            }
        //            e = new T(int.Parse(oDr["id"].ToString()), oDr["nombre"].ToString(), oDr["apellido"].ToString(), oDr["legajo"].ToString(), puesto, int.Parse(oDr["salario"].ToString()));
        //        }

        //        //CIERRO EL DATAREADER
        //        oDr.Close();

        //        TodoOk = true;
        //    }

        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    finally
        //    {
        //        if (TodoOk)
        //            ClaseDAO._conexion.Close();
        //    }
        //    return e;
        //}
        //#endregion

        #region Insertar 
        public static bool Insertar(T e)
        {
            //string sql = "INSERT INTO Empleados (legajo,salario,puestoJerarquico,nombre,apellido) VALUES(";
            //sql = sql + "'" + e.Legajo + "'," + e.Salario + "," + (int)e.PuestoJerarquico + ",'" + e.Nombre + "','" + e.Apellido + "')";

            //return EjecutarNonQuery(sql);

        }
        #endregion

        #region Modificar 
        public static bool Modificar(T e)
        {
            //string sql = "UPDATE Empleados SET legajo = '" + e.Legajo + "', nombre = '" + e.Nombre + "', apellido = '" + e.Apellido + "',";
            //sql = sql + " salario = " + e.Salario + ", puestoJerarquico = " + (int)e.PuestoJerarquico + " WHERE id = " + e.ID.ToString();

            //return EjecutarNonQuery(sql);
        }
        #endregion

        #region Eliminar 
        public static bool Eliminar(T e)
        {

            //string sql = "DELETE FROM Empleados WHERE id = " + e.ID.ToString();

            //return EjecutarNonQuery(sql);
        }
        #endregion

        private static bool EjecutarNonQuery(string sql)
        {
            bool todoOk = false;
            try
            {
                // LE PASO LA INSTRUCCION SQL
                ClaseDAO._comando.CommandText = sql;

                // ABRO LA CONEXION A LA BD
                ClaseDAO._conexion.Open();

                // EJECUTO EL COMMAND
                ClaseDAO._comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception e)
            {
                todoOk = false;
            }
            finally
            {
                if (todoOk)
                    ClaseDAO._conexion.Close();
            }
            return todoOk;
        }

        #endregion


    }
}

