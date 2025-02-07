using Laboratorio.Logica;
using Laboratorio.Modelo;
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
    public partial class Sobre : Form
    {
        public Sobre()
        {
            InitializeComponent();
        }
        private Bitmap panelBitmap;

        private void button3_Click(object sender, EventArgs e)
        {
            SobreM objeto = new SobreM()
            {
                Nombre = txtPaciente.Text,
                Doctor = txtDr.Text,
                Presente = txtPresente.Text,
                Paciente = txtPaciente.Text,
           
            };

            bool respuesta = SobreLogica.Instancia.Guardar(objeto);

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
            dgvPersonar.DataSource = SobreLogica.Instancia.Listar();
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
                SobreM paciente = SobreLogica.Instancia.BuscarPorNombre(idPaciente);

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
        public void LlenarCampos(SobreM paciente)
        {
            if (paciente != null)
            {
                txtSeñor.Text = paciente.Nombre;
                txtDr.Text = paciente.Doctor;
                txtPresente.Text = paciente.Presente;
                txtPaciente.Text = paciente.Paciente;
           
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

        
    }
}
