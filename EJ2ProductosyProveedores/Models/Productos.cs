using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2ProductosyProveedores.Models
{
    public class Productos
    {

        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }

        [DataType(DataType.Date)]
        public string FECHA_VENC { get; set; }
        public int ID_PROVEEDOR { get; set; }

    }

    public class DatosProductos
    {
        public int[] SelectedItem { get; set; }
        public int IDSelected { get; set; }
        private static List<Productos> Producto;
        public List<Productos> Productos
        {
            get
            {
                if (Producto == null)
                {
                    Producto = new List<Productos>();
                }
                return Producto;
            }
        }
    }
}
