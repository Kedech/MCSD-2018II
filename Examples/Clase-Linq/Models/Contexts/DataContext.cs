using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Clase_Linq.Models;

namespace Clase_Linq
{
    public class DataContext : DbContext
    {
        private string dbProvider = "";
        public DataContext() { dbProvider = "SQLServer"; }
        public DataContext(string dbprovider)
        {
            dbProvider = dbprovider;
        }
        public DbSet<Lista> Listas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (dbProvider)
            {
                case "SQLServer":
                    optionsBuilder.UseSqlServer(@"Server=DESKTOP-1GRCKMV;Database=TestingClass22;Trusted_Connection=True;");
                    break;
                default:
                    optionsBuilder.UseSqlite("Data Source=listas.db");
                    break;
            }
        }
    }
}