using System;
using System.Windows.Forms;
using TestsSGBD.Clases;
using System.Drawing;
using System.Text.RegularExpressions;

namespace TestsSGBD
{
    public partial class frmConfigurarBloque : Form
    {
        #region Propiedades
        private Bloque _Item;
        private bool _Change;
        private bool _AllowClose;
        private bool _CancelClose;

        private Test.TipoSeccion _Seccion;
        #endregion

        public frmConfigurarBloque()
        {
            InitializeComponent();
            this._Item = new Bloque();

        }

        #region Metodos Accesibles desde fuera
        public void CargarItem(Bloque aItem, Test.TipoSeccion aSeccion)
        {
            this._Item = aItem == null ? new Bloque() : aItem;
            this._Seccion = aSeccion;

            this.Text = "Configurar Bloque " + aSeccion;

            if (this._Seccion == Test.TipoSeccion.CREACION)
            {
                this._Item.Hilos_Inicio = 1;
                this._Item.Hilos_Fin = 1;
                this._Item.Hilos_Step = 1;
                this._Item.Conexion = Bloque.TipoConexion.BLOQUE;

                udHilosInicio.Enabled = false;
                udHilosFin.Enabled = false;
                udHilosStep.Enabled = false;
                chkBloque.Enabled = false;
                chkHilo.Enabled = false;
                chkSentencia.Enabled = false;
            }

            if (this._Item != null)
            {
                // Nombre
                txtNombre.Text = this._Item.Nombre;

                // Sentencias
                txtSentencias.Text = this._Item.SentenciasToString();

                udHilosInicio.Value = this._Item.Hilos_Inicio;
                udHilosFin.Value = this._Item.Hilos_Fin;
                udHilosStep.Value = this._Item.Hilos_Step;

                chkBloque.Checked = ((this._Item.Conexion & Bloque.TipoConexion.BLOQUE) == 0) ? false : true;
                chkHilo.Checked = ((this._Item.Conexion & Bloque.TipoConexion.HILO) == 0) ? false : true;
                chkSentencia.Checked = ((this._Item.Conexion & Bloque.TipoConexion.SENTENCIA) == 0) ? false : true;
            }
        }
        public Bloque ObtenItem()
        {
            // Nombre
            this._Item = ObtenBloque();

            return this._Item;
        }
        private Bloque ObtenBloque()
        {
            Bloque lItem = new Bloque();
            // Nombre
            lItem.Nombre = txtNombre.Text;
            // Sentencias
            txtSentencias.Text = Regex.Replace(txtSentencias.Text, @"\s{2,}", " ");
            string[] lsSentencias = txtSentencias.Text.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string lsItem in lsSentencias)
            {
                string lsSQL = lsItem.Replace("  ", " ").Trim();
                if (lsSQL.Length > 1)
                {
                    lItem.Sentencias.Add(new Sentencia(lsSQL + ";"));
                }
            }

            lItem.Hilos_Inicio = DatosBase.ObtenNumero(udHilosInicio.Value.ToString());
            lItem.Hilos_Fin = DatosBase.ObtenNumero(udHilosFin.Value.ToString());
            lItem.Hilos_Step = DatosBase.ObtenNumero(udHilosStep.Value.ToString());

            lItem.Conexion = 0;
            lItem.Conexion |= chkBloque.Checked ? Bloque.TipoConexion.BLOQUE : 0;
            lItem.Conexion |= chkHilo.Checked ? Bloque.TipoConexion.HILO : 0;
            lItem.Conexion |= chkSentencia.Checked ? Bloque.TipoConexion.SENTENCIA : 0;

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
            if (this._CancelClose)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                if (!this._AllowClose)
                {
                    this.actualizarEstado();
                    if (this._Change)
                    {
                        this._Change = false;
                        if (MessageBox.Show("El bloque a sido modificado, esta seguro de querer salir sin guardar ?", "Bloque", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this._CancelClose = false;
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this._AllowClose = true;
            this._CancelClose = false;
            this.actualizarEstado();

            if (!this.validarSentencias())
            {
                _AllowClose = false;
                this._CancelClose = true;
                return;
            }
            
            if (!this.validar())
            {
                _AllowClose = false;
                MessageBox.Show("Debe especificar un nombre, no se puede guardar.", "Bloque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Close();
        }

        private void actualizarEstado()
        {
            this._Change = false;

            //Montar un obj con los datos del form.
            Bloque lItem = ObtenBloque();

            //Comprobar si es distinto.
            this._Change = !this._Item.Equals(lItem);
        }

        private bool validarSentencias()
        {
            bool lswRes = true;
            string lsMensajeError = "";
            //Montar un obj con los datos del form.
            Bloque lItem = ObtenBloque();

            string lsSentenciasPermitidas = "";
            switch (this._Seccion)
            {
                case Test.TipoSeccion.CREACION:
                    lsMensajeError = "En esta seccion debe escribir sentencias CREATE";
                    lsSentenciasPermitidas = "create";
                    break;
                case Test.TipoSeccion.INSERCION:
                    lsMensajeError = "En esta seccion debe escribir sentencias INSERT o UPDATE";
                    lsSentenciasPermitidas = "insertupdate";
                    break;
                case Test.TipoSeccion.CONSULTA:
                    lsMensajeError = "En esta seccion debe escribir sentencias SELECT";
                    lsSentenciasPermitidas = "select";
                    break;
                case Test.TipoSeccion.BORRADO:
                    lsMensajeError = "En esta seccion debe escribir sentencias DELETE";
                    lsSentenciasPermitidas = "delete";
                    break;
            }

            foreach (Sentencia lSentencia in lItem.Sentencias)
            {
                // Comprobar que la sentencia es del tipo correcto para la seccion en cuestion.
                string lsSentencia = lSentencia.SQL.Substring(0, 6).ToLower();
                if (!lsSentenciasPermitidas.Contains(lsSentencia))
                {
                    MessageBox.Show(lsMensajeError, "Bloque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _AllowClose = false;
                    lswRes = false;
                    break;
                }
            }

            return lswRes;
        }
        private bool validar()
        {
            Bloque lItem = ObtenBloque();
            return lItem.Validar();
        }
        #endregion


    }
}
