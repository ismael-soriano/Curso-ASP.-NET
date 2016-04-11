using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactorizacion2;

namespace PruebaUnitaria
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Should_Pay_Ok()
        {
            // Arrange
            var card = new Visa() { CCC = "1234" };
            var payment = FactoryPayment.GetPayment(card);

            // Act
            var message = payment.Pay(20, card, "1111");

            // Assert
            Assert.AreEqual(message.Text, "Operación aceptada.");
        }

        [TestMethod]
        public void Should_Fail_Password()
        {
            // Arrange
            var card = new Visa() { CCC = "1234" };
            var payment = FactoryPayment.GetPayment(card);

            // Act
            var message = payment.Pay(20, card, "2222");

            // Assert
            Assert.AreEqual(message.Text, "El pin es incorrecto.");
        }

        [TestMethod]
        public void Should_Fail_Pay()
        {
            // Arrange
            var card = new Visa() { CCC = "1234" };
            var payment = FactoryPayment.GetPayment(card);

            // Act
            var message = payment.Pay(1000, card, "1111");

            // Assert
            Assert.AreEqual(message.Text, "No tiene saldo.");
        }
    }
}
