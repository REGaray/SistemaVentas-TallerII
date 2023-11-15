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
    public partial class frmRegistrarVenta : Form
    {
        public frmRegistrarVenta()
        {
            InitializeComponent();
        }

        private void frmRegistrarVenta_Load(object sender, EventArgs e)
        {
            dgvdata.Rows.Add("", "Alfajor tatin", "$150.00", 3, "$450.00");
            dgvdata.Rows.Add("", "Alaris Malbec", "$1500.00", 1, "$1.500.00");
            dgvdata.Rows.Add("", "Coca 1,5L Ret.", "$650.00", 2, "$1300.00");
            dgvdata.Rows.Add("", "Marlboro box", "$1.100.00", 2, "$2.200.00");
            dgvdata.Rows.Add("", "Topline Seven Menta", "$250.00", 2, "$500.00");
        }
    }
}
