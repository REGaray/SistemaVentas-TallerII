﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class frmRegistrarCompra : Form
    {
        private Usuario _Usuario;

        public frmRegistrarCompra(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }


        private void frmRegistrarCompra_Load(object sender, EventArgs e)
        {
            // Se agregan elementos al control 'cbotipodocumento' como opciones en un combo.
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });

            // Se establece el miembro para mostrar en el control 'cbotipodocumento' como "Texto".
            cbotipodocumento.DisplayMember = "Texto";

            // Se establece el valor interno en el control 'cbotipodocumento' como "Valor".
            cbotipodocumento.ValueMember = "Valor";

            // Se establece el índice seleccionado en el control 'cbotipodocumento' para mostrar la primera opción por defecto.
            cbotipodocumento.SelectedIndex = 0;

            // Se establece el texto del control 'txtfecha' como la fecha y hora actual formateada como "dd/MM/yyyy".
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Se inicializan los campos de texto 'txtidproveedor' y 'txtidproducto' con el valor "0".
            txtidproveedor.Text = "0";
            txtidproducto.Text = "0";

            //MessageBox.Show(_Usuario.NombreCompleto);


            //dgvRC.Rows.Add("", "Alfajor tatin", "$150.00", 3, "$450.00");
            //dgvRC.Rows.Add("", "Alaris Malbec", "$1500.00", 1, "$1.500.00");
            //dgvRC.Rows.Add("", "Coca 1,5L Ret.", "$650.00", 2, "$1300.00");
            //dgvRC.Rows.Add("", "Marlboro box", "$1.100.00", 2, "$2.200.00");
            //dgvRC.Rows.Add("", "Topline Seven Menta", "$250.00", 2, "$500.00");
        }











    }
}
