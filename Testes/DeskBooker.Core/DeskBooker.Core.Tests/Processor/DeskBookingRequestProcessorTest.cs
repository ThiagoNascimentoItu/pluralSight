using DeskBooker.Core.Domain;
using System;
using Xunit;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTest
    {
        private readonly DeskBookingRequestProcessor _processor;

        public DeskBookingRequestProcessorTest()
        {
            _processor = new DeskBookingRequestProcessor();
        }
        
        [Fact]
        public void ShouldReturnDeskBookingResultWithRequestValues()
        {
            var request = new DeskBookingRequest
            {
                FirstName = "Thomes",
                LastName = "Huber",
                Email = "thomas@thomasclaudiushuber.com",
                Date = new DateTime(2000, 1, 28)
            };

            var processor = new DeskBookingRequestProcessor();

            DeskBookingResult result = processor.BookDesk(request);

            Assert.NotNull(result);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);

        }

        [Fact]
        public void ShouldthrowExceptionIfRequestIsNull()
        {
           

            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookDesk(null));

            Assert.Equal("request", exception.ParamName);
        }
    }
}
