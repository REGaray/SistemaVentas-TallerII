using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
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
            // Agrega las opciones "Activo" e "Inactivo" al ComboBox "cboestado".
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });

            // Establece el atributo "Texto" como el valor a mostrar en el ComboBox "cboestado".
            cboestado.DisplayMember = "Texto";

            // Establece el atributo "Valor" como el valor a obtener del ComboBox "cboestado".
            cboestado.ValueMember = "Valor";

            // Selecciona la primera opción en el ComboBox "cboestado" (en este caso, "Activo").
            cboestado.SelectedIndex = 0;



            // Llena el ComboBox "cbobusqueda" con las opciones de búsqueda basadas en las columnas visibles del DataGridView.
            foreach (DataGridViewColumn columna in dgvcategoria.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            // Establece el atributo "Texto" como el valor a mostrar en el ComboBox "cbobusqueda".
            cbobusqueda.DisplayMember = "Texto";

            // Establece el atributo "Valor" como el valor a obtener del ComboBox "cbobusqueda".
            cbobusqueda.ValueMember = "Valor";

            // Selecciona la primera opción en el ComboBox "cbobusqueda".
            cbobusqueda.SelectedIndex = 0;

            // Obtiene una lista de usuarios y los muestra en el DataGridView.
            List<Categoria> lista = new CN_Categoria().Listar();

            foreach (Categoria item in lista)
            {
                // Agrega una nueva fila con los datos del usuario al DataGridView.
                dgvcategoria.Rows.Add(new object[] { "", item.IdCategoria, item.Descripcion,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo" : "Inactivo"
                });
            }



            //dgvcategoria.Rows.Add("", "Lácteos", "Activo");
            //dgvcategoria.Rows.Add("", "Gaseosas", "Activo");
            //dgvcategoria.Rows.Add("", "Almacén", "Activo");
            //dgvcategoria.Rows.Add("", "Espirituosas", "Activo");
            //dgvcategoria.Rows.Add("", "Higiene Personal", "Activo");
            //dgvcategoria.Rows.Add("", "Cigarrillos", "Activo");
        }
    }
}
