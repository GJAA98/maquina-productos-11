using System;

namespace maquina_productos_11
{
    class Program
    {
        static Producto[] productos = new Producto[] {
                new Producto()
                {
                    Nombre = "Dulce",
                    Precio=5,
                    Existencia = 20
                },
                new Producto()
                {
                    Nombre = "Agua",
                    Precio=25,
                    Existencia = 50
                },
                new Producto()
                {
                    Nombre = "Bizcocho",
                    Precio=10,
                    Existencia = 60
                },
                 new Producto()
                {
                    Nombre = "Chocolate",
                    Precio=35,
                    Existencia = 45
                },
                  new Producto()
                {
                    Nombre = "Refresco",
                    Precio=15,
                    Existencia = 35
                },

        };

        static void Main(string[] args)
        {
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            Console.WriteLine("MENU PRINCIPAL:");
            Console.WriteLine("------------------");
            Console.WriteLine("1.Continuar venta");
            Console.WriteLine("2.Mostrar Informe");
            Console.WriteLine("3.Salir");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opcion:");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ComprarProducto();
                    break;
                case "2":
                    MostrarInforme();
                    break;
                case "3":
                    Console.WriteLine("Fin de aplicacion");
                    break;
                default:
                    Console.WriteLine("Seleccion invalida.");
                    MostrarMenu();
                    break;
            }
        }

        static void MostrarInforme()
        {
            Console.WriteLine("INFORME DE PRODUCTOS VENDIDOS");
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < productos.Length; i++)
            {
                int numero = i + 1;
                Producto producto = productos[i];
                Console.WriteLine("----------------------");
                Console.WriteLine("Producto {0}:", numero);
                Console.WriteLine("Nombre: {0}", producto.Nombre);
                Console.WriteLine("Precio: {0}", producto.Precio);
                Console.WriteLine("Cantidad restante: {0}", producto.Existencia);
            }
            Console.WriteLine("Presione cualquier tecla para volver al menu...");
            Console.ReadKey();
            MostrarMenu();
        }

        private static void ComprarProducto()
        {
            Console.WriteLine("LISTA DE PRODUCTOS DISPINOBLES:");
            for (int i = 0; i < productos.Length; i++)
            {
                int numero = i + 1;
                Producto producto = productos[i];
                Console.WriteLine("----------------------");
                Console.WriteLine("Producto {0}:", numero);
                Console.WriteLine("Nombre: {0}", producto.Nombre);
                Console.WriteLine("Precio: {0}", producto.Precio);
                Console.WriteLine("Cantidad restante: {0}", producto.Existencia);
            }
            Console.WriteLine("Inserte el numero de producto que desea:");
            string codigo = Console.ReadLine();
            int numeroProducto = int.Parse(codigo)-1;
            Producto productSeleccionado = productos[numeroProducto];
            Console.WriteLine("Ha seleccionado el producto {0} con un precio de RD${1}",productSeleccionado.Nombre, productSeleccionado.Precio);
            PagarProducto(productSeleccionado);
        }

        static void PagarProducto(Producto producto)
        {
            int montoRestante = producto.Precio;            
            while (montoRestante>0) {
                Console.WriteLine("Inserte el monto para pagar:");
                string valor = Console.ReadLine();
                int montoIngresado = int.Parse(valor);
                if (EsMontoValido(montoIngresado, montoRestante))
                {
                    montoRestante = montoRestante - montoIngresado;
                    if (montoRestante > 0) { 
                        Console.WriteLine("Monto restante {0}", montoRestante);
                    }
                }
                else
                {
                    Console.WriteLine("Por favor insertar un monto valido. La maquina solo acepta monedas de 5,10,25 y billetes de 50,100,200.");
                }
            }
            producto.Existencia--;
            Console.WriteLine("Compra de articulo existosa!!!");
            MostrarMenu();
        }

        static bool EsMontoValido(int montoPagado, int montoRestante)
        {
            int[] montosPermitidos = new int[] { 5, 10, 25, 50, 100, 200 };            
            for (int i = 0; i < montosPermitidos.Length; i++)
            {
                if(montoPagado == montosPermitidos[i] && montoRestante>= montoPagado)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
