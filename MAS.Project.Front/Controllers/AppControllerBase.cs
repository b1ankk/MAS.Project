using AutoMapper;
using MAS.Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Project.Front.Controllers;

public abstract class AppControllerBase : Controller
{
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly IMapper Mapper;
    
    protected AppControllerBase(IUnitOfWork unitOfWork, IMapper mapper) {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }
    
    
}
