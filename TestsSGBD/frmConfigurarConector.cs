using System;
using System.Windows.Forms;
using TestsSGBD.Clases;
using System.Drawing;

namespace TestsSGBD
{
    public partial class frmConfigurarConector : Form
    {
        #region Propiedades
        private Conector _Item;
        private bool _Change;
        private bool _AllowClose;
        #endregion

        public frmConfigurarConector()
        {
            InitializeComponent();
            this._Item = new Conector();

        }

        #region Metodos Accesibles desde fuera
        public void CargarConector(Conector aItem)
        {
            this._Item = aItem == null ? new Conector() : aItem;

            if (aItem != null)
            {
                // Nombre
                txtNombre.Text = aItem.Nombre;

                // Tipo
                cmbTipo.SelectedIndex = aItem.Tipo == "ODBC"? 0: 1;

                // Cadena
                txtCadena.Text = aItem.CadenaConexion;
            }

        }
        public Conector ObtenItem()
        {
            this._Item = ObtenBloque();
            
            return this._Item;
        }
        private Conector ObtenBloque()
        {
            Conector lItem = new Conector();

            // Nombre
            lItem.Nombre = txtNombre.Text;
            // Tipo
            lItem.Tipo = cmbTipo.Text.Contains("ODBC")? "ODBC": "MySQL";
            // Cadena
            lItem.CadenaConexion = txtCadena.Text;

            return lItem;
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
                    if (MessageBox.Show("El conector a sido modificado, esta seguro de querer salir sin guardar ?", "Conector", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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
                MessageBox.Show("Faltan datos o no son validos, no se puede guardar.", "Conector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Close();
        }

        private void actualizarEstado()
        {
            this._Change = false;
            //Montar un obj con los datos del form.
            Conector lItem = ObtenBloque();
            //Comprobar si es distinto.
            this._Change = !this._Item.Equals(lItem);
        }

        private bool validar()
        {
            //Montar un obj con los datos del form.
            Conector lItem = ObtenBloque();

            return lItem.Validar();
        }
        #endregion

    }
}
