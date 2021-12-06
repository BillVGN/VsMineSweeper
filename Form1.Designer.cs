
namespace MyMineSweeper
{
    partial class Board
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemNovo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSair = new System.Windows.Forms.ToolStripMenuItem();
            this.tblpnlStatusBar = new System.Windows.Forms.TableLayoutPanel();
            this.lblMines = new System.Windows.Forms.Label();
            this.lblCoins = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.tblpnlStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNovo,
            this.menuItemConfig,
            this.menuItemSair});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // menuItemNovo
            // 
            this.menuItemNovo.Name = "menuItemNovo";
            resources.ApplyResources(this.menuItemNovo, "menuItemNovo");
            this.menuItemNovo.Click += new System.EventHandler(this.menuItemNovo_Click);
            // 
            // menuItemConfig
            // 
            this.menuItemConfig.Name = "menuItemConfig";
            resources.ApplyResources(this.menuItemConfig, "menuItemConfig");
            this.menuItemConfig.Click += new System.EventHandler(this.menuItemConfig_Click_1);
            // 
            // menuItemSair
            // 
            this.menuItemSair.Name = "menuItemSair";
            resources.ApplyResources(this.menuItemSair, "menuItemSair");
            this.menuItemSair.Click += new System.EventHandler(this.menuItemSair_Click);
            // 
            // tblpnlStatusBar
            // 
            resources.ApplyResources(this.tblpnlStatusBar, "tblpnlStatusBar");
            this.tblpnlStatusBar.Controls.Add(this.lblMines, 0, 0);
            this.tblpnlStatusBar.Controls.Add(this.lblCoins, 1, 0);
            this.tblpnlStatusBar.Controls.Add(this.lblTime, 2, 0);
            this.tblpnlStatusBar.Name = "tblpnlStatusBar";
            // 
            // lblMines
            // 
            resources.ApplyResources(this.lblMines, "lblMines");
            this.lblMines.Name = "lblMines";
            // 
            // lblCoins
            // 
            resources.ApplyResources(this.lblCoins, "lblCoins");
            this.lblCoins.Name = "lblCoins";
            // 
            // lblTime
            // 
            resources.ApplyResources(this.lblTime, "lblTime");
            this.lblTime.Name = "lblTime";
            // 
            // pnlBoard
            // 
            resources.ApplyResources(this.pnlBoard, "pnlBoard");
            this.pnlBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBoard.Name = "pnlBoard";
            // 
            // Board
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.tblpnlStatusBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Board";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tblpnlStatusBar.ResumeLayout(false);
            this.tblpnlStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemNovo;
        private System.Windows.Forms.TableLayoutPanel tblpnlStatusBar;
        private System.Windows.Forms.Label lblMines;
        private System.Windows.Forms.Label lblCoins;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.ToolStripMenuItem menuItemSair;
        private System.Windows.Forms.ToolStripMenuItem menuItemConfig;
    }
}

