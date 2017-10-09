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
    public class AdminController : Controller
    {
        private IFieldEventRepository _repositoryFields;
        private IEventTitleRepository _titleRepository;


        public AdminController(IFieldEventRepository repositoryFields, IEventTitleRepository eventTitleRepository)
        {
            _repositoryFields = repositoryFields;
            _titleRepository = eventTitleRepository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(new EventModel());
        }

        public ActionResult CreateEvent()
        {
            return View(new EventModel());
        }
        

        [HttpPost]
        public ActionResult CreateEvent(EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                EventTitle newEventTitle = new EventTitle();
                newEventTitle.Title = eventModel.TitleEvent;
                newEventTitle.StartDateTime = eventModel.StartDateTime;

                _titleRepository.AddEventTitle(newEventTitle);

                eventModel.IdEvent = _titleRepository.EventTitles.Max(e => e.IdEvent);
            }

            return PartialView(eventModel);
        }

        [HttpPost]
        public ActionResult AddEventField(EventModel eventModel, string titleField, string descriptionField)
        {
            if (ModelState.IsValid)
            {
                FieldEvent newField = new FieldEvent()
                {
                    Title = titleField,
                    Description = descriptionField,
                    IdEvent = eventModel.IdEvent
                };

                _repositoryFields.AddField(newField);

                eventModel.Fields = _repositoryFields.EventFields.Where(f => f.IdEvent == eventModel.IdEvent);
            }

            return PartialView("CreateEvent", eventModel);
        }

        
    }
}