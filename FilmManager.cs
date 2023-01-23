using System;
using FilmDB502v2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB502v2
{
    public class FilmManager
    {
        public FilmManager AddFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                try
                {
                    context.Films.Add(filmModel);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    filmModel.ID = 0;
                    context.Films.Add(filmModel);
                    context.SaveChanges();
                }
            }
            
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            using (var context = new FilmContext())
            {
                var wpis = context.Films.SingleOrDefault(x => x.ID == id);
                context.Films.Remove(wpis);

                context.SaveChanges();
            }
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                var wpis = context.Films.Update(filmModel);
                context.SaveChanges();
            }

            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            using (var context = new FilmContext())
            {
                var wpis = context.Films.Single(x => x.ID == id);
                wpis.Title = newTitle;
                context.SaveChanges();
            }
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            using (var context = new FilmContext())
            {
                var wpis = context.Films.SingleOrDefault(x => x.ID == id);
                return wpis;
            }
        }

        public List<FilmModel> GetFilms()
        {
            using (var context = new FilmContext())
            {
                return context.Films.ToList<FilmModel>();
            }
        }
    }
}
