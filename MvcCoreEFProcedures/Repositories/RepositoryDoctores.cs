using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCoreEFProcedures.Data;
using MvcCoreEFProcedures.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

#region PROCEDIMIENTOS ALMACENADOS

//CREATE PROCEDURE SP_ESPECIALIDADES
//    AS

//    select DISTINCT(especialidad) from doctor
//GO

//CREATE PROCEDURE SP_ALLDOCTORES
//AS

//    SELECT* FROM DOCTOR
//GO

//CREATE PROCEDURE SP_INCREMENTARSALARIO(@INCREMENTO INT
//, @ESPECIALIDAD NVARCHAR(50))
//AS
//    UPDATE DOCTOR
//    set SALARIO = (SALARIO+@INCREMENTO)
//	WHERE ESPECIALIDAD = @ESPECIALIDAD
//GO

//CREATE PROCEDURE 
//SP_DOCTORESESPECIALIDAD(@ESPECIALIDAD NVARCHAR(50))
//	AS

//    SELECT* FROM DOCTOR
//   WHERE ESPECIALIDAD=@ESPECIALIDAD
//GO

#endregion

namespace MvcCoreEFProcedures.Repositories
{
    public class RepositoryDoctores
    {
        private EnfermosContext context;

        public RepositoryDoctores(EnfermosContext context)
        {
            this.context = context;
        }

        public List<String> GetEspecialidades ()
        {
            using (DbCommand com =
                this.context.Database.GetDbConnection().CreateCommand())
            {
                string sql = "SP_ESPECIALIDADES";
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = sql;
                com.Connection.Open();
                DbDataReader reader = com.ExecuteReader();
                List<string> especialidades = new List<string>();
                while (reader.Read())
                {
                    especialidades.Add(reader["ESPECIALIDAD"].ToString());
                }
                reader.Close();
                com.Connection.Close();
                return especialidades;
            }
        }

        public List<Doctor> GetDoctores()
        {
            string sql = "SP_ALLDOCTORES";
            var consulta =
                this.context.Doctores.FromSqlRaw(sql);
            List<Doctor> doctores = consulta.AsEnumerable().ToList();
            return doctores;
        }

        public List<Doctor> GetDoctoresEspecialidad(string especialidad)
        {
            string sql = "SP_DOCTORESESPECIALIDAD @ESPECIALIDAD";
            SqlParameter pamespe = new SqlParameter("@ESPECIALIDAD", especialidad);
            var consulta = this.context.Doctores.FromSqlRaw(sql, pamespe);
            List<Doctor> doctores = consulta.AsEnumerable().ToList();
            if (doctores.Count() == 0)
            {
                return null;
            }
            else
            {
                return doctores;
            }
        }

        public void UpdateSalarioDoctores(string especialidad, int incremento)
        {
            string sql = "SP_INCREMENTARSALARIO @INCREMENTO,@ESPECIALIDAD";
            SqlParameter pamespe = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamincremento = new SqlParameter("@INCREMENTO", incremento);
            this.context.Database.ExecuteSqlRaw(sql, pamincremento, pamespe);
        }
    }
}
