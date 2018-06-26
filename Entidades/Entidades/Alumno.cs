using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno
    {
        #region Atributos


        private string _apellido;
        private int _dni;
        private string _fotoAlumno;
        private string _nombre;
       
        #endregion


        #region Propiedades

        public string Apellido 
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = value;
            }
        }
        public int Dni 
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = value;
            }
        }
        public string Nombre 
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }
        public string RutaDeLaFoto 
        {
            get
            {
                return this._fotoAlumno;
            }
            set
            {
                this._fotoAlumno = value;
            }
        }
        #endregion

        #region Constructor

        public Alumno(string nombre, string apellido, int dni, string ruta)
        {
            this._apellido = apellido;
            this._dni = dni;
            this._nombre = nombre;
            this._fotoAlumno = ruta;

        }

        #endregion


    }
}
