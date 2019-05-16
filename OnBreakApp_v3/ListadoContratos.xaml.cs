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
    /// Lógica de interacción para ListadoContratos.xaml
    /// </summary>
    public partial class ListadoContratos
    {
        private ContratoCollection _contratoCollection = new ContratoCollection();
        private ClienteCollection _clienteCollection = new ClienteCollection();
        private Listas _listas = new Listas();

        public static ListadoContratos ventanaListadoContratos;

        public static ListadoContratos getInstance()
        {
            if (ventanaListadoContratos == null)
            {
                ventanaListadoContratos = new ListadoContratos();
            }
            return ventanaListadoContratos;
        }

        public ContratoCollection ContratoCollection
        {
            get
            {
                return _contratoCollection;
            }

            set
            {
                _contratoCollection = value;
            }
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

        public ListadoContratos()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //cargamos cboFiltrarPorContrato
            cboFiltrarPorTipoDeContrato.ItemsSource = Listas.TiposEventos();
            cboFiltrarPorTipoDeContrato.SelectedIndex = 0;
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ventanaListadoContratos = null;
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgListaContratos.ItemsSource = null;
                dgListaContratos.ItemsSource = this.ContratoCollection.Contratos;
            }
            catch (Exception)
            {
                MessageBox.Show("Error actualizando");
            }
        }

        private void BtnFiltrarPorTipoDeContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgListaContratos.ItemsSource = null;
                dgListaContratos.ItemsSource = this.ContratoCollection.contratoPorTipo(cboFiltrarPorTipoDeContrato.SelectedItem.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Error filtrando por tipo de contrato");
            } 
        }

        private void BtnFiltrarPorRutDelCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rut = int.Parse(txtFiltrarPorRutDelCliente.Text);

                dgListaContratos.ItemsSource = null;
                dgListaContratos.ItemsSource = this.ContratoCollection.contratoPorRut(rut);
            }
            catch (Exception)
            {
                MessageBox.Show("Error filtrando por rut del cliente");
            }
        }

        private void BtnFiltrarPorNumeroDeContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numero = int.Parse(txtFiltrarPorNumeroDeContrato.Text);
                
                if (numero.ToString().Length < 12 || numero.ToString().Length > 12)
                {
                    MessageBox.Show("Ingrese un NUMERO de contrato valido");
                }

                dgListaContratos.ItemsSource = null;
                dgListaContratos.ItemsSource = this.ContratoCollection.contratoPorNumero(numero);
            }
            catch (Exception)
            {
                MessageBox.Show("Error filtrando por numero de contrato");
            }

        }
    }
}