using Microsoft.AspNetCore.Mvc;
using CalculadoraServidor.Models;
using System;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace CalculadoraServidor.Controllers
{
    public class CalculatorController : Controller
    {
        /*
        Cada controlador comprueba que las datos sean correctos, si lo son cada modelo se encarga del calculo
        en caso de que no lo sea devuelve un error 400 con la info en el json
         */
        // Post a suma

        [HttpPost]
        public JsonResult Add([FromBody]ObjSuma datos)
        {
            try
            {
                string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
                if (datos.addens.Length > 1)
                {
                    return Json(AddModel.sumar(datos, IdEvi));
                }
                else
                {
                    Response.StatusCode = 400;
                    return Json(crearJson.CrearError("Internal Error", "400", "Datos introducidos erróneos"));
                }
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return Json(crearJson.CrearError("Error inesperado", "500", "Error inesperado en el servidor"));
            }
        }
        // Post a resta
        [HttpPost]
        public JsonResult Sub([FromBody]ObjResta datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if (datos.subtrahend.Length > 0)
            {
                return Json(SubModel.restar(datos, IdEvi));
            }
            else
            {
                Response.StatusCode = 400;
                return Json(crearJson.CrearError("Internal Error", "400", "Datos introducidos erróneos"));
            }
        }
        // Post a multiplicacion
        [HttpPost]
        public JsonResult Mult([FromBody]ObjMult datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if (datos.factors.Length > 1)
            {
                return Json(MultModel.multiplicar(datos, IdEvi));
            }
            else
            {
                Response.StatusCode = 400;
                return Json(crearJson.CrearError("Internal Error", "400", "Datos introducidos erróneos"));
            }
        }
        // Post a division
        [HttpPost]
        public JsonResult Div([FromBody]ObjDiv datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if (datos.GetDivisor().Length > 0)
            {
                try
                {
                    return Json(DivModel.dividir(datos, IdEvi));
                }
                catch (Exception)
                {
                    Response.StatusCode = 400;
                    return Json(crearJson.CrearError("Internal Error", "400", "Division entre 0"));
                }
            }
            else
            {
                Response.StatusCode = 400;
                return Json(crearJson.CrearError("Internal Error", "400", "Datos introducidos erróneos"));
            }
        }
        // Post a raiz cuadrada
        [HttpPost]
        public JsonResult Sqrt([FromBody]ObjSqr datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            return Json(SqrModel.RaizCuadrada(datos, IdEvi));
        }
        // Post a journal
        [HttpPost]
        public JsonResult Journal([FromBody]ObjId EviId)
        {
            try
            {

                return Json(JournalModel.PedirJournal(EviId.id));
            }
            catch (Exception)
            {
                Response.StatusCode = 400;

                return Json(crearJson.CrearError("Internal Error", "400", "Datos introducidos erróneos"));
            }

        }
    }
}