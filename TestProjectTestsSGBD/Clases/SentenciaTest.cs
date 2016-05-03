using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsSGBD.Clases;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for SentenciaTest and is intended
    ///to contain all SentenciaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SentenciaTest
    {
        private Sentencia _Item;
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

        [TestInitialize()]
        public void Inicialize()
        {
            this._Item = SentenciaTest.Inicializar();
        }

        [TestCleanup()]
        public void Fnalize()
        {
            this._Item = null;
        }
        
        /// <summary>
        ///A test for Sentencia Constructor
        ///</summary>
        [TestMethod()]
        public void Sentencia_Constructor_Test()
        {
            // Arrange
            Sentencia target = new Sentencia(this._Item.SQL);
            // Act

            // Assert
            Assert.AreEqual("SELECT * FROM pruebas;", target.SQL);
        }

        /// <summary>
        ///A test for Sentencia Constructor
        ///</summary>
        [TestMethod()]
        public void Sentencia_Constructor_Test1()
        {
            // Arrange
            Sentencia target = new Sentencia(this._Item);
            // Act

            // Assert
            Assert.AreEqual("SELECT * FROM pruebas;", target.SQL);
        }

        /// <summary>
        ///A test for Sentencia Constructor
        ///</summary>
        [TestMethod()]
        public void Sentencia_Constructor_Test2()
        {
            // Arrange
            Sentencia target = new Sentencia();
            // Act
            target.SQL = "SELECT * FROM pruebas;";
            // Assert
            Assert.AreEqual("SELECT * FROM pruebas;", target.SQL);
        }

        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void Sentencia_Clone_Test()
        {
            Sentencia target = this._Item.Clone();

            Assert.AreEqual(this._Item, target);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Sentencia_Equals_Test()
        {
            Sentencia target = this._Item.Clone();

            bool expected = this._Item.Equals(target);

            Assert.IsTrue(expected);
        }
        [TestMethod()]
        public void Sentencia_EqualsNop_Test()
        {
            Sentencia target = new Sentencia("Nop");

            bool expected = this._Item.Equals(target);

            Assert.IsFalse(expected);
        }
        
        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Sentencia_EqualsObject_Test()
        {
            Sentencia target = this._Item.Clone();

            bool expected = this._Item.Equals((object)target);

            Assert.IsTrue(expected);
        }
        [TestMethod()]
        public void Sentencia_EqualsObjectNop_Test()
        {
            Sentencia target = new Sentencia("Nop");

            bool expected = this._Item.Equals((object)target);

            Assert.IsFalse(expected);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod()]
        public void Sentencia_OpEquality_Test()
        {
            Sentencia target = this._Item.Clone();

            bool expected = (this._Item == target);

            Assert.IsTrue(expected);
        }
        [TestMethod()]
        public void Sentencia_OpEqualityNop_Test()
        {
            Sentencia target = new Sentencia("Nop");

            bool expected = (this._Item == target);

            Assert.IsFalse(expected);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod()]
        public void Sentencia_OpInequality_Test()
        {
            Sentencia target = this._Item.Clone();

            bool expected = (this._Item != target);

            Assert.IsFalse(expected);
        }
        [TestMethod()]
        public void Sentencia_OpInequalityNop_Test()
        {
            Sentencia target = new Sentencia("Nop");

            bool expected = (this._Item != target);

            Assert.IsTrue(expected);
        }

        /// <summary>
        ///A test for SQL
        ///</summary>
        [TestMethod()]
        public void Sentencia_SetSQL_Test()
        {
            Sentencia target = new Sentencia();
            string expected = "Prueba";
            string actual;

            target.SQL = expected;
            actual = target.SQL;
            
            Assert.AreEqual(expected, actual);
        }

        public static Sentencia Inicializar()
        {
            return new Sentencia("SELECT * FROM pruebas;");
        }
    }
}
