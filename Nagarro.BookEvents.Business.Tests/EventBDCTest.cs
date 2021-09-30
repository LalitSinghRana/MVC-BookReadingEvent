using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;

namespace Nagarro.BookEvents.Business.Tests
{
    [TestClass]
    public class EventBDCTest
    {
        private readonly IEventBDC eventBDC;
        private readonly Mock<IDACFactory> mockDacFactory;
        private readonly Mock<IEventDAC> mockEventDac;

        private EventDTO eventDTO;

        private List<EventDTO> eventDTOs;

        public EventBDCTest()
        {
            mockDacFactory = new Mock<IDACFactory>();
            mockEventDac = new Mock<IEventDAC>();
            mockDacFactory.Setup(x => x.Create(It.IsAny<DACType>())).Returns(mockEventDac.Object);
            eventBDC = new EventBDC(mockDacFactory.Object);
        }

        [TestMethod]
        public void GetAllFutureEventsTest()
        {
          
                mockEventDac.Setup(x => x.GetFutureEvents()).Returns(eventDTOs);
        
                var response = eventBDC.GetFutureEvents();
                Assert.AreEqual(OperationResultType.Failure, response.ResultType);
           
        }

        [TestMethod]
        public void GetAllPastEventsTest()
        {
            mockEventDac.Setup(x => x.GetPastEvents()).Returns(eventDTOs);
            var response = eventBDC.GetPastEvents();
            Assert.AreEqual(OperationResultType.Failure, response.ResultType);
        }

        [TestMethod]
        public void GetAllEvents()
        {
            mockEventDac.Setup(x => x.GetEvents(eventDTO)).Returns(eventDTOs);
            var response = eventBDC.GetEvents(eventDTO);
            Assert.AreEqual(OperationResultType.Success, response.ResultType);
        }
    }
}
