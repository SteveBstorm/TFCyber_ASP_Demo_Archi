﻿using ASP_Demo_Archi_DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace ASP_Demo_Archi.Models
{
    public class MovieCreateForm 
    {
        [Required(ErrorMessage = "Un film ça a un titre abruti")]
        public string Title { get; set; }

        [Required]
        [MinLength(40, ErrorMessage = "La description doit faire un minimum de 40 caractères")]
        public string Description { get; set; }
        [Required]
        public int RealisatorId { get; set; }

        public List<Actor> Casting { get; set; }

        public MovieCreateForm()
        {
            Casting = new List<Actor>();
            Casting.Add(new Actor());
            Casting.Add(new Actor());
            Casting.Add(new Actor());
        }
    }

    public class Actor
    {
        public int MovieId { get; set; }
        public int PersonId { get; set; }
        public string Role { get; set; }
    }
}
