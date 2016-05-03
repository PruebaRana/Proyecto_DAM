using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsSGBD.Clases;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for ConectoresTest and is intended
    ///to contain all ConectoresTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConectoresTest
    {
        private Conectores _Item;
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
            this._Item = ConectoresTest.Inicializar();
        }

        [TestCleanup()]
        public void Fnalize()
        {
            this._Item = null;
        }

        #region Constructores
        /// <summary>
        ///A test for Conectores Constructor
        ///</summary>
        [TestMethod()]
        public void Conectores_Constructor_Test()
        {
            string asRutaXML = @"c:\"; 
            Conectores target = new Conectores(asRutaXML);

            Assert.AreEqual(0, target.Conector.Count);
            Assert.AreEqual(@"c:\", target.RutaXML);
        }

        /// <summary>
        ///A test for Conectores Constructor
        ///</summary>
        [TestMethod()]
        public void Conectores_Constructor_Test1()
        {
            string asRutaXML = @"c:\";
            Conectores target = new Conectores();
            target.RutaXML = asRutaXML;

            Assert.AreEqual(0, target.Conector.Count);
            Assert.AreEqual(@"c:\", target.RutaXML);
        }
        #endregion

        #region Clone
        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void Conectores_Clone_Test()
        {
            Conectores expected = this._Item.Clone();

            Assert.AreEqual(expected, this._Item);
        }
        #endregion

        #region Comparaciones
        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Conectores_Equals_Test()
        {
            Conectores target1 = this._Item.Clone();

            bool expected1 = this._Item.Equals(((Object)target1));

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Conectores_EqualsNot_Test()
        {
            Conectores target2 = this._Item.Clone();
            target2.RutaXML = "Nop";

            bool expected2 = this._Item.Equals(((Object)target2));

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Conectores_EqualsObject_Test()
        {
            Conectores target1 = this._Item.Clone();

            bool expected1 = this._Item.Equals(target1);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Conectores_EqualsObjectNot_Test()
        {
            Conectores target2 = this._Item.Clone();
            target2.RutaXML = "Nop";

            bool expected2 = this._Item.Equals(target2);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod()]
        public void Conectores_OpEquality_Test()
        {
            Conectores target1 = this._Item.Clone();

            bool expected1 = (this._Item == target1);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Conectores_OpEqualityNot_Test()
        {
            Conectores target2 = this._Item.Clone();
            target2.RutaXML = "Nop";

            bool expected2 = (this._Item == target2);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod()]
        public void Conectores_OpInequality_Test()
        {
            Conectores target1 = this._Item.Clone();

            bool expected1 = (this._Item != target1);

            Assert.IsFalse(expected1);
        }
        [TestMethod()]
        public void Conectores_OpInequalityNot_Test()
        {
            Conectores target2 = this._Item.Clone();
            target2.RutaXML = "Nop";

            bool expected2 = (this._Item != target2);

            Assert.IsTrue(expected2);
        }
        #endregion

        #region XML
        [TestMethod()]
        public void Conectores_SaveAndLoadXML_Test()
        {
            Conectores target1 = this._Item.Clone();
            Conectores target2 = new Conectores();

            target1.RutaXML = Path.Combine(TestContext.TestDir, "Conectores.xml");
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
        /// <summary>
        ///A test for Conector
        ///</summary>
        [TestMethod()]
        public void Conectores_SetConector_Test()
        {
            Conectores target = new Conectores(); // TODO: Initialize to an appropriate value
            List<Conector> expected = this._Item.Conector;
            List<Conector> actual;
            
            target.Conector = expected;
            actual = target.Conector;
            
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Conectores_SetRutaXML_Test()
        {
            Conectores target = new Conectores(); // TODO: Initialize to an appropriate value
            string expected = this._Item.RutaXML;
            string actual;

            target.RutaXML = expected;
            actual = target.RutaXML;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        public static Conectores Inicializar()
        {
            Conector lConector = TestsSGBDTest.ConectorTest.Inicializar();
            Conectores lItem = new Conectores(@"c:\");

            lItem.Conector.Add(lConector);
            lConector = TestsSGBDTest.ConectorTest.Inicializar();
            lItem.Conector.Add(lConector);
            lConector = TestsSGBDTest.ConectorTest.Inicializar();
            lItem.Conector.Add(lConector);

            return lItem;
        }
    }
}
