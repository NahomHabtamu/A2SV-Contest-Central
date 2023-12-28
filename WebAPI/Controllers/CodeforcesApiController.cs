using Application.Features.CodeforcesApi.Commands;
using Application.Features.CodeforcesApi.Queries.CheckContestUrl;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class CodeforcesApiController : Controller
    {
        private readonly IMediator _mediator;

        public CodeforcesApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("fetch/{contest_id}")]
        public async Task<IActionResult> FetchContest(string contest_id)
        {
            await _mediator.Send(new FetchContestDataFromApiCommand { ContestId = contest_id });
            return Ok();
        }

        [HttpGet]
        [Route("ContestUrlChecker/{contest_url}")]
        public async Task<IActionResult> ContestUrlChecker(string contest_url)
        {
            bool res = await _mediator.Send(new ContestUrlCheckerRequest { ContestUrl = contest_url });
            return Ok(res);
        }
    }
}
