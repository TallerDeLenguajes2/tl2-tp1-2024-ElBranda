using ClienteSpace;

namespace PedidoSpace {
    public class Pedido {
        private string nro;
        private string obs;
        private Cliente cliente;
        private Estado estado;
        public enum Estado { EN_PROCESO, PREPARANDO_PEDIDO, LLEVANDO_PEDIDO, PEDIDO_ENTREGADO };

        public Pedido(string nro, string obs, Cliente cliente) {
            this.nro = nro;
            this.obs = obs;
            this.cliente = cliente;
            estado = Estado.EN_PROCESO;
        }

        public Estado Estate {get=>estado;set=>estado=value;}

        public void VerDatosPedido() {
            Console.WriteLine("Obs: "+obs);
            Console.WriteLine("Nro: "+nro);
            Console.WriteLine("Estado: "+estado);
        }
        public void VerDireccionCliente() {
            Console.WriteLine(cliente.Direccion);
            Console.WriteLine(cliente.DatosReferenciaDireccion);
        }
        public void VerDatosCliente() {
            Console.WriteLine(cliente.Nombre);
            Console.WriteLine(cliente.Telefono);
        }
    }
}