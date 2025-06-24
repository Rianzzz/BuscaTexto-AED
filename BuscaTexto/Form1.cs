using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic; // Importação para funcionalidades do Visual Basic

namespace BuscaTexto
{
    /// <summary>
    /// Classe principal do formulário da aplicação de busca em texto.
    /// Esta aplicação implementa diferentes algoritmos de busca de padrões em texto:
    /// - Força Bruta
    /// - Rabin-Karp  
    /// - KMP (Knuth-Morris-Pratt)
    /// - Boyer-Moore
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Construtor do formulário principal.
        /// Inicializa os componentes da interface gráfica.
        /// </summary>
        public Form1()
        {
            InitializeComponent(); // Inicializa os controles do formulário
        }

        /// <summary>
        /// Evento do menu "Novo" - limpa o conteúdo do RichTextBox.
        /// Permite ao usuário iniciar um novo documento limpando todo o texto.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento</param>
        /// <param name="e">Argumentos do evento</param>
        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texto.Text = ""; // Limpa todo o conteúdo do RichTextBox
        }

        /// <summary>
        /// Método auxiliar para obter dados de busca do usuário através de um formulário modal.
        /// Centraliza a lógica de coleta de dados para evitar repetição de código.
        /// </summary>
        /// <param name="titulo">Título do formulário de busca a ser exibido</param>
        /// <returns>
        /// Uma tupla contendo:
        /// - padrao: O texto a ser buscado
        /// - substituicao: O texto para substituição (se aplicável)
        /// - caseSensitive: Se a busca deve considerar maiúsculas/minúsculas
        /// - substituir: Se deve realizar substituição além da busca
        /// </returns>
        private (string padrao, string substituicao, bool caseSensitive, bool substituir) ObterDadosBusca(string titulo)
        {
            // Cria uma instância do formulário de busca usando 'using' para garantir disposal
            using (var form = new FormBusca(titulo))
            {
                // Exibe o formulário como modal e verifica se o usuário clicou OK
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Retorna os dados coletados do formulário
                    return (form.Padrao, form.Substituicao, form.CaseSensitive, form.Substituir);
                }
            }
            // Retorna valores padrão se o usuário cancelou
            return (null, null, true, false);
        }

        /// <summary>
        /// Método auxiliar para destacar ocorrências encontradas no texto ou realizar substituições.
        /// Centraliza a lógica de exibição de resultados para todos os algoritmos de busca.
        /// </summary>
        /// <param name="posicoes">Lista com as posições onde o padrão foi encontrado</param>
        /// <param name="padrao">O padrão que foi buscado</param>
        /// <param name="substituicao">Texto para substituição</param>
        /// <param name="substituir">Flag indicando se deve substituir ou apenas destacar</param>
        private void DestacarOcorrencias(List<int> posicoes, string padrao, string substituicao, bool substituir)
        {
            // Verifica se foram encontradas ocorrências
            if (posicoes.Count == 0)
            {
                // Exibe mensagem informando que nenhuma ocorrência foi encontrada
                MessageBox.Show(this,
                    "O termo pesquisado não foi encontrado no texto.",
                    "Nenhuma ocorrência encontrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // Se foi solicitada substituição e há texto de substituição
            if (substituir && !string.IsNullOrEmpty(substituicao))
            {
                // Ordena as posições em ordem decrescente para substituir de trás para frente
                // Isso evita que as posições sejam alteradas durante o processo de substituição
                var posicoesOrdenadas = posicoes.OrderByDescending(p => p).ToList();
                string textoAtual = texto.Text;

                // Realiza as substituições
                foreach (int pos in posicoesOrdenadas)
                {
                    // Remove o padrão original na posição encontrada
                    textoAtual = textoAtual.Remove(pos, padrao.Length);
                    // Insere o texto de substituição na mesma posição
                    textoAtual = textoAtual.Insert(pos, substituicao);
                }

                // Atualiza o texto no RichTextBox
                texto.Text = textoAtual;

                // Exibe mensagem de sucesso da substituição
                MessageBox.Show(this,
                    $"{posicoes.Count} ocorrência(s) substituída(s) com sucesso!",
                    "Substituição concluída",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                // Modo de apenas destacar as ocorrências (sem substituir)
                Random rand = new Random(); // Para gerar cores aleatórias

                // Destaca cada ocorrência encontrada
                foreach (int pos in posicoes)
                {
                    // Gera uma cor aleatória clara para melhor legibilidade
                    Color corAleatoria = Color.FromArgb(
                        255,                    // Canal alpha (opacidade total)
                        rand.Next(128, 256),   // Red (valores entre 128-255 para cores claras)
                        rand.Next(128, 256),   // Green
                        rand.Next(128, 256)    // Blue
                    );

                    // Seleciona o texto na posição encontrada
                    texto.Select(pos, padrao.Length);
                    // Aplica a cor de fundo à seleção
                    texto.SelectionBackColor = corAleatoria;
                }

                // Remove a seleção atual (para não deixar texto selecionado)
                texto.SelectionLength = 0;

                // Exibe mensagem informando quantas ocorrências foram encontradas
                MessageBox.Show(this,
                    $"{posicoes.Count} ocorrência(s) encontrada(s) e destacada(s)!",
                    "Busca concluída",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Evento do menu "Força Bruta" - executa busca usando algoritmo de força bruta.
        /// O algoritmo de força bruta compara o padrão com cada posição possível no texto.
        /// É o mais simples mas também o menos eficiente para textos grandes.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento</param>
        /// <param name="e">Argumentos do evento</param>
        private void forcaBrutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Limpa destaques anteriores selecionando todo o texto
            texto.SelectAll();
            texto.SelectionBackColor = Color.White; // Remove cores de fundo
            texto.SelectionLength = 0; // Remove seleção

            // Obtém os dados de busca do usuário
            var dados = ObterDadosBusca("Força Bruta");
            if (dados.padrao == null) return; // Sai se o usuário cancelou

            string conteudo = texto.Text;
            // Executa a busca usando o algoritmo de força bruta
            var posicoes = BuscaForcaBruta.forcaBruta(dados.padrao, conteudo, dados.caseSensitive);

            // Processa e exibe os resultados
            DestacarOcorrencias(posicoes, dados.padrao, dados.substituicao, dados.substituir);
        }

        /// <summary>
        /// Evento do menu "Rabin-Karp" - executa busca usando algoritmo Rabin-Karp.
        /// O algoritmo Rabin-Karp usa hash para comparar padrões, sendo mais eficiente
        /// que força bruta em muitos casos, especialmente com padrões longos.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento</param>
        /// <param name="e">Argumentos do evento</param>
        private void rabinKarpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Limpa destaques anteriores
            texto.SelectAll();
            texto.SelectionBackColor = Color.White;
            texto.SelectionLength = 0;

            // Obtém os dados de busca do usuário
            var dados = ObterDadosBusca("Rabin-Karp");
            if (dados.padrao == null) return;

            string conteudo = texto.Text;
            // Executa a busca usando o algoritmo Rabin-Karp
            var posicoes = BuscaRabinKarp.RKSearchAll(dados.padrao, conteudo, dados.caseSensitive);

            // Processa e exibe os resultados
            DestacarOcorrencias(posicoes, dados.padrao, dados.substituicao, dados.substituir);
        }

        /// <summary>
        /// Evento do menu "KMP" - executa busca usando algoritmo Knuth-Morris-Pratt.
        /// O algoritmo KMP é muito eficiente pois evita comparações desnecessárias
        /// usando informações sobre o próprio padrão para "pular" posições.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento</param>
        /// <param name="e">Argumentos do evento</param>
        private void kmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Limpa destaques anteriores
            texto.SelectAll();
            texto.SelectionBackColor = Color.White;
            texto.SelectionLength = 0;

            // Obtém os dados de busca do usuário
            var dados = ObterDadosBusca("KMP");
            if (dados.padrao == null) return;

            string conteudo = texto.Text;
            // Executa a busca usando o algoritmo KMP
            var posicoes = BuscaKMP.KMPSearchAll(dados.padrao, conteudo, dados.caseSensitive);

            // Processa e exibe os resultados
            DestacarOcorrencias(posicoes, dados.padrao, dados.substituicao, dados.substituir);
        }

        /// <summary>
        /// Evento do menu "Boyer-Moore" - executa busca usando algoritmo Boyer-Moore.
        /// O algoritmo Boyer-Moore é muito eficiente, especialmente para padrões longos,
        /// pois pode "pular" várias posições baseado em caracteres que não casam.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento</param>
        /// <param name="e">Argumentos do evento</param>
        private void boyerMooreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Limpa destaques anteriores
            texto.SelectAll();
            texto.SelectionBackColor = Color.White;
            texto.SelectionLength = 0;

            // Obtém os dados de busca do usuário
            var dados = ObterDadosBusca("Boyer-Moore");
            if (dados.padrao == null) return;

            string conteudo = texto.Text;
            // Executa a busca usando o algoritmo Boyer-Moore
            var posicoes = BuscaBoyerMoore.BMSearchAll(dados.padrao, conteudo, dados.caseSensitive);

            // Processa e exibe os resultados
            DestacarOcorrencias(posicoes, dados.padrao, dados.substituicao, dados.substituir);
        }

        /// <summary>
        /// Evento do menu "Sobre" - exibe informações sobre o projeto e desenvolvedores.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento</param>
        /// <param name="e">Argumentos do evento</param>
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exibe uma caixa de diálogo com informações do projeto
            MessageBox.Show(this,
               "Busca em Texto - 2025/1\n\n" +
               "Desenvolvido por: Rian Nascimento Alves e Rafael Augusto\n" +
               "72301015 e 72301350\n" +
               "Prof. Roselene Henrique Pereira Costa\n\n" +
               "Algoritmos e Estruturas de Dados II\n" +
               "Faculdade COTEMIG\n" +
               "Somente para fins didáticos.",
               "Sobre o trabalho...",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        /// <summary>
        /// Evento do menu "Abrir" - permite ao usuário carregar um arquivo de texto.
        /// Suporta arquivos .txt (texto simples) e .rtf (Rich Text Format).
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento</param>
        /// <param name="e">Argumentos do evento</param>
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria e configura o diálogo de abertura de arquivo
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Define os filtros de arquivo disponíveis
                openFileDialog.Filter =
                    "Arquivos de Texto e RTF (*.txt;*.rtf)|*.txt;*.rtf|" +
                    "Arquivos de Texto (*.txt)|*.txt|" +
                    "Rich Text Format (*.rtf)|*.rtf|" +
                    "Todos os arquivos (*.*)|*.*";
                openFileDialog.FilterIndex = 1; // Define o primeiro filtro como padrão
                openFileDialog.Title = "Abrir arquivo";

                // Exibe o diálogo e verifica se o usuário selecionou um arquivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivo = openFileDialog.FileName;
                    try
                    {
                        // Verifica a extensão do arquivo para determinar como carregá-lo
                        if (System.IO.Path.GetExtension(caminhoArquivo).ToLower() == ".rtf")
                        {
                            // Para arquivos RTF, carrega mantendo a formatação
                            texto.LoadFile(caminhoArquivo, RichTextBoxStreamType.RichText);
                        }
                        else
                        {
                            // Para outros arquivos, carrega como texto simples com codificação UTF-8
                            texto.Text = System.IO.File.ReadAllText(caminhoArquivo, Encoding.UTF8);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Exibe mensagem de erro se não conseguir abrir o arquivo
                        MessageBox.Show(this,
                            $"Erro ao abrir o arquivo:\n{ex.Message}",
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Evento do menu "Sair" - encerra a aplicação.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento</param>
        /// <param name="e">Argumentos do evento</param>
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Encerra a aplicação
        }
    }
}