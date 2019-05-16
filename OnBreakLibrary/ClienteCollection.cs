using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class ClienteCollection
    {

        private List<Cliente> _clientes = new List<Cliente>();

        public List<Cliente> Clientes
        {
            get
            {
                return _clientes;
            }

            set
            {
                _clientes = value;
            }
        }

        public bool AgregarCliente(Cliente cliente)
        {
            if (BuscarClientePorRut(cliente.Rut) != null)
            {
                return false;
            }

            this.Clientes.Add(cliente);
            return true;
        }

        public Cliente BuscarClientePorRut(int rut)
        {
            foreach (var item in Clientes)
            {
                if (item.Rut == rut)
                {
                    return item;
                }
            }
            return null;
        }

        public bool EliminarCliente(int Rut)
        {
            Cliente cliente = BuscarClientePorRut(Rut);
            if (cliente == null)
            {
                return false;
            }

            this.Clientes.Remove(cliente);
            return true;
        }

        public List<Cliente> clientePorRut(int Rut)
        {
            return (from c in this.Clientes
                    where c.Rut == Rut
                    select c).ToList();
        }

        public List<Cliente> clientesPorActividad(string actividad)
        {
            return (from c in this.Clientes
                    where c.ActividadEmpresa == actividad
                    select c).ToList();
        }

        public List<Cliente> clientesPorTipo(string tipo)
        {
            return (from c in this.Clientes
                    where c.TipoEmpresa == tipo
                    select c).ToList();
        }

        public List<Cliente> listaClientes(string clientes)
        {
            return (from c in this.Clientes
                    select c).ToList();
        }
    }
}