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
        public formAlta()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulos art = new Articulos();
            ArticulosNegocio negocio = new ArticulosNegocio();

            try
            {
                art.Codigo = txtCodigo.Text;
                art.Nombre = txtNombre.Text;
                art.Descripcion = txtNombre.Text;
                art.Categoria = (Categorias)boxCategoria.SelectedItem;
                art.Marca = (Marcas)boxMarca.SelectedItem;
                //imagen?
              
                negocio.Agregar(art);
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

            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
