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
using System.Globalization;
using OnBreakLibrary;

namespace OnBreakApp_v3
{
    /// <summary>
    /// Lógica de interacción para AdministracionContratos.xaml
    /// </summary>
    public partial class AdministracionContratos
    {
        private ContratoCollection _contratoCollection = new ContratoCollection();
        private ClienteCollection _clienteCollection = new ClienteCollection();
        private Listas _listas = new Listas();
        private Validadores _validadores = new Validadores();

        private int _cumpleaños = 300000;
        private int _graduacionTitulacion = 200000;
        private int _matrimonio = 500000;
        private int _uf = 28000;
        private int _recargoAsistentes;
        private double _recargoPersonalAdicional;

        public static AdministracionContratos ventanaAdmContratos;

        public static AdministracionContratos getInstance()
        {
            if (ventanaAdmContratos == null)
            {
                ventanaAdmContratos = new AdministracionContratos();
            }
            return ventanaAdmContratos;
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

        public AdministracionContratos()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            cboTipoEvento.ItemsSource = Listas.TiposEventos();
            cboTipoEvento.SelectedIndex = 0;

            Contrato contrato = new Contrato();
            txtNumeroAsistentes.Text = contrato.Asistentes.ToString();
            txtNumeroPersonalAdicional.Text = contrato.PersonalAdicional.ToString();
        }

