using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2ProductosyProveedores.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2ProductosyProveedores.Controllers
{
    public class ProductosController : Controller
    {
        // GET: /<controller>/
        public IActionResult AgregarProducto()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AgregarProducto(DatosProductos datosProductos, Productos productos)
        {

            if (ModelState.IsValid)
            {
            
                    datosProductos.Productos.Add(productos);
                return RedirectToAction("VerProductos", productos);
            }

            return View(productos);
        }

        public IActionResult VerProductos(DatosProductos datosProductos)
        {
    
            return View(datosProductos);
        }


        public IActionResult EditarProducto(Productos productos)
        {

            return View(productos);

        }
        [HttpPost]
        public IActionResult EditarProducto(DatosProductos datosProductos, Productos productos)
        {

            if (ModelState.IsValid)
            {
                var opciones = Request.Form["opciones"];
                foreach(var datos in datosProductos.Productos) {
                   
                    if(datos.ID.ToString() == opciones) { 
                    ViewData["Codigo"] = datos.ID;
                    ViewData["Nombre"] = datos.NOMBRE;
                    ViewData["descripcion"] = datos.DESCRIPCION;
                    ViewData["FechaVenc"] = datos.FECHA_VENC;
                    ViewData["IDproveedor"] = datos.ID_PROVEEDOR;
                        break;
                    }

                }
                var SaveButton = Request.Form["Save"];
                if (SaveButton == "save")
                {
                    int x = 0;

                    foreach (var datos in datosProductos.Productos)
                    {
                        if (datos.ID == productos.ID)
                        {
                            break;

                        }
                        x++;
                    }

                    datosProductos.Productos.RemoveAt(x);
                    datosProductos.Productos.Add(productos);
                    return RedirectToAction("VerProductos", productos);
                }



            }

            return View(productos);
        }
        public IActionResult EliminarProducto(DatosProductos datosProductos)
        {

            return View(datosProductos);

        }
        [HttpPost]
        public IActionResult EliminarProducto(DatosProductos datosProductos, Productos productos)
        {

            if (ModelState.IsValid)
            {
            
                     var ID = Request.Form["opciones"];
                    foreach (var datos in datosProductos.Productos)
                    {

                        if ( ID == datos.ID.ToString())
                        {
                            ViewData["Codigo"] = datos.ID;
                            ViewData["Nombre"] = datos.NOMBRE;
                            ViewData["descripcion"] = datos.DESCRIPCION;
                            ViewData["FechaVenc"] = datos.FECHA_VENC;
                            ViewData["IDproveedor"] = datos.ID_PROVEEDOR;
                            break;

                        }

                    }

               
                    var DeleteButton = Request.Form["Delete"];
                    if (DeleteButton== "delete")
                    {
                        int x = 0;
                  
                        foreach (var datos in datosProductos.Productos)
                        {
                            if(datos.ID == datosProductos.IDSelected){
                                break;

                            }
                        x++;
                        }
                      
                        datosProductos.Productos.RemoveAt(x);
                         return View("VerProductos",datosProductos);
                }
                
            }

            return View(datosProductos);
        }


    }
}

