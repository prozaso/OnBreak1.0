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
    /// Lógica de interacción para AdministracionClientes.xaml
    /// </summary>

    public partial class AdministracionClientes
    {
        private ClienteCollection _clienteCollection = new ClienteCollection();
        private Validadores _validadores = new Validadores();
        private Listas _listas = new Listas();


        public static AdministracionClientes ventanaAdmClientes;

        public static AdministracionClientes getInstance()
        {
            if (ventanaAdmClientes == null)
            {
                ventanaAdmClientes = new AdministracionClientes();
            }
            return ventanaAdmClientes;
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

        public Validadores Validadores
        {
            get
            {
                return _validadores;
            }
            set
            {
                _validadores = value;
            }
        }

        public Listas Listas
        {
            get
            {
                return _listas;
            }
        }

        public AdministracionClientes()
        {
            InitializeComponent();

            //ventana inicia centrada
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            //cargamos el combobox cboActividad con su enumerador y lo iniciamos en su index
            cboActividad.ItemsSource = Listas.ActividadesEmpresas();
            cboActividad.SelectedIndex = 0;

            //Cargamos el combobox cboTipo y lo iniciamos en su index
            cboTipo.ItemsSource = Listas.TiposEmpresas();
            cboTipo.SelectedIndex = 0;         
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtRut.Text = "";
                txtRazonSocial.Text = "";
                txtNombre.Text = "";
                txtMail.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                cboActividad.SelectedIndex = 0;
                cboTipo.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Error limpiando campos");
            }
        }

        private void BtnListado_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientes.getInstance().Show();
            ListadoClientes.getInstance().ClienteCollection = this._clienteCollection;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int rut = int.Parse(txtRut.Text);

                if (rut.Equals("") || txtRazonSocial.Text.Equals("") || txtNombre.Text.Equals("")
                    || txtMail.Text.Equals("") || txtDireccion.Text.Equals("") || txtTelefono.Text.Equals("")
                    || cboActividad.Text.Equals("Seleccione") || cboTipo.Text.Equals("Seleccione"))
                {
                    MessageBox.Show("No pueden quedar campos vacios");
                }
                else if (txtRut.Text.Length < 8 || txtRut.Text.Length > 10)
                {
                    MessageBox.Show("Ingrese un RUT valido");
                }
                else if (!Validadores.validadorTexto(txtNombre.Text))
                {
                    MessageBox.Show("El nombre no acepta numeros");
                }
                else if (!Validadores.validadorTelefono(txtTelefono.Text))
                {
                    MessageBox.Show("Telefono mal ingresado, '+numero'");
                }
                else if (!Validadores.IsValidEmail(txtMail.Text))
                {
                    MessageBox.Show("Correo mal ingresado");
                }
                else
                {

                    Cliente cliente = new Cliente();
                    cliente.Rut = int.Parse(txtRut.Text);
                    cliente.RazonSocial = txtRazonSocial.Text;
                    cliente.Nombre = txtNombre.Text;
                    cliente.Mail = txtMail.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Telefono = txtTelefono.Text;
                    cliente.ActividadEmpresa = cboActividad.SelectedItem.ToString();
                    cliente.TipoEmpresa = cboTipo.Text;

                    if (this.ClienteCollection.AgregarCliente(cliente))
                    {
                        MessageBox.Show("Cliente agregado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Cliente no se pudo agregar");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en RUT, ingrese solo numeros");
            }
        }
        

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rut = int.Parse(txtRut.Text);
                Cliente cliente = ClienteCollection.BuscarClientePorRut(rut);

                if (cliente == null)
                {
                    MessageBox.Show("El cliente no existe");
                    return;
                }
                else if (!Validadores.validadorNumerico(rut))
                {
                    MessageBox.Show("RUT invalido");
                }


                rut = cliente.Rut;
                txtRazonSocial.Text = cliente.RazonSocial;
                txtNombre.Text = cliente.Nombre;
                txtMail.Text = cliente.Mail;
                txtDireccion.Text = cliente.Direccion;
                txtTelefono.Text = cliente.Telefono;
                cboActividad.SelectedItem = cliente.ActividadEmpresa.ToString();
                cboTipo.SelectedItem = cliente.TipoEmpresa;
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando Cliente");
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ventanaAdmClientes = null;
        }

    }
}