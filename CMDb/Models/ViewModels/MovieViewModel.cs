using CMDb.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class MovieViewModel
    {
        public List<MovieDetailDto> Movies { get; set; }

        public MovieViewModel(List<MovieDetailDto> movies)
        {
            this.Movies = movies;           
        }        
    }
}
