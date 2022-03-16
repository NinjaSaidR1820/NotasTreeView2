namespace Presentacion.Formularios
{
    partial class FrmBlockDeNotas
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
            this.MsOpciones = new System.Windows.Forms.MenuStrip();
            this.TsmArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmGuardarComo = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmEdiciones = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmPegar = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmSeleccionar = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmLimpiar = new System.Windows.Forms.ToolStripMenuItem();
            this.Ofd = new System.Windows.Forms.OpenFileDialog();
            this.Sfd = new System.Windows.Forms.SaveFileDialog();
            this.CD = new System.Windows.Forms.ColorDialog();
            this.TvArbol = new System.Windows.Forms.TreeView();
            this.RtbNota = new System.Windows.Forms.RichTextBox();
            this.MsOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // MsOpciones
            // 
            this.MsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmArchivo,
            this.TsmEdiciones});
            this.MsOpciones.Location = new System.Drawing.Point(0, 0);
            this.MsOpciones.Name = "MsOpciones";
            this.MsOpciones.Size = new System.Drawing.Size(784, 24);
            this.MsOpciones.TabIndex = 1;
            this.MsOpciones.Text = "menuStrip1";
            // 
            // TsmArchivo
            // 
            this.TsmArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmNuevo,
            this.TsmAbrir,
            this.TsmGuardarComo,
            this.TsmSalir});
            this.TsmArchivo.Name = "TsmArchivo";
            this.TsmArchivo.Size = new System.Drawing.Size(60, 20);
            this.TsmArchivo.Text = "Archivo";
            // 
            // TsmNuevo
            // 
            this.TsmNuevo.Name = "TsmNuevo";
            this.TsmNuevo.Size = new System.Drawing.Size(180, 22);
            this.TsmNuevo.Text = "Nuevo Archivo";
            this.TsmNuevo.Click += new System.EventHandler(this.TsmNuevo_Click);
            // 
            // TsmAbrir
            // 
            this.TsmAbrir.Name = "TsmAbrir";
            this.TsmAbrir.Size = new System.Drawing.Size(180, 22);
            this.TsmAbrir.Text = "Abrir Archivo";
            this.TsmAbrir.Click += new System.EventHandler(this.TsmAbrir_Click);
            // 
            // TsmGuardarComo
            // 
            this.TsmGuardarComo.Name = "TsmGuardarComo";
            this.TsmGuardarComo.ShowShortcutKeys = false;
            this.TsmGuardarComo.Size = new System.Drawing.Size(180, 22);
            this.TsmGuardarComo.Text = "Guardar Como...";
            this.TsmGuardarComo.Click += new System.EventHandler(this.TsmGuardarComo_Click);
            // 
            // TsmSalir
            // 
            this.TsmSalir.Name = "TsmSalir";
            this.TsmSalir.Size = new System.Drawing.Size(180, 22);
            this.TsmSalir.Text = "Salir";
            this.TsmSalir.Click += new System.EventHandler(this.TsmSalir_Click);
            // 
            // TsmEdiciones
            // 
            this.TsmEdiciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmCopiar,
            this.TsmPegar,
            this.TsmSeleccionar,
            this.TsmLimpiar});
            this.TsmEdiciones.Name = "TsmEdiciones";
            this.TsmEdiciones.Size = new System.Drawing.Size(58, 20);
            this.TsmEdiciones.Text = "Edicion";
            // 
            // TsmCopiar
            // 
            this.TsmCopiar.Name = "TsmCopiar";
            this.TsmCopiar.Size = new System.Drawing.Size(180, 22);
            this.TsmCopiar.Text = "Copiar";
            this.TsmCopiar.Click += new System.EventHandler(this.TsmCopiar_Click);
            // 
            // TsmPegar
            // 
            this.TsmPegar.Name = "TsmPegar";
            this.TsmPegar.Size = new System.Drawing.Size(180, 22);
            this.TsmPegar.Text = "Pegar";
            this.TsmPegar.Click += new System.EventHandler(this.TsmPegar_Click);
            // 
            // TsmSeleccionar
            // 
            this.TsmSeleccionar.Name = "TsmSeleccionar";
            this.TsmSeleccionar.Size = new System.Drawing.Size(180, 22);
            this.TsmSeleccionar.Text = "Seleccionar Todo";
            this.TsmSeleccionar.Click += new System.EventHandler(this.TsmSeleccionar_Click);
            // 
            // TsmLimpiar
            // 
            this.TsmLimpiar.Name = "TsmLimpiar";
            this.TsmLimpiar.Size = new System.Drawing.Size(180, 22);
            this.TsmLimpiar.Text = "Limpiar";
            this.TsmLimpiar.Click += new System.EventHandler(this.TsmLimpiar_Click);
            // 
            // Ofd
            // 
            this.Ofd.FileName = "openFileDialog1";
            // 
            // TvArbol
            // 
            this.TvArbol.Location = new System.Drawing.Point(12, 27);
            this.TvArbol.Name = "TvArbol";
            this.TvArbol.Size = new System.Drawing.Size(131, 420);
            this.TvArbol.TabIndex = 4;
            this.TvArbol.DoubleClick += new System.EventHandler(this.TvArbol_DoubleClick);
            // 
            // RtbNota
            // 
            this.RtbNota.Location = new System.Drawing.Point(149, 27);
            this.RtbNota.Name = "RtbNota";
            this.RtbNota.Size = new System.Drawing.Size(534, 420);
            this.RtbNota.TabIndex = 3;
            this.RtbNota.Text = "";
            // 
            // FrmBlockDeNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.TvArbol);
            this.Controls.Add(this.RtbNota);
            this.Controls.Add(this.MsOpciones);
            this.Name = "FrmBlockDeNotas";
            this.Text = "Block De Notas";
            this.MsOpciones.ResumeLayout(false);
            this.MsOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MsOpciones;
        private System.Windows.Forms.ToolStripMenuItem TsmArchivo;
        private System.Windows.Forms.ToolStripMenuItem TsmNuevo;
        private System.Windows.Forms.ToolStripMenuItem TsmAbrir;
        private System.Windows.Forms.ToolStripMenuItem TsmGuardarComo;
        private System.Windows.Forms.ToolStripMenuItem TsmSalir;
        private System.Windows.Forms.ToolStripMenuItem TsmEdiciones;
        private System.Windows.Forms.ToolStripMenuItem TsmCopiar;
        private System.Windows.Forms.ToolStripMenuItem TsmPegar;
        private System.Windows.Forms.ToolStripMenuItem TsmSeleccionar;
        private System.Windows.Forms.ToolStripMenuItem TsmLimpiar;
        private System.Windows.Forms.OpenFileDialog Ofd;
        private System.Windows.Forms.SaveFileDialog Sfd;
        private System.Windows.Forms.ColorDialog CD;
        private System.Windows.Forms.TreeView TvArbol;
        private System.Windows.Forms.RichTextBox RtbNota;
    }
}