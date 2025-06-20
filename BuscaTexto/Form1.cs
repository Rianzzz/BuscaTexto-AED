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

namespace BuscaTexto {
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

        // Evento do menu "Força Bruta" - busca e destaca ocorrências usando o algoritmo de força bruta
        private void forcaBrutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Limpa destaques anteriores
            texto.SelectAll();
            texto.SelectionBackColor = Color.White;

            // Solicita ao usuário o termo de busca
            string padrao = Interaction.InputBox("Digite o termo a ser pesquisado:", "Força Bruta", "");

            // Se o usuário cancelar ou não digitar nada, sai do método
            if (string.IsNullOrEmpty(padrao))
                return;

            string conteudo = texto.Text; // Texto a ser pesquisado
            int inicio = 0; // Posição inicial da busca
            int idx; // Índice da ocorrência encontrada

            Random rand = new Random(); // Gerador de cores aleatórias

            // Busca todas as ocorrências do padrão no texto
            while (inicio < conteudo.Length)
            {
                idx = BuscaForcaBruta.forcaBruta(padrao, conteudo.Substring(inicio));
                if (idx == -1)
                    break;

                // Destaca a ocorrência encontrada com uma cor aleatória
                Color corAleatoria = Color.FromArgb(
                    255,
                    rand.Next(256),
                    rand.Next(256),
                    rand.Next(256)
                );

                texto.Select(inicio + idx, padrao.Length);
                texto.SelectionBackColor = corAleatoria;
                inicio += idx + padrao.Length; // Avança para buscar a próxima ocorrência
            }

            texto.SelectionLength = 0; // Remove seleção ao final
        }

        // Evento do menu "Rabin-Karp" - busca e destaca ocorrências usando o algoritmo Rabin-Karp
        private void rabinKarpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texto.SelectAll();
            texto.SelectionBackColor = Color.White;

            string padrao = Interaction.InputBox("Digite o termo a ser pesquisado:", "Rabin-Karp", "");

            if (string.IsNullOrEmpty(padrao))
                return;

            string conteudo = texto.Text;
            int inicio = 0;
            int idx;

            Random rand = new Random();

            while (inicio < conteudo.Length)
            {
                idx = BuscaRabinKarp.RKSearch(padrao, conteudo.Substring(inicio));
                if (idx == -1)
                    break;

                Color corAleatoria = Color.FromArgb(
                    255,
                    rand.Next(256),
                    rand.Next(256),
                    rand.Next(256)
                );

                texto.Select(inicio + idx, padrao.Length);
                texto.SelectionBackColor = corAleatoria;
                inicio += idx + padrao.Length;
            }

            texto.SelectionLength = 0;
        }

        // Evento do menu "KMP" - busca e destaca ocorrências usando o algoritmo KMP
        private void kmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texto.SelectAll();
            texto.SelectionBackColor = Color.White;

            string padrao = Interaction.InputBox("Digite o termo a ser pesquisado:", "KMP", "");

            if (string.IsNullOrEmpty(padrao))
                return;

            string conteudo = texto.Text;
            int inicio = 0;
            int idx;

            Random rand = new Random();

            while (inicio < conteudo.Length)
            {
                idx = BuscaKMP.KMPSearch(padrao, conteudo.Substring(inicio));
                if (idx == -1)
                    break;

                Color corAleatoria = Color.FromArgb(
                    255,
                    rand.Next(256),
                    rand.Next(256),
                    rand.Next(256)
                );

                texto.Select(inicio + idx, padrao.Length);
                texto.SelectionBackColor = corAleatoria;
                inicio += idx + padrao.Length;
            }

            texto.SelectionLength = 0;
        }

        // Evento do menu "Boyer-Moore" - busca e destaca ocorrências usando o algoritmo Boyer-Moore
        private void boyerMooreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texto.SelectAll();
            texto.SelectionBackColor = Color.White;

            string padrao = Interaction.InputBox("Digite o termo a ser pesquisado:", "Boyer-Moore", "");

            if (string.IsNullOrEmpty(padrao))
                return;

            string conteudo = texto.Text;
            int inicio = 0;
            int idx;

            Random rand = new Random();

            while (inicio < conteudo.Length)
            {
                idx = BuscaBoyerMoore.BMSearch(padrao, conteudo.Substring(inicio));
                if (idx == -1)
                    break;

                Color corAleatoria = Color.FromArgb(
                    255,
                    rand.Next(256),
                    rand.Next(256),
                    rand.Next(256)
                );

                texto.Select(inicio + idx, padrao.Length);
                texto.SelectionBackColor = corAleatoria;
                inicio += idx + padrao.Length;
            }

            texto.SelectionLength = 0;
        }

        // Evento do menu "Sobre" - exibe informações sobre o trabalho
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Complete com seu nome e código de matrícula
            MessageBox.Show(this,
               "Busca em Texto - 2025/1\n\nDesenvolvido por: Rian Nascimento Alves e Rafael Augusto\n72301015 e 7230????\nProf. Virgílio Borges de Oliveira\n\nAlgoritmos e Estruturas de Dados II\nFaculdade COTEMIG\nSomente para fins didáticos.",
               "Sobre o trabalho...",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        // Evento do menu "Abrir" - permite abrir arquivos de texto ou RTF
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
                openFileDialog.Title = "Abrir arquivo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivo = openFileDialog.FileName;

                    // Se for RTF, carrega como RTF, senão como texto simples
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

        // Evento do menu "Sair" - fecha a aplicação
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
