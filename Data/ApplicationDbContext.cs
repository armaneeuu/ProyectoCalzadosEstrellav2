using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoCalzadosEstrella.Models;

namespace ProyectoCalzadosEstrella.Data
{

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProyectoCalzadosEstrella.Models.Insumo> DataInsumos {get; set;}
}
}