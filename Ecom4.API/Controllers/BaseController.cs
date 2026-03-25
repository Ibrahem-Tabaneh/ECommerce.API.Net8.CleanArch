using AutoMapper;
using Ecom4.Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        protected IMapper mapper { get; }
        protected IUnitOfWork UnitOfWork { get; }
    }
}
