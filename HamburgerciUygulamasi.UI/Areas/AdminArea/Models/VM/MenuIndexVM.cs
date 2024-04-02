namespace HamburgerciUygulamasi.UI.Areas.AdminArea.Models.VM
{
    public class MenuIndexVM
    {
        public string Name { get; set; }
        public bool? IsEnter { get; set; }
        public List<MenuIndexItem> Menus { get; set; }
    }
    public class MenuIndexItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[]? Picture { get; set; }
    }
}