        private void BtnListaContratos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListadoContratos.getInstance().Show();
                ListadoContratos.getInstance().ContratoCollection = this._contratoCollection;
            }
            catch (Exception)
            {
                MessageBox.Show("Error listando contratos");
            }
        }

        private void BtnLimpiarCampos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtNumeroContrato.Text = "";
                calCalendario.SelectedDate = DateTime.Today;
                txtHoraInicio.Text = "";
                txtHoraTermino.Text = ""; ;
                txtDireccion.Text = "";
                txtObservaciones.Text = "";
                txtRutCliente.Text = "";
                txtNombreCompletoCliente.Text = "";
                cboTipoEvento.SelectedIndex = 0;
                txtNumeroAsistentes.Text = "3";
                txtNumeroPersonalAdicional.Text = "2";
                txtValorEvento.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Error limpiando campos");
            }
        }


        private void BtnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rut = int.Parse(txtRutCliente.Text);
                if (!Validadores.validadorNumerico(rut))
                {
                    MessageBox.Show("RUT invalido");
                }
                

                Cliente cliente = ClienteCollection.BuscarClientePorRut(rut);

                if (cliente == null)
                {
                    MessageBox.Show("El cliente no existe");
                    return;
                }
                else
                {
                    txtNombreCompletoCliente.Text = cliente.Nombre;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando cliente");
            }
        }

        private void BtnCrearContrato_Click(object sender, RoutedEventArgs e)
        {
            Contrato contrato = new Contrato();

            if (txtRutCliente is null)
            {
                MessageBox.Show("Favor ingrese RUT del cliente");
            }
            else if (txtNombreCompletoCliente is null)
            {
                MessageBox.Show("Cliente no registrado");
            }
            else
            {
                
                contrato.InicioEvento = calCalendario.SelectedDate.Value;
                contrato.HoraInicio = txtHoraInicio.Text;
                contrato.HoraTermino = txtHoraTermino.Text;
                contrato.Direccion = txtDireccion.Text;
                contrato.Observaciones = txtObservaciones.Text;
                contrato.Cliente = ClienteCollection.BuscarClientePorRut(int.Parse(txtRutCliente.Text));
                contrato.Tipo = cboTipoEvento.SelectedValue.ToString();
                contrato.Asistentes = int.Parse(txtNumeroAsistentes.Text);
                contrato.PersonalAdicional = int.Parse(txtNumeroPersonalAdicional.Text);
                contrato.Vigente = true;
                contrato.CreacionContrato = DateTime.Today;


                contrato.Numero = int.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
                

                //obtenemos el valor de RECARGO POR ASISTENTES
                if (int.Parse(txtNumeroAsistentes.Text) < 21)
                {
                    _recargoAsistentes = (_uf * 3);
                }
                else if (int.Parse(txtNumeroAsistentes.Text) < 51)
                {
                    _recargoAsistentes = (_uf * 5);
                }
                else
                {
                    _recargoAsistentes = /*Math.Truncate*/(((int.Parse(txtNumeroAsistentes.Text) - 50) / 20) * (_uf * 2)) + (_uf * 5);
                }


                //obtenemos el valor de RECARGO POR PERSONAL ADICIONAL
                if (int.Parse(txtNumeroPersonalAdicional.Text) < 3)
                {
                    _recargoPersonalAdicional = (_uf * 2);
                }
                else if (int.Parse(txtNumeroPersonalAdicional.Text) < 4)
                {
                    _recargoPersonalAdicional = (_uf * 3);
                }
                else if (int.Parse(txtNumeroPersonalAdicional.Text) < 5)
                {
                    _recargoPersonalAdicional = (_uf * 3.5);
                }
                else
                {
                    _recargoPersonalAdicional = ((int.Parse(txtNumeroPersonalAdicional.Text) - 4) * (_uf / 2)) + (_uf * 3.5);
                }


                //recibimos el tipo de evento, le sumamos los recargos y le asignamos el valor total al contrato y textbox
                if (cboTipoEvento.Text.Equals("Cumpleaños"))
                {
                    contrato.ValorEvento = _cumpleaños + _recargoAsistentes + _recargoPersonalAdicional;
                    txtValorEvento.Text = contrato.ValorEvento.ToString("C0");
                }
                else if (cboTipoEvento.Text.Equals("Graduacion/Titulacion"))
                {
                    contrato.ValorEvento = _graduacionTitulacion + _recargoAsistentes + _recargoPersonalAdicional;
                    txtValorEvento.Text = contrato.ValorEvento.ToString("C0");
                }
                else if (cboTipoEvento.Text.Equals("Matrimonio"))
                {
                    contrato.ValorEvento = _matrimonio + _recargoAsistentes + _recargoPersonalAdicional;
                    txtValorEvento.Text = contrato.ValorEvento.ToString("C0");
                }
            }

            if (this.ContratoCollection.AgregarContrato(contrato))
            {
                MessageBox.Show("Contrato creado correctamente");
            }
            else
            {
                MessageBox.Show("Contrato no se pudo crear");
            }

        }

        private void BtnBuscarContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumeroContrato.Text);
                Contrato contrato = ContratoCollection.BuscarContratoPorNumero(numero);

                if (!Validadores.validadorNumerico(numero) || numero < 12 || numero > 12)
                {
                    MessageBox.Show("Numero de contrato invalido");
                }
                else if (contrato == null)
                {
                    MessageBox.Show("El contrato no existe");
                    return;
                }

                if (contrato.Vigente == false)
                {
                    casillasDisable();
                }
                else
                {

                    numero = contrato.Numero;
                    calCalendario.DisplayDate = contrato.InicioEvento;
                    txtHoraInicio.Text = contrato.HoraInicio;
                    txtHoraTermino.Text = contrato.HoraTermino;
                    txtDireccion.Text = contrato.Direccion;
                    txtObservaciones.Text = contrato.Observaciones;
                    cboTipoEvento.Text = contrato.Tipo;
                    txtNumeroAsistentes.Text = contrato.Asistentes.ToString();
                    txtNumeroPersonalAdicional.Text = contrato.PersonalAdicional.ToString();
                    txtValorEvento.Text = contrato.ValorEvento.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando contrato");
            }
        }

        private void BtnCalcularValor_Click(object sender, RoutedEventArgs e)
        {

            //validamos que se mantenga el numero de asistentes base
            try
            {
                if (int.Parse(txtNumeroAsistentes.Text) < 3)
                {
                    MessageBox.Show("Cada contrato cuenta con 3 Asistentes (Solo incrementables)");
                    txtNumeroAsistentes.Text = "3";
                }
                else if (txtNumeroAsistentes.Text is null)
                {
                    MessageBox.Show("Este campo no puede quedar vacio");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Solo puede ingresar numeros");
                txtNumeroAsistentes.Text = "3";
            }


            //validamos que se mantenga el numero de personal adicional base
            try
            {
                if (int.Parse(txtNumeroPersonalAdicional.Text) < 2)
                {
                    MessageBox.Show("El numero de Personal Adicional base es 2 (Solo incrementables)");
                    txtNumeroPersonalAdicional.Text = "2";
                }
                else if (txtNumeroPersonalAdicional.Text is null)
                {
                    MessageBox.Show("Este campo no puede quedar vacio");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Solo puede ingresar numeros");
                txtNumeroPersonalAdicional.Text = "2";
            }


            //obtenemos el valor de RECARGO POR ASISTENTES
            try
            {
                if (int.Parse(txtNumeroAsistentes.Text) < 21)
                {
                    _recargoAsistentes = (_uf * 3);
                }
                else if (int.Parse(txtNumeroAsistentes.Text) < 51)
                {
                    _recargoAsistentes = (_uf * 5);
                }
                else
                {
                    _recargoAsistentes = /*Math.Truncate*/(((int.Parse(txtNumeroAsistentes.Text) - 50) / 20) * (_uf * 2)) + (_uf * 5);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error calculando recargo por asistentes");
            }


            try
            {
                //obtenemos el valor de RECARGO POR PERSONAL ADICIONAL
                if (int.Parse(txtNumeroPersonalAdicional.Text) < 3)
                {
                    _recargoPersonalAdicional = (_uf * 2);
                }
                else if (int.Parse(txtNumeroPersonalAdicional.Text) < 4)
                {
                    _recargoPersonalAdicional = (_uf * 3);
                }
                else if (int.Parse(txtNumeroPersonalAdicional.Text) < 5)
                {
                    _recargoPersonalAdicional = (_uf * 3.5);
                }
                else
                {
                    _recargoPersonalAdicional = ((int.Parse(txtNumeroPersonalAdicional.Text) - 4) * (_uf / 2)) + (_uf * 3.5);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error calculando recargo por personal adicional");
            }


            try
            {
                //recibimos el tipo de evento, le sumamos los recargos y le asignamos el valor total al contrato y textbox
                if (cboTipoEvento.Text.Equals("Cumpleaños"))
                {
                    txtValorEvento.Text = (_cumpleaños + _recargoAsistentes + _recargoPersonalAdicional).ToString("C0");
                }
                else if (cboTipoEvento.Text.Equals("Graduacion/Titulacion"))
                {
                    txtValorEvento.Text = (_graduacionTitulacion + _recargoAsistentes + _recargoPersonalAdicional).ToString("C0");
                }
                else if (cboTipoEvento.Text.Equals("Matrimonio"))
                {
                    txtValorEvento.Text = (_matrimonio + _recargoAsistentes + _recargoPersonalAdicional).ToString("C0");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error calculando valor del contrato");
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ventanaAdmContratos = null;
        }

        private void BtnTerminarContrato_Click(object sender, RoutedEventArgs e)
        {
            Contrato contrato = new Contrato();
            contrato.TerminoContrato = DateTime.Today;

            contrato.Vigente = false;
            casillasDisable();
        }

        private void casillasDisable()
        {
            txtNumeroContrato.IsEnabled = false;
            calCalendario.IsEnabled = false;
            txtHoraInicio.IsEnabled = false;
            txtHoraTermino.IsEnabled = false;
            txtDireccion.IsEnabled = false;
            txtObservaciones.IsEnabled = false;
            cboTipoEvento.IsEnabled = false;
            txtNumeroAsistentes.IsEnabled = false;
            txtNumeroPersonalAdicional.IsEnabled = false;
        }
    }
}