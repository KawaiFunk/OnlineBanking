using AutoMapper;
using Core.DTOs;
using Core.DTOs.CardDTOs;
using Core.Models.CardModels;
using Core.Services.CardServices;
using Domain.Entites;
using System.Web.Mvc;
using Web.Attributes;

namespace Web.Controllers
{
    [RequireLogin]
    public class CardController : Controller
    {
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
            _mapper = DependencyResolver.Current.GetService<IMapper>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var cards = _cardService.GetAll();
            return View(cards);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UpsertCardModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userDTO = _mapper.Map<CardCreateDTO>(model);
            _cardService.Create(userDTO);
            return RedirectToAction("Index", "Home");
        }
    }
}