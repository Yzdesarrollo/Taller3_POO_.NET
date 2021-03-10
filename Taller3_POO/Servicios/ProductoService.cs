using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller3_POO.Entidades;

namespace Taller3_POO.Servicios
{
    class ProductoService
    {
        public List<Producto> ListaProductos = new List<Producto>();


        /*Método crear o guardar recibe como parametro un objeto */
        public void CrearProducto(Producto producto)
        {
            // Agrega el objeto a la lista
            ListaProductos.Add(producto);
        }

        public bool ValidarCodigo(int codigo)
        {
            //Recorre la lista y pregunta si la codigo que se el envia como parametro existe o no.
            foreach (var producto in ListaProductos)
            {
                if (producto.codigo.Equals(codigo))
                    return true;
            }
            return false;
        }

        public int BuscarPosicionProducto(int codigo)
        {
            // Recorre la lista si la cedula existe retorna el indice del objeto.
            foreach (var producto in ListaProductos)
            {
                if (producto.codigo.Equals(codigo))
                    return ListaProductos.IndexOf(producto);  /*posicion:{listaClientes.IndexOf(iCliente)} 
                                                             Devuelve la posición del objeto de 0 en adelante*/
            }
            return -1; // Si devuelve -1 significa que no lo encontro.
        }

        /*Método Buscar cliente o listar cliente  recibe como parametro la cédula
       Devuelve el segun su índice el objeto*/
        public Producto BuscarProductoPorCodigo(int codigo)
        {
            // Retorna el cliente segun la cédula
            return ListaProductos[BuscarPosicionProducto(codigo)]; // lista[0]
        }

        /*Metodo módificar recibe como parametro el objeto y la posición para poder sobreescribirlo*/
        public void ModificarProducto(Producto producto, int index)
        {
            // A la lista según el índice Ej: {listaClientes[0].nombre = "Camila"}
            ListaProductos[index].codigo = producto.codigo;
            ListaProductos[index].nombre = producto.nombre;
            ListaProductos[index].precio = producto.precio;
            ListaProductos[index].cantidad = producto.cantidad;
        }

        /*Método Eliminar recibe como parametro la cédula*/
        public void EliminarProducto(int codigo)
        {
            // Busca el objeto por indice y si lo encuentra lo elimina
            if (BuscarPosicionProducto(codigo) >= 0) // indice >= 0
            {
                ListaProductos.RemoveAt(BuscarPosicionProducto(codigo)); // lista.RemoveAt(0)
                Console.WriteLine("Producto eliminado");
            }
            else
            {
                Console.WriteLine("Producto no encontrado");
            }
        }

        public List<Producto> ListarProductos()
        {
            return ListaProductos;
        }

    }
}
