using System;
using System.Net;
using Xunit;

namespace Test.Adapters.Errors.ErrorResponses
{
    public class ErrorManagerTest
    {
        [Fact]
        public void Should_create_empty_error()
        {
            ErrorResponseMock erm = new ErrorResponseMock();

            Assert.True(string.IsNullOrEmpty(erm.Error));
        }

        [Fact]
        public void Should_return_500_status_code()
        {
            ErrorResponseMock erm = new ErrorResponseMock();

            Assert.Equal((int)HttpStatusCode.InternalServerError, erm.GetResult().StatusCode);
        }

        [Fact]
        public void Should_set_time_stamp()
        {
            ErrorResponseMock erm = new ErrorResponseMock();
            DateTime time = DateTime.Now;

            erm.SetTimeStamp(time);

            Assert.Equal(time, erm.TimeStamp);
        }
    }
}
