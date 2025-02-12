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
using static System.Net.Mime.MediaTypeNames;

using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using Laboratorio.Vista;
namespace Laboratorio
{
    public partial class Micro : Form
    {
        public Micro()
        {
            InitializeComponent();
        }
        private Bitmap panelBitmap;

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void Micro_Load(object sender, EventArgs e)
        {
            mostrarPersonas();
        }

      
        public void mostrarPersonas()
        {
            dgvPersonar.DataSource = null;
            dgvPersonar.DataSource = MicroLogica.Instancia.Listar();
            foreach (DataGridViewColumn col in dgvPersonar.Columns)
            {
                if (col.Name != "Id" && col.Name != "Nombre")
                {
                    col.Visible = false;
                }
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            MicroM objeto = new MicroM()
            {
                Nombre = txtNombre.Text,
                Nombre_Medico = txtMedico.Text,
                Edad = txtEdad.Text,
                Muestra = txtMuestra.Text,
                M1 = txtM1.Text,
                M2 = txtM2.Text,
                M3 = txtM3.Text,
                Cultivo = txtCultivo.Text,
                Colonia = txtColonia.Text,
                Identificacion = txtIdentificacion.Text,
                Sensible = txtSensibles.Text,
                Resistencia = txtResistentes.Text,
            };

            bool respuesta = MicroLogica.Instancia.Guardar(objeto);

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

        private void button2_Click(object sender, EventArgs e)
        {
            int idPaciente;

            // Verifica si la entrada es un número válido
            if (int.TryParse(txtBuscarNombre.Text, out idPaciente))
            {
                MicroM paciente = MicroLogica.Instancia.BuscarPorNombre(idPaciente);

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
        public void LlenarCampos(MicroM paciente)
        {
            if (paciente != null)
            {
                txtNombre.Text = paciente.Nombre;
                txtMedico.Text = paciente.Nombre_Medico;
                txtEdad.Text = paciente.Edad;
                txtMuestra.Text = paciente.Muestra;
                txtM1.Text = paciente.M1;
                txtM2.Text = paciente.M2;
                txtM3.Text = paciente.M3;
                txtCultivo.Text = paciente.Cultivo;
                txtColonia.Text = paciente.Colonia;
                txtIdentificacion.Text = paciente.Identificacion;
                txtSensibles.Text = paciente.Sensible;
                txtResistentes.Text = paciente.Resistencia;
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
            MicroM pacienteExistente = MicroLogica.Instancia.BuscarPorNombre(idPaciente);
            if (pacienteExistente == null)
            {
                MessageBox.Show("El paciente con este ID no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el objeto con los datos del formulario
            MicroM objeto = new MicroM()
            {
                Id = idPaciente, // Usamos el ID validado
                Nombre = txtNombre.Text,
                Nombre_Medico = txtMedico.Text,
                Edad = txtEdad.Text,
                Muestra = txtMuestra.Text,
                M1 = txtM1.Text,
                M2 = txtM2.Text,
                M3 = txtM3.Text,
                Cultivo = txtCultivo.Text,
                Colonia = txtColonia.Text,
                Identificacion = txtIdentificacion.Text,
                Sensible = txtSensibles.Text,
                Resistencia = txtResistentes.Text,
            };

            // Intentar editar el registro en la base de datos
            bool respuesta = MicroLogica.Instancia.Editar(objeto);

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
            MicroM objeto = new MicroM()
            {
                Id = int.Parse(txtId.Text),
            };

            bool respuesta = MicroLogica.Instancia.Eliminar(objeto);

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

        private void btnCopros_ClicK_1(object sender, EventArgs e)
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
            Hemograma formQuimica = new Hemograma();
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

       
    }
}
