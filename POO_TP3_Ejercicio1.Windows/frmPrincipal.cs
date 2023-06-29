using POO_TP3_Ejercicio1.Entidades;
using System;
using System.Windows.Forms;

namespace POO_TP3_Ejercicio1.Windows
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void dataGridViewTabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            FormDatos formDatos = new FormDatos() { Text = "Ingresá los nuevos datos." };
            DialogResult dr = formDatos.ShowDialog();       // Objeto dialog result
            if (dr == DialogResult.Cancel)
            {
                //Me voy del procedimiento
                return;
            }
            //Pido el objeto al formDatos
            SegmentoDeRecta sRecta = formDatos.GetSegmento();
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, sRecta);
            AgregarFila(r);
            MessageBox.Show("Registro Agregado","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information );
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dataGridViewTabla.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, SegmentoDeRecta sRecta)
        {
            r.Cells[ColumnSegmento.Index].Value = sRecta.GetSegmento();
            r.Cells[ColumnEsRecto.Index].Value = sRecta.GetEsRecto();
            r.Cells[ColumnPuntoMedio.Index].Value=sRecta.GetPuntoMedio();
            r.Cells[ColumnModulo.Index].Value = sRecta.GetModuloDelSegmento().ToString("N2");

            r.Tag= sRecta;
        }

        /// <summary>
        /// Método para crear la fila con sus celdas
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridViewTabla);
            return r;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            /*Si no tengo ninguna fila seleccionada 
             * me voy
             */
            if (dataGridViewTabla.SelectedRows.Count==0)
            {
                return;
            }
            DataGridViewRow r = dataGridViewTabla.SelectedRows[0];//tomo la fila seleccionada de la colección de filas seleccionada
            SegmentoDeRecta sRecta =(SegmentoDeRecta) r.Tag;
            DialogResult dr=MessageBox.Show($"¿Deseas borrar el segmento {sRecta.GetSegmento()}?",
                "Confirmar Borrado",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr==DialogResult.No ) { return; }
            dataGridViewTabla.Rows.Remove(r);
            MessageBox.Show("Registro Borrado","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information );
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewTabla.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow r = dataGridViewTabla.SelectedRows[0];//tomo la fila seleccionada de la colección de filas seleccionada
            SegmentoDeRecta sRecta = (SegmentoDeRecta)r.Tag;
            FormDatos formDatos = new FormDatos() { Text = "Editar Segmento" };
            formDatos.SetSegmento(sRecta);
            DialogResult dr = formDatos.ShowDialog();       // Objeto dialog result
            if (dr == DialogResult.Cancel)
            {
                //Me voy del procedimiento
                return;
            }
            //Pido el objeto al formDatos
            sRecta = formDatos.GetSegmento();
            
            SetearFila(r, sRecta);
            MessageBox.Show("Registro Editado","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information );
            

        }
    }
}
