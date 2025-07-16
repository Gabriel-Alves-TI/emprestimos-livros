using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmprestimosLivros.Data;
using EmprestimosLivros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmprestimosLivros.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private AppDbContext _context;
        public EmprestimoController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _context.Emprestimos;

            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                _context.Emprestimos.Add(emprestimos);
                _context.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _context.Emprestimos.FirstOrDefault(emp => emp.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Emprestimos.Update(emprestimo);
                _context.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar a edição!";

            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _context.Emprestimos.FirstOrDefault(emp => emp.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo)
        {
            if (emprestimo == null)
            {
                return NotFound();
            }

            _context.Emprestimos.Remove(emprestimo);
            _context.SaveChanges();

            TempData["MensagemSucesso"] = "Remoção realizada com sucesso!";

            return RedirectToAction("Index");
        }
    }
}