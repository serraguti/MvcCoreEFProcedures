using Oracle.ManagedDataAccess.Client;
using Microsoft.EntityFrameworkCore;
using MvcCoreEFProcedures.Data;
using MvcCoreEFProcedures.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
#region STORED PROCEDURES
//CREATE OR REPLACE PROCEDURE TODOS_EMPLEADOS
//(P_CURSOR OUT SYS_REFCURSOR)
//AS
//    CONSULTA SYS_REFCURSOR;
//BEGIN
//    OPEN CONSULTA FOR
//    SELECT * FROM EMP;
//END;

#endregion

namespace MvcCoreEFProcedures.Repositories
{
    public class RepositoryEmpleados
    {
        private EnfermosContext context;

        public RepositoryEmpleados(EnfermosContext context)
        {
            this.context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            //string sql = "ALL_EMPLEADOS P_CURSOR";
            var sql = "BEGIN ALL_EMPLEADOS(:P_CURSOR); END;";

            ////This one gets mapped without problems.
            //var validaResCursor = await _context.CursorValidaRes.FromSqlRaw(sql, parameters).ToListAsync();

            ////This one throws the exception.
            //var opcionesCursor = await _context.CursorOpciones.FromSqlRaw(sql, parameters).ToListAsync();

            //var result = (opcionesCursor, validaResCursor);
            //SE UTILIZAN PARAMETROS DE LA CLASE SqlParameter
            //PERO DEL NAMESPACE Microsoft.Data.SqlClient
            OracleParameter pamcursor = new OracleParameter();
            pamcursor.ParameterName = "P_CURSOR";
            pamcursor.OracleDbType = OracleDbType.RefCursor;
            pamcursor.Direction = ParameterDirection.Output;
            pamcursor.Value = null;
            var consulta =
                this.context.Empleados.FromSqlRaw(sql, pamcursor);
            return consulta.ToList();
        }
    }
}
