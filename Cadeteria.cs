using CadeteSpace;

namespace CadeteriaSpace {
    public class Cadeteria {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;

        public Cadeteria() {
            nombre = null;
            telefono = null;
            listadoCadetes = [];
        } 
        public Cadeteria(string nombre, string telefono) {
            this.nombre = nombre;
            this.telefono = telefono;
            listadoCadetes = [];
        }

        public string Nombre {get=>nombre;set=>nombre=value;}
        public string Telefono {get=>telefono;set=>telefono=value;}
        public List<Cadete> ListadoCadetes {get=>listadoCadetes;}

        public void AgregarCadete(Cadete cadete) {
            listadoCadetes.Add(cadete);
        }
    }
}