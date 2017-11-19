using NUnit.Framework;
using System;
using Job.Logger.Core;

namespace Job.Logger.UnitTests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestErrorMessageCreation()
        {
            var message = DateTime.UtcNow.ToString();
            var type = MessageType.Error;

            var testFactory = new LogMessageFactory(MessageKind.Error);
            var testObject = testFactory.ErrorMessage(message);

            Assert.AreEqual(message, testObject.Message);
            Assert.AreEqual(type, testObject.LogMessageType);
            Assert.IsTrue(testFactory.AllowedMessages.HasFlag(MessageKind.Error));
        }

        [Test()]
        public void TestWarningMessageCreation()
        {
            var message = DateTime.UtcNow.ToString();
            var type = MessageType.Warning;

            var testFactory = new LogMessageFactory(MessageKind.Warning);
            var testObject = testFactory.ErrorMessage(message);

            Assert.AreEqual(message, testObject.Message);
            Assert.AreEqual(type, testObject.LogMessageType);
            Assert.IsTrue(testFactory.AllowedMessages.HasFlag(MessageKind.Warning));
        }

        [Test()]
        public void TestInformativeMessageCreation()
        {
            var message = DateTime.UtcNow.ToString();
            var type = MessageType.Message;

            var testFactory = new LogMessageFactory(MessageKind.Message);
            var testObject = testFactory.ErrorMessage(message);

            Assert.AreEqual(message, testObject.Message);
            Assert.AreEqual(type, testObject.LogMessageType);
            Assert.IsTrue(testFactory.AllowedMessages.HasFlag(MessageKind.Message));
        }

        [Test()]
        public void TestFormattedMessage()
        {
            var message = DateTime.UtcNow.ToString();
            var type = MessageType.Success;

            var formattedMessage = String.Format("DATE: {0}, MESSAGE: {1}, TYPE: {2}", DateTime.UtcNow.ToShortDateString(), message, type);

            var testFactory = new LogMessageFactory(MessageKind.Success);
            var testObject = testFactory.ErrorMessage(message);

            Assert.AreEqual(formattedMessage, testObject.FormattedMessage);
        }

        [Test()]
        public void TestAllKindMessages()
        {
            var message = DateTime.UtcNow.ToString();

            var testFactory = new LogMessageFactory(MessageKind.All);

            var testError = testFactory.ErrorMessage(message);
            var testWarning = testFactory.WarningMessage(message);
            var testSuccess = testFactory.SuccessMessage(message);
            var testMessage = testFactory.Message(message);

            Assert.AreEqual(message, testMessage.Message);
            Assert.AreEqual(message, testSuccess.Message);
            Assert.AreEqual(message, testWarning.Message);
            Assert.AreEqual(message, testError.Message);

            Assert.AreEqual(MessageType.Message, testMessage.LogMessageType);
            Assert.AreEqual(MessageType.Success, testSuccess.LogMessageType);
            Assert.AreEqual(MessageType.Warning, testWarning.LogMessageType);
            Assert.AreEqual(MessageType.Error, testError.LogMessageType);

            Assert.IsTrue(testFactory.AllowedMessages.HasFlag(MessageKind.Message));
            Assert.IsTrue(testFactory.AllowedMessages.HasFlag(MessageKind.Success));
            Assert.IsTrue(testFactory.AllowedMessages.HasFlag(MessageKind.Warning));
            Assert.IsTrue(testFactory.AllowedMessages.HasFlag(MessageKind.Error));
        }
    }
}
