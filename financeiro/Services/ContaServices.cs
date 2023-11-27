using financeiro.Infra;
using financeiro.Models;
using financeiro.Models.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace financeiro.Services
{
    public class ContaServices
    {



        public async Task<ContaFilter> List(int pageNumber = 1, int pageSize = 10)
        {
            using (var db = new Contexto())
            {
                int skipAmount = (pageNumber - 1) * pageSize;


                var totalRecords = await db.Conta.CountAsync();

                var retorno = await db.Conta
                    .OrderBy(x => x.Id)
                    .Skip(skipAmount)
                    .Take(pageSize)                   
                    .ToListAsync();

                var viewModel = new ContaFilter
                {
                    Conta = retorno,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = totalRecords
                };
                return viewModel;
            }
           
        }


        public async Task<Conta> Details(int? id)
        {
            using (var db = new Contexto())
            {
                Conta conta = await db.Conta.FindAsync(id);
                return conta;
            }


        }



        public async Task<bool> Create(Conta conta)
        {
            using (var db = new Contexto())
            {
                db.Conta.Add(conta);
                var response = await db.SaveChangesAsync();
                return response > 0;
            }
        }



        public async Task<bool> Edit(Conta conta)
        {
            using (var db = new Contexto())
            {
                db.Entry(conta).State = EntityState.Modified;
                var response = await db.SaveChangesAsync();
                return response > 0;
            }
        }



        public async Task<bool> DeleteConfirmed(int id)
        {
            using (var db = new Contexto())
            {
                Conta conta = await db.Conta.FindAsync(id);
                db.Conta.Remove(conta);
                var response = await db.SaveChangesAsync();
                return response > 0;
            }
        }

        public async Task<Conta> Deposito(int id, double valor)
        {
            using (var db = new Contexto())
            {
               var conta = await db.Conta.FindAsync(id);
                if (conta != null)
                {
                    conta.Deposito(valor);
                    await db.SaveChangesAsync();
                    return conta;
                }
                return null;

            }
        } 
        public async Task<Conta> Saque(int id, double valor)
        {
            using (var db = new Contexto())
            {
               var conta = await db.Conta.FindAsync(id);
                if (conta != null)
                {
                    conta.Saque(valor);
                    await db.SaveChangesAsync();
                    return conta;
                }
                return null;

            }
        }

    }
}