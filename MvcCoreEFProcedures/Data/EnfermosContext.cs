using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCoreEFProcedures.Models;

#region VISTAS SQL SERVER
//create view EMPLEADOS_DEPARTAMENTOS
//AS
//select ISNULL(EMP.EMP_NO, 0) AS EMP_NO
//	, EMP.APELLIDO, EMP.OFICIO
//	, DEPT.DNOMBRE AS DEPARTAMENTO
//	, DEPT.LOC AS LOCALIDAD
//from EMP 
//inner join DEPT
//ON EMP.DEPT_NO = DEPT.DEPT_NO
#endregion

namespace MvcCoreEFProcedures.Data
{
	public class EnfermosContext: DbContext
	{
		public EnfermosContext
		(DbContextOptions<EnfermosContext> options)
		:base(options){}
		public DbSet<Enfermo> Enfermos {get;set;}

		public DbSet<Doctor> Doctores { get; set; }
	}
}
