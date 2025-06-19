using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaTexto {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e) {
            texto.Text = "";
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e) {
            // TODO
            // Complete com seu nome e código de matrícula
            MessageBox.Show(this,
               "Busca em Texto - 2025/1\n\nDesenvolvido por: Rian Nascimento Alves e Rafael Augusto\n72301015 e 7230????\nProf. Virgílio Borges de Oliveira\n\nAlgoritmos e Estruturas de Dados II\nFaculdade COTEMIG\nSomente para fins didáticos.",
               "Sobre o trabalho...",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
                openFileDialog.Title = "Abrir arquivo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivo = openFileDialog.FileName;
                  
                    if (System.IO.Path.GetExtension(caminhoArquivo).ToLower() == ".rtf")
                    {
                        texto.Rtf = System.IO.File.ReadAllText(caminhoArquivo);
                    }
                    else
                    {
                        texto.Text = System.IO.File.ReadAllText(caminhoArquivo);
                    }
                }
            }
        }


        private void sairToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
