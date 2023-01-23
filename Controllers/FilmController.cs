using FilmDB502v2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB502v2.Controllers
{
    public class FilmController : Controller
    {

        public IActionResult Index()
        {
            var manager = new FilmManager();
            var films = manager.GetFilms();
            return View(films);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(FilmModel film)
        {
            var manager = new FilmManager();
            manager.AddFilm(film);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var manager = new FilmManager();
            var film = manager.GetFilm(id);
            return View(film);
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            var manager = new FilmManager();
            try
            {
                var film = manager.GetFilm(id);
                manager.RemoveFilm(film.ID);
                return RedirectToAction("Index");
            }

            catch (SystemException)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var manager = new FilmManager();
            var film = manager.GetFilm(id);
            return View(film);
        }

        [HttpPost]
        public IActionResult Edit(FilmModel filmModel)
        {
            var manager = new FilmManager();
            try
            {
                var film = manager.UpdateFilm(filmModel);
                return RedirectToAction("Index");
            }

            catch (SystemException)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Details(int id) 
        {
            var manager = new FilmManager();
            var film = manager.GetFilm(id);
            return View(film);
        }
    }
}
