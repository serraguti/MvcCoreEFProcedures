using System.Data;
using System;
using System.Collections.Generic;
using MvcCoreEFProcedures.Data;
using MvcCoreEFProcedures.Models;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MvcCoreEFProcedures.Repositories
{
    public class RepositoryEnfermos
    {
        private HospitalContext context;
        public RepositoryEnfermos(HospitalContext context)
        {
            this.context = context;
        }

        public List<Enfermo> GetEnfermos()
        {
            var consulta = from datos in this.context.Enfermos
                           select datos;
            return consulta.ToList();
            //PARA LLAMAR A PROCEDIMIENTOS SELECT
            //DEBEMOS EXTRAER LA CONEXION DE NUESTRO CONTEXT
            //SE UTILIZAN OBJETOS A LA ANTIGUA DE ADO EF
            //using (DbCommand com =
            //this.context.Database.GetDbConnection().CreateCommand())
            //{
            //    string sql = "SP_ALLENFERMOS";
            //    com.CommandType = CommandType.StoredProcedure;
            //    com.CommandText = sql;
            //    com.Connection.Open();
            //    DbDataReader reader = com.ExecuteReader();
            //    List<Enfermo> enfermos = new List<Enfermo>();
            //    while (reader.Read())
            //    {
            //        Enfermo enfermo = new Enfermo();
            //        enfermo.Inscripcion =
            //        int.Parse(reader["INSCRIPCION"].ToString());
            //        enfermo.Apellido = reader["APELLIDO"].ToString();
            //        enfermo.Direccion = reader["DIRECCION"].ToString();
            //        enfermo.FechaNacimiento =
            //        DateTime.Parse(reader["FECHA_NAC"].ToString());
            //        enfermo.Genero = reader["S"].ToString();
            //        enfermos.Add(enfermo);
            //    }
            //    reader.Close();
            //    com.Connection.Close();
            //    return enfermos;
            //}
        }

        public Enfermo FindEnfermo(int inscripcion)
        {
            //PARA LLAMAR A LOS PROCEDIMIENTOS CON PARAMETROS
            //SE REALIZA DE LA SIGUIENTE FORMA:
            //  SP_PROCEDURE @PARAM1, @PARAM2...
            string sql = "SP_FINDENFERMO @INSCRIPCION";
            //SE UTILIZAN PARAMETROS DE LA CLASE SqlParameter
            //PERO DEL NAMESPACE Microsoft.Data.SqlClient
            SqlParameter paminscripcion =
            new SqlParameter("@INSCRIPCION", inscripcion);
            //COMO ES UN PROCEDIMIENTO DE CONSULTAS DE SELECCION
            //UTILIZAMOS EL METODO FromSqlRaw(sql, Param1, Param2)
            //CUANDO UTILIZAMOS METODOS DE LINQ CON PROCEDIMIENTOS
            //EN ENTITY FRAMEWORK, NO PODEMOS EXTRAER LAS ENTIDADES
            //Y APLICAR LOS METODOS A LA VEZ
            //DEBEMOS CONVERTIR A COLECCION LA CONSULTA
            var consulta =
                this.context.Enfermos.FromSqlRaw(sql, paminscripcion);
            Enfermo enfermo = consulta.AsEnumerable().FirstOrDefault();
            return enfermo;
        }

        public void DeleteEnfermo(int inscripcion)
        {
            string sql = "SP_DELETEENFERMO @INSCRIPCION";
            SqlParameter paminscripcion =
                new SqlParameter("@INSCRIPCION", inscripcion);
            this.context.Database.ExecuteSqlRaw(sql, paminscripcion);
        }
    }
}