using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace OnBreakLibrary
{
    public class Listas
    {
        private List<string> _tiposEmpresas = new List<string>();
        private List<string> _actividadesEmpresas = new List<string>();
        private List<string> _tipoEventos = new List<string>();

        public List<string> TiposEmpresas()
        {
            _tiposEmpresas.Add("Seleccione");
            _tiposEmpresas.Add("SPA");
            _tiposEmpresas.Add("EIRL");
            _tiposEmpresas.Add("Limitada");
            _tiposEmpresas.Add("Sociedad Anonima");

            return _tiposEmpresas;
        }

        public List<string> ActividadesEmpresas()
        {
            _actividadesEmpresas.Add("Seleccione");
            _actividadesEmpresas.Add("Agropecuaria");
            _actividadesEmpresas.Add("Mineria");
            _actividadesEmpresas.Add("Manufactura");
            _actividadesEmpresas.Add("Comercio");
            _actividadesEmpresas.Add("Hoteleria");
            _actividadesEmpresas.Add("Alimentos");
            _actividadesEmpresas.Add("Transporte");
            _actividadesEmpresas.Add("Servicios");

            return _actividadesEmpresas;
        }

        public List<string> TiposEventos()
        {
            _tipoEventos.Add("Seleccione");
            _tipoEventos.Add("Cumpleaños");
            _tipoEventos.Add("Graduacion/Titulacion");
            _tipoEventos.Add("Matrimonio");

            return _tipoEventos;
        }

    }
}