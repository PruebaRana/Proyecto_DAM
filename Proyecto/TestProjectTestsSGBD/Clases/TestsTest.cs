using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsSGBD.Clases;
using System.IO;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for TestsTest and is intended
    ///to contain all TestsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TestsTest
    {
        private Tests _Item;
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
            this._Item = TestsTest.Inicializar();
        }

        [TestCleanup()]
        public void Fnalize()
        {
            this._Item.Dispose();
            this._Item = null;
        }

        #region Constructores
        /// <summary>
        ///A test for Tests Constructor
        ///</summary>
        [TestMethod()]
        public void Tests_Constructor_Test()
        {
            // Arrange
            Tests target = new Tests(this._Item.RutaXML, this._Item.TestInfo);
            // Act

            // Assert
            Assert.AreEqual(3, target.TestInfo.Count);
            Assert.AreEqual("Prueba", target.TestInfo[0].Nombre);
            Assert.AreEqual("Prueba2", target.TestInfo[1].Nombre);
        }

        /// <summary>
        ///A test for Tests Constructor
        ///</summary>
        [TestMethod()]
        public void Tests_Constructor_Test1()
        {
            // Arrange
            Tests target = new Tests();
            // Act
            target.TestInfo = this._Item.TestInfo;

            // Assert
            Assert.AreEqual(3, target.TestInfo.Count);
            Assert.AreEqual("Prueba", target.TestInfo[0].Nombre);
            Assert.AreEqual("Prueba2", target.TestInfo[1].Nombre);
        }
        [TestMethod()]
        public void Tests_Constructor_Test2()
        {
            // Arrange
            Tests target = new Tests(this._Item);
            // Act

            // Assert
            Assert.AreEqual(3, target.TestInfo.Count);
            Assert.AreEqual("Prueba", target.TestInfo[0].Nombre);
            Assert.AreEqual("Prueba2", target.TestInfo[1].Nombre);
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void Tests_Dispose_Test()
        {
            Tests target = this._Item.Clone();
            target.Dispose();

            Assert.IsNull(target.TestInfo);
        }
        #endregion

        #region Clone
        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void Tests_Clone_Test()
        {
            // Arrange
            Tests target = this._Item.Clone();

            Assert.AreEqual(this._Item, target);
        }
        #endregion

        #region Comparaciones
        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Tests_Equals_Test()
        {
            Tests target2 = this._Item.Clone();

            bool expected1 = this._Item.Equals(target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Tests_EqualsNot_Test()
        {
            Tests target3 = this._Item.Clone();
            target3.TestInfo.Add(this._Item.TestInfo[1]);

            bool expected2 = this._Item.Equals(target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Tests_EqualsObject_Test()
        {
            Tests target2 = this._Item.Clone();

            bool expected1 = this._Item.Equals((object)target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Tests_EqualsObjectNot_Test()
        {
            Tests target3 = this._Item.Clone();
            target3.TestInfo.Add(this._Item.TestInfo[1]);

            bool expected2 = this._Item.Equals((object)target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod()]
        public void Tests_OpEquality_Test()
        {
            Tests target2 = this._Item.Clone();

            bool expected1 = (this._Item == target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Tests_OpEqualityNot_Test()
        {
            Tests target3 = this._Item.Clone();
            target3.TestInfo.Add(this._Item.TestInfo[1]);

            bool expected2 = (this._Item == target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod()]
        public void Tests_OpInequality_Test()
        {
            Tests target2 = this._Item.Clone();

            bool expected1 = (this._Item != target2);

            Assert.IsFalse(expected1);
        }
        [TestMethod()]
        public void Tests_OpInequalityNot_Test()
        {
            Tests target3 = this._Item.Clone();
            target3.TestInfo.Add(this._Item.TestInfo[1]);

            bool expected2 = (this._Item != target3);

            Assert.IsTrue(expected2);
        }
        #endregion

        #region XML
        [TestMethod()]
        public void Conectores_SaveAndLoadXML_Test()
        {
            Tests target1 = this._Item.Clone();
            Tests target2 = new Tests();

            target1.RutaXML = Path.Combine(TestContext.TestDir, "Tests.xml");
            target1.SaveXML();

            target2.RutaXML = target1.RutaXML;
            target2.LoadXML();

            bool lExisteFile = File.Exists(target1.RutaXML);
            File.Delete(target1.RutaXML);
            bool lNoExisteFile = File.Exists(target1.RutaXML);

            Assert.AreEqual(target1, target2);
            Assert.IsTrue(lExisteFile);
            Assert.IsFalse(lNoExisteFile);
        }
        #endregion

        #region Seteos
        [TestMethod()]
        public void Tests_SetTest_Test()
        {
            Tests target = new Tests(); // TODO: Initialize to an appropriate value
            List<TestInfo> expected = this._Item.TestInfo;
            List<TestInfo> actual;
            target.TestInfo = expected;
            actual = target.TestInfo;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Tests_SetRutaXML_Test()
        {
            Tests target = new Tests(); // TODO: Initialize to an appropriate value
            string expected = this._Item.RutaXML;
            string actual;
            target.RutaXML = expected;
            actual = target.RutaXML;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        public static Tests Inicializar()
        {
            Tests lTests = new Tests();

            TestInfo lItem = TestInfoTest.Inicializar();
            lTests.TestInfo.Add(lItem);
            
            lItem = TestInfoTest.Inicializar();
            lItem.Nombre = "Prueba2";
            lTests.TestInfo.Add(lItem);

            lItem = TestInfoTest.Inicializar();
            lItem.Nombre = "Prueba3";
            lTests.TestInfo.Add(lItem);
            
            return lTests;
        }
    }
}
