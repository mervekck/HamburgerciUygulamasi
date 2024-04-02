namespace HamburgerciUygulamasi.UI.Areas.AdminArea.Models.VM
{
    public class ExtraIndexVM
    {
        public string Name { get; set; }
        public bool? IsEnter { get; set; }
        public List<ExtraIndexItem> Extras { get; set; }
    }
    public class ExtraIndexItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[]? Picture { get; set; }
    }
}
