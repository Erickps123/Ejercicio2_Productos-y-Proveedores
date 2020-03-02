using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2ProductosyProveedores.Models
{
    public class Proveedores
    {

        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public string NUM_TELEF { get; set; }

    }

    public class DatosProveedor
    {
        public int IDSelected { get; set; }
        private static List<Proveedores> Proveedor;
        public List<Proveedores> Proveedores
        {
            get
            {
                if (Proveedor == null)
                {
                    Proveedor = new List<Proveedores>();
                }
                return Proveedor;
            }
        }
    }
}
