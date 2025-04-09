using Business.Interfaces;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]

    public class PersonController : GenericController<PermissionDto>
    {
        public PersonController(IGenericService<PermissionDto> service) : base(service)
        {
        }
    }
}
