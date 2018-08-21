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
using Estudo.Clinica.Web.ViewModels.Medico;
using Estudo.Repositorios.Comum;

namespace Estudo.Clinica.Web.Controllers
{
    public class MedicosController : Controller
    {
        private IRepositorioGenerico<Medico, long> repositorioMedicos
            = new MedicoRepositorio(new Contexto());

        // GET: Medicos
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Medico>, List<MedicoExibicaoViewModel>>(repositorioMedicos.Selecionar()));
        }

        public ActionResult FiltrarPorNome(string pesquisa)
        {
            List<Medico> medicos = repositorioMedicos.Selecionar().Where(a => a.Nome.Contains(pesquisa)).ToList();
            List<MedicoExibicaoViewModel> viewModels = Mapper.Map<List<Medico>, List<MedicoExibicaoViewModel>>(medicos);
            return Json(viewModels, JsonRequestBehavior.AllowGet);

        }
        // GET: Medicos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = repositorioMedicos.SelecionarPorId(id.Value);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Medico, MedicoExibicaoViewModel>(medico));
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Especialidade,NumeroCRV")] MedicoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Medico medico = Mapper.Map<MedicoViewModel, Medico>(viewModel);
                repositorioMedicos.Inserir(medico);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = repositorioMedicos.SelecionarPorId(id.Value);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Medico, MedicoViewModel>(medico));
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Especialidade,NumeroCRV")] MedicoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Medico medico = Mapper.Map<MedicoViewModel, Medico>(viewModel);
                repositorioMedicos.Alterar(medico);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = repositorioMedicos.SelecionarPorId(id.Value);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Medico, MedicoExibicaoViewModel>(medico));
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Medico medico = repositorioMedicos.SelecionarPorId(id);
            repositorioMedicos.Excluir(medico);
            return RedirectToAction("Index");
        }

    }
}
