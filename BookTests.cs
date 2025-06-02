using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab6_op.Models;

namespace lab6_op.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void GetStatus_ReturnsAvailable()
        {
            var book = new Book("Назва", "Автор", 2000, 250)
            {
                Available = true
            };

            Assert.AreEqual("Доступна", book.GetStatus());
        }

        [TestMethod]
        public void GetStatus_ReturnsReserved()
        {
            var book = new Book("Назва", "Автор", 2000, 250)
            {
                Available = false
            };

            Assert.AreEqual("Заброньована", book.GetStatus());
        }
    }
}
