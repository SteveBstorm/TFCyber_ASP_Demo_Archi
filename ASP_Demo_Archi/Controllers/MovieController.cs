using ASP_Demo_Archi.Models;
using ASP_Demo_Archi.Tools;
using ASP_Demo_Archi_DAL.Models;
using ASP_Demo_Archi_DAL.Repositories;
using ASP_Demo_Archi_DAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Demo_Archi.Controllers
{
    // [AdminRequired]
    public class MovieController : Controller
    {
        private readonly IMovieRepo _movieRepo;
        private readonly IPersonRepo _personRepo;
        private readonly IMovie_PersonRepo _movie_personRepo;

        public MovieController(IMovieRepo movieRepo, IPersonRepo personRepo, IMovie_PersonRepo movie_personRepo)
        {
            _movieRepo = movieRepo;

            _personRepo = personRepo;
            _movie_personRepo = movie_personRepo;
        }
        public IActionResult Index()
        {
            return View(_movieRepo.GetAll());
        }

        public IActionResult Liste()
        {

            return View(_movieRepo.GetAll());
        }

        public IActionResult Details(int id)
        {
            Movie m = _movieRepo.GetById(id);
            MovieDetailView detail = new MovieDetailView
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                
                Realisator = _personRepo.GetById(m.RealisatorId)
            };
            return View(detail);
        }
        [AdminRequired]
        public IActionResult Create()
        {
         
            TempData["ListPerson"] = _personRepo.GetAll();
            MovieCreateForm form = new MovieCreateForm();
            return View(form);
        }

        //Scénario de gestion des erreurs => Voir MovieService (Create)
        //Voir Modif dans controller Home/Error et dans la vue Shared/Error
        [HttpPost]
        public IActionResult Create(MovieCreateForm movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int newId = _movieRepo.Create(movie.ToDAL());
                    foreach(Actor a in movie.Casting)
                    {
                        _movie_personRepo.Create(newId, a.PersonId, a.Role);
                    }
                    
                    return RedirectToAction("Liste");
                    
                    
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", "Home", routeValues: new { ex.Message });
                }
            }
            return View(movie);

        }



        /*
         Mettre en place le formulaire de mise à jour d'un film
            => L'action en HttpPost pour enregistrer les modif quand on a cliqué sur Valider
            => La méthode de service Edit qui fait la mise à jour dans la liste
            => La vu qui présente le formulaire prérempli avec les données du film à éditer
         */

        //Afficher le formulaire prérempli sur base d'un id
        [AdminRequired]
        public IActionResult Edit(int id)
        {
            Movie aModifier = _movieRepo.GetById(id);
            TempData["ListPerson"] = _personRepo.GetAll();

            return View(aModifier);
        }

        //Action entreprise quand je clique sur Valider dans le formulaire
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepo.Edit(movie);
                return RedirectToAction("Liste");
            }
            return View(movie);
        }
        [AdminRequired]
        public IActionResult Delete(int id)
        {
            _movieRepo.Delete(id);
            return RedirectToAction("Liste");
        }
    }
}
