

namespace Domain.Services.Impl
{
    using Domain.Models;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Domain.Helpers;
    using System.Linq;

    public class GetRatingDomainService : IGetRatingDomainService
    {
        private readonly IDomainHelper _domainHelper;

        public GetRatingDomainService(IDomainHelper domainHelper)
        {
            _domainHelper = domainHelper;
        }

        public Rating GetRating(List<string> messages)
        {
            var score = 0;

            score = Score(messages, score);

            return new Rating
            {
                Starts = GetStarts(score)
            };

        }

        private int Score(List<string> messages, int score)
        {
            var excellentServiceCount = CountOccurrences(messages, "EXCELENTE SERVICIO");

            if (messages.Count == 1)
            {
                score = -100;
            }
            else if (excellentServiceCount > 0)
            {
                score = 100;
            }
            else
            {
                var scoreNumberOfMessages = ScoreNumberOfMessages(messages.Count);

                var scoreUrgent = ScoreUrgent(CountOccurrences(messages, "URGENTE"));

                var scoreKeyWords = ScoreKeyWords(messages, KeyWords());
                
                var scoreDurationTime = ScoreDurationTime(messages);

                score += scoreNumberOfMessages + scoreUrgent + scoreKeyWords + scoreDurationTime;
            }

            return score;
        }

        private int ScoreNumberOfMessages(int numberOfMessages)
        {
            var score = 0;
            
            if (numberOfMessages > 0 && numberOfMessages <= 5)
            {
                score = 20;
            }else if (numberOfMessages > 5)
            {
                score = 10;
            }

            return score;
        }

        private int ScoreUrgent( int urgentCount)
        {
            var score = 0;

            if (urgentCount >0 && urgentCount <= 2)
            {
                score = -5;
            }
            else if (urgentCount > 2)
            {
                score = -10;
            }

            return score;

        }

        private int ScoreKeyWords( List<string> messages,List<string> keyWords)
        {
            var count = 0;
            var score = 0;
            keyWords.ForEach(x =>
            {
                count+= CountOccurrences(messages, x);
            });

            if (count > 0)
                score = 10;

            return score;
        }

        private int ScoreDurationTime(List<string> messages)
        {
            var score = 0;
            var dateFirstMessage = _domainHelper.GeDateTime(messages.FirstOrDefault());
            var dateLastMessage = _domainHelper.GeDateTime(messages.LastOrDefault());
            var difference = (dateLastMessage - dateFirstMessage).TotalSeconds;

            score = difference < 60 ? 50 : 25;

            return score;

        }

        private int CountOccurrences(List<string> messages, string search)
        {
            int wordCount = 0;

            foreach (var message in messages)
            {
                foreach (var m in Regex.Matches(message, search))
                {
                    wordCount++;
                }
            }

            return wordCount;
        }

        private int GetStarts(int score)
        {
            var starts = 0;

            if (score > 0 && score < 25)
            {
                starts = 1;
            }
            else if (score >= 25 && score < 50)
            {
                starts = 2;
            }
            else if (score >= 50 && score < 75)
            {
                starts = 3;
            }
            else if (score >= 75 && score < 90)
            {
                starts = 4;
            }
            else if (score >= 90)
            {
                starts = 5;
            }

            return starts;
        }

        private List<string> KeyWords()
        {
            return new List<string>{"Gracias", "Buena Atención", "Muchas Gracias" };
        }
    }
}
