using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

//Esse controller é um MVC 5 Controller with views, using Entity Framework
//Select Models/Pessoa for the Model class.
//Select PessoaDBContext, specified in the Pessoa class for the Data context class.

//Ao criar esse controller, o Visual Studio cria:
//A PessoasController.cs file in the Controllers folder.
//A Views\Pessoas folder.
//Create.cshtml, Delete.cshtml, Details.cshtml, Edit.cshtml, and Index.cshtml
//in the new Views\Pessoas folder.
//Ou seja, o Visual Studio automaticamente cria o CRUD!

//the automatic creation of CRUD action methods and views is known as scaffolding.

//Agora vc pode colocar /Pessoas no fim da URL no navegador pra acessar o PessoasController

namespace WebApplication1.Controllers
{
    public class PessoasController : Controller
    {
        private PessoaDBContext db = new PessoaDBContext(); //Instância do contexto do banco de dados da pessoa

        //A request to the Movies controller returns all the entries in the 
        //Pessoas table and then passes the results to the Index view. 

        // GET: Pessoas
        public ActionResult Index(string pessoaNome)
        {
            var pessoas = from p in db.Pessoas
                          select p;

            //BUSCA: Se a string pessoaNome não estiver nula, a variável pessoas 
            //vai receber uma pessoa na qual se encontra a string pessoaNome, e essa
            //string pessoaNome vai servir como filtro quando vc clicar no botão filtrar.

            if(!String.IsNullOrEmpty(pessoaNome))
            {
                pessoas = pessoas.Where(s => s.Nome.Contains(pessoaNome));
            }

            return View(pessoas);
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }

            //If a Pessoa is found, 
            //an instance of the Pessoa model is passed to the Details view:

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Nascimento,CPF,CEP")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Nascimento,CPF,CEP")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
