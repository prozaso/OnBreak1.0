using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreakLibrary;

namespace OnBreakLibrary
{
    public class Cliente
    {

        private int _rut;
        private String _razonSocial;
        private String _nombre;
        private String _mail;
        private String _direccion;
        private String _telefono;
        private String _actividadEmpresa;
        private String _tipoEmpresa;

        public Cliente()
        {
        }

        public Cliente(int _rut, string _razonSocial, string _nombre, string _mail, string _direccion, string _telefono, string _actividadEmpresa, string _tipoEmpresa)
        {
            this.Rut = _rut;
            this.RazonSocial = _razonSocial;
            this.Nombre = _nombre;
            this.Mail = _mail;
            this.Direccion = _direccion;
            this.Telefono = _telefono;
            this.ActividadEmpresa = _actividadEmpresa;
            this.TipoEmpresa = _tipoEmpresa;
        }

        public int Rut
        {
            get
            {
                return _rut;
            }

            set
            {
                _rut = value;
            }
        }

        public string RazonSocial
        {
            get
            {
                return _razonSocial;
            }

            set
            {
                _razonSocial = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string Mail
        {
            get
            {
                return _mail;
            }

            set
            {
                _mail = value;
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

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        public string ActividadEmpresa
        {
            get
            {
                return _actividadEmpresa;
            }

            set
            {
                _actividadEmpresa = value;
            }
        }

        public String TipoEmpresa
        {
            get
            {
                return _tipoEmpresa;
            }

            set
            {
                _tipoEmpresa = value;
            }
        }


    }
}