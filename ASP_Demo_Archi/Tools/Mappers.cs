using ASP_Demo_Archi.Models;
using ASP_Demo_Archi_DAL.Models;
using ASP_Demo_Archi_DAL.Repositories;

namespace ASP_Demo_Archi.Tools
{
    public static class Mappers
    {
        public static Movie ToDAL(this MovieCreateForm form)
        {
            return new Movie
            {
                Title = form.Title,
                Description = form.Description,
                RealisatorId = form.RealisatorId
            };
        }

        public static Person ToDAL(this PersonCreateForm form)
        {
            return new Person
            {
                Firstname = form.Firstname,
                Lastname = form.Lastname,
                PictureURL = form.PictureUrl
            };
        }

        public static PersonDetailView ToASP(this Person p, IMovieRepo repo)
        {
            return new PersonDetailView
            {
                Id = p.Id,
                Firstname = p.Firstname,
                Lastname = p.Lastname,
                PictureURL = p.PictureURL,
                Filmographie = repo.GetMovieByPersonId(p.Id)
            };
        }
    }
}
