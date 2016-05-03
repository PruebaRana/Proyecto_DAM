using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsSGBD;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for ConfigTest and is intended
    ///to contain all ConfigTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConfigTest
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
        ///A test for CadenaConexion
        ///</summary>
        [TestMethod()]
        public void Config_SetCadenaConexion_Test()
        {
            string expected = "Prueba";
            string actual;
            
            Config.CadenaConexion = expected;
            actual = Config.CadenaConexion;
            
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RutaConfiguraciones
        ///</summary>
        [TestMethod()]
        public void Config_SetRutaConfiguraciones_Test()
        {
            string expected = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
            expected = System.IO.Path.Combine(expected, "") + @"\Config";
            
            string actual;
            actual = Config.RutaConfiguraciones;

            Assert.AreEqual(expected, actual);
        }
    }
}
