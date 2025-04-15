using AutoMapper;
using Entity.DTOs.Select;
using Entity.Model;

namespace Entity.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Ejemplo de mapeo
            CreateMap<Form, FormDto>();
            CreateMap<FormDto, Form>();

            CreateMap<Module, ModuleDto>();
            CreateMap<ModuleDto, Module>();

            CreateMap<FormModule, FormModuleDto>();
            CreateMap<FormModuleDto, FormModule>();

            CreateMap<Module, ModuleDto>();
            CreateMap<ModuleDto, Module>();

            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionDto, Permission>();


            // Para mostrar datos
            CreateMap<Person, PersonSelectDto>()
                .ForMember(dest => dest.full_name,
                   opt => opt.MapFrom(src => $"{src.first_name} {src.last_name}"));

            // Para crear o actualizar  
            CreateMap<PersonDto, Person>();
            CreateMap<Person, PersonDto>();



            CreateMap<rol, rolDto>();
            CreateMap<rolDto, rol>();

            CreateMap<RolFormPermission, RolFormPermissionDto>();
            CreateMap<RolFormPermissionDto, RolFormPermission>();

            //CreateMap<RolUser, RolUserDto>();

            CreateMap<RolUser, RolUserDto>();
            CreateMap<RolUserDto, RolUser>();

            CreateMap<User, UserSelectDto>()
                .ForMember(dest => dest.Name_Person, opt => opt.MapFrom(src => src.person.first_name + " " + src.person.last_name));

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
