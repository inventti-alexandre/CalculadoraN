using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using CalculadoraServidor.Models;
using Microsoft.AspNetCore.Diagnostics;

using CalculadoraServidor.Interfaces;
using CalculadoraServidor.servicios;

namespace CalculadoraServidor.Controllers
{


    public class CalculatorController : Controller
    {
        private readonly IservicioCalc _servicioCalc;


        public CalculatorController(IservicioCalc calculatorService)
        {
            _servicioCalc = calculatorService;
        }

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
                var resultado = _servicioCalc.calcular(new AddModel(datos.addens));
                saveInFile.GuardarOperaciones(IdEvi,$"{_servicioCalc.ToString(new AddModel(datos.addens))}{resultado.Sum}",String.Format("{0:u}", DateTime.Now), "sum");
                return Json(resultado);
            }
            else
            {
                return ErrorDatos();
            }
        }
        // Post a resta
        [HttpPost]
        public JsonResult Sub([FromBody]ObjResta datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if (datos.subtrahend.Length > 0)
            {
                var resultado = _servicioCalc.calcular(new SubModel(datos.minuend, datos.subtrahend));
                saveInFile.GuardarOperaciones(IdEvi,$"{_servicioCalc.ToString(new SubModel(datos.minuend,datos.subtrahend))}{resultado.difference}",String.Format("{0:u}", DateTime.Now), "sub");
                return Json(resultado);
            }
            else
            {
                return ErrorDatos();
            }
        }
        // Post a multiplicacion
        [HttpPost]
        public JsonResult Mult([FromBody]ObjMult datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if (datos.factors.Length > 1)
            {
                var resultado = _servicioCalc.calcular(new MultModel(datos.factors));
                saveInFile.GuardarOperaciones(IdEvi,$"{_servicioCalc.ToString(new MultModel(datos.factors))}{resultado.product}",String.Format("{0:u}", DateTime.Now), "mul");
                return Json(resultado);
            }
            else
            {
                return ErrorDatos();
            }
        }
        // Post a division
        [HttpPost]
        public JsonResult Div([FromBody]ObjDiv datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if (datos.divisor.Length > 0)
            {
                var resultado = _servicioCalc.calcular(new DivModel(datos.dividend, datos.divisor));
                saveInFile.GuardarOperaciones(IdEvi,$"{_servicioCalc.ToString(new DivModel(datos.dividend,datos.divisor))}{resultado.quotient} R: {resultado.remainder}",String.Format("{0:u}", DateTime.Now), "div");
                return Json(resultado);
            }
            else
            {
                return ErrorDatos();
            }
        }
        // Post a raiz cuadrada
        [HttpPost]
        public JsonResult Sqrt([FromBody]ObjSqr datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            var resultado = _servicioCalc.calcular(new SqrModel(datos.number));
            saveInFile.GuardarOperaciones(IdEvi,$"{_servicioCalc.ToString(new SqrModel(datos.number))}{resultado.square}",String.Format("{0:u}", DateTime.Now), "sqr");
            return Json(resultado);
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
                return ErrorDatos("No existen datos de ese usuario");
            }
        }


        public JsonResult Error()
        {
            return Json(crearJson.CrearError("Internal Error", "500", "Error interno"));
        }
        public JsonResult ErrorDatos(string mensaje = "Datos introducidos no válidos")
        {
            Response.StatusCode = 400;
            return Json(crearJson.CrearError("Bad Request", "400", mensaje));
        }
    }
}