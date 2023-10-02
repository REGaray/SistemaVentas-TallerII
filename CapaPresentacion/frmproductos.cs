using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmproductos : Form
    {
        public frmproductos()
        {
            InitializeComponent();
        }

        private void frmproductos_Load(object sender, EventArgs e)
        {
            dgvproductos.Rows.Add("", 100, "Leche LV LS x 1l", "Leche Larga Vida La Serenísima x 1l", "Lácteos", 30, "$230", "$310", "Activo");
            dgvproductos.Rows.Add("", 101, "Coca Cola x3l", "Gaseosa Coca Cola x 3l Regular", "Gaseosas", 20, "$1100", "$1400", "Activo");
            dgvproductos.Rows.Add("", 102, "Chocolatada Cindor x1l", "Leche Chocolatada Cindor x 1l", "Lácteos", 10, "$800", "$980", "Activo");
            dgvproductos.Rows.Add("", 103, "Puré De la Huerta 510ml", "Puré de Tomate De la Huerta 510ml", "Almacén", 18, "$200", "$300", "Activo");
            dgvproductos.Rows.Add("", 104, "Marlboro Box 20", "Cigarrillo Marlboro Box 20", "Cigarrilos", 30, "990", "$1100", "Activo");
            dgvproductos.Rows.Add("", 105, "Fernet Branca 75cc", "Fernet Branca 75cc", "Espirituosas", 6, "$2900", "$3600", "Activo");
            dgvproductos.Rows.Add("", 106, "Sprite 2.25l", "Gaseosa Sprite 2.25l Regular", "Gaseosas", 10, "$890", "$1100", "Activo");
            dgvproductos.Rows.Add("", 107, "Gancia 450cc", "Aperitivo Gancia 450cc", "Espirituosas", 10, "$800", "$1230", "Activo");
        }
    }
}
