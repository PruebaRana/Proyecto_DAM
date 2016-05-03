using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsSGBD.Clases;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for DatosBaseTest and is intended
    ///to contain all DatosBaseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DatosBaseTest
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
        
        [TestMethod()]
        public void DatosBase_ObtenStringNormal_Test()
        {
            // Arrange
            string expected = "Es una Prueba!!";
            string actual;

            // Act
            actual = DatosBase.ObtenString(expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DatosBase_ObtenStringWithQuotes_Test()
        {
            // Arrange
            string expected = "l'Alcudia l''Alcudia";
            string actual;

            // Act
            actual = DatosBase.ObtenString("l''Alcudia l''''Alcudia");

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DatosBase_ObtenStringNot_Test()
        {
            // Arrange
            string expected = "Una cosa";
            string actual;

            // Act
            actual = DatosBase.ObtenString("Otra cosa");

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void DatosBase_ObtenFecha_Test()
        {
            // Arrange
            DateTime expected = DateTime.Now;
            string lsFormato = "yyyy/MM/dd H:mm:ss";
            string lsFecha = expected.ToString(lsFormato);
            DateTime actual;

            // Act
            actual = DatosBase.ObtenFecha(lsFecha, lsFormato);

            // Assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod()]
        public void DatosBase_ObtenFechaNot_Test()
        {
            // Arrange
            DateTime expected = DateTime.Now;
            string lsFormato = "yyyy/MM/dd H:mm:ss";
            string lsFecha = expected.AddHours(2).ToString(lsFormato);
            DateTime actual;

            // Act
            actual = DatosBase.ObtenFecha(lsFecha, lsFormato);

            // Assert
            Assert.AreNotEqual(expected, actual);
        }
        
        [TestMethod()]
        public void DatosBase_ObtenNumero_Test()
        {
            // Arrange
            int expected = 69;
            int actual;

            // Act
            actual = DatosBase.ObtenNumero("69");

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DatosBase_ObtenNumeroNot_Test()
        {
            // Arrange
            int expected = 69;
            int actual;

            // Act
            actual = DatosBase.ObtenNumero("68");

            // Assert
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod()]
        public void DatosBase_ObtenNumeroNotNumber_Test()
        {
            // Arrange
            int expected = 0;
            int actual;

            // Act
            actual = DatosBase.ObtenNumero("Esto");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DatosBase_ObtenNumeroDecimal_Test()
        {
            // Arrange
            float expected = 69.3f;
            float actual;

            // Act
            actual = DatosBase.ObtenNumeroDecimal("69.3");

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DatosBase_ObtenNumeroDecimalNot_Test()
        {
            // Arrange
            float expected = 69.3f;
            float actual;

            // Act
            actual = DatosBase.ObtenNumeroDecimal("68");

            // Assert
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod()]
        public void DatosBase_ObtenNumeroDecimalNotNumber_Test()
        {
            // Arrange
            float expected = 0f;
            float actual;

            // Act
            actual = DatosBase.ObtenNumero("Esto");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DatosBase_ObtenSiNoWithSi_Test()
        {
            // Arrange
            bool expected = true;
            bool actual;

            // Act
            actual = DatosBase.ObtenSiNo("Si");

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DatosBase_ObtenSiNoWith1_Test()
        {
            // Arrange
            bool expected = true;
            bool actual;

            // Act
            actual = DatosBase.ObtenSiNo("1");

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DatosBase_ObtenSiNoWithTrue_Test()
        {
            // Arrange
            bool expected = true;
            bool actual;

            // Act
            actual = DatosBase.ObtenSiNo("True");

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DatosBase_ObtenSiNoWithVerdadero_Test()
        {
            // Arrange
            bool expected = true;
            bool actual;

            // Act
            actual = DatosBase.ObtenSiNo("Verdadero");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
