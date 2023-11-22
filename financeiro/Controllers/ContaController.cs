using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using financeiro.Infra;
using financeiro.Models;
using System.Web.Services.Description;
using financeiro.Services;

namespace financeiro.Controllers
{
    public class ContaController : Controller
    {
       ContaServices contaServices =new ContaServices();

        
        public async Task<ActionResult> Index()
        {
            return View(await contaServices.Index() );
        }

        
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = await contaServices.Details(id) ;
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

      
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Balance,AccountNumber,CreatedAt")] Conta conta)
        {
            if (ModelState.IsValid)
            {
               
               await  contaServices.Create(conta);
                return RedirectToAction("Index");
            }

            return View(conta);
        }

       
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = await contaServices.Details(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Balance,AccountNumber,CreatedAt")] Conta conta)
        {
            if (ModelState.IsValid)
            {
               
                await contaServices.Edit(conta);
                return RedirectToAction("Index");
            }
            return View(conta);
        }

       
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = await contaServices.Details(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await contaServices.DeleteConfirmed(id);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Saque")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Saque(int id,double valor)
        {
            var response = await contaServices.Saque(id,valor);
            return View(response);
        }

        [HttpPost, ActionName("Deposito")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Deposito(int id,double valor)
        {
            var response = await contaServices.Deposito(id,valor);
            return View(response);
        }

        public async Task<ActionResult> OperacaoSaque(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = await contaServices.Details(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        } 
      public async Task<ActionResult> OperacaoDeposito(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = await contaServices.Details(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        } 
      
    }
}
