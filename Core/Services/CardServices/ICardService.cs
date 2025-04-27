using Core.DTOs.CardDTOs;
using Domain.Entites;
using System.Collections.Generic;

namespace Core.Services.CardServices
{
    public interface ICardService
    {
        void Create(CardCreateDTO card);
        void Update(int cardId, CardUpdateDTO card);
        void Delete(int cardId);
        IEnumerable<Card> GetAll();
    }
}
