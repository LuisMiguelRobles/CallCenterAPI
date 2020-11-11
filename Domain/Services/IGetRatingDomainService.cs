namespace Domain.Services
{
    using Domain.Models;
    using System.Collections.Generic;

    public interface IGetRatingDomainService
    {
        Rating GetRating(List<string> messages);
    }
}
