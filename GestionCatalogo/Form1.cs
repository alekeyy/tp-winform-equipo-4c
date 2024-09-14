using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace GestionCatalogo
{
    public partial class Form1 : Form
    {
        // lista local
        private List<Articulos> listaArticulos;
        public Form1()
        {
            InitializeComponent();
        }

        //Apenas carga la aplicacion, se ejecutara esto
        private void Form1_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            listaArticulos = negocio.listar();
            dgvCatalogo.DataSource = listaArticulos;
            //cargar imagen
            cargarImagen(listaArticulos[0].Imagen.UrlImagen);

            //oculto ids de marca y categoria
            dgvCatalogo.Columns["IdMarca"].Visible = false;
            dgvCatalogo.Columns["IdCategoria"].Visible = false;
            dgvCatalogo.Columns["Imagen"].Visible = false;
        }

        private void dgvCatalogo_SelectionChanged(object sender, EventArgs e)
        {
            Articulos aux = (Articulos)dgvCatalogo.CurrentRow.DataBoundItem;
            cargarImagen(aux.Imagen.ToString());
        }

        private void cargarImagen(string url)
        {
            try {
                picArticulos.Load(url);
            } catch (Exception ex)
            {
               picArticulos.Load("https://www.drupal.org/files/project-images/broken-image.jpg");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formAlta alta = new formAlta();
            alta.ShowDialog();
        }
    }
}
