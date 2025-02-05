using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using Laboratorio.Logica;
using Laboratorio.Modelo;
using System.Data.SQLite;
namespace Laboratorio
{
    public partial class Hemograma : Form
    {
        public Hemograma()
        {
            InitializeComponent();
        }

        private Bitmap panelBitmap;

        

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

       
        private void Hemograma_Load(object sender, EventArgs e)
        {
            mostrarPersonas();
        }

       

       

        private void qUIMICAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quimica mainForm = new Quimica();
            mainForm.Show();
        }
        public void LlenarCampos(Hematologia paciente)
        {
            if (paciente != null)
            {
                textEritrocitos.Text = paciente.Eritrocitos;
                textLeucocitos.Text = paciente.Leucocitos;
                textHemoglobina.Text = paciente.Hemoglobina;
                textHematocritos.Text = paciente.Hematocrito;
                textPlaquetas.Text = paciente.Plaquetas;
                textMielocitos.Text = paciente.Mielocitos;
                textMetamielocitos.Text = paciente.Melamielocitos;
                textCayados.Text = paciente.Cayados;
                textSegmentados.Text = paciente.Segmentados;
                textLinfocitos.Text = paciente.Linfocitos;
                textMonocitos.Text = paciente.Monocitos;
                textEosinofilos.Text = paciente.Eosinofilos;
                textBasofilos.Text = paciente.Basofilos;
                textVES1.Text = paciente.VES1;
                textVES2.Text = paciente.VES2;
                textIK.Text = paciente.Ik;
                textGrupoSanguineo.Text = paciente.GrupoSanguineo;
                textFactorRh.Text = paciente.Factor;
                txtTiempoSangria.Text = paciente.TiempoSangria;
                txtTiempoCoagulacion.Text = paciente.TiempoCoagulacion;
                txtTiempoProtrombina.Text = paciente.TiempoProtrombina;
                txtPorcentajeActividad.Text = paciente.PorcentajeActividad;
                txtAPTT.Text = paciente.Aptt;
                txtSerieRoja.Text = paciente.SerieRoja;
                txtSerieBlanca.Text = paciente.SerieBlanca;
                textNombre.Text = paciente.NombrePaciente;
                txtMedico.Text = paciente.MedicoSolicitante;
                txtEdad.Text = paciente.Edad;
            }
            else
            {
                MessageBox.Show("Paciente no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            Hematologia objeto = new Hematologia()
            {
                Eritrocitos = textEritrocitos.Text,
                Leucocitos = textLeucocitos.Text,
                Hemoglobina = textHemoglobina.Text,
                Hematocrito = textHematocritos.Text,
                Plaquetas = textPlaquetas.Text,
                Mielocitos = textMielocitos.Text,   
                Melamielocitos  = textMetamielocitos.Text,
                Cayados = textCayados.Text,
                Segmentados = textSegmentados.Text,
                Linfocitos  = textLinfocitos.Text,  
                Monocitos = textMonocitos.Text,
                Eosinofilos = textEosinofilos.Text,
                Basofilos = textBasofilos.Text,
                VES1 = textVES1.Text,
                VES2 = textVES2.Text,
                Ik  =   textIK.Text,    
                GrupoSanguineo = textGrupoSanguineo.Text,
                Factor= textFactorRh.Text,
                TiempoSangria = txtTiempoSangria.Text,
                TiempoCoagulacion = txtTiempoCoagulacion.Text,
                TiempoProtrombina = txtTiempoProtrombina.Text,
                PorcentajeActividad = txtPorcentajeActividad.Text,
                Aptt = txtAPTT.Text,    
                SerieRoja = txtSerieRoja.Text,
                SerieBlanca = txtSerieBlanca.Text,
                NombrePaciente = textNombre.Text,
                MedicoSolicitante = txtMedico.Text,
                Edad = txtEdad.Text
          
            };

            bool respuesta = HematologiaLogica.Instancia.Guardar(objeto);

            if (respuesta)
            {
                MessageBox.Show("Usuario guardado con éxito.");
                
                mostrarPersonas();

            }
            else
            {
                MessageBox.Show("Error al guardar el usuario.");
            }
            // Capturar el contenido del panel
            CapturarPanel(panel7); // Reemplaza 'panel1' con el nombre de tu panel.

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
        public void mostrarPersonas()
        {
            dgvPersonar.DataSource = null;
            dgvPersonar.DataSource = HematologiaLogica.Instancia.Listar();
        }
       
       
        private void button2_Click(object sender, EventArgs e)
        {

            string nombrePaciente = txtBuscarNombre.Text; // Campo de texto donde el usuario ingresa el nombre
            Hematologia paciente  = HematologiaLogica.Instancia.BuscarPorNombre(nombrePaciente);
            LlenarCampos(paciente);
        }

    
}
}
