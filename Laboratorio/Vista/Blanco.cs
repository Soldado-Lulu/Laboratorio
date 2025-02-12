using Laboratorio.Logica;
using Laboratorio.Modelo;
using Laboratorio.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Laboratorio
{
    public partial class Blanco : Form
    {
        public Blanco()
        {
            InitializeComponent();
        }
        private Bitmap panelBitmap;

        private void Blanco_Load(object sender, EventArgs e)
        {
            mostrarPersonas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            BlancoM objeto = new BlancoM()
            {
                Nombre = txtNombre.Text,
                Nombre_Medico = txtMedico.Text,
                Edad = txtEdad.Text,
                Muestra = txtMuestra.Text,
                Examen = txtExamen.Text,
                Datos = txtDatos.Text,
                Otros = txtOtros.Text,
            };

            bool respuesta = BlancoLogica.Instancia.Guardar(objeto);

            if (respuesta)
            {
                MessageBox.Show("Usuario guardado con éxito.");

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
            dgvPersonar.DataSource = BlancoLogica.Instancia.Listar();
            foreach (DataGridViewColumn col in dgvPersonar.Columns)
            {
                if (col.Name != "Id" && col.Name != "Nombre")
                {
                    col.Visible = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idPaciente;

            // Verifica si la entrada es un número válido
            if (int.TryParse(txtBuscarNombre.Text, out idPaciente))
            {
                BlancoM paciente = BlancoLogica.Instancia.BuscarPorNombre(idPaciente);

                if (paciente != null)
                {
                    LlenarCampos(paciente);
                }
                else
                {
                    MessageBox.Show("Paciente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LlenarCampos(BlancoM paciente)
        {
            if (paciente != null)
            {
                txtNombre.Text = paciente.Nombre;
                txtMedico.Text = paciente.Nombre_Medico;
                txtEdad.Text = paciente.Edad;
                txtMuestra.Text = paciente.Muestra;
                txtExamen.Text = paciente.Examen;
                txtDatos.Text = paciente.Datos;
                txtOtros.Text = paciente.Otros;
            }
            else
            {
                MessageBox.Show("Paciente no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CapturarPanel(Panel panel)
        {
            // Crear un Bitmap con el tamaño del panel
            panelBitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(panelBitmap, new Rectangle(0, 0, panel.Width, panel.Height));
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Dibujar el contenido del panel capturado en la página de impresión
            if (panelBitmap != null)
            {
                e.Graphics.DrawImage(panelBitmap, new Point(0, 0));
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CapturarPanel(panelCap); 

            // Configurar el documento de impresión
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            // Mostrar el cuadro de diálogo de impresión
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar que el campo ID no esté vacío y sea un número válido
            if (!int.TryParse(txtId.Text, out int idPaciente))
            {
                MessageBox.Show("Ingrese un ID válido antes de editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Buscar si el paciente con ese ID realmente existe
            BlancoM pacienteExistente = BlancoLogica.Instancia.BuscarPorNombre(idPaciente);
            if (pacienteExistente == null)
            {
                MessageBox.Show("El paciente con este ID no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el objeto con los datos del formulario
            BlancoM objeto = new BlancoM()
            {
                Id = idPaciente, // Usamos el ID validado
                Nombre = txtNombre.Text,
                Nombre_Medico = txtMedico.Text,
                Edad = txtEdad.Text,
                Examen = txtExamen.Text,
                Muestra = txtMuestra.Text,
                Datos = txtDatos.Text,
                Otros = txtOtros.Text,
            };

            // Intentar editar el registro en la base de datos
            bool respuesta = BlancoLogica.Instancia.Editar(objeto);

            if (respuesta)
            {
                MessageBox.Show("Paciente editado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarPersonas(); // Recargar la lista
            }
            else
            {
                MessageBox.Show("Error al editar el paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BlancoM objeto = new BlancoM()
            {
                Id = int.Parse(txtId.Text),
            };

            bool respuesta = BlancoLogica.Instancia.Eliminar(objeto);

            if (respuesta)
            {
                MessageBox.Show("Usuario eliminado con éxito.");
                mostrarPersonas();
            }
            else
            {
                MessageBox.Show("Error al eliminado el usuario.");
            }
        }

        private void btnHemograma_Click_1(object sender, EventArgs e)
        {
            Hemograma formQuimica = new Hemograma();
            formQuimica.Show();  // Abre el formulario de Química
            this.Hide();  // Oculta el formulario actual
        }

        private void btnOrina_Click_1(object sender, EventArgs e)
        {
            Orina formQuimica = new Orina();
            formQuimica.Show();
            this.Hide();
        }

        private void btnCopros_Click_1(object sender, EventArgs e)
        {
            Copros formQuimica = new Copros();
            formQuimica.Show();
            this.Hide();
        }

        private void btnHCG_Click_1(object sender, EventArgs e)
        {
            HCG formQuimica = new HCG();
            formQuimica.Show();
            this.Hide();
        }

        private void btnSerologia_Click_1(object sender, EventArgs e)
        {
            Serologia formQuimica = new Serologia();
            formQuimica.Show();
            this.Hide();
        }

        private void btnMicro_Click_1(object sender, EventArgs e)
        {
            Micro formQuimica = new Micro();
            formQuimica.Show();
            this.Hide();
        }

        private void btnBlanco_Click_1(object sender, EventArgs e)
        {
            Quimica formQuimica = new Quimica();
            formQuimica.Show();
            this.Hide();
        }

        private void btnSobre_Click_1(object sender, EventArgs e)
        {
            Sobre formQuimica = new Sobre();
            formQuimica.Show();
            this.Hide();
        }

        private void btnVarios_Click_1(object sender, EventArgs e)
        {
            Varios formQuimica = new Varios();
            formQuimica.Show();
            this.Hide();
        }

    }
}
