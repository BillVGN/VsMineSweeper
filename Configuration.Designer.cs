
namespace MyMineSweeper
{
    partial class Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.numMinesQty = new System.Windows.Forms.NumericUpDown();
            this.lblQtdeMinas = new System.Windows.Forms.Label();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.lblLinhas = new System.Windows.Forms.Label();
            this.lblColunas = new System.Windows.Forms.Label();
            this.lblCoinsTip = new System.Windows.Forms.Label();
            this.numCols = new System.Windows.Forms.NumericUpDown();
            this.numCoinsTip = new System.Windows.Forms.NumericUpDown();
            this.lblNível = new System.Windows.Forms.Label();
            this.cmbNivel = new System.Windows.Forms.ComboBox();
            this.numCellSize = new System.Windows.Forms.NumericUpDown();
            this.lblCellSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMinesQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoinsTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCellSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            resources.ApplyResources(this.btnSalvar, "btnSalvar");
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // numMinesQty
            // 
            resources.ApplyResources(this.numMinesQty, "numMinesQty");
            this.numMinesQty.Maximum = new decimal(new int[] {
            479,
            0,
            0,
            0});
            this.numMinesQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinesQty.Name = "numMinesQty";
            this.numMinesQty.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // lblQtdeMinas
            // 
            resources.ApplyResources(this.lblQtdeMinas, "lblQtdeMinas");
            this.lblQtdeMinas.Name = "lblQtdeMinas";
            // 
            // numRows
            // 
            resources.ApplyResources(this.numRows, "numRows");
            this.numRows.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numRows.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numRows.Name = "numRows";
            this.numRows.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // lblLinhas
            // 
            resources.ApplyResources(this.lblLinhas, "lblLinhas");
            this.lblLinhas.Name = "lblLinhas";
            // 
            // lblColunas
            // 
            resources.ApplyResources(this.lblColunas, "lblColunas");
            this.lblColunas.Name = "lblColunas";
            // 
            // lblCoinsTip
            // 
            resources.ApplyResources(this.lblCoinsTip, "lblCoinsTip");
            this.lblCoinsTip.Name = "lblCoinsTip";
            // 
            // numCols
            // 
            resources.ApplyResources(this.numCols, "numCols");
            this.numCols.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numCols.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numCols.Name = "numCols";
            this.numCols.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numCoinsTip
            // 
            resources.ApplyResources(this.numCoinsTip, "numCoinsTip");
            this.numCoinsTip.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCoinsTip.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCoinsTip.Name = "numCoinsTip";
            this.numCoinsTip.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblNível
            // 
            resources.ApplyResources(this.lblNível, "lblNível");
            this.lblNível.Name = "lblNível";
            // 
            // cmbNivel
            // 
            resources.ApplyResources(this.cmbNivel, "cmbNivel");
            this.cmbNivel.DisplayMember = "Personalizado";
            this.cmbNivel.FormattingEnabled = true;
            this.cmbNivel.Items.AddRange(new object[] {
            resources.GetString("cmbNivel.Items"),
            resources.GetString("cmbNivel.Items1"),
            resources.GetString("cmbNivel.Items2"),
            resources.GetString("cmbNivel.Items3")});
            this.cmbNivel.Name = "cmbNivel";
            // 
            // numCellSize
            // 
            resources.ApplyResources(this.numCellSize, "numCellSize");
            this.numCellSize.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numCellSize.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numCellSize.Name = "numCellSize";
            this.numCellSize.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // lblCellSize
            // 
            resources.ApplyResources(this.lblCellSize, "lblCellSize");
            this.lblCellSize.Name = "lblCellSize";
            // 
            // Configuration
            // 
            this.AcceptButton = this.btnSalvar;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.Controls.Add(this.numCellSize);
            this.Controls.Add(this.lblCellSize);
            this.Controls.Add(this.cmbNivel);
            this.Controls.Add(this.lblNível);
            this.Controls.Add(this.numCoinsTip);
            this.Controls.Add(this.numCols);
            this.Controls.Add(this.lblCoinsTip);
            this.Controls.Add(this.lblColunas);
            this.Controls.Add(this.lblLinhas);
            this.Controls.Add(this.numRows);
            this.Controls.Add(this.lblQtdeMinas);
            this.Controls.Add(this.numMinesQty);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.numMinesQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoinsTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCellSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.NumericUpDown numMinesQty;
        private System.Windows.Forms.Label lblQtdeMinas;
        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.Label lblLinhas;
        private System.Windows.Forms.Label lblColunas;
        private System.Windows.Forms.Label lblCoinsTip;
        private System.Windows.Forms.NumericUpDown numCols;
        private System.Windows.Forms.NumericUpDown numCoinsTip;
        private System.Windows.Forms.Label lblNível;
        private System.Windows.Forms.ComboBox cmbNivel;
        private System.Windows.Forms.NumericUpDown numCellSize;
        private System.Windows.Forms.Label lblCellSize;
    }
}