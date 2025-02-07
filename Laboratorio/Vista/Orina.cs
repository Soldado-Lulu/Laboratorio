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
using System.Drawing.Printing;

using static System.Net.Mime.MediaTypeNames;
namespace Laboratorio
{
    public partial class Orina : Form
    {
        public Orina()
        {
            InitializeComponent();
        }
        private Bitmap panelBitmap;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Orina_Load(object sender, EventArgs e)
        {
            mostrarPersonas();

        }

      
        public void mostrarPersonas()
        {
            dgvPersonar.DataSource = null;
            dgvPersonar.DataSource = OrinaLogica.Instancia.Listar();
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
                OrinaM paciente = OrinaLogica.Instancia.BuscarPorNombre(idPaciente);

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

        public void LlenarCampos(OrinaM paciente)
        {
            if (paciente != null)
            {
                txtNombre.Text = paciente.Nombre;
                txtMedico.Text = paciente.Nombre_Medico;
                txtEdad.Text = paciente.Edad;
                txtAspecto.Text = paciente.Aspecto;
                txtColor.Text = paciente.Color;
                txtOlor.Text = paciente.Olor;
                txtDensidad.Text = paciente.Densidad;
                txtReaccion.Text = paciente.Reaccion;
                txtGlucosa.Text = paciente.Glucosa;
                txtBilirrubina.Text = paciente.Bilirrubina;
                txtCetonas.Text = paciente.Cetonas;
                txtSangre.Text = paciente.Sangre;
                txtProteina.Text = paciente.Proteina;
                txtBilirrubina.Text = paciente.Urobiliogeno;
                txtNitrito.Text = paciente.Nitrito;
                txtLeucocitos.Text = paciente.Leucocito1;
                txteritrocitos.Text = paciente.Eritrocito;
                txtLeucocitos1.Text = paciente.Leucocito2;
                txtced.Text = paciente.CED;
                txtredondas.Text = paciente.Redonda;
                txtEmbarazo.Text = paciente.Embarazo;
                txtOtros.Text = paciente.Otros;
                txtObservaciones.Text = paciente.Observaciones;
                txtFlora.Text = paciente.Flora;
                txtPiocitos.Text = paciente.Piocito;
                txtCristales.Text = paciente.Cristale;
                txtCilindros.Text = paciente.Cilindro;
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
            OrinaM pacienteExistente = OrinaLogica.Instancia.BuscarPorNombre(idPaciente);
            if (pacienteExistente == null)
            {
                MessageBox.Show("El paciente con este ID no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el objeto con los datos del formulario
            OrinaM objeto = new OrinaM()
            {
                Id = idPaciente, // Usamos el ID validado
                Nombre = txtNombre.Text,
                Nombre_Medico = txtMedico.Text,
                Edad = txtEdad.Text,
                Aspecto = txtAspecto.Text,
                Color = txtColor.Text,
                Olor = txtOlor.Text,
                Densidad = txtDensidad.Text,
                Reaccion = txtReaccion.Text,
                Glucosa = txtGlucosa.Text,
                Bilirrubina = txtBilirrubina.Text,
                Cetonas = txtCetonas.Text,
                Sangre = txtSangre.Text,
                Proteina = txtProteina.Text,
                Urobiliogeno = txtUrobiliogeno.Text,
                Nitrito = txtNitrito.Text,
                Leucocito1 = txtLeucocitos.Text,
                Eritrocito = txteritrocitos.Text,
                Leucocito2 = txtLeucocitos1.Text,
                CED = txtced.Text,
                Redonda = txtredondas.Text,
                Embarazo = txtEmbarazo.Text,
                Otros = txtOtros.Text,
                Observaciones = txtObservaciones.Text,
                Flora = txtFlora.Text,
                Piocito = txtPiocitos.Text,
                Cristale = txtCristales.Text,
                Cilindro = txtCilindros.Text
            };

            // Intentar editar el registro en la base de datos
            bool respuesta = OrinaLogica.Instancia.Editar(objeto);

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
            OrinaM objeto = new OrinaM()
            {
                Id = int.Parse(txtId.Text),
            };

            bool respuesta = OrinaLogica.Instancia.Eliminar(objeto);

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

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            OrinaM objeto = new OrinaM()
            {
                Nombre = txtNombre.Text,
                Nombre_Medico = txtMedico.Text,
                Edad = txtEdad.Text,
                Aspecto = txtAspecto.Text,
                Color = txtColor.Text,
                Olor = txtOlor.Text,
                Densidad = txtDensidad.Text,
                Reaccion = txtReaccion.Text,
                Glucosa = txtGlucosa.Text,
                Bilirrubina = txtBilirrubina.Text,
                Cetonas = txtCetonas.Text,
                Sangre = txtSangre.Text,
                Proteina = txtProteina.Text,
                Urobiliogeno = txtUrobiliogeno.Text,
                Nitrito = txtNitrito.Text,
                Leucocito1 = txtLeucocitos.Text,
                Eritrocito = txteritrocitos.Text,
                Leucocito2 = txtLeucocitos1.Text,
                CED = txtced.Text,
                Redonda = txtredondas.Text,
                Embarazo = txtEmbarazo.Text,
                Otros = txtOtros.Text,
                Observaciones = txtObservaciones.Text,
                Flora = txtFlora.Text,
                Piocito = txtPiocitos.Text,
                Cristale = txtCristales.Text,
                Cilindro = txtCilindros.Text
            };

            bool respuesta = OrinaLogica.Instancia.Guardar(objeto);

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
    }
}
