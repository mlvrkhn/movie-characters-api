using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MovieCharactersAPI.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IMapper _mapper;

        protected BaseApiController(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected ActionResult<TDestination> MapAndReturn<TSource, TDestination>(TSource source)
        {
            var mapped = _mapper.Map<TDestination>(source);
            return Ok(mapped);
        }

        protected ActionResult<IEnumerable<TDestination>> MapAndReturn<TSource, TDestination>(IEnumerable<TSource> source)
        {
            var mapped = _mapper.Map<IEnumerable<TDestination>>(source);
            return Ok(mapped);
        }

        protected ActionResult<TDestination> MapAndReturnCreated<TSource, TDestination>(
            TSource source, string actionName, object routeValues)
        {
            var mapped = _mapper.Map<TDestination>(source);
            return CreatedAtAction(actionName, routeValues, mapped);
        }

        protected ActionResult<TDestination> MapAndReturnNotFound<TDestination>()
        {
            return NotFound();
        }

        protected ActionResult<TDestination> MapAndReturnBadRequest<TDestination>(string message)
        {
            return BadRequest(new { message });
        }
    }
} 