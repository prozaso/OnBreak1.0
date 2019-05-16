using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreakLibrary;

namespace OnBreakLibrary
{
    public class Contrato
    {

        private int _numero;
        private DateTime _creacionContrato;
        private DateTime _terminoContrato;
        private DateTime _inicioEvento;
        private DateTime _terminoEvento;
        private String _horaInicio;
        private String _horaTermino;
        private String _direccion;
        private bool _vigente;
        private String _tipo;
        private String _observaciones;
        private Cliente _cliente;
        private int _asistentes = 3;
        private int _personalAdicional = 2;
        private double _valorEvento;

        public Contrato()
        {
        }

        public Contrato(int _numero, DateTime _creacionContrato, DateTime _terminoContrato, DateTime _inicioEvento, 
                        DateTime _terminoEvento, string _horaInicio, string _horaTermino, string _direccion, bool _vigente, 
                        string _tipo, string _observaciones, Cliente _cliente, int _asistentes, int _personalAdicional, double _valorEvento)
        {
            this.Numero = _numero;
            this.CreacionContrato = _creacionContrato;
            this.TerminoContrato = _terminoContrato;
            this.InicioEvento = _inicioEvento;
            this.TerminoEvento = _terminoEvento;
            this.HoraInicio = _horaInicio;
            this.HoraTermino = _horaTermino;
            this.Direccion = _direccion;
            this.Vigente = _vigente;
            this.Tipo = _tipo;
            this.Observaciones = _observaciones;
            this.Cliente = _cliente;
            this.Asistentes = _asistentes;
            this.PersonalAdicional = _personalAdicional;
            this.ValorEvento = _valorEvento;
        }

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public DateTime CreacionContrato
        {
            get
            {
                return _creacionContrato;
            }

            set
            {
                _creacionContrato = value;
            }
        }

        public DateTime TerminoContrato
        {
            get
            {
                return _terminoContrato;
            }

            set
            {
                _terminoContrato = value;
            }
        }

        public DateTime InicioEvento
        {
            get
            {
                return _inicioEvento;
            }

            set
            {
                _inicioEvento = value;
            }
        }

        public DateTime TerminoEvento
        {
            get
            {
                return _terminoEvento;
            }

            set
            {
                _terminoEvento = value;
            }
        }

        public string HoraInicio
        {
            get
            {
                return _horaInicio;
            }

            set
            {
                _horaInicio = value;
            }
        }

        public string HoraTermino
        {
            get
            {
                return _horaTermino;
            }

            set
            {
                _horaTermino = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        public bool Vigente
        {
            get
            {
                return _vigente;
            }

            set
            {
                _vigente = value;
            }
        }

        public string Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                _tipo = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return _observaciones;
            }

            set
            {
                _observaciones = value;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }

            set
            {
                _cliente = value;
            }
        }

        public int Asistentes
        {
            get
            {
                return _asistentes;
            }

            set
            {
                _asistentes = value;
            }
        }

        public int PersonalAdicional
        {
            get
            {
                return _personalAdicional;
            }

            set
            {
                _personalAdicional = value;
            }
        }

        public double ValorEvento
        {
            get
            {
                return _valorEvento;
            }

            set
            {
                _valorEvento = value;
            }
        }
    }
}