using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Books.API.Dtos.Tag;
using Books.API.DTOs.Tag;
using Books.ApplicationCore.Entities.BookAggregate;
using Books.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IAsyncRepository<Tag> _tagRepository;
        private readonly IMapper _mapper;

        public TagsController(IAsyncRepository<Tag> tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET api/tags
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _tagRepository.ListAllAsync();

            if (tags == null || tags.Count == 0)
                return NotFound();

            IReadOnlyList<TagForReturnDto> tagsForReturn = _mapper.Map<IReadOnlyList<TagForReturnDto>>(tags);

            return Ok(tagsForReturn);
        }

        // GET api/tags/5
        [HttpGet]
        [Route("{id}", Name = "GetTag")]
        public async Task<IActionResult> GetTag(int? id = 0)
        {
            if (id == 0 || id == null)
                return BadRequest();

            var tag = await _tagRepository.GetByIdAsync(id);

            if (tag == null)
                return NotFound();

            TagForReturnDto tagForReturn = _mapper.Map<TagForReturnDto>(tag);

            return Ok(tagForReturn);
        }

        // POST api/tag
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TagForCreationDto tag)
        {
            Tag tagEntity = _mapper.Map<Tag>(tag);
             
            if (!ModelState.IsValid)
                return BadRequest();
                       
            await _tagRepository.AddAsync(tagEntity);

            return CreatedAtRoute("GetTag",
                new { id = tagEntity.Id }, tagEntity);
        }

        // PUT api/tags/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int? id, [FromBody] TagForCreationDto tagFromUser)
        {
            if (id == null || !ModelState.IsValid)
                return BadRequest();

            var tagInDb = await _tagRepository.GetByIdAsync(id);

            if (tagInDb == null)
                return NotFound();

            tagInDb.Name = tagFromUser.Name;
            tagInDb.Description = tagFromUser.Description;

            await _tagRepository.UpdateAsync(tagInDb);

            return Ok();
        }

        // DELETE api/tags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id < 1 || id == null)
                return BadRequest();

            var tagInDb = await _tagRepository.GetByIdAsync(id);

            if (tagInDb == null)
                return NotFound();

            await _tagRepository.DeleteAsync(tagInDb);

            return Ok();
        }
    }
}
