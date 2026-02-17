using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Createasync([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walksDominModel = mapper.Map<Walks>(addWalkRequestDto);
            await walkRepository.CreateAsync(walksDominModel);
            return Ok(mapper.Map<WalksDto>(walksDominModel));

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var WalksDomainModel = await walkRepository.GetAllAsync();
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
