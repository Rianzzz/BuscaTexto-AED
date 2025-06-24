using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace BuscaTexto
{
    // Classe principal do formulário da aplicação
    public partial class Form1 : Form
    {
        // Construtor do formulário
        public Form1()
        {
            InitializeComponent();
        }

        // Evento do menu "Novo" - limpa o conteúdo do RichTextBox
        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texto.Text = "";
        }

        // Método auxiliar para obter dados de busca do usuário
        private (string padrao, string substituicao, bool caseSensitive, bool substituir) ObterDadosBusca(string titulo)
        {
            using (var form = new FormBusca(titulo))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return (form.Padrao, form.Substituicao, form.CaseSensitive, form.Substituir);
                }
            }
            return (null, null, true, false);
        }

        // Método auxiliar para destacar ocorrências
        private void DestacarOcorrencias(List<int> posicoes, string padrao, string substituicao, bool substituir)
        {
            if (posicoes.Count == 0)
            {
                MessageBox.Show(this,
                    "O termo pesquisado não foi encontrado no texto.",
                    "Nenhuma ocorrência encontrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (substituir && !string.IsNullOrEmpty(substituicao))
            {
                // Substitui as ocorrências (de trás para frente para não alterar as posições)
                var posicoesOrdenadas = posicoes.OrderByDescending(p => p).ToList();
                string textoAtual = texto.Text;

                foreach (int pos in posicoesOrdenadas)
                {
                    textoAtual = textoAtual.Remove(pos, padrao.Length);
                    textoAtual = textoAtual.Insert(pos, substituicao);
                }

                texto.Text = textoAtual;

                MessageBox.Show(this,
                    $"{posicoes.Count} ocorrência(s) substituída(s) com sucesso!",
                    "Substituição concluída",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                // Apenas destaca as ocorrências
                Random rand = new Random();

                foreach (int pos in posicoes)
                {
                    Color corAleatoria = Color.FromArgb(
                        255,
                        rand.Next(128, 256), // Cores mais claras para melhor legibilidade
                        rand.Next(128, 256),
                        rand.Next(128, 256)
                    );

                    texto.Select(pos, padrao.Length);
                    texto.SelectionBackColor = corAleatoria;
                }

                texto.SelectionLength = 0;

                MessageBox.Show(this,
                    $"{posicoes.Count} ocorrência(s) encontrada(s) e destacada(s)!",
                    "Busca concluída",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // Evento do menu "Força Bruta"
        private void forcaBrutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Limpa destaques anteriores
            texto.SelectAll();
            texto.SelectionBackColor = Color.White;
            texto.SelectionLength = 0;

            var dados = ObterDadosBusca("Força Bruta");
            if (dados.padrao == null) return;

            string conteudo = texto.Text;
            var posicoes = BuscaForcaBruta.forcaBruta(dados.padrao, conteudo, dados.caseSensitive);

            DestacarOcorrencias(posicoes, dados.padrao, dados.substituicao, dados.substituir);
        }

        // Evento do menu "Rabin-Karp"
        private void rabinKarpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Limpa destaques anteriores
            texto.SelectAll();
            texto.SelectionBackColor = Color.White;
            texto.SelectionLength = 0;

            var dados = ObterDadosBusca("Rabin-Karp");
            if (dados.padrao == null) return;

            string conteudo = texto.Text;
            var posicoes = BuscaRabinKarp.RKSearchAll(dados.padrao, conteudo, dados.caseSensitive);

            DestacarOcorrencias(posicoes, dados.padrao, dados.substituicao, dados.substituir);
        }

        // Evento do menu "KMP"
        private void kmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Limpa destaques anteriores
            texto.SelectAll();
            texto.SelectionBackColor = Color.White;
            texto.SelectionLength = 0;

            var dados = ObterDadosBusca("KMP");
            if (dados.padrao == null) return;

            string conteudo = texto.Text;
            var posicoes = BuscaKMP.KMPSearchAll(dados.padrao, conteudo, dados.caseSensitive);

            DestacarOcorrencias(posicoes, dados.padrao, dados.substituicao, dados.substituir);
        }

        // Evento do menu "Boyer-Moore"
        private void boyerMooreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Limpa destaques anteriores
            texto.SelectAll();
            texto.SelectionBackColor = Color.White;
            texto.SelectionLength = 0;

            var dados = ObterDadosBusca("Boyer-Moore");
            if (dados.padrao == null) return;

            string conteudo = texto.Text;
            var posicoes = BuscaBoyerMoore.BMSearchAll(dados.padrao, conteudo, dados.caseSensitive);

            DestacarOcorrencias(posicoes, dados.padrao, dados.substituicao, dados.substituir);
        }

        // Evento do menu "Sobre"
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
               "Busca em Texto - 2025/1\n\nDesenvolvido por: Rian Nascimento Alves e Rafael Augusto\n72301015 e 72301350\nProf. Roselene Henrique Pereira Costa\n\nAlgoritmos e Estruturas de Dados II\nFaculdade COTEMIG\nSomente para fins didáticos.",
               "Sobre o trabalho...",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        // Evento do menu "Abrir"
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
                openFileDialog.Title = "Abrir arquivo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivo = openFileDialog.FileName;

                    try
                    {
                        // Se for RTF, carrega como RTF, senão como texto simples
                        if (System.IO.Path.GetExtension(caminhoArquivo).ToLower() == ".rtf")
                        {
                            texto.LoadFile(caminhoArquivo, RichTextBoxStreamType.RichText);
                        }
                        else
                        {
                            texto.Text = System.IO.File.ReadAllText(caminhoArquivo, Encoding.UTF8);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this,
                            $"Erro ao abrir o arquivo:\n{ex.Message}",
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Evento do menu "Sair"
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}