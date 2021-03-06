﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projeto.Curso.Core.Application.Pedidos.Interfaces;

namespace Projeto.Curso.Core.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            this._clienteAppService = clienteAppService;
        }

        public IActionResult Index()
        { 
            return View();
        }

        public JsonResult ListagemClientesJson()
        {
            var model = this._clienteAppService.GetAll(); 
            return Json(model);
        }
    }
}