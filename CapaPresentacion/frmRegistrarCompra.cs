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
    public partial class frmRegistrarCompra : Form
    {
        public frmRegistrarCompra()
        {
            InitializeComponent();
        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmRegistrarCompra_Load(object sender, EventArgs e)
        {
            dgvRC.Rows.Add("", "Alfajor tatin", "$150.00", 3, "$450.00");
            dgvRC.Rows.Add("", "Alaris Malbec", "$1500.00", 1, "$1.500.00");
            dgvRC.Rows.Add("", "Coca 1,5L Ret.", "$650.00", 2, "$1300.00");
            dgvRC.Rows.Add("", "Marlboro box", "$1.100.00", 2, "$2.200.00");
            dgvRC.Rows.Add("", "Topline Seven Menta", "$250.00", 2, "$500.00");
        }
    }
}
