using PedidoSpace;

namespace CadeteSpace {
    public class Cadete {
        public int id {get;set;}
        public string nombre {get;set;}
        public string direccion {get;set;}
        public string telefono {get;set;}
        public int pedidosDespachados {get;set;}

        public Cadete(int id, string nombre, string direccion, string telefono) {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            pedidosDespachados = 0;
        }

        public void VerDatosCadete() {
            Console.WriteLine(id);
            Console.WriteLine(nombre);
        }
    }
}