using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.API.Dtos;
using Books.ApplicationCore.Entities;
using Books.ApplicationCore.Entities.BookAggregate;
using Books.ApplicationCore.Interfaces;
using Books.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IAsyncRepository<Tag> _tagRepository;

        public TagController(IAsyncRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        // GET api/tags
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _tagRepository.ListAllAsync();

            if (tags == null || tags.Count == 0)
                return NotFound();

            return Ok(tags);
        }

        // GET api/tags/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int? id = 0)
        {
            if (id == 0 || id == null)
                return BadRequest();

            var tag = await _tagRepository.GetByIdAsync(id);

            if (tag == null)
                return NotFound();

            return Ok(tag);
        }

        // POST api/tag
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TagDto tagObj)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tag = new Tag
            {
                Name = tagObj.Name,
                Description = tagObj.Description
            };

            var newTag = await _tagRepository.AddAsync(tag);
            return Ok(newTag);
        }

        // PUT api/tags/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int? id, [FromBody] TagDto tagFromUser)
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
