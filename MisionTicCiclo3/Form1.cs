using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisionTicCiclo3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            BDMiticEntitiesConection contexto = new BDMiticEntitiesConection();
            grid.DataSource = contexto.ClientesMitic.ToList();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtIdClientes.Text);
            string nombre = this.txtNombreClientes.Text;
            string direccion = this.txtDireccion.Text;
            string telefono = this.txtTelefono.Text;

            using(BDMiticEntitiesConection contexto = new BDMiticEntitiesConection ())
            {
                ClientesMitic c = new ClientesMitic
                {
                    idClientes = id,
                    nombreClientes = nombre,
                    direccion = direccion,
                    telefono = telefono
                };
               
                contexto.ClientesMitic.Add(c);
                contexto.SaveChanges();
                cargar();
            }


        }
    }
}
 