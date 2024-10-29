using PedidoSpace;

namespace ClienteSpace {
    public class Cliente {
        private string nombre;
        private string direccion;
        private string telefono;
        private string datosReferenciaDireccion;
        private List<Pedido> listaPedidos;

        public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion) {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.datosReferenciaDireccion = datosReferenciaDireccion;
        }
        public void AgregarPedido(Pedido pedido) {
            listaPedidos.Add(pedido);
        }
        public string Nombre {get=>nombre;}
        public string Direccion { get=>direccion; }
        public string Telefono {get=>telefono;}
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; }
    }
}