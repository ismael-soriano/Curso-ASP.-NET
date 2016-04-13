using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using NMock;
using DAO;

namespace PruebaUnitaria
{
    [TestClass]
    public class DbTests
    {
        private MockFactory _factory = new MockFactory();

        [TestCleanup]
        public void Cleanup()
        {
            _factory.VerifyAllExpectationsHaveBeenMet();
            _factory.ClearExpectations();
        }

        [TestMethod]
        public void ExecuteReturnOk()
        {
            var connection = _factory.CreateMock<IDbConnection>();
            connection.Expects.One.GetProperty(_ => _.State).WillReturn(ConnectionState.Open);
            connection.Expects.One.Method(_ => _.Dispose());
            //connection.Expects.One.Method(_ => _.Open());

            var command = _factory.CreateMock<IDbCommand>();
            command.Expects.One.GetProperty(_ => _.CommandText).WillReturn("insert into [Table](Name) Values(@name)");
            command.Expects.One.GetProperty(_ => _.Connection).WillReturn(connection.MockObject);
            command.Expects.One.SetProperty(_ => _.Connection);
            command.Expects.One.SetProperty(_ => _.CommandTimeout);
            command.Expects.One.SetProperty(_ => _.CommandType);
            command.Expects.One.SetProperty(_ => _.Transaction);
            command.Expects.One.Method(_ => _.Dispose());
            command.Expects.One.MethodWith(_ => _.ExecuteNonQuery()).WillReturn(1);

            var result = Db.Execute(command.MockObject);

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void NullParameterCommand()
        {
            var exception = ExceptionAssert.Throws<ArgumentNullException>(() => Db.Execute(null));
            Assert.AreEqual("command", exception.ParamName);
        }
    }
}
