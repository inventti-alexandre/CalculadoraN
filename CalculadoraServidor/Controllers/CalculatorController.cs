using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using CalculadoraServidor.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace CalculadoraServidor.Controllers
{
    [HandleException]
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
                    return Json(DivModel.dividir(datos, IdEvi));                          
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
            if (System.IO.File.Exists($"Journal\\{EviId.id}.txt"))
            {
                return Json(JournalModel.PedirJournal(EviId.id));
            }
            else
            {
                Response.StatusCode = 400;
                return Json(crearJson.CrearError("Internal Error", "400", "El fichero no existe"));
            }
        }


        public JsonResult Error()
        {
            return Json(crearJson.CrearError("Internal Error", "500", "Error interno"));
        }
    }
}