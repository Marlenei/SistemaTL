﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;


namespace TonerHP.Controllers
{
    public class TonerController : Controller
    {
        // GET: Toner
        public ActionResult Proveedores()
        {
            return View();
        }

        public ActionResult Tipos()
        {
            return View();
        }

        public ActionResult Productos()
        {
            return View();
        }
        //RUBROS

        #region RUBROS
        [HttpGet]
        public JsonResult ListarRubros()
        {
            List<Rubros> oLista = new List<Rubros>();
            oLista = new CN_Rubros().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //PROVEEDORES

        #region PROVEEDORES
        [HttpGet]
        public JsonResult ListarProveedores()
        {
            List<Proveedores> oLista = new List<Proveedores>();
            oLista = new CN_Proveedores().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarProveedor(Proveedores objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdProveedor == 0)
            {
                resultado = new CN_Proveedores().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Proveedores().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarProveedor(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Proveedores().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        #endregion
        //TIPOS
        #region TIPOS
        [HttpGet]
        public JsonResult ListarTipos()
        {
            List<Tipos> oLista = new List<Tipos>();
            oLista = new CN_Tipos().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarTipos(Tipos objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdTipo == 0)
            {
                resultado = new CN_Tipos().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Tipos().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTipos(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Tipos().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        //PRODUCTOS
        #region PRODUCTOS
        [HttpGet]
        public JsonResult ListarProductos()
        {
            List<Productos> oLista = new List<Productos>();
            oLista = new CN_Productos().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public JsonResult GuardarProductos(Productos objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdProducto == 0)
            {
                resultado = new CN_Productos().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Productos().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
