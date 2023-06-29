using POO_TP3_Ejercicio1.Entidades;
using System;
using System.Windows.Forms;

namespace POO_TP3_Ejercicio1.Windows
{
    public partial class FormDatos : Form
    {
        public FormDatos()
        {
            InitializeComponent();
        }
        private SegmentoDeRecta segmentoDeRecta;
        private void FormDatos_Load(object sender, EventArgs e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);//Funcioná como siempre
            if (segmentoDeRecta!=null)
            {
                //Mostrar los datos
                textBoxXInicial.Text = segmentoDeRecta.GetInicioX().ToString();
                textBoxXFinal.Text=segmentoDeRecta.GetFinalX().ToString();
                textBoxYInicial.Text=segmentoDeRecta.GetInicioY().ToString();
                textBoxYFinal.Text=segmentoDeRecta.GetFinalY().ToString();
            }

        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBoxXInicial.Clear();
            textBoxXInicial.Focus();
            textBoxYInicial.Clear();
            textBoxXFinal.Clear();
            textBoxYFinal.Clear();
        }
        /// <summary>
        /// Método para validar los datos ingresados en el formulario
        /// </summary>
        /// <returns></returns>
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (!double.TryParse(textBoxXInicial.Text, out double valorXInicial))
            {
                valido = false;
                errorProvider1.SetError(textBoxXInicial, "Valor no válido");
            }
            else if (valorXInicial <= 0)
            {
                valido = false;
                errorProvider1.SetError(textBoxXInicial, "El valor debe ser positivo");
            }

            if (!double.TryParse(textBoxYInicial.Text, out double valorYInicial))
            {
                valido = false;
                errorProvider1.SetError(textBoxYInicial, "Valor no válido");
            }
            else if (valorYInicial <= 0)
            {
                valido = false;
                errorProvider1.SetError(textBoxYInicial, "El valor debe ser positivo");
            }

            if (!double.TryParse(textBoxXFinal.Text, out double valorXFinal))
            {
                valido = false;
                errorProvider1.SetError(textBoxXFinal, "Valor no válido");
            }
            else if (valorXFinal <= 0)
            {
                valido = false;
                errorProvider1.SetError(textBoxXFinal, "El valor debe ser positivo");
            }

            if (!double.TryParse(textBoxYFinal.Text, out double valorYFinal))
            {
                valido = false;
                errorProvider1.SetError(textBoxYFinal, "Valor no válido");
            }
            else if (valorYFinal <= 0)
            {
                valido = false;
                errorProvider1.SetError(textBoxYFinal, "El valor debe ser positivo");
            }


            return valido;

        }
        /// <summary>
        /// Método para pasar el objeto Segmento al otro formulario
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public SegmentoDeRecta GetSegmento()
        {
            return segmentoDeRecta;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                double inicioX = double.Parse(textBoxXInicial.Text);
                double finalX = double.Parse(textBoxXFinal.Text);
                double inicioY = double.Parse(textBoxYInicial.Text);
                double finalY = double.Parse(textBoxYFinal.Text);
                if (segmentoDeRecta == null)
                {
                    segmentoDeRecta = new SegmentoDeRecta(inicioX, finalX, inicioY, finalY);     // Creación del objeto segmento

                }
                else
                {
                    segmentoDeRecta.SetInicioX(inicioX);
                    segmentoDeRecta.SetFinalX(finalX);
                    segmentoDeRecta.SetInicioY(inicioY);
                    segmentoDeRecta.SetFinalY(finalY);
                        
                }
                if (segmentoDeRecta.Validar())
                {
                    DialogResult = DialogResult.OK;

                }
                else
                {
                    //MessageBox.Show("Ambos punto son iguales!!!","Error",
                    //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(groupBoxDatos, "Ambos punto son iguales!!!");
                }

            }
        }

        public void SetSegmento(SegmentoDeRecta sRecta)
        {
            segmentoDeRecta=sRecta;
        }
    }
}
