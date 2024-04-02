namespace HamburgerciUygulamasi.UI.Areas.AdminArea.Models.VM
{
    public class MenuEditVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IFormFile Picture_ { get; set; }
    }
}
