using Business.Interfaces;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]

    public class RolUserController : GenericController<RolUserDto>
    {
        public RolUserController(IGenericService<RolUserDto> service) : base(service)
        {
        }
    }

}
