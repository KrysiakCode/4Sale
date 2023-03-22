using _4Sale.Models;
using _4Sale.ViewModels;
using AutoMapper;

namespace _4Sale
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemViewModel>();
            CreateMap<Invoice, InvoiceViewModel>();
        }
    }
}
