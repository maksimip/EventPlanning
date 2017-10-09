using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class EFEventTitlesRepositoryTests
    {
        [TestMethod]
        public void AddEventTitle_CreateNewEventTitleAndAddToDb()
        {
            //arrange
            EventTitle newEventTitle = new EventTitle()
            {
                Title = "testTitle2",
                StartDateTime = DateTime.Now
            };
            IEventTitleRepository repository = new EFEventTitleRepository();
            
            //act
            repository.AddEventTitle(newEventTitle);

            //assert
            Assert.IsTrue(repository.EventTitles.Any(et => et.Title == newEventTitle.Title));
        }
    }
}
