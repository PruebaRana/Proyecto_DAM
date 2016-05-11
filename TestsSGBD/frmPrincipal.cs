﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TestsSGBD.Clases;
using TestsSGBD.MisCS;

namespace TestsSGBD
{
    public partial class frmPrincipal : Form
    {
        #region Propiedades
        private FormWindowState _CurrentState;
        private string _Seccion;

        private Conectores _Conectores;
        private Tests _Tests;
        #endregion

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            activarSeccion("btnConfiguracion");
            sysTrayIcon.Visible = false;
            this._CurrentState = this.WindowState;

            //lvConectores_Resize(sender, e);
            //lvTests_Resize(sender, e);

            // Crear las carpetas si no existen
            if (!Directory.Exists(Config.RutaConfiguraciones))
            {
                Utiles.CheckFolder(Config.RutaConfiguraciones);
            }
            
            // Pruebas
            Conectores lConectores = new Conectores(Config.RutaConfiguraciones + @"\Conectores.xml");
            lConectores.LoadXML();

            Test lTest = new Test();
            lTest.RutaXML = Config.RutaConfiguraciones + @"\Primer test.XML";
            lTest.LoadXML(lTest.RutaXML);

            EjecutarTest lEjecutarTest = new EjecutarTest(lConectores.Conector, lTest);
            lEjecutarTest.Ejecutar();

        }

        #region Metodos para el control de la ventana
        private void sysTrayIcon_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            sysTrayIcon.Visible = false;

