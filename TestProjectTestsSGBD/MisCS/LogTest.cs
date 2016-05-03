using TestsSGBD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for LogTest and is intended
    ///to contain all LogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LogTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for EscribeLog
        ///</summary>
        [TestMethod()]
        public void Log_EscribeLog_Test()
        {
            string asMensaje = "Prueba";    // TODO: Initialize to an appropriate value
            string asSource = "LogTest";    // TODO: Initialize to an appropriate value
            int aiTipo = 2;                 // TODO: Initialize to an appropriate value
            string actual;

            string expected = DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "  ERROR " + asMensaje + "  [" + asSource + "]";
            actual = Log.EscribeLog(asMensaje, asSource, aiTipo);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for EscribeLog
        ///</summary>
        [TestMethod()]
        public void Log_EscribeLog_Test1()
        {
            string asMensaje = "Prueba";        // TODO: Initialize to an appropriate value
            string expected = null;     // TODO: Initialize to an appropriate value
            string actual;
            
            actual = Log.EscribeLog(asMensaje);
            if (Config.TipoLog == "0")
            {
                expected = DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "  INFO " + asMensaje + "  []";
            }

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for EscribeLog
        ///</summary>
        [TestMethod()]
        public void Log_EscribeLog_Test2()
        {
            string asMensaje = "Prueba";        // TODO: Initialize to an appropriate value
            string asSource = "LogTest";        // TODO: Initialize to an appropriate value
            string expected = null;     // TODO: Initialize to an appropriate value
            string actual;

            actual = Log.EscribeLog(asMensaje, asSource);
            if (Config.TipoLog == "0")
            {
                expected = DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "  INFO " + asMensaje + "  [" + asSource + "]";
            }

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for EscribeLog
        ///</summary>
        [TestMethod()]
        public void Log_EscribeLog_Test3()
        {
            string asMensaje = "Prueba";            // TODO: Initialize to an appropriate value
            string asSource = "LogTest";            // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;

            actual = Log.EscribeLog(asMensaje, asSource, Log.Tipo.ERROR);
            expected = DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "  ERROR " + asMensaje + "  [" + asSource + "]";

            Assert.AreEqual(expected, actual);
        }
    }
}
