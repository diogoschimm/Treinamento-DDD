using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            var model = this._clienteAppService.GetAll();
            return View(model);
        }
    }
}