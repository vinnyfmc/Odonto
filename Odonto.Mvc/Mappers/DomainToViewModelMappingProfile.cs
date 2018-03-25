using AutoMapper;
using Odonto.Domain.Entities;
using Odonto.Mvc.Models;

namespace Odonto.Mvc.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Empresa, EmpresaViewModel>();
        }
    }
}