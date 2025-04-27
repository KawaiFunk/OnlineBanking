using AizenBankV1.Web.Extensions;
using AutoMapper;
using Core.DTOs.CardDTOs;
using Domain.Entites;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Services.CardServices
{
    public class CardService : ICardService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Card> _cardRepository;

        public CardService(IMapper mapper, IGenericRepository<Card> cardRepository)
        {
            _mapper = mapper;
            _cardRepository = cardRepository;
        }

        public void Create(CardCreateDTO card)
        {
            var cardEntity = _mapper.Map<Card>(card);
            cardEntity.UserId = HttpContext.Current.GetMySessionObject().Id;
            _cardRepository.Add(cardEntity);
        }

        public void Update(int cardId, CardUpdateDTO card)
        {
            var existingCard = _cardRepository.GetAll().FirstOrDefault(c => c.Id == cardId);
            if (existingCard != null)
            {
                _mapper.Map(card, existingCard);
                _cardRepository.Update(existingCard);
            }
        }

        public void Delete(int cardId)
        {
            if (cardId == null)
            {
                return;
            }
            _cardRepository.Delete(cardId);
        }

        public IEnumerable<Card> GetAll()
        {
            var userId = HttpContext.Current.GetMySessionObject().Id;

            return _cardRepository.GetAll().Where(c => c.UserId == userId);
        }
    }
}
