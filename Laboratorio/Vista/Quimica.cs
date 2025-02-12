using Laboratorio.Logica;
using Laboratorio.Modelo;
using Laboratorio.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio
{
    public partial class Quimica : Form
    {
        public Quimica()
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
        private void Quimica_Load(object sender, EventArgs e)
        {
            mostrarPersonas();

        }
        public void mostrarPersonas()
        {
            dgvPersonar.DataSource = null;
            dgvPersonar.DataSource = QuimicaLogica.Instancia.Listar();
            foreach (DataGridViewColumn col in dgvPersonar.Columns)
            {
                if (col.Name != "Id" && col.Name != "Nombre")
                {
                    col.Visible = false;
                }
            }
        }

        public void LlenarCampos(QuimicaM paciente)
        {
            if (paciente != null)
            {
                txtNombre.Text = paciente.Nombre;
                txtMedico.Text = paciente.NombreM;
                txtEdad.Text = paciente.Edad;
                txtGlucosa.Text = paciente.Glucosa; 
                txtUrea.Text = paciente.Urea;
                txtCreatinina.Text = paciente.Creatina;
                txtBUN.Text = paciente.BUN;
                txtUrico.Text = paciente.Urico; 
                txtColesterol.Text = paciente.Colesterol;   
                txtHDL.Text = paciente.HDL;
                txtLDL.Text = paciente.LDL; 
                txtTrigliceridos.Text = paciente.Triglicerido;
                txtBilirrubina.Text = paciente.Bilirrubina;
                txtDirecta.Text = paciente.Directa;
                txtIndirecta.Text = paciente.Indirecta;
                txtTotal.Text = paciente.Total;
                txtGOT.Text = paciente.GOT;
                txtGPT.Text = paciente.GPT;
                txtFosfatasaAlcalina.Text = paciente.FosfatasaAlcalina;
                txtAmilasa.Text = paciente.Amilasa;
                txtProteina.Text = paciente.Proteina;
                txtAlbumina.Text = paciente.Albumina;
                txtglobulina.Text = paciente.Globulina;
                txtRelacion.Text = paciente.Relacion;
                txtFofatasaacida.Text = paciente.FosfatasaAcida;
                txtFosfatasaprotastica.Text = paciente.FosfatasaAcidaProstatica;
                txtCKMB.Text = paciente.CKMB;
                txtCPK.Text = paciente.CPK;
                txtHemoGlicosilada.Text = paciente.Hemoglobina;
            //    txt.Text = paciente.Lipasa;
                txtSodio.Text = paciente.Sodio;
                txtPotasio.Text = paciente.Potasio;
                txtCloro.Text = paciente.Cloro;
                txtCalcio.Text = paciente.Calcio;
            }
            else
            {
                MessageBox.Show("Paciente no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            QuimicaM objeto = new QuimicaM()
            {
               
                
                
                Nombre = txtNombre.Text,
                NombreM = txtMedico.Text,
                Edad = txtEdad.Text,
                Glucosa = txtGlucosa.Text,
                Urea = txtUrea.Text,
                Creatina = txtCreatinina.Text,
                BUN = txtBUN.Text,
                Urico = txtUrico.Text,
                Colesterol = txtColesterol.Text,
                HDL = txtHDL.Text,
                LDL = txtLDL.Text,
                Triglicerido = txtTrigliceridos.Text,
                Bilirrubina = txtBilirrubina.Text,
                Directa = txtDirecta.Text,
                Indirecta = txtIndirecta.Text,
                Total = txtTotal.Text,
                GOT = txtGOT.Text,
                GPT = txtGPT.Text,
                FosfatasaAlcalina = txtFosfatasaAlcalina.Text,
                Amilasa = txtAmilasa.Text,
                Proteina = txtProteina.Text,
                Albumina = txtAlbumina.Text,
                Globulina = txtglobulina.Text,
                Relacion = txtRelacion.Text,
                FosfatasaAcida = txtFofatasaacida.Text,
                FosfatasaAcidaProstatica = txtFosfatasaprotastica.Text,
                CKMB = txtCKMB.Text,
                CPK = txtCPK.Text,
                Hemoglobina = txtHemoGlicosilada.Text,
            //    Lipasa = txtLipasa.Text,
                Sodio = txtSodio.Text,
                Potasio = txtPotasio.Text,
                Cloro = txtCloro.Text,
                Calcio = txtCalcio.Text
            };

            bool respuesta = QuimicaLogica.Instancia.Guardar(objeto);

            if (respuesta)
            {
                MessageBox.Show("Paciente guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarPersonas(); // Recargar la lista
            }
            else
            {
                MessageBox.Show("Error al guardar el paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            QuimicaM pacienteExistente = QuimicaLogica.Instancia.BuscarPorId(idPaciente);
            if (pacienteExistente == null)
            {
                MessageBox.Show("El paciente con este ID no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el objeto con los datos del formulario
            QuimicaM objeto = new QuimicaM()
            {
                Id = idPaciente, // Usamos el ID validado

                Nombre = txtNombre.Text,
                NombreM = txtMedico.Text,
                Edad = txtEdad.Text,
                Glucosa = txtGlucosa.Text,
                Urea = txtUrea.Text,
                Creatina = txtCreatinina.Text,
                BUN = txtBUN.Text,
                Urico = txtUrico.Text,
                Colesterol = txtColesterol.Text,
                HDL = txtHDL.Text,
                LDL = txtLDL.Text,
                Triglicerido = txtTrigliceridos.Text,
                Bilirrubina = txtBilirrubina.Text,
                Directa = txtDirecta.Text,
                Indirecta = txtIndirecta.Text,
                Total = txtTotal.Text,
                GOT = txtGOT.Text,
                GPT = txtGPT.Text,
                FosfatasaAlcalina = txtFosfatasaAlcalina.Text,
                Amilasa = txtAmilasa.Text,
                Proteina = txtProteina.Text,
                Albumina = txtAlbumina.Text,
                Globulina = txtglobulina.Text,
                Relacion = txtRelacion.Text,
                FosfatasaAcida = txtFofatasaacida.Text,
                FosfatasaAcidaProstatica = txtFosfatasaprotastica.Text,
                CKMB = txtCKMB.Text,
                CPK = txtCPK.Text,
                Hemoglobina = txtHemoGlicosilada.Text,
           //     Lipasa = txtLipasa.Text,
                Sodio = txtSodio.Text,
                Potasio = txtPotasio.Text,
                Cloro = txtCloro.Text,
                Calcio = txtCalcio.Text
            };

            // Intentar editar el registro en la base de datos
            bool respuesta = QuimicaLogica.Instancia.Editar(objeto);

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

        

        private void btnImprimir_Click(object sender, EventArgs e)
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
       

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idPaciente;

            // Verifica si la entrada es un número válido
            if (int.TryParse(txtBuscarNombre.Text, out idPaciente))
            {
                QuimicaM paciente = QuimicaLogica.Instancia.BuscarPorId(idPaciente);

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

        private void btnNuevoPaciente_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            QuimicaM objeto = new QuimicaM()
            {
                Id = int.Parse(txtId.Text),
            };

            bool respuesta = QuimicaLogica.Instancia.Eliminar(objeto);

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

        private void txtLDL_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
