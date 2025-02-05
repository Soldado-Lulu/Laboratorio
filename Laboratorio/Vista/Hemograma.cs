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

        }

       

       

        private void qUIMICAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quimica mainForm = new Quimica();
            mainForm.Show();
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAPTT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
