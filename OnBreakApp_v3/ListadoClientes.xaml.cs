using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OnBreakLibrary;

namespace OnBreakApp_v3
{
    /// <summary>
    /// Lógica de interacción para ListadoClientes.xaml
    /// </summary>
    /// 
    public partial class ListadoClientes
    {
        private ClienteCollection _clienteCollection = new ClienteCollection();
        private Listas _listas = new Listas();

        public static ListadoClientes ventanaListadoClientes;

        public static ListadoClientes getInstance()
        {
            if (ventanaListadoClientes == null)
            {
                ventanaListadoClientes = new ListadoClientes();
            }
            return ventanaListadoClientes;
        }

        public ClienteCollection ClienteCollection
        {
            get
            {
                return _clienteCollection;
            }

            set
            {
                _clienteCollection = value;
            }
        }

        public Listas Listas
        {
            get
            {
                return _listas;
            }
        }

        public ListadoClientes()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //cargamos actividades al combobox
            cboFiltrarPorActividad.ItemsSource = Listas.ActividadesEmpresas();
            cboFiltrarPorActividad.SelectedIndex = 0;

            //Cargamos tipos al combobox
            cboFiltrarPorTipo.ItemsSource = Listas.TiposEmpresas();
            cboFiltrarPorTipo.SelectedIndex = 0;

        }

        
        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgListaClientes.ItemsSource = null;
                //le pasamos los datos a la grilla
                dgListaClientes.ItemsSource = this.ClienteCollection.Clientes;
            }
            catch (Exception)
            {
                MessageBox.Show("Error actualizando");
            }
        }

        private void BtnFiltrarPorRut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rut = txtFiltrarPorRut.Text;

                if (rut.Length < 8 || rut.Length > 10)
                {
                    MessageBox.Show("Ingrese un RUT valido");
                }

                dgListaClientes.ItemsSource = null;
                dgListaClientes.ItemsSource = this.ClienteCollection.clientePorRut(int.Parse(rut));
            }
            catch (Exception)
            {
                MessageBox.Show("Error filtrando por rut");
            }
        }

        private void BtnFiltrarPorActividad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgListaClientes.ItemsSource = null;
                dgListaClientes.ItemsSource = this.ClienteCollection.clientesPorActividad(cboFiltrarPorActividad.SelectedItem.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Error filtrando por actividad");
            }
        }

        private void BtnFiltrarPorTipo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgListaClientes.ItemsSource = null;
                dgListaClientes.ItemsSource = this.ClienteCollection.clientesPorTipo(cboFiltrarPorTipo.SelectedItem.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Error filtrando por tipo");
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ventanaListadoClientes = null;
        }
    }
}