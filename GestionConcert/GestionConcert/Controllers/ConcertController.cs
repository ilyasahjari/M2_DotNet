using GestionDisque.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDisque.Controllers
{
    public class ConcertController : Controller
    {


        private static List<Concert> list = new List<Concert> { 
            new Concert { id = 1, nom = "Francis Cabrel", salle = "Theatre Royal", date = new DateTime(2021, 03, 23) },
            new Concert { id = 2, nom = "Lara Fabian", salle = "Palais des beaux-arts", date = new DateTime(2021, 06, 11) },
            new Concert { id = 3, nom = "The Weekend", salle = "arena de Bercy", date = new DateTime(2021, 11, 17) },
            new Concert { id = 3, nom = "Andre Rieu", salle = "Palais des sports", date = new DateTime(2021, 01, 10) }

        };

        // GET: ConcertController
        public ActionResult Index(string searchTitle)
        {
            if (!String.IsNullOrEmpty(searchTitle))
            {
                var concerts = list.Where(s => s.nom.ToLower().Contains(searchTitle.ToLower()));
                return View(concerts);
            }
            return View(list);
        }

        // GET: ConcertController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var concert = list.Single(d => d.id == id.Value);
            if (concert == null)
            {
                return NotFound();
            }
            return View(concert);
        }

        // GET: DisqueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConcertController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("nom, salle, date")] Concert concert)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (list.Count() == 0)
                    {
                        concert.id = 1;
                    }
                    else
                    {
                        concert.id = list.Max(d => d.id) + 1;
                    }
                    list.Add(concert);
                    return RedirectToAction(nameof(Index));
                }
                return View(concert);
            }
            catch
            {
                return View();
            }
        }

        // GET: ConcertController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var concert = list.Single(c => c.id == id.Value);
            if(concert == null)
            {
                return NotFound();
            }
            return View(concert);
        }

        // POST: ConcertController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("id, nom, salle, date")] Concert concert)
        {
            try
            {
                var co = list.Single(c => c.id == id);
                co.nom = concert.nom;
                co.salle = concert.salle;
                co.date = concert.date;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConcertController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var concert = list.FirstOrDefault(c => c.id == id.Value);
            if (concert == null)
            {
                return NotFound();
            }
            return View(concert);
        }

        // POST: ConcertController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var concert = list.Single(c => c.id == id);
                list.Remove(concert);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
