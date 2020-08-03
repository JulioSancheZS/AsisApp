using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TLG080FinalApp.com.somee.asisappbackend;

namespace TLG080FinalApp
{
    public class Global
    {
        //Instancia el servicio web
        public static webservice servicio = new webservice();

        #region Departamento

        public static List<DepartamentoSW> ListaDepar()
        {
            return servicio.ListaDepartamento().ToList();
        }

        public static bool AgregarDepar(string nomdepartamento)
        {
            return servicio.AddDepartamento(nomdepartamento);
        }

        public static bool EliminarDepar(int id)
        {
            return servicio.EliminarDepartamento(id);
        }

        public static List<DepartamentoSW> BuscarDepar(int id)
        {
            return servicio.BuscarDepartamento(id).ToList();
        }

        #endregion

        #region AnioElectivo

        public static List<AnioElectivoSW> ListaAnio()
        {
            return servicio.ListaAnioElectivo().ToList();
        }

        public static bool AgregarAnio(string descripcion, string semestre )
        {
            return servicio.AddAnioElectivo(descripcion, semestre);
        }

        public static bool EliminarAnio(int id)
        {
            return servicio.EliminarAnioElectivo(id);
        }

        public static List<AnioElectivoSW> BuscarAnio(int id)
        {
            return servicio.BuscarAnioElectivo(id).ToList();
        }

        #endregion

        #region Colegio

        public static List<ColegioInnerJoin> ListaCole()
        {
            return servicio.ListaColegioInner().ToList();
        }

        public static bool AgregarCole(string nomColegio, int idDepartamento, int idAnioElectivo)
        {
            return servicio.AddColegio(nomColegio, idDepartamento, idAnioElectivo);
        }

        public static bool EliminarCole(int id)
        {
            return servicio.EliminarColegio(id);
        }

        public static List<ColegioSW> BuscarCole(int id)
        {
            return servicio.BuscarColegio(id).ToList();
        }

        public static List<ColegioSW> ListColeSpinner()
        {
            return servicio.ListaSpinnerCole().ToList();
        }
        #endregion

        #region Grado

        public static List<GradoInnerJoin> ListaGrado()
        {
            return servicio.ListaGradoInner().ToList();
        }

        public static bool AgregarGrado(string descripcion, int idColegio)
        {
            return servicio.AddGrado(descripcion, idColegio);
        }

        public static bool EliminarGrado(int id)
        {
            return servicio.EliminarGrado(id);
        }

        public static List<GradoSW> BuscarGrado(int id)
        {
            return servicio.BuscarGrado(id).ToList();
        }

        public static List<GradoSW> ListaSpinnerGrado()
        {
            return servicio.ListaSpinnerGrado().ToList();
        }
        #endregion

        #region Alumno

        public static List<AlumnoInnerJoin> ListaAlumno()
        {
            return servicio.ListaAlumnoInner().ToList();
        }

        public static bool AgregarAlumno(string nombre, string apellido, string sexo, string telefono, string email, int idgrado)
        {
            return servicio.AddAlumno(nombre, apellido, sexo, telefono, email, idgrado);
        }

        public static bool EliminarAlumno(int id)
        {
            return servicio.EliminarAlumno(id);
        }


        public static List<AlumnoSW> ListaAlumnoSpinner()
        {
            return servicio.ListaSpinnerAlumno().ToList();
        }

        //public static List<GradoSW> BuscarGrado(int id)
        //{
        //    return servicio.BuscarGrado(id).ToList();
        //}

        public static List<AlumnoSW> ListaSpinnerAlumno()
        {
            return servicio.ListaSpinnerAlumno().ToList();
        }
        #endregion

        #region Materia

        public static List<MateriaInnerJoin> ListaMateria()
        {
            return servicio.ListaMateriaInner().ToList();
        }

        public static bool AgregarMateria(string descripcion, int idAlumno)
        {
            return servicio.AddMateria(descripcion, idAlumno);
        }

        public static bool EliminarMateria(int id)
        {
            return servicio.EliminarMateria(id);
        }

        //public static List<GradoSW> BuscarGrado(int id)
        //{
        //    return servicio.BuscarGrado(id).ToList();
        //}

        //public static List<mater> ListaSpinnerGrado()
        //{
        //    return servicio.ListaSpinnerGrado().ToList();
        //}
        #endregion

        #region Enum

        public static List<EnumAsisSW> ListaEnum()
        {
            return servicio.ListaEnum().ToList();
        }

        public static bool AgregarEnum(string descripcion)
        {
            return servicio.AddEnumAsis(descripcion);
        }

        public static bool EliminarEnum(int id)
        {
            return servicio.EliminarEnumAsis(id);
        }

        //public static List<GradoSW> BuscarGrado(int id)
        //{
        //    return servicio.BuscarGrado(id).ToList();
        //}

        //public static List<mater> ListaSpinnerGrado()
        //{
        //    return servicio.ListaSpinnerGrado().ToList();
        //}
        #endregion

        #region Asistencia

        public static List<AsistenciaInnerJoin> ListAsistencia()
        {
            return servicio.ListaAsistenciaInner().ToList();
        }

        public static bool AgregarAsisten(DateTime fecha, int idAlumno, int idEnumAsis)
        {
            return servicio.AddAsistencia(fecha, idAlumno, idEnumAsis);
        }

        public static bool EliminarAsis(int id)
        {
            return servicio.EliminarAsistencia(id);
        }

        #endregion

        #region Login y registro

        public static bool LoginApp(string email, string pass)
        {
            return servicio.Login(email, pass);
        }

        public static ResultRegister RegisterApp(string email, string pass)
        {
            return servicio.Register(email, pass);
        }

        #endregion
    }
}