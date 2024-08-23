class Cadeteria {
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;

    public Cadeteria(string nombre, string telefono) {
        this.nombre = nombre;
        this.telefono = telefono;
    }

    public void AgregarCadete(Cadete cadete) {
        listadoCadetes.Add(cadete);
    }
}

class Cadete {
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadoPedidos;
    private int pedidosDespachados;
}

class Pedido {

}