using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.IO;

namespace winTreeView
{
    public partial class Form1 : Form
    {
        public StreamReader sr;                
        public StreamWriter sw;                 
        public static TreeView tvNodos;         
        public static List<Nodo> nodos;        
        public static List<Elemento> elementos; 
        string sLine;                           

        public Form1()
        {
            InitializeComponent();

            cargaDatos();   
        }

        private void cargaDatos()
        {
            try
            {
                #region "Nodos"
                nodos = new List<Nodo>();
                tvNodos = new TreeView();   //Variable temporal para almacenar los nodos
                if (File.Exists("nodos.xml"))
                {   //Si existe el XML cargamos los nodos desde el archivo
                    XmlDocument doc = new XmlDocument();
                    doc.Load("nodos.xml");
                    cargaNodosXML(doc.DocumentElement, treeNodos.Nodes);    
                    treeNodos.ExpandAll();
                    tvNodos = treeNodos;
                }
                #endregion

                #region "Elementos"
                elementos = new List<Elemento>();
                //Cargamos el archivo archivo de los elementos.  Si no existe lo creamos
                sr = new StreamReader(File.Open("elementos.txt", FileMode.OpenOrCreate));
                //Vamos leyendo líneas y añadiéndolos a la lista
                while ((sLine = sr.ReadLine()) != null)
                {
                    string _nodo, _elemento;
                    _nodo = _elemento = "";
                    int pos = 0, trobat = -1;
                    //NODO
                    trobat = sLine.IndexOf("|", pos);
                    if (trobat > -1)
                    {
                        _nodo = sLine.Substring(pos, trobat);
                        pos = trobat + 1;
                        trobat = -1;
                        sLine = sLine.Substring(pos);
                    }
                    //ELEMENTO
                    pos = 0;
                    trobat = sLine.IndexOf("|", pos);
                    if (trobat > -1)
                    {
                        _elemento = sLine.Substring(pos, trobat);
                        pos = trobat + 1;
                        trobat = -1;
                        sLine = sLine.Substring(pos);
                    }
                    //Añadimos el elemento al nodo
                    elementos.Add(new Elemento(_nodo, _elemento));
                }
                sr.Close();

                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en cargaDatos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region "NODOS"
        private void cargaNodosXML(XmlNode nodo, TreeNodeCollection nodoP)
        {
            try
            {
                if (nodo == null || nodo.NodeType == XmlNodeType.Text || nodo.NodeType == XmlNodeType.CDATA)
                    return;

                //Añadimos el nodo a la colección
                TreeNodeCollection tmpColeccion = AddNodo(nodo, nodoP);
                //Añade todos los hijos del nodo actual al treeview
                foreach (XmlNode NodoHijo in nodo.ChildNodes)
                {
                    cargaNodosXML(NodoHijo, tmpColeccion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + "\n" + ex.Message, "Error en cargaNodosXML", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TreeNodeCollection AddNodo(XmlNode nodo, TreeNodeCollection nodoP)
        {
            try
            {
                TreeNode nuevoHijo = creaNodo(nodo);
                //Si no hay nada que añadir devuelve el padre
                if (nuevoHijo == null) return nodoP;
                //Añade el nodo nuevo al padre
                if (nodoP != null) nodoP.Add(nuevoHijo);

                return nuevoHijo.Nodes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + "\n" + ex.Message, "Error AddNodo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return nodoP;
            }
        }

        private TreeNode creaNodo(XmlNode nodo)
        {
            try
            {
                TreeNode tmpNodo = new TreeNode();
                if ((nodo.HasChildNodes) && (nodo.FirstChild.Value != null))
                {
                    tmpNodo = new TreeNode(nodo.Name);
                    TreeNode tmpNodo2 = new TreeNode(nodo.FirstChild.Value);
                    tmpNodo.Nodes.Add(tmpNodo2);
                }
                else if (nodo.NodeType != XmlNodeType.CDATA)
                {
                    tmpNodo = new TreeNode(nodo.Name);
                }

                return tmpNodo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + "\n" + ex.Message, "Error en creaNodo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string recuperaindiceNodo(TreeNode nodo)
        {
            try
            {
                //Recuperamos la posición del nodo añadido
                TreeNode Tnodo = new TreeNode();
                string indice = treeNodos.SelectedNode.Index.ToString();
                Tnodo = treeNodos.SelectedNode.Parent;
                while (Tnodo != null)
                {
                    indice = Tnodo.Index.ToString() + treeNodos.PathSeparator + indice;
                    Tnodo = Tnodo.Parent;
                }

                return indice;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + "\n" + ex.Message, "Error en recuperaindiceNodo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void guardaNodosXML()
        {
            try
            {
                //Creamos el documento XML
                if (File.Exists("nodos.xml"))
                {
                    File.Delete("nodos.xml");
                }

                if (tvNodos != null)
                {
                    if (tvNodos.Nodes != null)
                    {
                        sw = new StreamWriter("nodos.xml", false, Encoding.UTF8);
                        sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");

                        foreach (TreeNode node in tvNodos.Nodes)
                        {
                            sw.WriteLine("<" + node.Text + ">");
                            nodoNuevo(node.Nodes);
                            sw.WriteLine("</" + node.Text + ">");
                        }
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + "\n" + ex.Message, "Error en Guardar Nodos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
            }

        }

        private void nodoNuevo(TreeNodeCollection treeColeccion)
        {
            try
            {
                foreach (TreeNode node in treeColeccion)
                {
                    if (node.Nodes.Count > 0)
                    {
                        sw.WriteLine("<" + node.Text + ">");
                        nodoNuevo(node.Nodes);
                        sw.WriteLine("</" + node.Text + ">");
                    }
                    else
                    {
                        sw.WriteLine("<" + node.Text + "/>");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + "\n" + ex.Message, "Error en nodoNuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
            }
        }

        private void treeNodos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                stlMensaje.Text = "";

                
                string nodo = treeNodos.SelectedNode.Text;
                
                lstElementos.Items.Clear();
               
                foreach (Elemento _elemento in elementos)
                {   
                    if (_elemento.nodo == nodo)
                    {
                        lstElementos.Items.Add(_elemento.elemento);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en treeNodos_AfterSelect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stlMensaje.Text = ex.Message;
            }
        }

        #endregion
        private void Limpiar()
        {
            stlMensaje.Text = null;
        }


        private void guardaElementos()
        {
            try
            {
                
                StreamWriter sw = new StreamWriter(File.OpenWrite("elementos.txt"));
                
                string cadena;
                foreach (Elemento item in elementos)
                {
                    cadena = item.nodo.ToString() + "|";
                    cadena += item.elemento.ToString() + "|";
                    sw.WriteLine(cadena);
                }
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + "\n" + ex.Message, "Error en guardaElementos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
            }
        }
        
        private void btnNodo_Click(object sender, EventArgs e)
        {
            string indice = "";

            try
            {
                Limpiar();

                if (txtNodo.Text == "")
                {
                    stlMensaje.Text = "Debe Asignar Un Nombre Al Folder";
                    MessageBox.Show(stlMensaje.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                TreeNode aNode = new TreeNode(txtNodo.Text.Trim());
                string nodoP, nodo;
                nodoP = nodo = "";


                //Comprueba si existen nodos
                if (treeNodos.Nodes.Count == 0)
                {   //Si no hay lo añade al nodo raíz
                    nodoP = "";
                    nodo = aNode.Text;
                    treeNodos.Nodes.Add(aNode);
                }
                else
                {
                    nodo = aNode.Text;
                    if (treeNodos.SelectedNode != null)
                    {
                        //Añadimos el nodo al treeView
                        treeNodos.SelectedNode.Nodes.Add(aNode);
                        
                        indice = recuperaindiceNodo(treeNodos.SelectedNode);
                    }
                    else
                    {
                        nodoP = "";
                        treeNodos.Nodes.Add(aNode);
                    }
                }


                nodos.Add(new Nodo(indice, nodo, nodo));        //Añade el nodo a la lista en memoria
                txtNodo.Text = "";
                treeNodos.SelectedNode = new TreeNode("Categorias"); 
                btnElemento.Enabled = true;

                treeNodos.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en btnNodo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stlMensaje.Text = ex.Message;
            }
        }

        private void btnEliminarNodo_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();

               
                if (treeNodos.SelectedNode != null)
                {  
                    if (treeNodos.SelectedNode.Nodes.Count == 0)
                    {   
                        if (lstElementos != null)
                        {
                            if (lstElementos.Items.Count > 0)
                            {
                                MessageBox.Show("Este Nodo tiene elementos.  Elimine primero los elementos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                stlMensaje.Text = "Este Nodo tiene elementos.  Elimine primero los elementos.";
                                return;
                            }
                        }
                        string nodo = treeNodos.SelectedNode.Text;
                        string indice = recuperaindiceNodo(treeNodos.SelectedNode);

                        treeNodos.Nodes.Remove(treeNodos.SelectedNode);  
                        nodos.Remove(new Nodo(indice, nodo, nodo));      

                        if (treeNodos.Nodes.Count == 0)
                            btnElemento.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Existen nodos que cuelgan de éste.  Elimínelos primero para poder eliminar éste.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        stlMensaje.Text = "Existen nodos que cuelgan de éste.  Elimínelos primero para poder eliminar éste.";
                    }
                    
                    treeNodos.SelectedNode = null;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el Nodo que desea eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stlMensaje.Text = "Debe seleccionar el Nodo que desea eliminar";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en btnEliminarNodo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stlMensaje.Text = ex.Message;
            }
        }
        
        private void btnElemento_Click(object sender, EventArgs e)
        {
            try
            {
                stlMensaje.Text = "";
                if (txtElemento.Text == "")
                {
                    MessageBox.Show("Debe teclear el elemento que desea añadir", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stlMensaje.Text = "Debe teclear el elemento que desea añadir";
                    return;
                }
                
                lstElementos.Items.Add(txtElemento.Text.Trim());
                
                string nodo = treeNodos.SelectedNode.Text;
                elementos.Add(new Elemento(nodo, txtElemento.Text.Trim()));
                txtElemento.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en btnElemento_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stlMensaje.Text = ex.Message;
            }

        }

        private void btnEliminarElem_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();

                if (lstElementos.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione Un Elemeto a Eliminar", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stlMensaje.Text = "Seleccione Un Elemeto a Eliminar";
                    lstElementos.Focus();
                    return;
                }

                int indice;
                indice = lstElementos.SelectedIndex;
                lstElementos.Items.RemoveAt(indice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en btnEliminarElem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stlMensaje.Text = ex.Message;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Estas Seguro que quieres salir?", "Registro De Estudiantes",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (r == DialogResult.Yes) this.Close();
            if (r == DialogResult.No) return;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                guardaNodosXML();
                guardaElementos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se Pudieron Guardar Los Archivos Agregados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stlMensaje.Text = ex.Message;
            }
        }




        #region Buttons Tools

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtElemento.SelectAll();
        }

        private void CopyCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtElemento.Copy();
        }

        private void PasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtElemento.Paste();
        }

        private void CleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtElemento.Clear();
        }

        #endregion

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Estas Seguro que quieres salir?", "Registro De Estudiantes",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (r == DialogResult.Yes) this.Close();
            if (r == DialogResult.No) return;

        }
    }
}
