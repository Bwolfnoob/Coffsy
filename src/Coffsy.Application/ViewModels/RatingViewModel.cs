using Coffsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Application.ViewModels
{
    public class RatingViewModel: EntityViewModel
    {
        [Display(Name = "Rate")]
        public int Rate { get; set; }

        [Display(Name = "Usuario")]
        public UserViewModel User { get; set; }
    }
}
