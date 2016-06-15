using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsSGBD.Clases;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for TestsTest and is intended
    ///to contain all TestsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TestTest
    {
        private Test _Item;
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
            this._Item = TestTest.Inicializar();
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
        public void Test_Constructor_Test()
        {
            // Arrange
            Test target = new Test(this._Item.Clone());
            // Act

            // Assert
            Assert.AreEqual("Prueba", target.Nombre);
            Assert.AreEqual(true, target.Creacion.MantenerEsquema);
            Assert.AreEqual(3, target.Creacion.Bloque.Count);
            Assert.AreEqual(3, target.Insercion.Bloque.Count);
            Assert.AreEqual(3, target.Consulta.Bloque.Count);
            Assert.AreEqual(3, target.Borrado.Bloque.Count);
        }

        /// <summary>
        ///A test for Tests Constructor
        ///</summary>
        [TestMethod()]
        public void Test_Constructor_Test1()
        {
            // Arrange
            Test target = new Test();
            // Act
            target.Nombre = this._Item.Nombre;
            target.Creacion = this._Item.Creacion;
            target.Insercion = this._Item.Insercion;
            target.Consulta = this._Item.Consulta;
            target.Borrado = this._Item.Borrado;

            // Assert
            Assert.AreEqual("Prueba", target.Nombre);
            Assert.AreEqual(true, target.Creacion.MantenerEsquema);
            Assert.AreEqual(3, target.Creacion.Bloque.Count);
            Assert.AreEqual(3, target.Insercion.Bloque.Count);
            Assert.AreEqual(3, target.Consulta.Bloque.Count);
            Assert.AreEqual(3, target.Borrado.Bloque.Count);
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void Test_Dispose_Test()
        {
            Test target = this._Item.Clone();
            target.Dispose();

            Assert.IsNull(target.Creacion);
            Assert.IsNull(target.Insercion);
            Assert.IsNull(target.Consulta);
            Assert.IsNull(target.Borrado);
        }
        #endregion

        #region Clone
        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void Test_Clone_Test()
        {
            // Arrange
            Test target2 = this._Item.Clone();

            Assert.AreEqual(this._Item, target2);
        }
        #endregion

        #region Comparaciones
        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Test_Equals_Test()
        {
            Test target2 = this._Item.Clone();

            bool expected1 = this._Item.Equals(target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Test_EqualsNot_Test()
        {
            Test target3 = this._Item.Clone();
            target3.Nombre = "Nop";

            bool expected2 = this._Item.Equals(target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Test_EqualsObject_Test()
        {
            Test target2 = this._Item.Clone();

            bool expected1 = this._Item.Equals((object)target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Test_EqualsObjectNot_Test()
        {
            Test target3 = this._Item.Clone();
            target3.Nombre = "Nop";

            bool expected2 = this._Item.Equals((object)target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod()]
        public void Test_OpEquality_Test()
        {
            Test target2 = this._Item.Clone();

            bool expected1 = (this._Item == target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Test_OpEqualityNot_Test()
        {
            Test target3 = this._Item.Clone();
            target3.Nombre = "Nop";

            bool expected2 = (this._Item == target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod()]
        public void Test_OpInequality_Test()
        {
            Test target2 = this._Item.Clone();

            bool expected1 = (this._Item != target2);

            Assert.IsFalse(expected1);
        }
        [TestMethod()]
        public void Test_OpInequalityNot_Test()
        {
            Test target3 = this._Item.Clone();
            target3.Nombre = "Nop";

            bool expected2 = (this._Item != target3);

            Assert.IsTrue(expected2);
        }
        #endregion

        #region Seteos
        /// <summary>
        ///A test for Test
        ///</summary>
        [TestMethod()]
        public void Test_SetNombre_Test()
        {
            Test target = new Test(); // TODO: Initialize to an appropriate value
            string expected = "Prueba";
            string actual;

            target.Nombre = expected;
            actual = target.Nombre;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        public static Test Inicializar()
        {
            Test lTest = new Test();
            lTest.Nombre = "Prueba";

            SeccionCreacion lSeccionCreacion = SeccionCreacionTest.Inicializar();
            Seccion lSeccion = SeccionTest.Inicializar();
            lTest.Creacion = lSeccionCreacion;
            lTest.Insercion = lSeccion;
            lTest.Consulta = lSeccion.Clone();
            lTest.Borrado = lSeccion.Clone();

            return lTest;
        }
    }
}
