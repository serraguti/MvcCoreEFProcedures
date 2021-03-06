using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcCoreEFProcedures.Models
{
	[Table("ENFERMO")]
	public class Enfermo {
		[Key]
		[Column("INSCRIPCION")]
		public int Inscripcion {get;set;}
		[Column("APELLIDO")]
		public string Apellido {get;set;}
		[Column("DIRECCION")]
		public string Direccion {get;set;}
		[Column("FECHA_NAC")]
		public DateTime FechaNacimiento {get;set;}
		[Column("SEXO")]
		public string Genero {get;set;}
	}
}
