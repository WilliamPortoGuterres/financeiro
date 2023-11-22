using financeiro.Infra;
using financeiro.Models;
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



        public async Task<List<Conta>> Index()
        {
            using (var db = new Contexto())
            {

                return await db.Conta.ToListAsync();
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