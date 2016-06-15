using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsSGBD.Clases;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for SeccionCreacionTest and is intended
    ///to contain all SeccionCreacionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SeccionCreacionTest
    {
        private SeccionCreacion _Item;
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
            this._Item = SeccionCreacionTest.Inicializar();
        }

        [TestCleanup()]
        public void Fnalize()
        {
            this._Item.Dispose();
            this._Item = null;
        }

        #region Constructores
        /// <summary>
        ///A test for SeccionCreacion Constructor
        ///</summary>
        [TestMethod()]
        public void SeccionCreacion_Constructor_Test()
        {
            // Arrange
            SeccionCreacion target = new SeccionCreacion(this._Item.MantenerEsquema, this._Item.Bloque);
            // Act

            // Assert
            Assert.AreEqual(true, target.MantenerEsquema);
            Assert.AreEqual(3, target.Bloque.Count);
            Assert.AreEqual("Prueba", target.Bloque[0].Nombre);
            Assert.AreEqual("Prueba2", target.Bloque[1].Nombre);
            Assert.AreEqual("Prueba3", target.Bloque[2].Nombre);
        }

        /// <summary>
        ///A test for SeccionCreacion Constructor
        ///</summary>
        [TestMethod()]
        public void SeccionCreacion_Constructor_Test1()
        {
            // Arrange
            SeccionCreacion target = new SeccionCreacion(this._Item);
            // Act

            // Assert
            Assert.AreEqual(true, target.MantenerEsquema);
            Assert.AreEqual(3, target.Bloque.Count);
            Assert.AreEqual("Prueba", target.Bloque[0].Nombre);
            Assert.AreEqual("Prueba2", target.Bloque[1].Nombre);
            Assert.AreEqual("Prueba3", target.Bloque[2].Nombre);
        }

        /// <summary>
        ///A test for SeccionCreacion Constructor
        ///</summary>
        [TestMethod()]
        public void SeccionCreacion_Constructor_Test2()
        {
            // Arrange
            SeccionCreacion target = new SeccionCreacion();
            // Act
            target.MantenerEsquema = this._Item.MantenerEsquema;
            target.Bloque = this._Item.Bloque;

            // Assert
            Assert.AreEqual(true, target.MantenerEsquema);
            Assert.AreEqual(3, target.Bloque.Count);
            Assert.AreEqual("Prueba", target.Bloque[0].Nombre);
            Assert.AreEqual("Prueba2", target.Bloque[1].Nombre);
            Assert.AreEqual("Prueba3", target.Bloque[2].Nombre);
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void SeccionCreacion_Dispose_Test()
        {
            SeccionCreacion target = this._Item;
            target.Dispose();

            Assert.AreEqual(null, target.Bloque);
        }
        #endregion

        #region Clone
        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void SeccionCreacion_Clone_Test()
        {
            // Arrange
            SeccionCreacion target = this._Item.Clone();

            Assert.AreEqual(this._Item, target);
        }
        #endregion

        #region Comparaciones
        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void SeccionCreacion_Equals_Test()
        {
            SeccionCreacion target2 = this._Item.Clone();

            bool expected1 = this._Item.Equals(target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void SeccionCreacion_EqualsNot_Test()
        {
            SeccionCreacion target3 = this._Item.Clone();
            target3.Bloque[0].Nombre = "Nop";

            bool expected2 = this._Item.Equals(target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void SeccionCreacion_EqualsObject_Test()
        {
            SeccionCreacion target2 = this._Item.Clone();

            bool expected1 = this._Item.Equals((object)target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void SeccionCreacion_EqualsObjectNot_Test()
        {
            SeccionCreacion target3 = this._Item.Clone();
            target3.Bloque[0].Nombre = "Nop";

            bool expected2 = this._Item.Equals((object)target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod()]
        public void SeccionCreacion_OpEquality_Test()
        {
            SeccionCreacion target2 = this._Item.Clone();

            bool expected1 = (this._Item == target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void SeccionCreacion_OpEqualityNot_Test()
        {
            SeccionCreacion target3 = this._Item.Clone();
            target3.Bloque[0].Nombre = "Nop";

            bool expected2 = (this._Item == target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod()]
        public void SeccionCreacion_OpInequality_Test()
        {
            SeccionCreacion target2 = this._Item.Clone();

            bool expected1 = (this._Item != target2);

            Assert.IsFalse(expected1);
        }
        [TestMethod()]
        public void SeccionCreacion_OpInequalityNot_Test()
        {
            SeccionCreacion target3 = this._Item.Clone();
            target3.Bloque[0].Nombre = "Nop";

            bool expected2 = (this._Item != target3);

            Assert.IsTrue(expected2);
        }
        #endregion

        #region Seteos
        /// <summary>
        ///A test for MantenerEsquema
        ///</summary>
        [TestMethod()]
        public void SeccionCreacion_SetMantenerEsquema_Test()
        {
            SeccionCreacion target = new SeccionCreacion();
            bool expected = true;
            bool actual;

            target.MantenerEsquema = expected;
            actual = target.MantenerEsquema;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        public static SeccionCreacion Inicializar()
        {
            Bloque lBloque = TestsSGBDTest.BloqueTest.Inicializar();
            SeccionCreacion lSeccion = new SeccionCreacion();

            lSeccion.MantenerEsquema = true;
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
