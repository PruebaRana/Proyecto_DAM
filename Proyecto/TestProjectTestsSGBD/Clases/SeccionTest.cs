using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsSGBD.Clases;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for SeccionTest and is intended
    ///to contain all SeccionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SeccionTest
    {
        private Seccion _Item;
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
            this._Item = SeccionTest.Inicializar();
        }

        [TestCleanup()]
        public void Fnalize()
        {
            this._Item.Dispose();
            this._Item = null;
        }

        #region Constructores
        /// <summary>
        ///A test for Seccion Constructor
        ///</summary>
        [TestMethod()]
        public void Seccion_Constructor_Test()
        {
            // Arrange
            //Seccion target1 = IniciarSeccion();
            Seccion target1 = this._Item;
            Seccion target = new Seccion(target1.Bloque);
            // Act

            // Assert
            Assert.AreEqual(3, target.Bloque.Count);
            Assert.AreEqual("Prueba", target.Bloque[0].Nombre);
            Assert.AreEqual("Prueba2", target.Bloque[1].Nombre);
            Assert.AreEqual("Prueba3", target.Bloque[2].Nombre);
        }

        /// <summary>
        ///A test for Seccion Constructor
        ///</summary>
        [TestMethod()]
        public void Seccion_Constructor_Test1()
        {
            // Arrange
            Seccion target1 = this._Item;
            Seccion target = new Seccion(target1);
            // Act

            // Assert
            Assert.AreEqual(3, target.Bloque.Count);
            Assert.AreEqual("Prueba", target.Bloque[0].Nombre);
            Assert.AreEqual("Prueba2", target.Bloque[1].Nombre);
            Assert.AreEqual("Prueba3", target.Bloque[2].Nombre);
        }

        /// <summary>
        ///A test for Seccion Constructor
        ///</summary>
        [TestMethod()]
        public void Seccion_Constructor_Test2()
        {
            // Arrange
            Seccion target1 = this._Item;
            Seccion target = new Seccion();
            // Act
            target.Bloque = target1.Bloque;

            // Assert
            Assert.AreEqual(3, target.Bloque.Count);
            Assert.AreEqual("Prueba", target.Bloque[0].Nombre);
            Assert.AreEqual("Prueba2", target.Bloque[1].Nombre);
            Assert.AreEqual("Prueba3", target.Bloque[2].Nombre);
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void Seccion_Dispose_Test()
        {
            Seccion target = this._Item;
            target.Dispose();

            Assert.AreEqual(null, target.Bloque);
        }
        #endregion

        #region Clone
        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void Seccion_Clone_Test()
        {
            // Arrange
            Seccion target1 = this._Item;
            Seccion target2 = target1.Clone();

            Assert.AreEqual(target1, target2);
        }
        #endregion

        #region Comparaciones
        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Seccion_Equals_Test()
        {
            Seccion target1 = this._Item;
            Seccion target2 = target1.Clone();

            bool expected1 = target1.Equals(target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Seccion_EqualsNot_Test()
        {
            Seccion target1 = this._Item;
            Seccion target3 = target1.Clone();
            target3.Bloque[0].Nombre = "Nop";

            bool expected2 = target1.Equals(target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Seccion_EqualsObject_Test1()
        {
            Seccion target1 = this._Item;
            Seccion target2 = target1.Clone();

            bool expected1 = target1.Equals((object)target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Seccion_EqualsObjectNot_Test1()
        {
            Seccion target1 = this._Item;
            Seccion target3 = target1.Clone();
            target3.Bloque[0].Nombre = "Nop";

            bool expected2 = target1.Equals((object)target3);

            Assert.IsFalse(expected2);
        }
        
        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod()]
        public void Seccion_OpEquality_Test()
        {
            Seccion target1 = this._Item;
            Seccion target2 = target1.Clone();

            bool expected1 = (target1 == target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Seccion_OpEqualityNot_Test()
        {
            Seccion target1 = this._Item;
            Seccion target3 = target1.Clone();
            target3.Bloque[0].Nombre = "Nop";

            bool expected2 = (target1 == target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod()]
        public void Seccion_OpInequality_Test()
        {
            Seccion target1 = this._Item;
            Seccion target2 = target1.Clone();

            bool expected1 = (target1 != target2);

            Assert.IsFalse(expected1);
        }
        [TestMethod()]
        public void Seccion_OpInequalityNot_Test()
        {
            Seccion target1 = this._Item;
            Seccion target3 = target1.Clone();
            target3.Bloque[0].Nombre = "Nop";

            bool expected2 = (target1 != target3);

            Assert.IsTrue(expected2);
        }
        #endregion

        #region Seteos
        /// <summary>
        ///A test for Bloque
        ///</summary>
        [TestMethod()]
        public void Seccion_SetBloque_Test()
        {
            Seccion target1 = this._Item;
            Seccion target = new Seccion();
            
            List<Bloque> expected = target1.Bloque;
            List<Bloque> actual;
            target.Bloque = expected;
            actual = target.Bloque;
            
            Assert.AreEqual(expected, actual);
        }
        #endregion

        public static Seccion Inicializar()
        {
            Bloque lBloque = TestsSGBDTest.BloqueTest.Inicializar();
            Seccion lSeccion = new Seccion();

            lSeccion.Bloque.Add(lBloque);
            Bloque lBloqueClone = lBloque.Clone();
            lBloqueClone.Nombre = "Prueba2";
            lSeccion.Bloque.Add(lBloqueClone);
            lBloqueClone = lBloque.Clone();
            lBloqueClone.Nombre = "Prueba3";
            lSeccion.Bloque.Add(lBloqueClone);

            return lSeccion;
        }
    }
}
