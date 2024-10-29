using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks.Dataflow;
using CadeteriaSpace;
using CadeteSpace;
using ClienteSpace;
using PedidoSpace;

namespace HelperSpace {
    public class Helper {
        public static bool CargarDesdeCSV(ref Cadeteria cadeteria) {
            string path1 = "CSV/Cadeteria.csv";
            string path2 = "CSV/Cadetes.csv";

            if (File.Exists(path1) && File.Exists(path2)) {
                //CARGA DE CADETERIA
                string[] linea = File.ReadAllLines(path1);
                var data = linea[0].Split(',');

                cadeteria.Nombre = data[0];
                cadeteria.Telefono = data[1];

                //CARGA DE CADETES
                linea = File.ReadAllLines(path2);
                foreach (var line in linea) {
                    data = line.Split(',');
                    Cadete cadete = new(int.Parse(data[0]), data[1], data[2], data[3]);
                    cadeteria.AgregarCadete(cadete);
                } 
            } else return false;

            return true;
        }

        public static void DarDeAlta(Cliente cliente, ref List<Pedido> pedidosNoAsignados) {
            string nro, obs;

            nro = ""+new Random().Next(0,100000);

            Console.Write("OBS: ");
            obs = Console.ReadLine();

            Pedido pedido = new(nro, obs, cliente);

            pedidosNoAsignados.Add(pedido);
        }

        public static void AsignarACadete(ref Cadeteria cadeteria, ref List<Pedido> pedidosNoAsignados) {
            if (cadeteria.ListadoCadetes.Count == 0) {
                Console.WriteLine("No hay cadetes disponibles...");
                return;
            }

            if (pedidosNoAsignados.Count == 0) {
                Console.WriteLine("No hay pedidos disponibles...");
                return;
            }

            int elegirCadete = new Random().Next(0,cadeteria.ListadoCadetes.Count);

            cadeteria.ListadoCadetes[elegirCadete].AgregarPedido(pedidosNoAsignados[0]);
            pedidosNoAsignados.RemoveAt(0);
        }

        public static void CambiarEstado(ref Cadeteria cadeteria) {
            if (cadeteria.ListadoCadetes.Count == 0) {
                Console.WriteLine("No hay cadetes disponibles...");
                return;
            }

            Console.WriteLine("Qué cadete quiere ver: ");
            foreach(var c in cadeteria.ListadoCadetes) {
                if (c.ListaPedidos.Count > 0) {
                    c.VerDatosCadete();
                    Console.WriteLine();
                }
            }
            int ccad = int.Parse(Console.ReadLine());

            Console.WriteLine("Qué pedido quiere cambiar estado: ");
            foreach (var p in cadeteria.ListadoCadetes[ccad-1].ListaPedidos) {
                p.VerDatosPedido();
                Console.WriteLine();
            }

            int cped = int.Parse(Console.ReadLine());

            var pedido = cadeteria.ListadoCadetes[ccad - 1].ListaPedidos[cped - 1];

            if (pedido.Estate == Pedido.Estado.LLEVANDO_PEDIDO) {
                cadeteria.ListadoCadetes[ccad-1].pedidosDespachados++;
                cadeteria.ListadoCadetes[ccad-1].ListaPedidos.RemoveAt(cped-1);
            } else cadeteria.ListadoCadetes[ccad - 1].ListaPedidos[cped - 1].Estate = (Pedido.Estado)(((int)pedido.Estate) + 1);
        }

        public static void ReasignarPedido(ref Cadeteria cadeteria) {
            if (cadeteria.ListadoCadetes.Count == 0) {
                Console.WriteLine("No hay cadetes disponibles...");
                return;
            }

            Console.WriteLine("Qué cadete quiere reasignarle el pedido y a quien asignarle: ");
            foreach(var c in cadeteria.ListadoCadetes) {
                if (c.ListaPedidos.Count > 0) {
                    c.VerDatosCadete();
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Reasignarle a: ");
            int ccad1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Asignarle a: ");
            int ccad2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Qué pedido quiere reasignar: ");
            foreach (var p in cadeteria.ListadoCadetes[ccad1-1].ListaPedidos) {
                p.VerDatosPedido();
                Console.WriteLine();
            }

            int cped = int.Parse(Console.ReadLine());

            cadeteria.ListadoCadetes[ccad2-1].AgregarPedido(cadeteria.ListadoCadetes[ccad1-1].ListaPedidos[cped-1]);
            cadeteria.ListadoCadetes[ccad1-1].ListaPedidos.RemoveAt(cped-1);
        }

        public static void Informe(ref Cadeteria cadeteria) {
            if (cadeteria.ListadoCadetes.Count == 0) {
                Console.WriteLine("No hay cadetes registrados");
                Console.WriteLine("Ganancia total: 0");
                return;
            }

            int ganancia=0, promedio=0;

            foreach(var c in cadeteria.ListadoCadetes) {
                c.VerDatosCadete();
                Console.WriteLine("Total a cobrar: "+c.JornalACobrar());
                Console.WriteLine("Pedidos totales: "+c.pedidosDespachados);
                ganancia+=c.JornalACobrar();
                promedio+=c.pedidosDespachados;
            }

            Console.WriteLine("La ganancia total fue de: "+ganancia);
            Console.WriteLine("Promedio de envios fue de: "+(float)promedio/cadeteria.ListadoCadetes.Count);
        }
    }
}