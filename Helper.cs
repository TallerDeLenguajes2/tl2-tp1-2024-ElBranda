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

            if (File.Exists(path1)) {
                //CARGA DE CADETERIA
                string[] linea = File.ReadAllLines(path1);
                var data = linea[0].Split(',');

                cadeteria.Nombre = data[0];
                cadeteria.Telefono = data[1];
            } else {
                Console.WriteLine("NO SE PUDO CARGAR CADETERIA.CSV");
                return false;
            }

            if (File.Exists(path2)) {
                //CARGA DE CADETES
                string[] linea = File.ReadAllLines(path2);
                var data = linea[0].Split(',');

                linea = File.ReadAllLines(path2);
                foreach (var line in linea) {
                    data = line.Split(',');
                    Cadete cadete = new(int.Parse(data[0]), data[1], data[2], data[3]);
                    cadeteria.AgregarCadete(cadete);
                } 
            } else {
                Console.WriteLine("NO SE PUDO CARGAR CADETES.CSV");

                return false;
            }

            return true;
        }

        public static void DarDeAlta(Cliente cliente, ref Cadeteria cadeteria) {
            int nro;
            string obs;

            nro = new Random().Next(0,100000);

            Console.Write("OBS: ");
            obs = Console.ReadLine();

            Pedido pedido = new(nro, obs, cliente, cadeteria.ListadoCadetes[new Random().Next(0,cadeteria.ListadoCadetes.Count)]);

            cadeteria.AgregarPedido(pedido);
        }

        // public static void AsignarACadete(ref Cadeteria cadeteria, ref List<Pedido> pedidosNoAsignados) {
        //     if (cadeteria.ListadoCadetes.Count == 0) {
        //         Console.WriteLine("No hay cadetes disponibles...");
        //         return;
        //     }

        //     if (pedidosNoAsignados.Count == 0) {
        //         Console.WriteLine("No hay pedidos disponibles...");
        //         return;
        //     }

        //     int elegirCadete = new Random().Next(0,cadeteria.ListadoCadetes.Count);

        //     cadeteria.ListadoCadetes[elegirCadete].AgregarPedido(pedidosNoAsignados[0]);
        //     pedidosNoAsignados.RemoveAt(0);
        // }

        public static void CambiarEstado(ref Cadeteria cadeteria) {
            if (cadeteria.ListadoCadetes.Count == 0) {
                Console.WriteLine("No hay cadetes disponibles...");
                return;
            }

            Console.WriteLine("Qué cadete quiere ver: ");
            foreach(var c in cadeteria.listadoPedidos) {
                c.cadete.VerDatosCadete();
                Console.WriteLine();
            }
            int ccad = int.Parse(Console.ReadLine());

            Console.WriteLine("Qué pedido quiere cambiar estado: ");
            foreach (var p in cadeteria.listadoPedidos) {
                p.VerDatosPedido();
                Console.WriteLine();
            }

            int cped = int.Parse(Console.ReadLine());

            var pedido = cadeteria.listadoPedidos[cped - 1];

            if (pedido.Estate == Pedido.Estado.LLEVANDO_PEDIDO) {
                cadeteria.listadoPedidos[cped-1].cadete.pedidosDespachados++;
                cadeteria.listadoPedidos.RemoveAt(cped-1);
            } else cadeteria.listadoPedidos[cped - 1].Estate = (Pedido.Estado)(((int)pedido.Estate) + 1);
        }

        public static void ReasignarPedido(ref Cadeteria cadeteria) {
            if (cadeteria.ListadoCadetes.Count == 0) {
                Console.WriteLine("No hay cadetes disponibles...");
                return;
            }

            Console.WriteLine("Qué pedido quiere reasignar: ");
            foreach(var c in cadeteria.listadoPedidos) {
                c.VerDatosPedido();
                Console.WriteLine();
            }

            int ped = int.Parse(Console.ReadLine());

            Console.WriteLine("Reasignarlo a: ");
            
            foreach(var c in cadeteria.ListadoCadetes) {
                c.VerDatosCadete();
                Console.WriteLine();
            }

            int cad = int.Parse(Console.ReadLine());

            cadeteria.listadoPedidos[ped-1].cadete = cadeteria.ListadoCadetes[cad-1];
        }

        public static void Informe(ref Cadeteria cadeteria) {
            if (cadeteria.ListadoCadetes.Count == 0) {
                Console.WriteLine("No hay cadetes registrados");
                Console.WriteLine("Ganancia total: 0");
                return;
            }

            float ganancia=0, promedio=0;

            foreach(var c in cadeteria.ListadoCadetes) {
                c.VerDatosCadete();
                Console.WriteLine("Total a cobrar: "+cadeteria.JornalACobrar(c.id));
                Console.WriteLine("Pedidos totales: "+c.pedidosDespachados);
                ganancia+=cadeteria.JornalACobrar(c.id);
                promedio+=c.pedidosDespachados;
            }

            Console.WriteLine("La ganancia total fue de: "+ganancia);
            Console.WriteLine("Promedio de envios fue de: "+(float)promedio/cadeteria.ListadoCadetes.Count);
        }
    }
}