using AutoMapper;
using MAS.Project.DTOs;
using MAS.Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Project.Front.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceTimeSlotsController : AppControllerBase
{
    private const long UserId = 1; 
    
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
            .GetServiceTimeSlotsAsync(serviceTypeId, medicalWorkerId, dateFrom, dateTo);

        var dtos = Mapper.Map<IList<ServiceTimeSlotDto>>(serviceTimeSlots);
        return Ok(dtos);
    }

    [HttpPost]
    [Route("{id}/book")]
    public async Task<IActionResult> BookServiceTimeSlot(long id) {
        try {
            await UnitOfWork.ServiceTimeSlotRepository.BookServiceTimeSlotAsync(id, UserId);
        }
        catch (InvalidOperationException e) {
            return BadRequest();
        }
        return NoContent();
    }

    [HttpGet]
    [Route("upcoming")]
    public async Task<IActionResult> GetUpcoming() {
        var upcomingServices = await UnitOfWork.ServiceTimeSlotRepository.GetUpcomingServices(UserId);

        var dtos = Mapper.Map<IList<ServiceTimeSlotDto>>(upcomingServices);
        return Ok(dtos);
    }
}
