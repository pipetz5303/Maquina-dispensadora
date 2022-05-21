using System;
using System.Collections.Generic;

namespace BD
{
    public partial class Producto
    {
        


        public int IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public int Marca { get; set; }
        public int Precio { get; set; }
        public int UnidadesDisp { get; set; }

        public virtual Marca MarcaNavigation { get; set; } = null!;
    }
}
