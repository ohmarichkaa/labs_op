using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab6_op.Services;
using lab6_op.Models;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace lab6_op.Tests
{
    [TestClass]
    public class ValidationServiceTests
    {
        private readonly ValidationService _validationService = new ValidationService();

        [TestMethod]
        public void ValidateUser_ValidUser_ReturnsTrue()
        {
            var user = new Models.User("Марія", "Іваненко", "maria@example.com", "0931234567");
            var result = _validationService.ValidateUser(user, out string error);

            Assert.IsTrue(result);
            Assert.IsNull(error);
        }

        [TestMethod]
        public void ValidateUser_InvalidEmail_ReturnsFalse()
        {
            var user = new Models.User("Марія", "Іваненко", "bademail@", "0931234567");
            var result = _validationService.ValidateUser(user, out string error);

            Assert.IsFalse(result);
            Assert.AreEqual("Невірний формат email.", error);
        }

        [TestMethod]
        public void ValidateReservationDates_ValidDates_ReturnsTrue()
        {
            var start = DateTime.Today.AddDays(1);
            var end = DateTime.Today.AddDays(5);

            var result = _validationService.ValidateReservationDates(start, end, out string error);

            Assert.IsTrue(result);
            Assert.IsNull(error);
        }
            
        [TestMethod]
        public void ValidateReservationDates_StartAfterEnd_ReturnsFalse()
        {
            var result = _validationService.ValidateReservationDates(
                DateTime.Today.AddDays(2), DateTime.Today, out string error);

            Assert.IsFalse(result);
            Assert.AreEqual("Дата початку не може бути пізнішою за дату завершення.", error);
        }
    }
}
