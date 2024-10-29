using HelperSpace;
using ClienteSpace;
using CadeteriaSpace;
using CadeteSpace;
using System.Runtime.InteropServices.Marshalling;
using PedidoSpace;
using System.Diagnostics;

Cliente cliente = new("Etelredo I", "Castillo de Highclere", "+44 1635 253210", "Al lado del Highclere Park");
Cadeteria cadeteria = new();
List<Pedido> pedidosNoAsignados = [];
bool salir = false;

if (Helper.CargarDesdeCSV(ref cadeteria)) {
    while (!salir) {
        Console.Clear();
        Console.WriteLine("------------ MENÚ ------------");
        Console.WriteLine("a) Dar de alta pedidos");
        Console.WriteLine("b) Asignarlos a cadetes");
        Console.WriteLine("c) Cambiarlos de estado");
        Console.WriteLine("d) Reasignar pedido a otro cadete");
        Console.Write("Comando: ");
        char command = Console.ReadKey().KeyChar; Console.WriteLine();

        switch (command) {
            case 'a':
                Helper.DarDeAlta(cliente, ref pedidosNoAsignados);
                break;
            case 'b':
                Helper.AsignarACadete(ref cadeteria, ref pedidosNoAsignados);
                break;
            case 'c':
                Helper.CambiarEstado(ref cadeteria);
                break;
            case 'd':
                Helper.ReasignarPedido(ref cadeteria);
                break;
            case 'q': Helper.Informe(ref cadeteria); salir=true; break;
            default: break;
        }

        // if (pedidosNoAsignados.Count > 0) foreach (var p in pedidosNoAsignados) p.VerDatosPedido();

        // if (cadeteria.ListadoCadetes.Count > 0)
        //     foreach (var p in cadeteria.ListadoCadetes)
        //         if (p.ListaPedidos.Count > 0) {
        //             Console.WriteLine(p.nombre);
        //             foreach(var e in p.ListaPedidos)
        //                 e.VerDatosPedido();
        //         } 

        char s = Console.ReadKey().KeyChar;
    } 
} else {
    Console.WriteLine("NO SE PUDO CONECTAR, PA. MIRÁ YA LOS ARCHIVOS CSV QUE ESTÉN DONDE TIENEN QUE ESTAR");
}
