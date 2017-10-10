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
    /// <summary>
    /// пользовательская часть
    /// </summary>
    public class UserController : Controller
    {
        private IEventTitleRepository _titleRepository;
        private IFieldEventRepository _fieldRepository;
        private IUserRepository _userRepository;
        private IConfirmsRepository _confirmsRepository;

        public UserController(IEventTitleRepository titleRepository, IFieldEventRepository fieldRepository, 
                                IUserRepository userRepository, IConfirmsRepository confirmsRepository)
        { 
            _titleRepository = titleRepository;
            _fieldRepository = fieldRepository;
            _userRepository = userRepository;
            _confirmsRepository = confirmsRepository;
        }
        // GET: User
        public ActionResult Index()
        {
            return View(_titleRepository.EventTitles);
        }

        /// <summary>
        /// отображение мероприятия но отдельной странице
        /// </summary>
        /// <param name="idEvent"></param>
        /// <returns></returns>
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

        /// <summary>
        /// отображает страницу регистрации на определенное мероприятие
        /// </summary>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        public ActionResult Registration(int idEvent)
        {
            EventTitle eventTitle = _titleRepository.EventTitles.Where(e => e.IdEvent == idEvent).FirstOrDefault();

            EventModel eventModel = new EventModel()
            {
                IdEvent = eventTitle.IdEvent,
                TitleEvent = eventTitle.Title,
                StartDateTime = eventTitle.StartDateTime
            };

            return View(eventModel);
        }

        /// <summary>
        /// создает пользователя в базуданных, добавляет связь пользователя и мероприятия,
        ///  создает сообщение для подтверждения регистрации
        /// </summary>
        /// <param name="eventModel"></param>
        /// <param name="UserName"></param>
        /// <param name="UserEmail"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Registration(EventModel eventModel, string UserName, string UserEmail)
        {
            if (ModelState.IsValid)
            {
                Domain.Entities.User newUser = new User()
                {
                    Name = UserName,
                    Email = UserEmail
                };
                
                _userRepository.AddUser(newUser);

                int idUser = _userRepository.Users.Max(u => u.IdUser);

                RegistrationConfirmed newConfirmed = new RegistrationConfirmed();
                newConfirmed.IdEvent = eventModel.IdEvent;
                newConfirmed.IdUser = idUser;
                newConfirmed.EmailConfirmed = false;

                _confirmsRepository.AddConfirm(newConfirmed);

                EmailModel emailModel = new EmailModel();
                emailModel.To = UserEmail;
                emailModel.Subject = "подтверждение регистрации";
                var callbackUrl = Url.Action("ResultEmailConfirmed", "User", new{idConfirm = _confirmsRepository.Confirms.Max(m => m.Id)});
                emailModel.Body = string.Format("Для подтверждения регистрации пройдите по ссылке :: http://localhost:50381{0}", callbackUrl);

                TempData["message"] = string.Format("На email : {0} было отправлено сообщение. Подтвердите регистрацию по email.", UserEmail);
                
                new EmailController().SendMail(emailModel).Deliver();
            }

            return View("Index", _titleRepository.EventTitles);
        }

        /// <summary>
        /// подтверждение регистрации
        /// </summary>
        /// <param name="idConfirm"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ResultEmailConfirmed(int idConfirm)
        {
            _confirmsRepository.UpdateConfirm(idConfirm);

            TempData["message"] = string.Format("регистрация прошла успешно");

            return View("Index", _titleRepository.EventTitles);
        }
    }
}