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
using Estudo.Clinica.Web.ViewModels.Medico;
using Estudo.Clinica.Web.ViewModels.Prontuario;
using Estudo.Repositorios.Comum;

namespace Estudo.Clinica.Web.Controllers
{
    public class ProntuariosController : Controller
    {
        private Contexto db = new Contexto();
        private IRepositorioGenerico<Prontuario, long> repositorioProntuarios
          = new ProntuarioRepositorio(new Contexto());

        private IRepositorioGenerico<Animal, long> repositorioAnimais
            = new AnimalRepositorio(new Contexto());

        private IRepositorioGenerico<Medico, long> repositorioMedicos
            = new MedicoRepositorio(new Contexto());

        // GET: Prontuarios
        public ActionResult Index()
        {
            var prontuarios = db.Prontuarios.Include(p => p.Animal).Include(p => p.Medico);
            return View(Mapper.Map<List<Prontuario>, List<ProntuarioExibicaoViewModel>>(repositorioProntuarios.Selecionar()));
        }

        public ActionResult FiltrarPorNome(string pesquisa)
        {
            List<Prontuario> prontuarios = repositorioProntuarios.Selecionar().Where(a => a.Observacoes.Contains(pesquisa)).ToList();
            List<ProntuarioExibicaoViewModel> viewModels = Mapper.Map<List<Prontuario>, List<ProntuarioExibicaoViewModel>>(prontuarios);
            return Json(viewModels, JsonRequestBehavior.AllowGet);

        }


        // GET: Prontuarios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prontuario prontuario = repositorioProntuarios.SelecionarPorId(id.Value);
            if (prontuario == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Prontuario, ProntuarioExibicaoViewModel>(prontuario));
        }

        // GET: Prontuarios/Create
        public ActionResult Create()
        {
            List<AnimalExibicaoViewModel> animais = Mapper.Map<List<Animal>, List<AnimalExibicaoViewModel>>(repositorioAnimais.Selecionar());
            SelectList dropDownAnimais = new SelectList(animais, "Id", "Nome");
            ViewBag.DropDownAnimais = dropDownAnimais;

            List<MedicoExibicaoViewModel> medicos = Mapper.Map<List<Medico>, List<MedicoExibicaoViewModel>>(repositorioMedicos.Selecionar());
            SelectList dropDownMedicos = new SelectList(medicos, "Id", "Nome");
            ViewBag.DropDownMedicos = dropDownMedicos;
            return View();
        }

        // POST: Prontuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,Hora,Observacoes,IdMedico,IdAnimal")] ProntuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Prontuario prontuario = Mapper.Map<ProntuarioViewModel, Prontuario>(viewModel);
                repositorioProntuarios.Inserir(prontuario);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Prontuarios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prontuario prontuario = repositorioProntuarios.SelecionarPorId(id.Value);
            if (prontuario == null)
            {
                return HttpNotFound();
            }

            List<AnimalExibicaoViewModel> animais = Mapper.Map<List<Animal>, List<AnimalExibicaoViewModel>>(repositorioAnimais.Selecionar());
            SelectList dropDownAnimais = new SelectList(animais, "Id", "Nome");
            ViewBag.DropDownAnimais = dropDownAnimais;

            List<MedicoExibicaoViewModel> medicos = Mapper.Map<List<Medico>, List<MedicoExibicaoViewModel>>(repositorioMedicos.Selecionar());
            SelectList dropDownMedicos = new SelectList(medicos, "Id", "Nome");
            ViewBag.DropDownMedicos = dropDownMedicos;

            return View(Mapper.Map<Prontuario, ProntuarioViewModel>(prontuario));
        }

        // POST: Prontuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,Hora,Observacoes,IdMedico,IdAnimal")] ProntuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Prontuario prontuario = Mapper.Map<ProntuarioViewModel, Prontuario>(viewModel);
                repositorioProntuarios.Alterar(prontuario);
                return RedirectToAction("Index");
            }
            
            return View(viewModel);
        }

        // GET: Prontuarios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prontuario prontuario = repositorioProntuarios.SelecionarPorId(id.Value);
            if (prontuario == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Prontuario, ProntuarioExibicaoViewModel>(prontuario));
        }

        // POST: Prontuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Prontuario prontuario = repositorioProntuarios.SelecionarPorId(id);
            return RedirectToAction("Index");
        }

        
    }
}
