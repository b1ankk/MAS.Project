using AutoMapper;
using MAS.Project.DTOs;
using MAS.Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Project.Front.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceTypesController : AppControllerBase
{
    public ServiceTypesController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper) { }

    [HttpGet]
    public async Task<IActionResult> GetServiceTypesAsync() {
        var serviceTypes = await UnitOfWork.ServiceTypeRepository
            .GetAllServiceTypesWithAuthorizedMedicalWorkersAsync();

        var dtos = Mapper.Map<IList<ServiceTypeWithAuthorizedDto>>(serviceTypes);
        return Ok(dtos);
    }
}
