using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Laboratorio.Logica;
using Laboratorio.Modelo;



namespace Laboratorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Usuario objeto = new Usuario()
            {
                Nombre = txtnombre.Text,
                Password = txtpassword.Text
            };

            bool respuesta = PersonaLogica.Instancia.Guardar(objeto);   

            if (respuesta)
            {
                MessageBox.Show("Usuario guardado con éxito.");
                limpiar();
                mostrarPersonas();

            }
            else
            {
                MessageBox.Show("Error al guardar el usuario.");
            }
        }



        public void mostrarPersonas()
        {
            dgvPersonar.DataSource = null;
            dgvPersonar.DataSource = PersonaLogica.Instancia.Listar();
        }
        public void limpiar()
        {
            txtid.Text = "";
            txtnombre.Text = "";
            txtpassword.Text = "";
            txtnombre.Focus();
        }
        private void btneditar_Click(object sender, EventArgs e)
        {
            Usuario objeto = new Usuario()
            {
                idPersona =int.Parse(txtid.Text),
                Nombre = txtnombre.Text,
                Password = txtpassword.Text
            };

            bool respuesta = PersonaLogica.Instancia.Editar(objeto);

            if (respuesta)
            {
                MessageBox.Show("Usuario editado con éxito.");
                limpiar();
                mostrarPersonas();
            }
            else
            {
                MessageBox.Show("Error al editado el usuario.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarPersonas();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Usuario objeto = new Usuario()
            {
                idPersona = int.Parse(txtid.Text),
            };

            bool respuesta = PersonaLogica.Instancia.Eliminar(objeto);

            if (respuesta)
            {
                MessageBox.Show("Usuario eliminado con éxito.");
                limpiar();
                mostrarPersonas();
            }
            else
            {
                MessageBox.Show("Error al eliminado el usuario.");
            }
        }
    }
}
