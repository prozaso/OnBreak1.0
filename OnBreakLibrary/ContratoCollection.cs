using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class ContratoCollection
    {

        private List<Contrato> _contratos = new List<Contrato>();

        public List<Contrato> Contratos
        {
            get
            {
                return _contratos;
            }

            set
            {
                _contratos = value;
            }
        }

        public bool AgregarContrato(Contrato contrato)
        {
            if (BuscarContratoPorNumero(contrato.Numero) != null)
            {
                return false;
            }
            this.Contratos.Add(contrato);
            return true;
        }

        public Contrato BuscarContratoPorNumero(int numero)
        {
            foreach (var item in Contratos)
            {
                if (item.Numero == numero)
                {
                    return item;
                }
            }
            return null;
        }


        public List<Contrato> contratoPorRut(int rut)
        {
            return (from c in this.Contratos
                    where c.Cliente.Rut == rut
                    select c).ToList();
        }

        public List<Contrato> contratoPorNumero(int numero)
        {
            return (from c in this.Contratos
                    where c.Numero == numero
                    select c).ToList();
        }

        public List<Contrato> contratoPorTipo(string tipo)
        {
            return (from c in this.Contratos
                    where c.Tipo == tipo
                    select c).ToList();
        }


    }
}
