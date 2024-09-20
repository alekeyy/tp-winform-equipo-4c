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
    public partial class formAlta : Form
    {
        private Articulos articulo = null;
        public formAlta()
        {
            InitializeComponent();
        }

        public formAlta(Articulos aux)
        {
            InitializeComponent();
            this.articulo = aux;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();

            //antes de pisar el articulo, lo verificamos
            if(articulo == null)
            {
                articulo = new Articulos();
            }

            try
            {
                articulo.Id = 
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtNombre.Text;
                articulo.Categoria = (Categorias)boxCategoria.SelectedItem;
                articulo.Marca = (Marcas)boxMarca.SelectedItem;
                //imagen?
              
                if(articulo.Id != 0)
                {
                    negocio.Modificar(articulo);
                    MessageBox.Show("Articulo modificado correctamente");
                } else
                {
                    negocio.Agregar(articulo);
                    MessageBox.Show("Articulo agregado correctamente");
                }
                negocio.Agregar(articulo);
                MessageBox.Show("Articulo agregado correctamente");
                Close();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        private void formAlta_Load(object sender, EventArgs e)
        {
            MarcasNegocio marca = new MarcasNegocio();
            CategoriasNegocio categoria = new CategoriasNegocio();
            ImagenesNegocio imagen = new ImagenesNegocio();
            try
            {
                boxCategoria.DataSource = categoria.listar();
                boxMarca.DataSource = marca.listar();
                // pendiente agregar imagen

                if(articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    boxCategoria.SelectedValue = articulo.Categoria;
                    boxMarca.SelectedValue = articulo.Marca;
                    //cargar imagen
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
