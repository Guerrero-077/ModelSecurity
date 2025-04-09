using Business.Interfaces;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class FormModuleController : GenericController<FormModuleDto>
    {
        public FormModuleController(IGenericService<FormModuleDto> service) : base(service)
        {
        }
    }
}
