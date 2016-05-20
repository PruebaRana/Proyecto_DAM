using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TestsSGBD.Clases;
using TestsSGBD.MisCS;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TestsSGBD
{
    public partial class frmPrincipal : Form
    {
        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className, string windowTitle);
//        [DllImport("user32.dll")]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        static extern bool GetWindowPlacement(IntPtr hWnd, ref Windowplacement lpwndpl);
        //private enum ShowWindowEnum
        //{
        //    Hide = 0,
        //    ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
        //    Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
        //    Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
        //    Restore = 9, ShowDefault = 10, ForceMinimized = 11
        //};
        //private struct Windowplacement
        //{
        //    public int length;
        //    public int flags;
        //    public int showCmd;
        //    public System.Drawing.Point ptMinPosition;
        //    public System.Drawing.Point ptMaxPosition;
        //    public System.Drawing.Rectangle rcNormalPosition;
        //}

        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNORMAL = 1;

        
        #region Propiedades
        // flag para indicar si esta aplicación ya cuenta con una instancia:
        Mutex _Mutex;

        private FormWindowState _CurrentState;
        private string _Seccion;

        private Conectores _Conectores;
        private Tests _Tests;

        EjecucionTest _EjecutarTest;
        private string _sUltimoMensaje = "";
        #endregion

        public frmPrincipal()
        {
            // flag para indicar si esta aplicación ya cuenta con una instancia:
            bool appEnEjecucion;

            // Mutex para tomar el control de la ejecución de esta
            // aplicación por una única instancia:
            _Mutex = new Mutex(true, "TestsSGBD", out appEnEjecucion);

            InitializeComponent();

            if (!appEnEjecucion)
            {
                // La aplicación se haya en ejecución, La traemos al frente y cerramos esta
                IntPtr wdwIntPtr = FindWindow(null, this.Text);
                if (!wdwIntPtr.Equals(IntPtr.Zero))
                {
                    SetForegroundWindow(wdwIntPtr);
                    ShowWindow(wdwIntPtr, SW_SHOWNORMAL);
                }
                this.Close();
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            activarSeccion("btnConfiguracion");
            sysTrayIcon.Visible = false;
            this._CurrentState = this.WindowState;

            // Crear las carpetas si no existen
            if (!Directory.Exists(Config.RutaConfiguraciones))
            {
                Utiles.CheckFolder(Config.RutaConfiguraciones);
            }
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
                    CargarSeccionConfiguracion();
                    break;
                case "btnTests":
                    pnlTests.Visible = true;
                    CargarSeccionTest();
                    break;
                case "btnInformes":
                    pnlInformes.Visible = true;
                    break;
            }
        }

        private void tabConfiguracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSeccionConfiguracion();
        }
        private void CargarSeccionConfiguracion()
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
        private void CargarSeccionTest()
        {
            lvConectoresTest_Resize(null, null);
            CargarDatosSeccionTests();
        }
        #endregion

        #region Seccion Configuracion Conectores
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

        #region Seccion Configuracion Test
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



        #region Seccion Tests
        private void lvConectoresTest_Resize(object sender, EventArgs e)
        {
            if (lvConectoresTest.Width.ToString() == lvConectoresTest.Tag.ToString())
            {
                return;
            }

            int liAncho = lvConectoresTest.Width - 5;
            if (liAncho >= 501)
            {
                lvConectoresTest.Tag = lvConectoresTest.Width;
                liAncho -= (lvConectoresTest.Columns[0].Width + lvConectoresTest.Columns[1].Width);
                lvConectoresTest.Columns[2].Width = liAncho;
            }
        }

        private void CargarDatosSeccionTests()
        {
            lvConectoresTest.Items.Clear();
            this._Conectores = new Conectores(Config.RutaConfiguraciones + @"\Conectores.xml");
            this._Conectores.LoadXML();

            foreach (Conector lItem in this._Conectores.Conector)
            {
                addConectoresTest(lItem.Nombre, lItem.Tipo, lItem.CadenaConexion);
            }

            cbTest.Items.Clear();
            this._Tests = new Tests(Config.RutaConfiguraciones + @"\Tests.xml");
            this._Tests.LoadXML();

            foreach (TestInfo lItem in this._Tests.TestInfo)
            {
                cbTest.Items.Add( new ComboboxItem() { Text = lItem.Nombre, Value = lItem.File} );
            }

            if (this._EjecutarTest != null && this._EjecutarTest.EnProceso)
            {
                btnEjecutar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                btnCancelar.Enabled = false;
                btnEjecutar.Enabled = true;
            }
        }
        private void addConectoresTest(string asNombre, string asTipo, string asCadena)
        {
            ListViewItem llvItem = new ListViewItem(asNombre);
            llvItem.SubItems.Add(asTipo);
            llvItem.SubItems.Add(asCadena);
            lvConectoresTest.Items.Add(llvItem);
        }


        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            List<Conector> lConectores = new List<Conector>();
            Test lTest = new Test();

            // Comprobar que hay conectores y test seleccionados
            if (lvConectoresTest.SelectedItems.Count > 0)
            {
                int liCantidadConectores = lvConectoresTest.SelectedItems.Count;
                for (int i = 0; i < liCantidadConectores; i++)
                {
                    string lsNombre = lvConectoresTest.SelectedItems[i].Text;

                    //Obtene la tarea en cuestion de la lista
                    Conector lConector = obtenConector(lsNombre);
                    lConectores.Add(lConector);
                }
            }
            if (lConectores.Count == 0)
            {
                MessageBox.Show("Debe seleccionar algun conector para realizar el test");
                return;
            }

            if (cbTest.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar algun test que realizar");
                return;
            }

            //lTest.RutaXML = Config.RutaConfiguraciones + @"\Primer test.XML";
            lTest.RutaXML = ((ComboboxItem)cbTest.SelectedItem).Value.ToString();
            lTest.LoadXML(lTest.RutaXML);

            this._EjecutarTest = EjecucionTest.GetInstance(lConectores, lTest);
            this._EjecutarTest.Ejecutar();
            this._EjecutarTest.NotificarAccion += new EjecucionTest.MyEventHandler(OnNotificarAccion);

            btnEjecutar.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this._EjecutarTest != null)
            {
                if (this._EjecutarTest.EnProceso)
                {
                    this._EjecutarTest.CancelarEjecucion();
                    this._EjecutarTest.NotificarAccion -= new EjecucionTest.MyEventHandler(OnNotificarAccion);
                    this._EjecutarTest.Dispose();

                    this._EjecutarTest = null;
                }
                btnCancelar.Enabled = false;
                btnEjecutar.Enabled = true;
            }
        }
        #endregion




        private void timerRefresco_Tick(object sender, EventArgs e)
        {
            sbLabelMemoria.Text = Utiles.PintaMemoria(GC.GetTotalMemory(false));

            if (this._EjecutarTest != null && this._EjecutarTest.EnProceso)
            {
                //sbLabelEstadoTest.Text = "Se esta ejecutando un test.";
                sbLabelEstadoTest.Text = _sUltimoMensaje;
                sbInfo.Text = this._EjecutarTest.PasosActual + "/" + this._EjecutarTest.PasosTotales;
            }
            else
            {
                sbLabelEstadoTest.Text = "";
                sbInfo.Text = "";
 
                btnCancelar.Enabled = false;
                btnEjecutar.Enabled = true;
            }
            /*
            if (this._CantidadTotal == 0)
            {
                sbLabel.Text = string.Empty;
                sbProgressBar.Value = 0;
                return;
            }
            string lsTxt = "Procesados " + this._CantidadProcesada + " de " + this._CantidadTotal;
            sbLabel.Text = lsTxt;

            sbProgressBar.Maximum = this._CantidadTotal;
            int lI = this._CantidadProcesada;
            if (lI > sbProgressBar.Maximum)
            {
                lI = sbProgressBar.Maximum;
            }
            sbProgressBar.Value = lI;
            */
        }

        #region Metodos que se llamaran desde el evento del objeto EjecucionTest
        private void OnNotificarAccion(object sender, MyEventArgs e)
        {
            // Lanzar el evento de momento
            _sUltimoMensaje = e.Data;
        }
        #endregion

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._Mutex != null)
            {
                this._Mutex.ReleaseMutex();
            }
        }

    }
}
