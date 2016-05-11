﻿using System;
using System.Windows.Forms;
using TestsSGBD.Clases;
using System.Drawing;

namespace TestsSGBD
{
    public partial class frmConfigurarBloque : Form
    {
        #region Propiedades
        private Bloque _Item;
        private bool _Change;
        private bool _AllowClose;
        #endregion

        public frmConfigurarBloque()
        {
            InitializeComponent();
            this._Item = new Bloque();

        }

        #region Metodos Accesibles desde fuera
        public void CargarItem(Bloque aItem)
        {
            this._Item = aItem == null ? new Bloque() : aItem;

            if (aItem != null)
            {
                // Nombre
                txtNombre.Text = aItem.Nombre;

                // Sentencias
                txtSentencias.Text = aItem.SentenciasToString();

                udHilosInicio.Value = aItem.Hilos_Inicio;
                udHilosFin.Value = aItem.Hilos_Fin;
                udHilosStep.Value = aItem.Hilos_Step;

                chkBloque.Checked = ((aItem.Conexion & Bloque.TipoConexion.BLOQUE)==0)? false: true;
                chkHilo.Checked = ((aItem.Conexion & Bloque.TipoConexion.HILO) == 0) ? false : true;
                chkSentencia.Checked = ((aItem.Conexion & Bloque.TipoConexion.SENTENCIA) == 0) ? false : true;
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
            string[] lsSentencias = txtSentencias.Text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string lsItem in lsSentencias)
            {
                lItem.Sentencias.Add(new Sentencia(lsItem));
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
                MessageBox.Show("Faltan datos o no son validos, no se puede guardar.", "Bloque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private bool validar()
        {
            //Montar un obj con los datos del form.
            Bloque lItem = ObtenBloque();

            return lItem.Validar();
        }
        #endregion


    }
}