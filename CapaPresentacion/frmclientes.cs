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
    public partial class frmclientes : Form
    {
        public frmclientes()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void frmclientes_Load(object sender, EventArgs e)
        {
            dgvclientes.Rows.Add("", "12876456", "Constructora DelNea", "constructoradelnea@gmail.com", 3794877654, "Activo");
            dgvclientes.Rows.Add("", "90654783907", "Produnoa SA", "produnoa@gmail.com", 3624536740, "Activo");
            dgvclientes.Rows.Add("", "11111111", "Consumidor Final", "correoejemplo@gmail.com", 3794111222, "Activo");
            dgvclientes.Rows.Add("", "37876904", "Alberto Tito Rios", "albertito@gmail.com", 372453647, "Activo");
            dgvclientes.Rows.Add("", "41928847", "Juan Se", "juanse@gmail.com", 3795654372, "Activo");
        }
    }
}
