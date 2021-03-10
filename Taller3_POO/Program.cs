using System;
using Taller3_POO.Entidades;
using Taller3_POO.Servicios;

namespace Taller3_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.Creando objeto
            Venta venta = new Venta();
            Cliente cliente, cliente2;
            Producto producto, producto2;
            var Configuracion = new { Nombre = "Avansist" };

            // 2.Creando el objeto del servicio para llamar sus métodos
            ClienteService clienteservice = new ClienteService();
            ProductoService productoService = new ProductoService();
            VentaService ventaService = new VentaService();

            int cedula, codigo;

            // variable del while 1
            bool entrar = true;
            while (entrar)
            {
                try
                {

                    int modulo;
                    Console.WriteLine("MÓDULOS:\n1.Módulo Clientes\n2.Módulo Productos\n3.Módulo Ventas\n4.Modulo Reportes\n5.Módulo Configuración\n6.Salir del Sistema");
                    modulo = int.Parse(Console.ReadLine());
                    switch (modulo)
                    {

                        case 1: // Módulo Clientes
                            try
                            {
                                bool moduloClientes = true;
                                while (moduloClientes)
                                {
                                    int menuClientes;
                                    Console.WriteLine("BIENVENIDO AL MÓDULO DE CLIENTES");
                                    Console.WriteLine("Menú:\n1.Crear Cliente\n2.Buscar Cliente por cédula\n3.Modificar o Editar Cliente\n4.Eliminar Cliente\n5.Salir del módulo");
                                    menuClientes = int.Parse(Console.ReadLine());

                                    switch (menuClientes)
                                    {
                                        case 1: // Crear cliente
                                                // variable del while 2
                                            bool respuesta = true;
                                            while (respuesta)
                                            {

                                                cliente = new Cliente();
                                                // Creando o guardando Clientes
                                                Console.WriteLine("ingrese la cédula:");
                                                cedula = int.Parse(Console.ReadLine());
                                                if (clienteservice.Validarcedula(cedula))
                                                {
                                                    Console.WriteLine("El Cliente ya existe :("); // El objeto ya existe
                                                }
                                                else
                                                {
                                                    cliente.cedula = cedula; // asignando cedula a la propiedad Cliente.cedula.
                                                    Console.WriteLine("ingrese el nombre:");
                                                    cliente.nombre = Console.ReadLine();
                                                    Console.WriteLine("ingrese la dirección:");
                                                    cliente.direccion = Console.ReadLine();
                                                    Console.WriteLine("ingrese la teléfono:");
                                                    cliente.telefono = Console.ReadLine();
                                                    // 4.llamando el servicio para guardar o crear el Cliente
                                                    clienteservice.CrearCliente(cliente);
                                                }

                                                Console.WriteLine("¿Desea ingresar más Clientes...(si/no)?");

                                                string salir;
                                                salir = Console.ReadLine();
                                                if ((salir.ToLower()).Equals("no"))
                                                    respuesta = false;

                                            }
                                            break;
                                        case 2: // Buscar Cliente por cédula

                                            Console.WriteLine("Ingrese la cédula del cliente");
                                            cedula = int.Parse(Console.ReadLine());
                                            cliente2 = clienteservice.BuscarClientePorCedula(cedula);
                                            Console.WriteLine($"Cédula:{cliente2.cedula} Nombre:{cliente2.nombre} Direccion:{cliente2.direccion} Teléfono:{cliente2.telefono}");
                                            break;
                                        case 3: // Modificar cliente

                                            Console.WriteLine("ingrese la cédula:");
                                            cedula = int.Parse(Console.ReadLine());
                                            if (clienteservice.BuscarPosicionCliente(cedula) >= 0) // indice >= 0 creado
                                            {
                                                cliente = new Cliente();
                                                cliente.cedula = cedula; // asignando cedula a la propiedad Cliente.cedula.
                                                Console.WriteLine("ingrese el nombre:");
                                                int index = clienteservice.BuscarPosicionCliente(cedula);
                                                cliente.nombre = Console.ReadLine();
                                                Console.WriteLine("ingrese la dirección:");
                                                cliente.direccion = Console.ReadLine();
                                                Console.WriteLine("ingrese la teléfono:");
                                                cliente.telefono = Console.ReadLine();
                                                clienteservice.ModificarCliente(cliente, index);
                                                Console.WriteLine("El cliente se modificado");
                                            }
                                            else
                                                Console.WriteLine("Cliente no encontrado");
                                            break;
                                        case 4: // Eliminar cliente

                                            Console.WriteLine("ingrese la cédula:");
                                            cedula = int.Parse(Console.ReadLine());
                                            clienteservice.EliminarCliente(cedula);
                                            break;
                                        case 5:
                                            Console.WriteLine("¿Esta seguro que desea salir del módulo (Si/No)...?");
                                            var res1 = Console.ReadLine();
                                            if ((res1.ToLower()).Equals("si"))
                                                moduloClientes = false;
                                            break;

                                        default:
                                            Console.WriteLine("Opción incorrecta :(");
                                            break;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Debe ingresar las opciones que aparecen en el Ménu Clientes");
                            }
                            break;

                        case 2: // Módulo Productos
                            try
                            {
                                bool moduloProductos = true;
                                while (moduloProductos)
                                {
                                    int menuProductos;
                                    Console.WriteLine("BIENVENIDO AL MÓDULO DE PRODUCTOS");
                                    Console.WriteLine("Menú:\n1.Crear Productos\n2.Buscar producto\n.Modificar producto\n4.Eliminar Porducto\n5.Salir del módulo");
                                    menuProductos = int.Parse(Console.ReadLine());

                                    switch (menuProductos)
                                    {

                                        case 1: // Crear producto
                                            bool respuesta2 = true;

                                            while (respuesta2)
                                            {
                                                producto = new Producto();
                                                Console.WriteLine("Ingrese el código del producto");
                                                codigo = int.Parse(Console.ReadLine());
                                                if (productoService.ValidarCodigo(codigo))
                                                    Console.WriteLine("El producto ya existe");
                                                else
                                                {
                                                    producto.codigo = codigo; // asignando cedula a la propiedad Cliente.cedula.
                                                    Console.WriteLine("ingrese el nombre del Producto:");
                                                    producto.nombre = Console.ReadLine();
                                                    Console.WriteLine("ingrese el precio:");
                                                    producto.precio = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("ingrese la cantidad:");
                                                    producto.cantidad = int.Parse(Console.ReadLine());
                                                    // 4.llamando el servicio para guardar o crear el Cliente
                                                    productoService.CrearProducto(producto);
                                                }

                                                Console.WriteLine("¿Desea ingresar más Productos...(si/no)?");
                                                string salir;
                                                salir = Console.ReadLine();
                                                if ((salir.ToLower()).Equals("no"))
                                                    respuesta2 = false;

                                            }

                                            break;
                                        case 2:  // Buscar Producto por codigo

                                            Console.WriteLine("Ingrese el código del producto");
                                            codigo = int.Parse(Console.ReadLine());
                                            producto2 = productoService.BuscarProductoPorCodigo(codigo);

                                            Console.WriteLine($"Código:{producto2.codigo} Nombre:{producto2.nombre} Precio:{producto2.precio} Cantidad:{producto2.cantidad}");
                                            break;

                                        case 3: // Modificar Producto

                                            Console.WriteLine("ingrese El código:");
                                            codigo = int.Parse(Console.ReadLine());
                                            if (productoService.BuscarPosicionProducto(codigo) >= 0) // indice >= 0 creado
                                            {
                                                producto = new Producto();
                                                producto.codigo = codigo; // asignando cedula a la propiedad Cliente.cedula.
                                                Console.WriteLine("ingrese el nombre:");
                                                int index = productoService.BuscarPosicionProducto(codigo);
                                                producto.nombre = Console.ReadLine();
                                                Console.WriteLine("ingrese el precio:");
                                                producto.precio = int.Parse(Console.ReadLine());
                                                Console.WriteLine("ingrese la cantidad:");
                                                producto.cantidad = int.Parse(Console.ReadLine());
                                                productoService.ModificarProducto(producto, index);
                                                Console.WriteLine("El producto sea modificado");
                                            }
                                            else
                                                Console.WriteLine("Producto no encontrado");
                                            break;
                                        case 4:  // Eliminar Producto

                                            Console.WriteLine("Ingrese el código:");
                                            codigo = int.Parse(Console.ReadLine());
                                            productoService.EliminarProducto(codigo);
                                            break;
                                        case 5:
                                            Console.WriteLine("¿Esta seguro que desea salir del módulo (Si/No)...?");
                                            var res2 = Console.ReadLine();
                                            if ((res2.ToLower()).Equals("si"))
                                                moduloProductos = false;
                                            break;

                                        default:
                                            break;
                                    }
                                }

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Debe ingresar las opciones que aparecen en el Ménu Productos");

                            }
                            break;

                        case 3: // Módulo Ventas
                            try
                            {
                                bool moduloVentas = true;
                                while (moduloVentas)
                                {
                                    int menuVentas;
                                    Console.WriteLine("BIENVENIDO AL MÓDULO DE VENTAS");
                                    Console.WriteLine("Menú:\n1.Venta\n2.Salir del módulo");
                                    menuVentas = int.Parse(Console.ReadLine());
                                    switch (menuVentas)
                                    {
                                        case 1:
                                            Console.WriteLine("Factura Venta");
                                            Console.WriteLine($"Empresa:{Configuracion.Nombre} Fecha:{venta.fecha}");
                                            break;
                                        case 2:
                                            Console.WriteLine("¿Esta seguro que desea salir del módulo (Si/No)...?");
                                            var res3 = Console.ReadLine();
                                            if ((res3.ToLower()).Equals("si"))
                                                moduloVentas = false;
                                            break;
                                        default:
                                            break;
                                    }
                                }

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Debe ingresar las opciones que aparecen en el Menú de Ventas");
                            }
                            break;

                        case 4: // Módulo Reportes
                            try
                            {
                                bool moduloReportes = true;
                                while (moduloReportes)
                                {
                                    int menuReportes;
                                    Console.WriteLine("BIENVENIDO AL MÓDULO DE REPORTES");
                                    Console.WriteLine("Menú\n1.Lista de Clientes\n2.Lista de Productos\n3.Lista de Facturas\n4.Salir del módulo");
                                    menuReportes = int.Parse(Console.ReadLine());
                                    switch (menuReportes)
                                    {
                                        case 1: // Listar clientes

                                            var listaClientes = clienteservice.ListarClientes();
                                            foreach (Cliente iCliente in listaClientes)
                                            {
                                                Console.WriteLine($"nombre:{iCliente.nombre}\ndirección:{iCliente.direccion}\nteléfono:{iCliente.telefono}\ncédula:{iCliente.cedula}");
                                                Console.WriteLine("_____________");

                                            }

                                            break;

                                        case 2: // Listar productos
                                            var listaProductos = productoService.ListarProductos();
                                            foreach (Producto iProducto in listaProductos)
                                            {
                                                Console.WriteLine($"Código:{iProducto.codigo} Nombre:{iProducto.nombre} Precio:{iProducto.precio} Cantidad:{iProducto.cantidad}");
                                            }
                                            break;

                                        case 3: // Listar Facturas
                                            break;

                                        case 4:
                                            Console.WriteLine("¿Esta seguro que desea salir del módulo (Si/No)...?");
                                            var res4 = Console.ReadLine();
                                            if ((res4.ToLower()).Equals("si"))
                                                moduloReportes = false;
                                            break;

                                        default:
                                            break;
                                    }
                                }

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Debe ingresar las opciones que aparecen en el Ménu Reportes");
                            }
                            break;

                        case 5: // Módulo Configuración
                            try
                            {
                                bool moduloConfig = true;
                                while (moduloConfig)
                                {
                                    Console.WriteLine("BIENVENIDO AL MÓDULO DE CONFIGURACIÓN");
                                    Console.WriteLine($"Empresa {Configuracion.Nombre}");
                                    int menuConfig;
                                    Console.WriteLine("Menú:\n1.Salir del módulo");
                                    menuConfig = int.Parse(Console.ReadLine());
                                    switch (menuConfig)
                                    {
                                        case 1:
                                            Console.WriteLine("¿Esta seguro que desea salir del módulo (Si/No)...?");
                                            var res5 = Console.ReadLine();
                                            if ((res5.ToLower()).Equals("si"))
                                                moduloConfig = false;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                            break;
                        case 6: // Salir del programa
                            Console.WriteLine("¿Esta seguro que desea salir del sistema...(si/no)?");
                            var salir2 = Console.ReadLine();
                            if ((salir2.ToLower()).Equals("si"))
                                entrar = false;
                            break;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Debe ingresar solo las opciones que aparecen en el Menú de Modulos... :(");
                }
            }
            Console.WriteLine("Gracias...y hasta la próxima :)\nPresiones cualquier tecla para salir()");
            Console.ReadKey();
        }
    }
}















