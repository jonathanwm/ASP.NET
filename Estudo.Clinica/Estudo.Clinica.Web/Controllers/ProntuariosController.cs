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
using Estudo.Clinica.Web.ViewModels.Prontuario;

namespace Estudo.Clinica.Web.Controllers
{
    public class ProntuariosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Prontuarios
        public ActionResult Index()
        {
            var prontuarios = db.Prontuarios.Include(p => p.Animal).Include(p => p.Medico);
            return View(Mapper.Map<List<Prontuario>, List<ProntuarioExibicaoViewModel>>(prontuarios.ToList()));
        }

        // GET: Prontuarios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prontuario prontuario = db.Prontuarios.Find(id);
            if (prontuario == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Prontuario, ProntuarioExibicaoViewModel>(prontuario));
        }

        // GET: Prontuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdAnimal = new SelectList(db.Animais, "Id", "Nome");
            ViewBag.IdMedico = new SelectList(db.Medicos, "Id", "Nome");
            return View();
        }

        // POST: Prontuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,Hora,Observacoes,IdMedico,IdAnimal")] Prontuario prontuario)
        {
            if (ModelState.IsValid)
            {
                db.Prontuarios.Add(prontuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAnimal = new SelectList(db.Animais, "Id", "Nome", prontuario.IdAnimal);
            ViewBag.IdMedico = new SelectList(db.Medicos, "Id", "Nome", prontuario.IdMedico);
            return View(Mapper.Map<Prontuario, ProntuarioViewModel>(prontuario));
        }

        // GET: Prontuarios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prontuario prontuario = db.Prontuarios.Find(id);
            if (prontuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAnimal = new SelectList(db.Animais, "Id", "Nome", prontuario.IdAnimal);
            ViewBag.IdMedico = new SelectList(db.Medicos, "Id", "Nome", prontuario.IdMedico);
            return View(Mapper.Map<Prontuario, ProntuarioViewModel>(prontuario));
        }

        // POST: Prontuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,Hora,Observacoes,IdMedico,IdAnimal")] Prontuario prontuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prontuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAnimal = new SelectList(db.Animais, "Id", "Nome", prontuario.IdAnimal);
            ViewBag.IdMedico = new SelectList(db.Medicos, "Id", "Nome", prontuario.IdMedico);
            return View(Mapper.Map<Prontuario, ProntuarioViewModel>(prontuario));
        }

        // GET: Prontuarios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prontuario prontuario = db.Prontuarios.Find(id);
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
            Prontuario prontuario = db.Prontuarios.Find(id);
            db.Prontuarios.Remove(prontuario);
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
