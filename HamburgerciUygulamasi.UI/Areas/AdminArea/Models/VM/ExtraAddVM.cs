using System.ComponentModel.DataAnnotations;

namespace HamburgerciUygulamasi.UI.Areas.AdminArea.Models.VM
{
    public class ExtraAddVM
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        public IFormFile? Picture_ { get; set; }
    }
}
