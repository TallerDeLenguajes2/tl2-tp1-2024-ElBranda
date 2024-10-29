using PedidoSpace;

namespace CadeteSpace {
    public class Cadete {
        public int id {get;set;}
        public string nombre {get;set;}
        public string direccion {get;set;}
        public string telefono {get;set;}
        private List<Pedido> listadoPedidos;
        public int pedidosDespachados {get;set;}

        public Cadete(int id, string nombre, string direccion, string telefono) {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            listadoPedidos = [];
            pedidosDespachados = 0;
        }

        public void AgregarPedido(Pedido pedido) {
            listadoPedidos.Add(pedido);
        }
        public int JornalACobrar() {
            return pedidosDespachados*500;
        }
        public List<Pedido> ListaPedidos {get => listadoPedidos;}

        public void VerDatosCadete() {
            Console.WriteLine(id);
            Console.WriteLine(nombre);
        }
    }
}