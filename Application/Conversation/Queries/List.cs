namespace Application.Conversation.Queries
{
    using Domain.Models;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Services;

    public class List
    {
        public class Query : IRequest<List<Conversation>> { }

        public class ListConversationHandler : IRequestHandler<Query, List<Conversation>>
        {

            private readonly IGetConversationDomainService _conversationDomainService;

            public ListConversationHandler(IGetConversationDomainService conversationDomainService)
            {

                _conversationDomainService = conversationDomainService;
            }

            public Task<List<Conversation>> Handle(Query request, CancellationToken cancellationToken)
            {
                var conversations = _conversationDomainService.GetConversation();
                return Task.FromResult(conversations);
            }

        }
    }
}
