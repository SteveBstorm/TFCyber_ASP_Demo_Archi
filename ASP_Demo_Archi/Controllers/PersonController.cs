using ASP_Demo_Archi.Models;
using ASP_Demo_Archi.Tools;
using ASP_Demo_Archi_DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Demo_Archi.Controllers
{
    /*
        Un controller par resource (dans ce cas Person) 
        Une action pour une page ( + 1 action en cas de validation de formulaire ) => [HttpPost]
     */
    public class PersonController : Controller
    {
        private readonly IPersonRepo _personRepo;
        private readonly IMovieRepo _movieRepo;
        public PersonController(IPersonRepo personRepo, IMovieRepo movieRepo)
        {
            _personRepo = personRepo;
            _movieRepo = movieRepo;

        }

        // GET: PersonController
        public ActionResult Index()
        {
            return View(_personRepo.GetAll());
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            PersonDetailView view = _personRepo.GetById(id).ToASP(_movieRepo);
            return View(view);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonCreateForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            _personRepo.Create(form.ToDAL());
            return RedirectToAction("Index");
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
