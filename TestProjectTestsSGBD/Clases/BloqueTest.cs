using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsSGBD.Clases;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for BloqueTest and is intended
    ///to contain all BloqueTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BloqueTest
    {
        private Bloque _Item;
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
            this._Item = BloqueTest.Inicializar();
        }

        [TestCleanup()]
        public void Fnalize()
        {
            this._Item = null;
        }

        /// <summary>
        ///A test for Bloque Constructor
        ///</summary>
        [TestMethod()]
        public void Bloque_Constructor_Test()
        {
            // Arrange
            Bloque target = new Bloque(this._Item.Nombre, this._Item.Sentencias, this._Item.Hilos_Inicio, this._Item.Hilos_Fin, this._Item.Hilos_Step, Bloque.TipoConexion.HILO);
            // Act

            // Assert
            Assert.AreEqual("Prueba", target.Nombre);
            Assert.AreEqual(1, target.Hilos_Inicio);
            Assert.AreEqual(6, target.Hilos_Fin);
            Assert.AreEqual(2, target.Hilos_Step);
            Assert.AreEqual(Bloque.TipoConexion.HILO, target.Conexion);
            Assert.AreEqual(3, target.Sentencias.Count);
            Assert.AreEqual("Select1", target.Sentencias[0].SQL);
        }

        /// <summary>
        ///A test for Bloque Constructor
        ///</summary>
        [TestMethod()]
        public void Bloque_Constructor_Test1()
        {
            // Arrange
            Bloque target = new Bloque(this._Item);
            // Act

            // Assert
            Assert.AreEqual("Prueba", target.Nombre);
            Assert.AreEqual(1, target.Hilos_Inicio);
            Assert.AreEqual(6, target.Hilos_Fin);
            Assert.AreEqual(2, target.Hilos_Step);
            Assert.AreEqual(3, target.Sentencias.Count);
            Assert.AreEqual("Select1", target.Sentencias[0].SQL);
        }

        /// <summary>
        ///A test for Bloque Constructor
        ///</summary>
        [TestMethod()]
        public void Bloque_Constructor_Test2()
        {
            // Arrange
            Bloque target = new Bloque();
            // Act
            target.Nombre = this._Item.Nombre;
            target.Sentencias = this._Item.Sentencias;
            target.Hilos_Inicio = this._Item.Hilos_Inicio;
            target.Hilos_Fin = this._Item.Hilos_Fin;
            target.Hilos_Step = this._Item.Hilos_Step;

            // Assert
            Assert.AreEqual("Prueba", target.Nombre);
            Assert.AreEqual(1, target.Hilos_Inicio);
            Assert.AreEqual(6, target.Hilos_Fin);
            Assert.AreEqual(2, target.Hilos_Step);
            Assert.AreEqual(3, target.Sentencias.Count);
            Assert.AreEqual("Select1", target.Sentencias[0].SQL);
        }

        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void Bloque_Clone_Test()
        {
            // Arrange
            Bloque target = this._Item.Clone();

            Assert.AreEqual(this._Item, target);
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void Bloque_Dispose_Test()
        {
            Bloque target = this._Item.Clone();
            target.Dispose();

            Assert.AreEqual(null, target.Sentencias);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Bloque_Equals_Test()
        {
            Bloque target = this._Item.Clone();

            bool expected = this._Item.Equals(target);

            Assert.IsTrue(expected);
        }
        [TestMethod()]
        public void Bloque_EqualsNot_Test()
        {
            Bloque target = this._Item.Clone();
            target.Nombre = "Nop";

            bool expected = this._Item.Equals(target);

            Assert.IsFalse(expected);
        }


        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void Bloque_EqualsObject_Test()
        {
            Bloque target2 = this._Item.Clone();

            bool expected1 = this._Item.Equals((object)target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Bloque_EqualsObjectNot_Test()
        {
            Bloque target3 = this._Item.Clone();
            target3.Nombre = "Nop";

            bool expected2 = this._Item.Equals((object)target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod()]
        public void Bloque_OpEquality_Test()
        {
            Bloque target2 = this._Item.Clone();

            bool expected1 = (this._Item == target2);

            Assert.IsTrue(expected1);
        }
        [TestMethod()]
        public void Bloque_OpEqualityNot_Test()
        {
            Bloque target3 = this._Item.Clone();
            target3.Nombre = "Nop";

            bool expected2 = (this._Item == target3);

            Assert.IsFalse(expected2);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod()]
        public void Bloque_OpInequality_Test()
        {
            Bloque target2 = this._Item.Clone();

            bool expected1 = (this._Item != target2);

            Assert.IsFalse(expected1);
        }
        [TestMethod()]
        public void Bloque_OpInequalityNot_Test()
        {
            Bloque target3 = this._Item.Clone();
            target3.Nombre = "Nop";

            bool expected2 = (this._Item != target3);

            Assert.IsTrue(expected2);
        }

        /// <summary>
        ///A test for Hilos_Fin
        ///</summary>
        [TestMethod()]
        public void Bloque_SetHilosFin_Test()
        {
            Bloque target = new Bloque();
            int expected = 5;
            int actual;

            target.Hilos_Fin = expected;
            actual = target.Hilos_Fin;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Hilos_Inicio
        ///</summary>
        [TestMethod()]
        public void Bloque_SetHilosInicio_Test()
        {
            Bloque target = new Bloque();
            int expected = 5;
            int actual;

            target.Hilos_Inicio = expected;
            actual = target.Hilos_Inicio;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Hilos_Step
        ///</summary>
        [TestMethod()]
        public void Bloque_SetHilosStep_Test()
        {
            Bloque target = new Bloque();
            int expected = 5;
            int actual;

            target.Hilos_Step = expected;
            actual = target.Hilos_Step;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Nombre
        ///</summary>
        [TestMethod()]
        public void Bloque_SetNombre_Test()
        {
            Bloque target = new Bloque();
            string expected = "Prueba";
            string actual;

            target.Nombre = expected;
            actual = target.Nombre;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Sentencias
        ///</summary>
        [TestMethod()]
        public void Bloque_SetSentencias_Test()
        {
            Bloque target = new Bloque();

            List<Sentencia> expected = this._Item.Sentencias;
            List<Sentencia> actual;
            target.Sentencias = expected;
            actual = target.Sentencias;
            
            Assert.AreEqual(expected, actual);
        }

        public static Bloque Inicializar()
        {
            List<Sentencia> lSentencias = new List<Sentencia>();
            Sentencia lSentencia = new Sentencia("Select1");
            lSentencias.Add(lSentencia);
            lSentencia = new Sentencia("Select2");
            lSentencias.Add(lSentencia);
            lSentencia = new Sentencia("Select3");
            lSentencias.Add(lSentencia);

            return new Bloque("Prueba", lSentencias, 1, 6, 2, Bloque.TipoConexion.HILO);
        }
    }
}
