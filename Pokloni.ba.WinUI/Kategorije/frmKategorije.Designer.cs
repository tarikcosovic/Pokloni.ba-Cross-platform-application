﻿namespace Pokloni.ba.WinUI.Kategorije
{
    partial class frmKategorije
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
            System.Windows.Forms.ColumnHeader Dummy;
            this.listaKategorija = new MaterialSkin.Controls.MaterialListView();
            this.test1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.test2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPrikazi = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtPretraga = new MaterialSkin.Controls.MaterialSingleLineTextField();
            Dummy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Dummy
            // 
            Dummy.Text = "";
            Dummy.Width = 0;
            // 
            // listaKategorija
            // 
            this.listaKategorija.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listaKategorija.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listaKategorija.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Dummy,
            this.test1,
            this.test2});
            this.listaKategorija.Depth = 0;
            this.listaKategorija.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listaKategorija.FullRowSelect = true;
            this.listaKategorija.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listaKategorija.Location = new System.Drawing.Point(56, 143);
            this.listaKategorija.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listaKategorija.MouseState = MaterialSkin.MouseState.OUT;
            this.listaKategorija.Name = "listaKategorija";
            this.listaKategorija.OwnerDraw = true;
            this.listaKategorija.Size = new System.Drawing.Size(722, 411);
            this.listaKategorija.TabIndex = 9;
            this.listaKategorija.UseCompatibleStateImageBehavior = false;
            this.listaKategorija.View = System.Windows.Forms.View.Details;
            this.listaKategorija.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListaKategorija_MouseDoubleClick);
            // 
            // test1
            // 
            this.test1.Text = "Naziv";
            this.test1.Width = 146;
            // 
            // test2
            // 
            this.test2.Text = "Opis";
            this.test2.Width = 303;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.AutoSize = true;
            this.btnPrikazi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrikazi.Depth = 0;
            this.btnPrikazi.Icon = null;
            this.btnPrikazi.Location = new System.Drawing.Point(542, 83);
            this.btnPrikazi.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Primary = true;
            this.btnPrikazi.Size = new System.Drawing.Size(84, 36);
            this.btnPrikazi.TabIndex = 8;
            this.btnPrikazi.Text = "Pretraži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.BtnPrikazi_Click_1);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Depth = 0;
            this.txtPretraga.Hint = "";
            this.txtPretraga.Location = new System.Drawing.Point(56, 96);
            this.txtPretraga.MaxLength = 32767;
            this.txtPretraga.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.PasswordChar = '\0';
            this.txtPretraga.SelectedText = "";
            this.txtPretraga.SelectionLength = 0;
            this.txtPretraga.SelectionStart = 0;
            this.txtPretraga.Size = new System.Drawing.Size(454, 23);
            this.txtPretraga.TabIndex = 7;
            this.txtPretraga.TabStop = false;
            this.txtPretraga.UseSystemPasswordChar = false;
            // 
            // frmKategorije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 566);
            this.Controls.Add(this.listaKategorija);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.txtPretraga);
            this.Name = "frmKategorije";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kategorije";
            this.Load += new System.EventHandler(this.FrmKategorije_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialListView listaKategorija;
        private System.Windows.Forms.ColumnHeader test1;
        private System.Windows.Forms.ColumnHeader test2;
        private MaterialSkin.Controls.MaterialRaisedButton btnPrikazi;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPretraga;
    }
}