            // Retorno el estado al Form antes de minimizarlo
            this.WindowState = this._CurrentState;
        }
        private void frmPrincipal_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                sysTrayIcon.Visible = true;     //Visualizo el icono al lado de la hora
            }
            else
            {
                this._CurrentState = this.WindowState;
            }
        }
        #endregion

        #region Metodos para los botones laterales
        private void btnSeccion_MouseLeave(object sender, EventArgs e)
        {
            btnConfiguracion.BackColor = Color.FromArgb(64, 64, 64);
            btnConfiguracion.ForeColor = Color.Silver;
            btnTests.BackColor = Color.FromArgb(64, 64, 64);
            btnTests.ForeColor = Color.Silver;
            btnInformes.BackColor = Color.FromArgb(64, 64, 64);
            btnInformes.ForeColor = Color.Silver;

            Button lB = (Button)this.Controls.Find(this._Seccion, true)[0];
            if (lB != null)
            {
                lB.BackColor = Color.FromArgb(64, 64, 64);
                lB.ForeColor = Color.FromArgb(255, 153, 0);
            }
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(255, 153, 0);
            ((Button)sender).ForeColor = Color.White;
        }

        private void btnSeccion_Click(object sender, EventArgs e)
        {
            activarSeccion(((Button)sender).Name);
            //this._Seccion = this.Name;
            //btnSeccion_MouseLeave(sender, e);

            //activarPanel();
        }

        private void activarSeccion(string asSeccion)
        {
            switch (asSeccion)
            {
                case "btnConfiguracion":
                case "btnTests":
                case "btnInformes":
                    this._Seccion = asSeccion;
                    btnSeccion_MouseLeave(this, null);

                    activarPanel();
                    break;
            }
        }
        private void activarPanel()
        {
            pnlConfiguracion.Visible = false;
            pnlTests.Visible = false;
            pnlInformes.Visible = false;

            switch (this._Seccion)
            {
                case "btnConfiguracion":
                    pnlConfiguracion.Visible = true;
                    CargarConectoresOTest();
                    break;
                case "btnTests":
                    pnlTests.Visible = true;
                    break;
                case "btnInformes":
                    pnlInformes.Visible = true;
                    break;
            }
        }

        private void tabConfiguracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarConectoresOTest();
        }
        private void CargarConectoresOTest()
        {
            switch (tabConfiguracion.SelectedTab.Name)
            {
                case "tabConectores":
                    lvConectores_Resize(null, null);
                    CargarConectores();
                    break;
                case "tabTests":
                    lvTests_Resize(null, null);
                    CargarTests();
                    break;
            }
        }
        #endregion

        #region Configuracion Conectores
        private void lvConectores_Resize(object sender, EventArgs e)
        {
            if (lvConectores.Width.ToString() == lvConectores.Tag.ToString())
            {
                return;
            }

            int liAncho = lvConectores.Width - 5;
            if (liAncho >= 425)
            {
                lvConectores.Tag = lvConectores.Width;
                liAncho -= (lvConectores.Columns[0].Width + lvConectores.Columns[1].Width);
                lvConectores.Columns[2].Width = liAncho;
            }

        }

        private void CargarConectores()
        {
            lvConectores.Items.Clear();

            this._Conectores = new Conectores(Config.RutaConfiguraciones + @"\Conectores.xml");
            this._Conectores.LoadXML();

            foreach (Conector lItem in this._Conectores.Conector)
            {
                addConector(lItem.Nombre, lItem.Tipo, lItem.CadenaConexion);
            }
        }
        private void addConector(string asNombre, string asTipo, string asCadena)
        {
            ListViewItem llvItem = new ListViewItem(asNombre);
            llvItem.SubItems.Add(asTipo);
            llvItem.SubItems.Add(asCadena);
            lvConectores.Items.Add(llvItem);
        }
        
        private void btnAddConector_Click(object sender, EventArgs e)
        {
            frmConfigurarConector lForm = new frmConfigurarConector();
            lForm.CargarConector(null);
            // Lo abro como dialogo, para que mantenga el foco
            lForm.ShowDialog();
            // Al volver,
            if (lForm.Changed())
            {
                Conector lItem = lForm.ObtenItem();
                
                // Añadir el conector a la lista
                this._Conectores.Conector.Add(lItem.Clone());
                this._Conectores.SaveXML();

                // recargar la lista
                CargarConectores();
            }
        }

        private void btnUpdConector_Click(object sender, EventArgs e)
        {
            if (lvConectores.SelectedItems.Count > 0)
            {
                //int liIndex = lvConectores.SelectedItems[0].Index;
                // Obtener el nombre 
                string lsNombre = lvConectores.SelectedItems[0].Text;

                //Obtene la tarea en cuestion de la lista
                Conector lConector = obtenConector(lsNombre);
                int liIndex = obtenIndexConector(lsNombre);

                frmConfigurarConector lForm = new frmConfigurarConector();
                lForm.CargarConector(lConector);

                lForm.ShowDialog();
                // Al volver,
                if (lForm.Changed())
                {
                    Conector lItem = lForm.ObtenItem();

                    // Actualizamos la tarea 
                    this._Conectores.Conector[liIndex] = null;
                    this._Conectores.Conector[liIndex] = lItem.Clone();
                    this._Conectores.SaveXML();

                    lItem = null;

                    // recargar la lista
                    CargarConectores();
                }
            }
        }

        private void btnDelConector_Click(object sender, EventArgs e)
        {
            if (lvConectores.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Esta seguro de eliminar el conector ?", "Conector", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                string lsNombre = lvConectores.SelectedItems[0].Text;

                // Eliminarla de la lista
                this._Conectores.Conector.Remove(obtenConector(lsNombre));
                this._Conectores.SaveXML();

                // recargar la lista
                CargarConectores();
            }
        }

        private Conector obtenConector(string asNombre)
        {
            Conector lRes = null;
            foreach (Conector lItem in this._Conectores.Conector)
            {
                if (lItem.Nombre == asNombre)
                {
                    lRes = lItem;
                    break;
                }
            }
            return lRes;
        }
        private int obtenIndexConector(string asNombre)
        {
            int lRes = 0;
            foreach (Conector lItem in this._Conectores.Conector)
            {
                if (lItem.Nombre == asNombre)
                {
                    break;
                }
                lRes++;
            }
            return lRes;
        }

        private void lvConectores_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdConector.Enabled = false;
            btnDelConector.Enabled = false;

            if (lvConectores.SelectedItems.Count > 0)
            {
                btnUpdConector.Enabled = true;
                btnDelConector.Enabled = true;
            }
        }
        #endregion

        #region Configuracion Tests
        private void lvTests_Resize(object sender, EventArgs e)
        {
            if (lvTests.Width.ToString() == lvTests.Tag.ToString())
            {
                return;
            }

            int liAncho = lvTests.Width - 5;
            if (liAncho >= 425)
            {
                lvTests.Tag = lvTests.Width;
                liAncho -= (lvTests.Columns[0].Width);
                lvTests.Columns[1].Width = liAncho;
            }
        }

        private void CargarTests()
        {
            lvTests.Items.Clear();

            this._Tests = new Tests(Config.RutaConfiguraciones + @"\Tests.xml");
            this._Tests.LoadXML();

            foreach (TestInfo lItem in this._Tests.TestInfo)
            {
                addTest(lItem.Nombre, lItem.File);
            }
        }
        private void addTest(string asNombre, string asFile)
        {
            ListViewItem llvItem = new ListViewItem(asNombre);
            llvItem.SubItems.Add(asFile);
            lvTests.Items.Add(llvItem);
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            frmConfigurarTest lForm = new frmConfigurarTest();
            lForm.CargarItem(null);
            // Lo abro como dialogo, para que mantenga el foco
            lForm.ShowDialog();
            // Al volver,
            if (lForm.Changed())
            {
                Test lItem = lForm.ObtenItem();
                // Guardo el XML del Text
                lItem.SaveXML();

                // Añado el TestInfo a mi lista
                TestInfo lItemInfo = new TestInfo(lItem.Nombre, lItem.RutaXML);
                this._Tests.TestInfo.Add(lItemInfo);
                this._Tests.SaveXML();
                lItemInfo = null;
                lItem = null;

                // Recargar el listado de tests
                CargarTests();
            }
        }

        private void btnUpdTest_Click(object sender, EventArgs e)
        {
            if (lvTests.SelectedItems.Count > 0)
            {
                //int liIndex = lvTests.SelectedItems[0].Index;
                // Obtener el nombre 
                string lsNombre = lvTests.SelectedItems[0].Text;

                //Obtene la tarea en cuestion de la lista
                Test lTest = obtenTest(lsNombre);
                int liIndex = obtenIndexTestInfo(lsNombre);
                string lsRutaXML = lTest.RutaXML;

                frmConfigurarTest lForm = new frmConfigurarTest();
                lForm.CargarItem(lTest);

                lForm.ShowDialog();
                // Al volver,
                if (lForm.Changed())
                {
                    Test lItem = lForm.ObtenItem();
                    // Guardo el XML del Text
                    lItem.SaveXML();
                    if (lItem.RutaXML != lsRutaXML)
                    {
                        Utiles.DeleteFile(lsRutaXML);
                    }

                    // Añado el TestInfo a mi lista
                    TestInfo lItemInfo = new TestInfo(lItem.Nombre, lItem.RutaXML);
                    this._Tests.TestInfo[liIndex] = null;
                    this._Tests.TestInfo[liIndex] = lItemInfo;
                    this._Tests.SaveXML();
                    lItemInfo = null;
                    lItem = null;

                    // Recargar el listado de tests
                    CargarTests();
                }
            }
        }

        private void btnDelTest_Click(object sender, EventArgs e)
        {
            if (lvTests.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Esta seguro de eliminar el Test ?", "Test", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                string lsNombre = lvTests.SelectedItems[0].Text;

                // Eliminarla de la lista y el fichero xml del Test
                TestInfo lTestInfo = obtenTestInfo(lsNombre);
                Utiles.DeleteFile(lTestInfo.File);

                this._Tests.TestInfo.Remove(lTestInfo);
                this._Tests.SaveXML();

                // Recargar el listado de tests
                CargarTests();

            }
        }

        private Test obtenTest(string asNombre)
        {
            TestInfo lItemTest = obtenTestInfo(asNombre);
            Test lRes = new Test();
            
            lRes.LoadXML(lItemTest.File);
            
            return lRes;
        }
        private TestInfo obtenTestInfo(string asNombre)
        {
            TestInfo lRes = null;
            foreach (TestInfo lItem in this._Tests.TestInfo)
            {
                if (lItem.Nombre == asNombre)
                {
                    lRes = lItem;
                    break;
                }
            }
            return lRes;
        }
        private int obtenIndexTestInfo(string asNombre)
        {
            int lRes = 0;
            foreach (TestInfo lItem in this._Tests.TestInfo)
            {
                if (lItem.Nombre == asNombre)
                {
                    break;
                }
                lRes++;
            }
            return lRes;
        }

        private void lvTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdTest.Enabled = false;
            btnDelTest.Enabled = false;

            if (lvTests.SelectedItems.Count > 0)
            {
                btnUpdTest.Enabled = true;
                btnDelTest.Enabled = true;
            }
        }
        #endregion

    }
}