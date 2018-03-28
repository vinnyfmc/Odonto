using AutoMapper;
using Odonto.Domain.Entities;
using Odonto.Mvc.Models;

namespace Odonto.Mvc.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EmpresaViewModel, Empresa>();
            CreateMap<FuncionarioViewModel, Funcionario>();
        }
    }
}