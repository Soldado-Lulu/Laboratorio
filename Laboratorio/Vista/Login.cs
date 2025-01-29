using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Configuración inicial si es necesario
        }

       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validación básica de credenciales
            if (username == "admin" && password == "12345")
            {
                MessageBox.Show("¡Inicio de sesión exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aquí puedes abrir otro formulario o realizar acciones
                this.Hide();
                Hemograma mainForm = new Hemograma();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

