using Microsoft.AspNetCore.Mvc;
using MvcCoreEFProcedures.Models;
using MvcCoreEFProcedures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreEFProcedures.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryDoctores repo;

        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        public IActionResult DoctoresIncrementoSalarial()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            List<string> especialidades = this.repo.GetEspecialidades();
            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctores);
        }

        [HttpPost]
        public IActionResult DoctoresIncrementoSalarial
            (string especialidad, int incremento)
        {
            this.repo.UpdateSalarioDoctores(especialidad, incremento);
            List<Doctor> doctores = this.repo.GetDoctoresEspecialidad(especialidad);
            List<string> especialidades = this.repo.GetEspecialidades();
            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctores);
        }
    }
}
