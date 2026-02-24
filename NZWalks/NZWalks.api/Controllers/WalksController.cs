using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.api.CustomActionFilters;
using NZWalks.api.models.domain;
using NZWalks.api.models.DTO;
using NZWalks.api.Repositories;

namespace NZWalks.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Createasync([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walksDominModel = mapper.Map<Walks>(addWalkRequestDto);
            await walkRepository.CreateAsync(walksDominModel);
            return Ok(mapper.Map<WalksDto>(walksDominModel));

        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
           [FromQuery] string? sortBy, [FromQuery] bool? IsAscending,
           [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var WalksDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, IsAscending ?? true, pageNumber, pageSize);
            
            return Ok(mapper.Map<List<WalksDto>>(WalksDomainModel));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalksDto>(walkDomainModel));
        
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkDto updateWalkDto)
        {
            var walksDomainModel = mapper.Map<Walks>(updateWalkDto);
            walksDomainModel = await walkRepository.UpdateAsync(id, walksDomainModel);
            if (walksDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalksDto>(walksDomainModel));
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalk = await walkRepository.DeleteAsync(id);
            if (deletedWalk == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalksDto>(deletedWalk));
        }
    }
}
