using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private IEventTitleRepository _titleRepository;
        private IFieldEventRepository _fieldRepository;

        public UserController(IEventTitleRepository titleRepository, IFieldEventRepository fieldRepository)
        { 
            _titleRepository = titleRepository;
            _fieldRepository = fieldRepository;
        }
        // GET: User
        public ActionResult Index()
        {
            return View(_titleRepository.EventTitles);
        }

        public ActionResult Show(int idEvent)
        {
            EventTitle eventTitle = _titleRepository.EventTitles.Where(e => e.IdEvent == idEvent).FirstOrDefault();

            EventModel eventModel = new EventModel()
            {
                IdEvent = eventTitle.IdEvent,
                TitleEvent = eventTitle.Title,
                StartDateTime = eventTitle.StartDateTime,
                Fields = _fieldRepository.EventFields.Where(f => f.IdEvent == idEvent)
            };

            return View(eventModel);
        }

        public ActionResult Registration(int idEvent)
        {
            return null;
        }
    }
}