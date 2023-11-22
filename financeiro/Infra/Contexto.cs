using financeiro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace financeiro.Infra
{
    public class Contexto:DbContext
    {
        public Contexto() { }

        public DbSet<Conta> Conta { get; set; }

    }
}