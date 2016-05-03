using System;
using System.Windows.Forms;
using TestsSGBD.Clases;
using System.Collections.Generic;
using System.Drawing;

namespace TestsSGBD
{
    public partial class frmConfigurarTest : Form
    {
        #region Propiedades
        private Test _Item;
        private bool _Change;
        private bool _AllowClose;
        #endregion

        public frmConfigurarTest()
        {
            InitializeComponent();
            this._Item = new Test();
        }

        #region Metodos Accesibles desde fuera
        public void CargarItem(Test aItem)
        {
            this._Item = aItem == null ? new Test() : aItem;

            if (aItem != null)
            {
                // Nombre
                txtNombre.Text = aItem.Nombre;
            }

        }
        public Test ObtenItem()
        {
            // Nombre
            this._Item.Nombre = txtNombre.Text;
            
            return this._Item;
        }
        public bool Changed()
        {
            return this._Change;
        }
        #endregion
        
        #region Metodos usados para controlar los cambios y los botones de Aceptar / Cancelar
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.FromArgb(64, 64, 64);
            btnAceptar.ForeColor = Color.Silver;
            btnCancelar.BackColor = Color.FromArgb(64, 64, 64);
            btnCancelar.ForeColor = Color.Silver;
        }
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(255, 153, 0);
            ((Button)sender).ForeColor = Color.White;
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._AllowClose)
            {
                this.actualizarEstado();
                if (this._Change)
                {
                    this._Change = false;
                    if (MessageBox.Show("El Test a sido modificado, esta seguro de querer salir sin guardar ?", "Test", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _AllowClose = true;
            this.actualizarEstado();
            if (!this.validar())
            {
                _AllowClose = false;
                MessageBox.Show("Faltan datos o no son validos, no se puede guardar.", "Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Close();
        }

        private void actualizarEstado()
        {
            this._Change = false;

            //Montar un obj con los datos del form.
            Test lItem = new Test();
            lItem.Nombre = txtNombre.Text;

            //Comprobar si es distinto.
            this._Change = !this._Item.Equals(lItem);
        }

        private bool validar()
        {
            //Montar un obj con los datos del form.
            Test lItem = new Test();
            lItem.Nombre = txtNombre.Text;

            return lItem.Validar();
        }
        #endregion


        #region Fichas y Botones de cada ficha
        private void tabTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarBloques();
        }
        private void CargarBloques()
        {
            switch (tabTest.SelectedTab.Name)
            {
                case "tabCreacion":
                    lv_Resize(lvCreacion, null);
                    CargarBloque(this._Item.Creacion.Bloque, lvCreacion);
                    break;
                case "tabInsercion":
                    lv_Resize(lvInsercion, null);
                    CargarBloque(this._Item.Insercion.Bloque, lvInsercion);
                    break;
                case "tabConsulta":
                    lv_Resize(lvConsulta, null);
                    CargarBloque(this._Item.Consulta.Bloque, lvConsulta);
                    break;
                case "tabBorrado":
                    lv_Resize(lvBorrado, null);
                    CargarBloque(this._Item.Borrado.Bloque, lvBorrado);
                    break;
            }
        }
                
        private void lv_Resize(object sender, EventArgs e)
        {
            ListView lItem = (ListView)sender;
            if (lItem.Width.ToString() == lItem.Tag.ToString())
            {
                return;
            }

            int liAncho = lItem.Width - 5;
            if (liAncho >= 403)
            {
                lItem.Tag = lItem.Width;
                liAncho -= (185);
                lItem.Columns[0].Width = liAncho;
            }
        }
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lItem = (ListView)sender;
            Control lUpd = getBoton("Modificar", lItem.Parent.Controls);
            Control lDel = getBoton("Eliminar", lItem.Parent.Controls);

            lUpd.Enabled = false;
            lDel.Enabled = false;

            if (lItem.SelectedItems.Count > 0)
            {
                lUpd.Enabled = true;
                lDel.Enabled = true;
            }
        }
        private Control getBoton(string asText, Control.ControlCollection aControls)
        {
            Control lRes = new Control();
            foreach (Control lItem in aControls)
            {
                if (lItem.Text == asText)
                {
                    lRes = lItem;
                    break;
                }
            }

            return lRes;
        }

        private void CargarBloque(List<Bloque> aBloques, ListView aListView)
        {
            aListView.Items.Clear();

            foreach (Bloque lItem in aBloques)
            {
                int liSQLs = lItem.Sentencias.Count;
                string lsHilos = lItem.Hilos_Inicio + "-" + lItem.Hilos_Fin + "/" + lItem.Hilos_Step;
                string lsBloques = lItem.Conexion.ToString().Replace("BLOQUE", "B").Replace("HILO", "H").Replace("SENTENCIA", "S");
                int liRepeticones = ((lItem.Hilos_Fin - lItem.Hilos_Inicio) + 1) / lItem.Hilos_Step;

                addBloque(aListView, lItem.Nombre, liSQLs, lsHilos, lsBloques, liRepeticones);
            }
        }
        private void addBloque(ListView aListView, string asNombre, int aiSQLs, string asHilos, string asBloques, int aiRepeticiones)
        {
            ListViewItem llvItem = new ListViewItem(asNombre);
            llvItem.SubItems.Add(aiSQLs.ToString());
            llvItem.SubItems.Add(asHilos);
            llvItem.SubItems.Add(asBloques);
            llvItem.SubItems.Add(aiRepeticiones.ToString());
            aListView.Items.Add(llvItem);
        }
        
        private void obtenBloqueYListView(object sender, out List<Bloque> aBloques, out ListView aListView)
        {
            switch (((Button)sender).Name)
            {
                case "btnAddCreacion":
                case "btnUpdCreacion":
                case "btnDelCreacion":
                    aBloques = this._Item.Creacion.Bloque;
                    aListView = lvCreacion;
                    break;
                case "btnAddInsercion":
                case "btnUpdInsercion":
                case "btnDelInsercion":
                    aBloques = this._Item.Insercion.Bloque;
                    aListView = lvInsercion;
                    break;
                case "btnAddConsulta":
                case "btnUpdConsulta":
                case "btnDelConsulta":
                    aBloques = this._Item.Consulta.Bloque;
                    aListView = lvConsulta;
                    break;
                case "btnAddBorrado":
                case "btnUpdBorrado":
                case "btnDelBorrado":
                    aBloques = this._Item.Borrado.Bloque;
                    aListView = lvBorrado;
                    break;
                default:
                    aBloques = new List<Bloque>();
                    aListView = new ListView();
                    break;
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<Bloque> lItemBloque = new List<Bloque>();
            ListView lListView = new ListView();
            obtenBloqueYListView(sender, out lItemBloque, out lListView);

            frmConfigurarBloque lForm = new frmConfigurarBloque();
            lForm.CargarItem(null);
            // Lo abro como dialogo, para que mantenga el foco
            lForm.ShowDialog();
            // Al volver,
            if (lForm.Changed())
            {
                Bloque lItem = lForm.ObtenItem();

                // Añado el TestInfo a mi lista
                //this._Item.Creacion.Bloque.Add(lItem);
                lItemBloque.Add(lItem);
                lItem = null;
                // Recargar el listado de consultas
                CargarBloque(lItemBloque, lListView);
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            List<Bloque> lItemBloque = new List<Bloque>();
            ListView lListView = new ListView();
            obtenBloqueYListView(sender, out lItemBloque, out lListView);

            if (lListView.SelectedItems.Count > 0)
            {
                // Obtener el nombre 
                string lsNombre = lListView.SelectedItems[0].Text;

                //Obtene la tarea en cuestion de la lista
                int liIndex = lItemBloque.FindIndex(o => o.Nombre == lsNombre);
                Bloque lBloque = lItemBloque[liIndex];

                frmConfigurarBloque lForm = new frmConfigurarBloque();
                lForm.CargarItem(lBloque);

                lForm.ShowDialog();
                // Al volver,
                if (lForm.Changed())
                {
                    lItemBloque[liIndex] = lForm.ObtenItem();
                    // Recargar el listado de consultas
                    CargarBloque(lItemBloque, lListView);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            List<Bloque> lItemBloque = new List<Bloque>();
            ListView lListView = new ListView();
            obtenBloqueYListView(sender, out lItemBloque, out lListView);

            if (lListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Esta seguro de eliminar el bloque de sentencias ?", "Sentencias SQL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                string lsNombre = lListView.SelectedItems[0].Text;
                // Eliminarlo
                lItemBloque.RemoveAll(o => o.Nombre == lsNombre);
                // Recargar el listado de consultas
                CargarBloque(lItemBloque, lListView);
            }
        }
        #endregion

    }
}
