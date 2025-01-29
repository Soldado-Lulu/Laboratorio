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
    }
}
