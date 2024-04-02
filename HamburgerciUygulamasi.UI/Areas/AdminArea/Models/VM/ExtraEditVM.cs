namespace HamburgerciUygulamasi.UI.Areas.AdminArea.Models.VM
{
    public class ExtraEditVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IFormFile Picture_ { get; set; }
    }
}
