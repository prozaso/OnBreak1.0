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
using System.Windows.Shapes;
using OnBreakLibrary;

namespace OnBreakApp_v3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ClienteCollection _clienteCollection = new ClienteCollection();

        private ContratoCollection _contratoCollection = new ContratoCollection();

        public static MainWindow ventanaMenu;

        public static MainWindow getInstance()
        {
            if (ventanaMenu == null)
            {
                ventanaMenu = new MainWindow();
            }
            return ventanaMenu;
        }

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            ventanaMenu = this;
        }

        private void BtnAdminClientes_Click(object sender, RoutedEventArgs e)
        {
            AdministracionClientes.getInstance().Show();
            AdministracionClientes.getInstance().ClienteCollection = this._clienteCollection;
            
        }

        private void BtnListadoClientes_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientes.getInstance().Show();
            ListadoClientes.getInstance().ClienteCollection = this._clienteCollection;
        }

        private void BtnListadoContratos_Click(object sender, RoutedEventArgs e)
        {
            ListadoContratos.getInstance().Show();
            ListadoContratos.getInstance().ContratoCollection = this._contratoCollection;
            ListadoContratos.getInstance().ClienteCollection = this._clienteCollection;
        }

        private void BtnAdminContratos_Click(object sender, RoutedEventArgs e)
        {
            AdministracionContratos.getInstance().Show();
            AdministracionContratos.getInstance().ContratoCollection = this._contratoCollection;
            AdministracionContratos.getInstance().ClienteCollection = this._clienteCollection;
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}