using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using static System.Net.Mime.MediaTypeNames;
using Laboratorio.Logica;
using Laboratorio.Modelo;
using Laboratorio.Vista;
using System.Xml.Linq;
namespace Laboratorio
{
    public partial class Copros : Form
    {
        public Copros()
        {
            InitializeComponent();
        }
        private Bitmap panelBitmap;
      
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CoprosM objeto = new CoprosM()
            {
                Nombre = txtNombre.Text,
                Nombre_Medico = txtMedico.Text,
                Edad = txtEdad.Text,
                Consistencia = txtConsistencia.Text,
                Color = txtColor.Text,
                ExamenM = txtExamenM.Text,
                Observaciones = txtObservaciones.Text,
            };

            bool respuesta = CoprosLogica.Instancia.Guardar(objeto);

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

        private void Copros_Load(object sender, EventArgs e)
        {
            mostrarPersonas();
        }
        public void mostrarPersonas()
        {
            dgvPersonar.DataSource = null;
            dgvPersonar.DataSource = CoprosLogica.Instancia.Listar();
            foreach (DataGridViewColumn col in dgvPersonar.Columns)
            {
                if (col.Name != "Id" && col.Name != "Nombre")
                {
                    col.Visible = false;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idPaciente;

            // Verifica si la entrada es un número válido
            if (int.TryParse(txtBuscarNombre.Text, out idPaciente))
            {
                CoprosM paciente = CoprosLogica.Instancia.BuscarPorNombre(idPaciente);

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

        public void LlenarCampos(CoprosM paciente)
        {
            if (paciente != null)
            {
                txtNombre.Text = paciente.Nombre;
                txtMedico.Text = paciente.Nombre_Medico;
                txtEdad.Text = paciente.Edad;
                txtConsistencia.Text = paciente.Consistencia;
                txtColor.Text = paciente.Color;
                txtExamenM.Text = paciente.ExamenM;
                txtObservaciones.Text = paciente.Observaciones;
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
      
        

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int idPaciente))
            {
                MessageBox.Show("Ingrese un ID válido antes de editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Buscar si el paciente con ese ID realmente existe
            CoprosM pacienteExistente = CoprosLogica.Instancia.BuscarPorNombre(idPaciente);
            if (pacienteExistente == null)
            {
                MessageBox.Show("El paciente con este ID no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el objeto con los datos del formulario
            CoprosM objeto = new CoprosM()
            {
                Id = idPaciente, // Usamos el ID validado
                Nombre = txtNombre.Text,
                Nombre_Medico = txtMedico.Text,
                Edad = txtEdad.Text,
                Consistencia = txtConsistencia.Text,
                Color = txtColor.Text,
                ExamenM = txtExamenM.Text,
                Observaciones = txtObservaciones.Text,
            };

            // Intentar editar el registro en la base de datos
            bool respuesta = CoprosLogica.Instancia.Editar(objeto);

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

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CoprosM objeto = new CoprosM()
            {
                Id = int.Parse(txtId.Text),
            };

            bool respuesta = CoprosLogica.Instancia.Eliminar(objeto);

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

        private void btnImprimir_Click_1(object sender, EventArgs e)
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
        //****************************************************************************
        private void btnHemograma_Click_1(object sender, EventArgs e)
        {
            Quimica formQuimica = new Quimica();
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
            Hemograma formQuimica = new Hemograma();
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
            Blanco formQuimica = new Blanco();
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

        private void txtColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtConsistencia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
