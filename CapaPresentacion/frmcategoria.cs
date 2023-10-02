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
    public partial class frmcategoria : Form
    {
        public frmcategoria()
        {
            InitializeComponent();
        }

        private void frmcategoria_Load(object sender, EventArgs e)
        {
            dgvcategoria.Rows.Add("", "Lácteos", "Activo");
            dgvcategoria.Rows.Add("", "Gaseosas", "Activo");
            dgvcategoria.Rows.Add("", "Almacén", "Activo");
            dgvcategoria.Rows.Add("", "Espirituosas", "Activo");
            dgvcategoria.Rows.Add("", "Higiene Personal", "Activo");
            dgvcategoria.Rows.Add("", "Cigarrillos", "Activo");
        }
    }
}
