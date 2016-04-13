using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using DAO;

namespace PruebaUnitaria
{
    [TestClass]
    public class HelperDbTests
    {
        private MockFactory _factory = new MockFactory();

        [TestCleanup]
        public void Cleanup()
        {
            _factory.VerifyAllExpectationsHaveBeenMet();
            _factory.ClearExpectations();
        }

        [TestMethod]
        public void ExceptionOnNullConnection()
        {
            var exception = ExceptionAssert.Throws<ArgumentNullException>(() => HelperDb.GetCommand(null, "insert into [Table](Name) Values(@name)"));
            Assert.AreEqual("connection", exception.ParamName);
        }

        [TestMethod]
        public void ExceptionOnNullSql()
        {
            var exception = ExceptionAssert.Throws<ArgumentNullException>(() => HelperDb.GetCommand(HelperDb.GetConnection(), null));
            Assert.AreEqual("sql", exception.ParamName);
        }

        [TestMethod]
        public void CommandIsCreated()
        {
            var sql = "insert into [Table](Name) Values(@name)";
            var command = HelperDb.GetCommand(HelperDb.GetConnection(), sql);
            Assert.AreEqual(sql, command.CommandText);
            Assert.AreNotEqual(command.Connection, null);
            Assert.AreEqual(command.Parameters.Count, 0);
        }

        [TestMethod]
        public void NumberParamsInCommand()
        {
            var sql = "insert into [Table](Name) Values(@name)";
            var parameters = new Dictionary<string, object>()
            {
                {"@name", "Antonio"}
            };
            var command = HelperDb.GetCommand(HelperDb.GetConnection(), sql, parameters);
            Assert.AreEqual(sql, command.CommandText);
            Assert.AreNotEqual(command.Connection, null);
            Assert.AreEqual(1, command.Parameters.Count);
        }
    }
}
