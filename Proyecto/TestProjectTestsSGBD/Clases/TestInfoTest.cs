using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsSGBD.Clases;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for TestsTest and is intended
    ///to contain all TestsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TestInfoTest
    {
        private TestInfo _Item;
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
            this._Item = TestInfoTest.Inicializar();
        }

        [TestCleanup()]
        public void Fnalize()
        {
            this._Item = null;
        }

        /// <summary>
        ///A test for Tests Constructor
        ///</summary>
        [TestMethod()]
        public void TestInfo_Constructor_Test()
        {
            // Arrange
            TestInfo target = new TestInfo(this._Item);
            // Act

            // Assert
            Assert.AreEqual("Prueba", target.Nombre);
            Assert.AreEqual(@"C:\Prueba", target.File);
        }

        /// <summary>
        ///A test for Tests Constructor
        ///</summary>
        [TestMethod()]
        public void TestInfo_Constructor_Test1()
        {
            // Arrange
            TestInfo target = new TestInfo();
            // Act
            target.Nombre = this._Item.Nombre;
            target.File = this._Item.File;

            // Assert
            Assert.AreEqual("Prueba", target.Nombre);
            Assert.AreEqual(@"C:\Prueba", target.File);
        }

        /// <summary>
        ///A test for Tests Constructor
        ///</summary>
        [TestMethod()]
        public void TestInfo_Constructor_Test2()
        {
            // Arrange
            TestInfo target = new TestInfo(this._Item.Nombre, this._Item.File);
            // Act

            // Assert
            Assert.AreEqual("Prueba", target.Nombre);
            Assert.AreEqual(@"C:\Prueba", target.File);
        }

        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void TestInfo_Clone_Test()
        {
            // Arrange
            TestInfo target2 = this._Item.Clone();

            Assert.AreEqual(this._Item, target2);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void TestInfo_Equals_Test()
        {
            TestInfo target = this._Item.Clone();

            bool expected = this._Item.Equals(target);

            Assert.IsTrue(expected);
        }
        [TestMethod()]
        public void TestInfo_EqualsNot_Test()
        {
            TestInfo target = this._Item.Clone();
            target.Nombre = "Nop";

            bool expected = this._Item.Equals(target);

            Assert.IsFalse(expected);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void TestInfo_EqualsObject_Test()
        {
            TestInfo target = this._Item.Clone();

            bool expected = this._Item.Equals((object)target);

            Assert.IsTrue(expected);
        }
        [TestMethod()]
        public void TestInfo_EqualsObjectNot_Test()
        {
            TestInfo target = this._Item.Clone();
            target.Nombre = "Nop";

            bool expected = this._Item.Equals((object)target);

            Assert.IsFalse(expected);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod()]
        public void TestInfo_OpEquality_Test()
        {
            TestInfo target = this._Item.Clone();

            bool expected = (this._Item == target);

            Assert.IsTrue(expected);
        }
        [TestMethod()]
        public void TestInfo_OpEqualityNot_Test()
        {
            TestInfo target = this._Item.Clone();
            target.Nombre = "Nop";

            bool expected = (this._Item == target);

            Assert.IsFalse(expected);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod()]
        public void TestInfo_OpInequality_Test()
        {
            TestInfo target = this._Item.Clone();

            bool expected = (this._Item != target);

            Assert.IsFalse(expected);
        }
        [TestMethod()]
        public void TestInfo_OpInequalityNot_Test()
        {
            TestInfo target = this._Item.Clone();
            target.Nombre = "Nop";

            bool expected = (this._Item != target);

            Assert.IsTrue(expected);
        }

        /// <summary>
        ///A test for Test
        ///</summary>
        [TestMethod()]
        public void TestInfo_SetNombre_Test()
        {
            TestInfo target = new TestInfo();
            string expected = "Prueba";
            string actual;

            target.Nombre = expected;
            actual = target.Nombre;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Test
        ///</summary>
        [TestMethod()]
        public void TestInfo_SetFile_Test()
        {
            TestInfo target = new TestInfo();
            string expected = @"C:\Prueba";
            string actual;

            target.File = expected;
            actual = target.File;

            Assert.AreEqual(expected, actual);
        }

        public static TestInfo Inicializar()
        {
            return new TestInfo("Prueba", @"C:\Prueba");
        }
    }
}
