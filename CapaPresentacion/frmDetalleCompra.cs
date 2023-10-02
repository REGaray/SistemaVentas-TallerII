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
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
        }

        private void frmDetalleCompra_Load(object sender, EventArgs e)
        {
            dgvDetalleCompra.Rows.Add("", "Alfajor tatin", "$150.00", 3, "$450.00");
            dgvDetalleCompra.Rows.Add("", "Alaris Malbec", "$1500.00", 1, "$1.500.00");
            dgvDetalleCompra.Rows.Add("", "Coca 1,5L Ret.", "$650.00", 2, "$1300.00");
            dgvDetalleCompra.Rows.Add("", "Marlboro box", "$1.100.00", 2, "$2.200.00");
            dgvDetalleCompra.Rows.Add("", "Topline Seven Menta", "$250.00", 2, "$500.00");
        }
    }
}
