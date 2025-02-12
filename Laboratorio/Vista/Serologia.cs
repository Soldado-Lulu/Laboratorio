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
    public partial class Serologia : Form
    {
        public Serologia()
        {
            InitializeComponent();
        }


        private Bitmap panelBitmap;
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Serologia_Load(object sender, EventArgs e)
        {
            mostrarPersonas();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SerologiaM objeto = new SerologiaM()
            {
                Nombre = txtNombre.Text,
                NombreM = txtMedico.Text,
                Edad = txtEdad.Text,
                Campo11 = c11.Text,
                Campo12 = c12.Text,
                Campo13 = c13.Text,
                Campo14 = c14.Text,
                Campo15 = c15.Text,
                Campo21 = c21.Text,
                Campo22 = c22.Text,
                Campo23 = c23.Text,
                Campo24 = c24.Text,
                Campo25 = c25.Text,
                Campo31 = c31.Text,
                Campo32 = c32.Text,
                Campo33 = c33.Text,
                Campo34 = c34.Text,
                Campo35 = c35.Text,
                Campo41 = c41.Text,
                Campo42 = c42.Text,
                Campo43 = c43.Text,
                Campo44 = c44.Text,
                Campo45 = c45.Text,
                Observaciones= txtObservaciiones.Text,  
            };

            bool respuesta = SerologiaLogica.Instancia.Guardar(objeto);

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
            dgvPersonar.DataSource = SerologiaLogica.Instancia.Listar();
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
                SerologiaM paciente = SerologiaLogica.Instancia.BuscarPorNombre(idPaciente);

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
        public void LlenarCampos(SerologiaM paciente)
        {
            if (paciente != null)
            {
                 txtNombre.Text = paciente.Nombre;
                txtMedico.Text = paciente.NombreM;
                 txtEdad.Text = paciente.Edad;
                c11.Text = paciente.Campo11;
                c12.Text = paciente.Campo12;
                c13.Text = paciente.Campo13;
                c14.Text = paciente.Campo14;
                c15.Text = paciente.Campo15;
                c21.Text = paciente.Campo21;
                c22.Text = paciente.Campo22;
                c23.Text = paciente.Campo23;
                c24.Text = paciente.Campo24;
                c25.Text = paciente.Campo25;
                c31.Text = paciente.Campo31;
                c32.Text = paciente.Campo32;
                c33.Text = paciente.Campo33;
                c34.Text = paciente.Campo34;
             c35.Text = paciente.Campo35;
                c41.Text = paciente.Campo41;
                c42.Text = paciente.Campo42;
                c43.Text = paciente.Campo43;
                c44.Text = paciente.Campo44;
                c45.Text = paciente.Campo45;
                txtObservaciiones.Text = paciente.Observaciones;
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

        private void btneditar_Click(object sender, EventArgs e)
        {
            // Verificar que el campo ID no esté vacío y sea un número válido
            if (!int.TryParse(txtId.Text, out int idPaciente))
            {
                MessageBox.Show("Ingrese un ID válido antes de editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Buscar si el paciente con ese ID realmente existe
            SerologiaM pacienteExistente = SerologiaLogica.Instancia.BuscarPorNombre(idPaciente);
            if (pacienteExistente == null)
            {
                MessageBox.Show("El paciente con este ID no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el objeto con los datos del formulario
            SerologiaM objeto = new SerologiaM()
            {
                Id = idPaciente, // Usamos el ID validado
                Nombre = txtNombre.Text,
                NombreM = txtMedico.Text,
                Edad = txtEdad.Text,
                Campo11 = c11.Text,
                Campo12 = c12.Text,
                Campo13 = c13.Text,
                Campo14 = c14.Text,
                Campo15 = c15.Text,
                Campo21 = c21.Text,
                Campo22 = c22.Text,
                Campo23 = c23.Text,
                Campo24 = c24.Text,
                Campo25 = c25.Text,
                Campo31 = c31.Text,
                Campo32 = c32.Text,
                Campo33 = c33.Text,
                Campo34 = c34.Text,
                Campo35 = c35.Text,
                Campo41 = c41.Text,
                Campo42 = c42.Text,
                Campo43 = c43.Text,
                Campo44 = c44.Text,
                Campo45 = c45.Text,
                Observaciones = txtObservaciiones.Text,
            };

            // Intentar editar el registro en la base de datos
            bool respuesta = SerologiaLogica.Instancia.Editar(objeto);

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
            SerologiaM objeto = new SerologiaM()
            {
                Id = int.Parse(txtId.Text),
            };

            bool respuesta = SerologiaLogica.Instancia.Eliminar(objeto);

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
            Hemograma formQuimica = new Hemograma();
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
    }
}
