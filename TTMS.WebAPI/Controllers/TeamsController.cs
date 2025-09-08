using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Web;
using TTMS.Application.Features.Teams.Commands;
using TTMS.Domain.Contract.Response;
using TTMS.Domain.Entities;

namespace TTMS.WebAPI.Controllers
{
    [ApiController]
    public class TeamsController(ILogger<TeamsController> logger, 
        IMapper mapper, IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<TeamsController> _logger = logger;


        [HttpPost(ApiEndpoints.Teams.Create)]
        [ProducesResponseType(typeof(Team), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] TeamAddCommand request)
        {
            try
            {
                var reponse = await _mediator.Send(request);
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was a problem in getting books");
                return BadRequest();
            }
        }
    }
}
