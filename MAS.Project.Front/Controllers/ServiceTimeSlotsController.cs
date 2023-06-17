using AutoMapper;
using MAS.Project.DTOs;
using MAS.Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Project.Front.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceTimeSlotsController : AppControllerBase
{
    public ServiceTimeSlotsController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper) { }
    
    [HttpGet]
    public async Task<IActionResult> GetServiceTimeSlotsAsync(
        [FromQuery] long serviceTypeId,
        [FromQuery] long? medicalWorkerId,
        [FromQuery] DateTime? dateFrom, 
        [FromQuery] DateTime? dateTo
    ) {
        var serviceTimeSlots = await UnitOfWork.ServiceTimeSlotRepository
            .GetServiceTimeSlots(serviceTypeId, medicalWorkerId, dateFrom, dateTo);

        var dtos = Mapper.Map<IList<BookableServiceTimeSlotDto>>(serviceTimeSlots);
        return Ok(dtos);
    }
}
