using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsSGBD.Clases;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for SeccionTest and is intended
    ///to contain all SeccionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConectorTest
    {
        private Conector _Item;
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
            this._Item = ConectorTest.Inicializar();
        }

        [TestCleanup()]
        public void Fnalize()
        {
            this._Item = null;
        }

        #region Constructores
        /// <summary>
        ///A test for Seccion Constructor
        ///</summary>
        [TestMethod()]
        public void Conector_Constructor_Test()
        {
            // Arrange
            Conector target = this._Item.Clone();
            // Act
            string lsNombre = target.Nombre;
            string lsTipo = target.Tipo;
            string lsCadena = target.CadenaConexion;
            // Assert
            Assert.AreEqual("Prueba", lsNombre);
            Assert.AreEqual("MySQL", lsTipo);
            Assert.AreEqual("Cadena", lsCadena);
        }

        /// <summary>
        ///A test for Seccion Constructor
        ///</summary>
        [TestMethod()]
        public void Conector_Constructor_Test1()
        {
            // Arrange
            Conector target = new Conector(this._Item.Clone());
            // Act
            string lsNombre = target.Nombre;
            string lsTipo = target.Tipo;
            string lsCadena = target.CadenaConexion;
            // Assert
            Assert.AreEqual("Prueba", lsNombre);
            Assert.AreEqual("MySQL", lsTipo);
            Assert.AreEqual("Cadena", lsCadena);
        }

        /// <summary>
        ///A test for Seccion Constructor
        ///</summary>
        [TestMethod()]
        public void Conector_Constructor_Test2()
        {
            Conector target = new Conector();
            // Act
            target.Nombre = this._Item.Nombre;
            target.Tipo = this._Item.Tipo;
            target.CadenaConexion = this._Item.CadenaConexion;

            string lsNombre = target.Nombre;
            string lsTipo = target.Tipo;
            string lsCadena = target.CadenaConexion;
            // Assert
            Assert.AreEqual("Prueba", lsNombre);
            Assert.AreEqual("MySQL", lsTipo);
            Assert.AreEqual("Cadena", lsCadena);
        }
        #endregion

        #region Clone
        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void Conector_Clone_Test()
        {
            Conector target = this._Item.Clone();

            Assert.AreEqual(this._Item, target);
        }
        #endregion

        #region Comparaciones
        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Conector_Equals_Test()
        {
            Conector target2 = this._Item.Clone();

            bool expected1 = this._Item.Equals(target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Conector_EqualsNot_Test()
        {
            Conector target3 = new Conector("Nop", "MySQL", "Prueba");

            bool expected2 = this._Item.Equals(target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Conector_EqualsObject_Test()
        {
            Conector target2 = this._Item.Clone();

            bool expected1 = this._Item.Equals(((object)target2));

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Conector_EqualsObjectNot_Test()
        {
            Conector target3 = new Conector("Prueba3", "MySQL", "Prueba");

            bool expected2 = this._Item.Equals(((object)target3));

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod()]
        public void Conector_OpEquality_Test()
        {
            Conector target2 = this._Item.Clone();

            bool expected1 = this._Item == target2;

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Conector_OpEqualityNot_Test()
        {
            Conector target3 = new Conector("Prueba3", "MySQL", "Prueba");

            bool expected2 = this._Item == target3;

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod()]
        public void Conector_OpInequality_Test()
        {
            Conector target2 = this._Item.Clone();

            bool expected1 = this._Item != target2;

            Assert.IsFalse(expected1);
        }
        [TestMethod()]
        public void Conector_OpInequalityNot_Test()
        {
            Conector target3 = new Conector("Prueba3", "MySQL", "Prueba");

            bool expected2 = this._Item != target3;

            Assert.IsTrue(expected2);
        }
        #endregion

        #region Seteos
        [TestMethod()]
        public void Conector_SetNombre_Test()
        {
            Conector target = new Conector();

            string expected = this._Item.Nombre;
            string actual;
            target.Nombre = expected;
            actual = target.Nombre;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Conector_SetTipo_Test()
        {
            Conector target = new Conector();

            string expected = this._Item.Tipo;
            string actual;
            target.Tipo = expected;
            actual = target.Tipo;

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void Conector_SetCadenaConexion_Test()
        {
            Conector target = new Conector();

            string expected = this._Item.CadenaConexion;
            string actual;
            target.CadenaConexion = expected;
            actual = target.CadenaConexion;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        public static Conector Inicializar()
        {
            return new Conector("Prueba", "MySQL", "Cadena");
        }
    }
}
