namespace Domain.Services
{
    using Domain.Models;
    using System.Collections.Generic;

    public interface IGetConversationDomainService
    {
        List<Conversation> GetConversation();
    }
}
