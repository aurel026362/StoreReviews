using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreReview.Core.Commands;
using StoreReview.Core.Interfaces;
using StoreReview.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReview.Web.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public FileController(IFileService fileService, IMapper mapper, IMediator mediator)
        {
            _fileService = fileService;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetImageById(long id)
        {
            var query = new GetFileByIdQuery { FileId = id };
            var file = await _mediator.Send(query);

            if (file == null || !file.Extension.StartsWith("image"))
            {
                return NotFound();
            }

            return Ok(file);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormCollection formCollection)
        {
            if (formCollection == null || formCollection.Files.Count < 1)
                return BadRequest();

            var formFile = formCollection.Files.First();

            var uploadedImagePath = await _fileService.UploadAsync(formFile);

            // throws NullReferenceException if null mapping
            var command = _mapper.Map<IFormFile, AddFileCommand>(formFile);
            command.Path = uploadedImagePath;

            // should throw ArgumentNullException if command is null, but is overlapped by previous throw
            var file = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetImageById), new { id = file.Id }, file);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var file = await _mediator.Send(new GetFileByIdQuery { FileId = id });

            if (file == null || !file.Extension.StartsWith("image"))
            {
                return NotFound();
            }

            var command = new RemoveFileCommand { FileId = id };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
