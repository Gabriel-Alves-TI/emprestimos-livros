using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprestimosLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimosLivros.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<EmprestimosModel> Emprestimos { get; set; }
    }
}