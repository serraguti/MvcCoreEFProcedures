﻿using Microsoft.AspNetCore.Mvc;
using MvcCoreEFProcedures.Models;
using MvcCoreEFProcedures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreEFProcedures.Controllers
{
    public class VistaEmpleadosController : Controller
    {
        private RepositoryVistas repo;

        public VistaEmpleadosController(RepositoryVistas repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<VistaEmpleado> empleados = this.repo.GetVistaEmpleados();
            return View(empleados);
        }
    }
}
