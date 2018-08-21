using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Estudo.Clinica.AcessoDados.Entity;
using Estudo.Clinica.Dominio;
using Estudo.Clinica.Repositorio.Entity;
using Estudo.Clinica.Web.ViewModels.Animal;
using Estudo.Repositorios.Comum;

namespace Estudo.Clinica.Web.Controllers
{
    public class AnimalsController : Controller
    {
        private IRepositorioGenerico<Animal, long> repositorioAnimais 
            = new AnimalRepositorio(new Contexto());

        // GET: Animals
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Animal>, List<AnimalExibicaoViewModel>>(repositorioAnimais.Selecionar()));
                
        }

        public ActionResult FiltrarPorNome(string pesquisa)
        {
            List<Animal> animais = repositorioAnimais.Selecionar().Where(a => a.Nome.Contains(pesquisa)).ToList();
            List<AnimalExibicaoViewModel> viewModels = Mapper.Map<List<Animal>, List<AnimalExibicaoViewModel>>(animais);
            return Json(viewModels, JsonRequestBehavior.AllowGet);

        }

        // GET: Animals/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = repositorioAnimais.SelecionarPorId(id.Value);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Animal,AnimalExibicaoViewModel>(animal));
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Idade,Raca,NomeDoDono")] AnimalViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Animal animal = Mapper.Map<AnimalViewModel, Animal>(viewModel);
                repositorioAnimais.Inserir(animal);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Animal animal = repositorioAnimais.SelecionarPorId(id.Value);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Animal, AnimalViewModel>(animal));
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Idade,Raca,NomeDoDono")] AnimalViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Animal animal = Mapper.Map<AnimalViewModel, Animal>(viewModel);
                repositorioAnimais.Alterar(animal);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = repositorioAnimais.SelecionarPorId(id.Value);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Animal, AnimalExibicaoViewModel>(animal));
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Animal animal = repositorioAnimais.SelecionarPorId(id);
            repositorioAnimais.Excluir(animal);
            return RedirectToAction("Index");
        }

        
    }
}
