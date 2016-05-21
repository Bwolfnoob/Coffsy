using System.ComponentModel.DataAnnotations;

namespace Coffsy.Application.ViewModels
{
    public class RateViewModel: EntityViewModel
    {
        [Display(Name = "Pontuação")]
        public int Point { get; set; }

        [Display(Name = "Usuário")]
        public UserViewModel User { get; set; }
    }
}
