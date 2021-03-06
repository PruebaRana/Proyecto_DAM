﻿using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsSGBD.Clases;

namespace TestsSGBDTest
{
    /// <summary>
    ///This is a test class for DatosODBCTest and is intended
    ///to contain all DatosODBCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DatosODBCTest
    {
        private DatosODBC _Item;
        private string _Cadena;
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
            this._Cadena = "Driver={MySQL ODBC 5.3 Unicode Driver};Server=localhost;Port=3305;Database=pymsolutions-4325255;User=pymsolutions4325;Password=pym4325255;";
            this._Item = DatosODBCTest.Inicializar();
        }

        [TestCleanup()]
        public void Fnalize()
        {
            this._Item = null;
        }

        #region Constructores
        /// <summary>
        ///A test for DatosODBC Constructor
        ///</summary>
        [TestMethod()]
        public void DatosODBC_Constructor_Test()
        {
            DatosODBC target = this._Item;

            Assert.IsNull(target._conexion);
        }
        #endregion

        /// <summary>
        ///A test for Open
        ///</summary>
        [TestMethod()]
        public void DatosODBC_Open_Test()
        {
            DatosODBC target = this._Item;
            IDbConnection actual;

            actual = target.Open(this._Cadena);
            string lsDataBase = actual.Database;
            string lsEstatusOpen = actual.State.ToString();
            target.Close();
            string lsEstatusClose = actual.State.ToString();

            Assert.AreEqual("pymsolutions-4325255", lsDataBase);
            Assert.AreEqual("Open", lsEstatusOpen);
            Assert.AreEqual("Closed", lsEstatusClose);
        }

        /// <summary>
        ///A test for EjecutarCount
        ///</summary>
        [TestMethod()]
        public void DatosODBC_EjecutarCount_Test()
        {
            DatosODBC target = this._Item;
            IDbConnection actual = target.Open(this._Cadena);

            int liTotal = target.EjecutarCount("SELECT count(1) FROM votaciones");
            target.Close();

            Assert.AreEqual(5, liTotal);
        }

        /// <summary>
        ///A test for EjecutarEscalar
        ///</summary>
        [TestMethod()]
        public void DatosODBC_EjecutarEscalar_Test()
        {
            DatosODBC target = this._Item;
            IDbConnection actual = target.Open(this._Cadena);

            int liTotal = target.EjecutarEscalar("SELECT count(1) FROM votaciones");
            target.Close();

            Assert.AreEqual(5, liTotal);
        }

        /// <summary>
        ///A test for EjecutarNonQuery
        ///</summary>
        [TestMethod()]
        public void DatosODBC_EjecutarNonQuery_Test()
        {
            DatosODBC target = this._Item;
            IDbConnection actual = target.Open(this._Cadena);

            int liId = target.EjecutarNonQueryYObtenerLastId("INSERT INTO Votaciones ( URL) VALUES ('Prueba')");
            bool lsw = target.EjecutarNonQuery("DELETE FROM Votaciones WHERE ID =" + liId);
            target.Close();

            Assert.AreEqual(true, lsw);
        }

        /// <summary>
        ///A test for EjecutarNonQueryYObtenerLastId
        ///</summary>
        [TestMethod()]
        public void DatosODBC_EjecutarNonQueryYObtenerLastId_Test()
        {
            DatosODBC target = this._Item;
            IDbConnection actual = target.Open(this._Cadena);

            //int liId = target.EjecutarNonQueryYObtenerLastId("INSERT INTO Votaciones (Id, URL) VALUES (6, 'Prueba')");
            int liId = target.EjecutarNonQueryYObtenerLastId("INSERT INTO Votaciones ( URL) VALUES ('Prueba')");
            bool lsw = target.EjecutarNonQuery("DELETE FROM Votaciones WHERE ID =" + liId);
            target.Close();

            Assert.IsTrue(liId > 0);
            Assert.AreEqual(true, lsw);
        }

        public static DatosODBC Inicializar()
        {
            return new DatosODBC();
        }
    }
}
