using System;
using NUnit.Framework;
using WowPacketParser.SQL;

#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable 169

namespace WowPacketParser.Tests.SQL
{
    [TestFixture]
    public class QueryBuilderTest
    {
        private class TestData : IDataModel
        {
            [DBFieldName("ID", true)]
            public int? ID;

            [DBFieldName("TestInt1")]
            public int? TestInt1;

            [DBFieldName("TestInt2")]
            public int? TestInt2;

            [DBFieldName("TestString1")]
            public string TestString1;
        }

        [Test]
        public void TestSQLSelectNoCond()
        {
            Assert.AreEqual("SELECT `ID`, `TestInt1`, `TestInt2`, `TestString1` FROM world.test_data",
                new SQLSelect<TestData>().Build());
        }

        [Test]
        public void TestSQLSelectWithCond()
        {
            var cond = new ConditionsList<TestData>
            {
                new TestData {ID = 1, TestInt1 = 2, TestString1 = "string1"},
                new TestData {ID = 2, TestInt1 = 3}
            };

            Assert.AreEqual(
                "SELECT `ID`, `TestInt1`, `TestInt2`, `TestString1` FROM world.test_data WHERE (`ID` = 1 AND `TestInt1` = 2 AND `TestString1` = 'string1') OR (`ID` = 2 AND `TestInt1` = 3)",
                new SQLSelect<TestData>(cond, onlyPrimaryKeys: false).Build());

            Assert.AreEqual(
                "SELECT `ID`, `TestInt1`, `TestInt2`, `TestString1` FROM world.test_data WHERE (`ID` = 1) OR (`ID` = 2)",
                new SQLSelect<TestData>(cond).Build());
        }
    }
}
