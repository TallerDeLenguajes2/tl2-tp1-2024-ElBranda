using CadeteSpace;
using PedidoSpace;

namespace CadeteriaSpace {
    public class Cadeteria {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;
        public List<Pedido> listadoPedidos {get;set;}

        public Cadeteria() {
            nombre = null;
            telefono = null;
            listadoCadetes = [];
            listadoPedidos = [];
        } 
        public Cadeteria(string nombre, string telefono) {
            this.nombre = nombre;
            this.telefono = telefono;
            listadoCadetes = [];
            listadoPedidos = [];
        }

        public string Nombre {get=>nombre;set=>nombre=value;}
        public string Telefono {get=>telefono;set=>telefono=value;}
        public List<Cadete> ListadoCadetes {get=>listadoCadetes;}

        public void AgregarCadete(Cadete cadete) {
            listadoCadetes.Add(cadete);
        }
        public void AgregarPedido(Pedido pedido) {
            listadoPedidos.Add(pedido);
        }
        public float JornalACobrar(int id_cadete) {
            foreach (var c in listadoCadetes) {
                if (id_cadete == c.id) {
                    return c.pedidosDespachados*500;
                }
            }

            return 0;
        }
        public void AsignarCadeteAPedido(int id_cadete, int id_pedido) {
            foreach (var c in listadoCadetes) {
                if (id_cadete == c.id) {
                    foreach (var p in listadoPedidos) {
                        if (id_pedido == p.nro) {
                            p.cadete = c;
                            return;
                        }
                    }
                }
            }
        }
    }
}