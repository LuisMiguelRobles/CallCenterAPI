namespace API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;
    using Application.Conversation.Queries;
    using Microsoft.AspNetCore.Mvc;

    public class ConversationController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Conversation>>> List()
        {
            return await Mediator.Send(new List.Query());
        }
    }
}
