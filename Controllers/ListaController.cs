using Microsoft.AspNetCore.Mvc;
using ProyectoCalzadosEstrella.Models;
using ProyectoCalzadosEstrella.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ProyectoCalzadosEstrella.Controllers
{
    public class ListaController:Controller
    {
        private readonly ApplicationDbContext _context;

        public ListaController(ApplicationDbContext context)
        {
            _context = context;
        }

         public async Task<IActionResult> Index()
        {
            var lista = _context.DataInsumos.Where(x=>x.Categoria == "I");
            return View(lista);
        }
        public async Task<IActionResult> Index2()
        {
            var lista = _context.DataInsumos.Where(x=>x.Categoria == "C");
            return View(lista);
        }

        public async Task<IActionResult> Details(int id)
        {
           Insumo objProduct = await _context.DataInsumos.FindAsync(id);
           if(objProduct == null){
               return NotFound();
           }
           return View(objProduct);
        }
        public async Task<IActionResult> Details2(int id)
        {
           Insumo objProduct = await _context.DataInsumos.FindAsync(id);
           if(objProduct == null){
               return NotFound();
           }
           return View(objProduct);
        }

    }
}