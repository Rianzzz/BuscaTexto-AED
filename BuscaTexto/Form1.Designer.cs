namespace BuscaTexto {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forcaBrutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();              
            this.rabinKarpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kmpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boyerMooreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();


            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.texto = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.pesquisarToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(567, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "&Arquivo";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.novoToolStripMenuItem.Text = "&Novo";
            this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.abrirToolStripMenuItem.Text = "A&brir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.sairToolStripMenuItem.Text = "&Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // pesquisarToolStripMenuItem
            // 
            this.pesquisarToolStripMenuItem.Name = "pesquisarToolStripMenuItem";
            this.pesquisarToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.pesquisarToolStripMenuItem.Text = "&Pesquisar";
            this.forcaBrutaToolStripMenuItem.Name = "forcaBrutaToolStripMenuItem";
            this.forcaBrutaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.forcaBrutaToolStripMenuItem.Text = "Força Bruta";
            this.forcaBrutaToolStripMenuItem.Click += new System.EventHandler(this.forcaBrutaToolStripMenuItem_Click);
            this.pesquisarToolStripMenuItem.DropDownItems.Add(this.forcaBrutaToolStripMenuItem);
            this.rabinKarpToolStripMenuItem.Name = "rabinKarpToolStripMenuItem";
            this.rabinKarpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rabinKarpToolStripMenuItem.Text = "Rabin-Karp";
            this.rabinKarpToolStripMenuItem.Click += new System.EventHandler(this.rabinKarpToolStripMenuItem_Click);
            this.pesquisarToolStripMenuItem.DropDownItems.Add(this.rabinKarpToolStripMenuItem);
            this.kmpToolStripMenuItem.Name = "kmpToolStripMenuItem";
            this.kmpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kmpToolStripMenuItem.Text = "KMP";
            this.kmpToolStripMenuItem.Click += new System.EventHandler(this.kmpToolStripMenuItem_Click);
            this.pesquisarToolStripMenuItem.DropDownItems.Add(this.kmpToolStripMenuItem);
            this.boyerMooreToolStripMenuItem.Name = "boyerMooreToolStripMenuItem";
            this.boyerMooreToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.boyerMooreToolStripMenuItem.Text = "Boyer-Moore";
            this.boyerMooreToolStripMenuItem.Click += new System.EventHandler(this.boyerMooreToolStripMenuItem_Click);
            this.pesquisarToolStripMenuItem.DropDownItems.Add(this.boyerMooreToolStripMenuItem);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "A&juda";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.sobreToolStripMenuItem.Text = "S&obre...";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // texto
            // 
            this.texto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texto.Location = new System.Drawing.Point(0, 24);
            this.texto.Name = "texto";
            this.texto.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.texto.Size = new System.Drawing.Size(567, 430);
            this.texto.TabIndex = 1;
            this.texto.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 454);
            this.Controls.Add(this.texto);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trabalho Prático - Busca em Texto 2025.1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesquisarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forcaBrutaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rabinKarpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kmpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boyerMooreToolStripMenuItem;
        private System.Windows.Forms.RichTextBox texto;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        
    }
}

