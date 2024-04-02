using AutoMapper;
using HamburgerciUygulamasi.DAL.Entities.Concrete;
using HamburgerciUygulamasi.UI.Areas.AdminArea.Models.VM;
using HamburgerciUygulamasi.UI.Areas.CustomerArea.Models.VM;

namespace HamburgerciUygulamasi.UI.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<Extra, ExtraIndexItem>().ReverseMap();
            this.CreateMap<Extra, ExtraAddVM>().ReverseMap();
            this.CreateMap<Extra, ExtraEditVM>().ReverseMap();

            this.CreateMap<Menu, MenuIndexItem>().ReverseMap();
            this.CreateMap<Menu, MenuAddVM>().ReverseMap();
            this.CreateMap<Menu, MenuEditVM>().ReverseMap();

            this.CreateMap<Order, OrderIndexVM>().ReverseMap();
            this.CreateMap<Order, OrderAddVM>().ReverseMap();
            this.CreateMap<Order, OrderEditItem>().ReverseMap();

        }
    }
}
