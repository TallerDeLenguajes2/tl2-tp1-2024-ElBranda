using CadeteSpace;
using ClienteSpace;

namespace PedidoSpace {
    public class Pedido {
        public int nro {get;set;}
        private string obs;
        private Cliente cliente;
        public Cadete cadete {get;set;}
        private Estado estado;
        public enum Estado { EN_PROCESO, PREPARANDO_PEDIDO, LLEVANDO_PEDIDO, PEDIDO_ENTREGADO };

        public Pedido(int nro, string obs, Cliente cliente, Cadete cadete) {
            this.nro = nro;
            this.obs = obs;
            this.cliente = cliente;
            estado = Estado.EN_PROCESO;
            this.cadete = cadete;
        }

        public Estado Estate {get=>estado;set=>estado=value;}

        public void VerDatosPedido() {
            Console.WriteLine("Obs: "+obs);
            Console.WriteLine("Nro: "+nro);
            Console.WriteLine("Estado: "+estado);
            Console.WriteLine("Cadete: ");
            cadete.VerDatosCadete();
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