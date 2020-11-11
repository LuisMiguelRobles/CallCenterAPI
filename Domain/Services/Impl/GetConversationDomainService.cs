namespace Domain.Services.Impl
{
    using Domain.Models;
    using Infrastructure.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GetConversationDomainService : IGetConversationDomainService
    {
        private readonly IReadFileAppService _readFileAppService;
        private readonly IGetRatingDomainService _getRatingDomainService;
        private readonly string fileName = "historial_de_conversaciones.txt";

        public GetConversationDomainService(IReadFileAppService readFileAppService,
            IGetRatingDomainService getRatingDomainService)
        {
            _readFileAppService = readFileAppService;
            _getRatingDomainService = getRatingDomainService;
        }

        public List<Conversation> GetConversation()
        {
            var lines = _readFileAppService.GetFileContent(fileName);
            var conversations = new List<Conversation>();
            var numberOfMessages = 0;

            foreach (var line in lines)
            {
                var splitLine = line.Split(new[] {"\r\n"}, StringSplitOptions.None).ToList();
                if (splitLine.Any())
                {
                    splitLine = splitLine.Where(message => !message.StartsWith("CONVERSACION")).ToList();
                }

                conversations.Add(new Conversation
                {
                    Messages = GetMessages(splitLine.ToList(), out numberOfMessages),
                    NumberOfMessages = numberOfMessages,
                    Rating = _getRatingDomainService.GetRating(splitLine)
                });
            }

            return conversations;
        }

        private List<Message> GetMessages(List<string> messages, out int numberOfMessages)
        {
            var result = new List<Message>();
            numberOfMessages = 0;

            foreach (var message in messages)
            {
                numberOfMessages++;
                result.Add(new Message
                {
                    Text = message
                });
            }

            return result;
        }

        
    }
}
