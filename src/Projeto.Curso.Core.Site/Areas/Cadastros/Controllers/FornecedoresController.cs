using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Curso.Core.Application.Pedidos.Interfaces;

namespace Projeto.Curso.Core.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class FornecedoresController : Controller
    {
        private readonly IFornecedorAppService _fornecedorAppService;

        public FornecedoresController(IFornecedorAppService fornecedorAppService)
        {
            this._fornecedorAppService = fornecedorAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult ListagemFornecedoresJson()
        {
            var model = this._fornecedorAppService.GetAll();
            return Json(model);
        }
    }
}