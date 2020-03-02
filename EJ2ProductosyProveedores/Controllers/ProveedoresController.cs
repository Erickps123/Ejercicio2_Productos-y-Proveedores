using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2ProductosyProveedores.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2ProductosyProveedores.Controllers
{
    public class ProveedoresController : Controller
    {
        // GET: /<controller>/
        public IActionResult AgregarProveedor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AgregarProveedor(DatosProveedor datosProveedor, Proveedores proveedores)
        {
            if (ModelState.IsValid)
            {
                datosProveedor.Proveedores.Add(proveedores);
                return RedirectToAction("VerProveedor", proveedores);
            }
            return View(proveedores);
        }

        public IActionResult VerProveedor(DatosProveedor datosProveedor)
        {
            return View(datosProveedor);
        }


        public IActionResult EditarProveedor(Proveedores proveedores)
        {

            return View(proveedores);

        }
        [HttpPost]
        public IActionResult EditarProveedor(DatosProveedor datosProveedor, Proveedores proveedores)
        {

            if (ModelState.IsValid)
            {
                var opciones = Request.Form["opciones"];
                foreach (var datos in datosProveedor.Proveedores)
                {

                    if (datos.ID.ToString() == opciones)
                    {
                        ViewData["Codigo"] = datos.ID;
                        ViewData["Nombre"] = datos.NOMBRE;
                        ViewData["Direccion"] = datos.DIRECCION;
                        ViewData["NumeroTel"] = datos.NUM_TELEF;
                  
                        break;
                    }

                }
                var SaveButton = Request.Form["Save"];
                if (SaveButton == "save")
                {
                    int x = 0;

                    foreach (var datos in datosProveedor.Proveedores)
                    {
                        if (datos.ID == proveedores.ID)
                        {
                            break;

                        }
                        x++;
                    }

                    datosProveedor.Proveedores.RemoveAt(x);
                    datosProveedor.Proveedores.Add(proveedores);
                    return RedirectToAction("VerProveedor", proveedores);
                }



            }

            return View(proveedores);
        }

        public IActionResult EliminarProveedor(DatosProveedor datosProveedor)
        {

            return View(datosProveedor);

        }
        [HttpPost]
        public IActionResult EliminarProveedor(DatosProveedor datosProveedor, Proveedores proveedores)
        {

            if (ModelState.IsValid)
            {

                var ID = Request.Form["opciones"];
                foreach (var datos in datosProveedor.Proveedores)
                {

                    if (ID == datos.ID.ToString())
                    {
                        ViewData["Codigo"] = datos.ID;
                        ViewData["Nombre"] = datos.NOMBRE;
                        ViewData["Direccion"] = datos.DIRECCION;
                        ViewData["NumTelefono"] = datos.NUM_TELEF;
                 
                        break;

                    }

                }


                var DeleteButton = Request.Form["Delete"];
                if (DeleteButton == "delete")
                {
                    int x = 0;

                    foreach (var datos in datosProveedor.Proveedores)
                    {
                        if (datos.ID == datosProveedor.IDSelected)
                        {
                            break;

                        }
                        x++;
                    }

                    datosProveedor.Proveedores.RemoveAt(x);
                    return View("VerProveedor", datosProveedor);
                }

            }

            return View(datosProveedor);
        }

    }
}
