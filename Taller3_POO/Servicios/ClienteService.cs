using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller3_POO.Entidades;

namespace Taller3_POO.Servicios
{
    class ClienteService
    {
        // Creando la Lista de Clientes
        List<Cliente> listaClientes = new List<Cliente>();

        /*Método crear o guardar recibe como parametro un objeto */
        public void CrearCliente(Cliente cliente)
        {
            // Agrega el objeto a la lista
            listaClientes.Add(cliente);
        }

        /*Metodo válidar cédula recibe como parametro la cedula para comparar
         Devuelve un booleano*/
        public bool Validarcedula(int cedula)
        {
            //Recorre la lista y pregunta si la cedula que se el envia como parametro existe o no.
            foreach (var cliente in listaClientes)
            {
                if (cliente.cedula.Equals(cedula))
                    return true;
            }
            return false;
        }

        /*Método Buscar por posición o índice recibe como parametro la cédula
         Devuelve un entero.*/
        public int BuscarPosicionCliente(int cedula)
        {
            // Recorre la lista si la cedula existe retorna el indice del objeto.
            foreach (var cliente in listaClientes)
            {
                if (cliente.cedula.Equals(cedula))
                    return listaClientes.IndexOf(cliente);  /*posicion:{listaClientes.IndexOf(iCliente)} 
                                                             Devuelve la posición del objeto de 0 en adelante*/
            }
            return -1; // Si devuelve -1 significa que no lo encontro.
        }

        /*Método Buscar cliente o listar cliente  recibe como parametro la cédula
         Devuelve el segun su índice el objeto*/
        public Cliente BuscarClientePorCedula(int cedula)
        {
            Cliente cliente = new Cliente();
            // Retorna el cliente segun la cédula
            if (BuscarPosicionCliente(cedula) >= 0)
                cliente = listaClientes[BuscarPosicionCliente(cedula)]; // lista[0]
            else
                Console.WriteLine("Cliente no encontrado");

            return cliente;
        }

        /*Metodo módificar recibe como parametro el objeto y la posición para poder sobreescribirlo*/
        public void ModificarCliente(Cliente cliente, int index)
        {
            // A la lista según el índice Ej: {listaClientes[0].nombre = "Camila"}
            listaClientes[index].cedula = cliente.cedula;
            listaClientes[index].nombre = cliente.nombre;
            listaClientes[index].direccion = cliente.direccion;
            listaClientes[index].telefono = cliente.telefono;
        }

        /*Método Eliminar recibe como parametro la cédula*/
        public void EliminarCliente(int cedula)
        {
            // Busca el objeto por indice y si lo encuentra lo elimina
            if (BuscarPosicionCliente(cedula) >= 0) // indice >= 0
            {
                listaClientes.RemoveAt(BuscarPosicionCliente(cedula)); // lista.RemoveAt(0)
                Console.WriteLine("Cliente eliminado");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado");
            }
        }

        public List<Cliente> ListarClientes()
        {
            return listaClientes;
        }


    }
}
