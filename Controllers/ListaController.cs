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
            var lista = from o in _context.DataInsumos select o;
            return View(await lista.ToListAsync());
        }

    }
}