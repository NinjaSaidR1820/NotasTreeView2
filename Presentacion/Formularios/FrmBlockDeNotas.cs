#region Usos
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using AplicacionConsola.Procesos;
using System.IO;
#endregion

namespace Presentacion.Formularios
{
    public partial class FrmBlockDeNotas : Form
    {
        #region Variables Globales
        string rutapath = string.Empty;
        Block texto;
        #endregion

        #region Inicializacion de Componente FrmBlockDeNotas
        public FrmBlockDeNotas(Block Texto)
        {
            this.texto = Texto;
            InitializeComponent();
        }
        #endregion

        #region Opciones de Tool Strip Menu Item Archivo
        //Nuevo Archivo Click
        private void TsmNuevo_Click(object sender, EventArgs e)
        {
            RtbNota.Text = string.Empty;
        }
        //Abrir Archivo CLick
        private void TsmAbrir_Click(object sender, EventArgs e)
        {
            TvArbol.Nodes.Clear();
            Ofd.Title = "Abrir carpeta... ";

            string text = string.Empty;

            Ofd.Filter = "Archivos de Texto (*.txt)|*.txt";
            Ofd.FilterIndex = 1;
            Ofd.RestoreDirectory = false;

            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                rutapath = Path.GetDirectoryName(Ofd.FileName);
                LoadFolder(TvArbol.Nodes, new DirectoryInfo(Path.GetDirectoryName(Ofd.FileName)));
            }
        }
        //Guardar Como... Click
        private void TsmGuardarComo_Click(object sender, EventArgs e)
        {
            Sfd.Title = "Guardar archivo como... ";

            string text = string.Empty;

            Sfd.Filter = "txt files (*.txt)|*.txt";
            Sfd.FilterIndex = 1;
            Sfd.RestoreDirectory = false;
            if (Sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(Sfd.FileName))
                {
                    MessageBox.Show(RtbNota.Text);
                    string txt = Sfd.FileName;
                    texto.Add(RtbNota.Text, txt);
                }
                else
                {
                    MessageBox.Show(RtbNota.Text);
                    string txt = Sfd.FileName;
                    texto.Add(RtbNota.Text, txt);
                }
            }
            RtbNota.Text = string.Empty;
        }
        //Salir Click
        private void TsmSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro de querer salir?", "Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion

        #region Opciones de Tool Strip Menu Item Edicion
        //Copiar Click
        private void TsmCopiar_Click(object sender, EventArgs e)
        {
            RtbNota.Copy();
        }
        //Pegar Click
        private void TsmPegar_Click(object sender, EventArgs e)
        {
            RtbNota.Paste();
        }
        //Seleccionar Todo CLick
        private void TsmSeleccionar_Click(object sender, EventArgs e)
        {
            RtbNota.SelectAll();
        }
        //Limiar Click
        private void TsmLimpiar_Click(object sender, EventArgs e)
        {
            RtbNota.Clear();
        }
        #endregion

        #region Metodos
        private void LoadFolder(TreeNodeCollection nodes, DirectoryInfo folder)
        {
            var newNode = nodes.Add(folder.Name);
            foreach (var childFolder in folder.EnumerateDirectories())
            {
                LoadFolder(newNode.Nodes, childFolder);
            }
            foreach (FileInfo file in folder.EnumerateFiles())
            {
                newNode.Nodes.Add(file.Name);
            }
        }

        private void TvArbol_DoubleClick(object sender, EventArgs e)
        {
            RtbNota.Text = string.Empty;
            string textos = string.Empty;

            textos = rutapath + "\\" + TvArbol.SelectedNode.Text;

            RtbNota.Text = texto.Read((textos));
        }
        #endregion
    }
}