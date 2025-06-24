using System;
using System.Drawing;
using System.Windows.Forms;

namespace BuscaTexto
{
    public partial class FormBusca : Form
    {
        public string Padrao { get; private set; }
        public string Substituicao { get; private set; }
        public bool CaseSensitive { get; private set; }
        public bool Substituir { get; private set; }

        private TextBox txtPadrao;
        private TextBox txtSubstituicao;
        private CheckBox chkCaseSensitive;
        private CheckBox chkSubstituir;
        private Button btnOK;
        private Button btnCancelar;
        private Label lblPadrao;
        private Label lblSubstituicao;

        public FormBusca(string titulo)
        {
            InitializeComponent();
            this.Text = $"Busca - {titulo}";
            CaseSensitive = true;
            Substituir = false;
        }

        private void InitializeComponent()
        {
            this.txtPadrao = new TextBox();
            this.txtSubstituicao = new TextBox();
            this.chkCaseSensitive = new CheckBox();
            this.chkSubstituir = new CheckBox();
            this.btnOK = new Button();
            this.btnCancelar = new Button();
            this.lblPadrao = new Label();
            this.lblSubstituicao = new Label();
            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(400, 180);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // lblPadrao
            this.lblPadrao.AutoSize = true;
            this.lblPadrao.Location = new Point(12, 15);
            this.lblPadrao.Size = new Size(120, 13);
            this.lblPadrao.Text = "Texto para buscar:";

            // txtPadrao
            this.txtPadrao.Location = new Point(15, 35);
            this.txtPadrao.Size = new Size(360, 20);
            this.txtPadrao.TabIndex = 0;

            // lblSubstituicao
            this.lblSubstituicao.AutoSize = true;
            this.lblSubstituicao.Location = new Point(12, 65);
            this.lblSubstituicao.Size = new Size(120, 13);
            this.lblSubstituicao.Text = "Substituir por:";

            // txtSubstituicao
            this.txtSubstituicao.Location = new Point(15, 85);
            this.txtSubstituicao.Size = new Size(360, 20);
            this.txtSubstituicao.TabIndex = 1;
            this.txtSubstituicao.Enabled = false;

            // chkCaseSensitive
            this.chkCaseSensitive.AutoSize = true;
            this.chkCaseSensitive.Checked = true;
            this.chkCaseSensitive.Location = new Point(15, 115);
            this.chkCaseSensitive.Size = new Size(140, 17);
            this.chkCaseSensitive.TabIndex = 2;
            this.chkCaseSensitive.Text = "Diferenciar maiúsculas";
            this.chkCaseSensitive.UseVisualStyleBackColor = true;

            // chkSubstituir
            this.chkSubstituir.AutoSize = true;
            this.chkSubstituir.Location = new Point(180, 115);
            this.chkSubstituir.Size = new Size(100, 17);
            this.chkSubstituir.TabIndex = 3;
            this.chkSubstituir.Text = "Substituir texto";
            this.chkSubstituir.UseVisualStyleBackColor = true;
            this.chkSubstituir.CheckedChanged += new EventHandler(this.chkSubstituir_CheckedChanged);

            // btnOK
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(219, 145);
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);

            // btnCancelar
            this.btnCancelar.DialogResult = DialogResult.Cancel;
            this.btnCancelar.Location = new Point(300, 145);
            this.btnCancelar.Size = new Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;

            // Adiciona controles ao form
            this.Controls.Add(this.lblPadrao);
            this.Controls.Add(this.txtPadrao);
            this.Controls.Add(this.lblSubstituicao);
            this.Controls.Add(this.txtSubstituicao);
            this.Controls.Add(this.chkCaseSensitive);
            this.Controls.Add(this.chkSubstituir);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancelar);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void chkSubstituir_CheckedChanged(object sender, EventArgs e)
        {
            txtSubstituicao.Enabled = chkSubstituir.Checked;
            if (!chkSubstituir.Checked)
            {
                txtSubstituicao.Text = "";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPadrao.Text))
            {
                MessageBox.Show("Por favor, digite o texto para buscar.", "Campo obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPadrao.Focus();
                return;
            }

            Padrao = txtPadrao.Text;
            Substituicao = txtSubstituicao.Text;
            CaseSensitive = chkCaseSensitive.Checked;
            Substituir = chkSubstituir.Checked;
        }
    }
}