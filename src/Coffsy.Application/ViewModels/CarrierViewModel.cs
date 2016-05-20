using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Application.ViewModels
{
    public class CarrierViewModel: EntityViewModel
    {
        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string Phone { get; set; }

        [Display(Name = "Website")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string WebSite { get; set; }

        [Display(Name = "Endereco")]
        public AddressViewModel Address { get; set; }
        public ICollection<RatingViewModel> Ratings { get; set; }
    }
}
