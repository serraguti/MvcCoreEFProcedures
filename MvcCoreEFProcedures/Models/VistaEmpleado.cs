using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreEFProcedures.Models
{
    [Table("EMPLEADOS_DEPARTAMENTOS")]
    public class VistaEmpleado
    {
        [Key]
        [Column("EMP_NO")]
        public int IdEmpleado { get; set; }
        [Column("APELLIDO")]
        public String Apellido { get; set; }
        [Column("OFICIO")]
        public String Oficio { get; set; }
        [Column("DEPARTAMENTO")]
        public String Departamento { get; set; }
        [Column("LOCALIDAD")]
        public String Localidad { get; set; }
    }
}
