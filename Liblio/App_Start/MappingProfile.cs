using AutoMapper;
using Liblio.Dtos;
using Liblio.Models;

namespace Liblio.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Employee, EmployeeDto>();
            Mapper.CreateMap<EmployeeDto, Employee>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<LibraryItem, LibraryItemDto>();
            Mapper.CreateMap<LibraryItemDto, LibraryItem>()
                .ForMember(b => b.Id, opt => opt.Ignore());

            Mapper.CreateMap<Category, CategoryDto>();
        }
    }
}