using Microsoft.AspNetCore.Mvc;
using CalculadoraServidor.Models;
using System;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace CalculadoraServidor.Controllers
{

    public class Calculator : Controller
    {



        public string Index()
        {
            return "Código por defecto";

        }

        /*
        Cada controlador comprueba que las datos sean correctos, si lo son cada modelo se encarga del calculo
        en caso de que no lo sea devuelve un error 400 con la info en el json
         */
        // Post a suma

        [HttpPost]
        public object Add([FromBody]Objsuma datos)
        {
            try{
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if (datos.GetSumandos().Length > 1)
            {
                return AddModel.sumar(datos, IdEvi);
            }
            else
            {
                Response.StatusCode = 400;
                return crearJson.CrearError("Internal Error", "400", "Datos introducidos erróneos");
            }
            }
            catch(Exception)
            {
                Response.StatusCode =500;
                return crearJson.CrearError("Error inesperado","500","Error inesperado en el servidor");
            }

        }
        // Post a resta
        [HttpPost]
        public object Sub([FromBody]ObjResta datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if (datos.GetSubtrahend().Length > 0)
            {
                return SubModel.restar(datos, IdEvi);
            }
            else
            {
                Response.StatusCode = 400;
                return crearJson.CrearError("Internal Error", "400", "Datos introducidos erróneos");
            }
        }
        // Post a multiplicacion
        [HttpPost]
        public object Mult([FromBody]ObjMult datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if (datos.GetFactors().Length > 1)
            {
                return MultModel.multiplicar(datos, IdEvi);
            }
            else
            {
                Response.StatusCode = 400;
                return crearJson.CrearError("Internal Error", "400", "Datos introducidos erróneos");
            }

        }
        // Post a division
        [HttpPost]
        public object Div([FromBody]ObjDiv datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if (datos.GetDivisor().Length > 0)
            {
                try
                {
                    return DivModel.dividir(datos, IdEvi);
                }
                catch (Exception)
                {
                    Response.StatusCode = 400;
                    return crearJson.CrearError("Internal Error", "400", "Division entre 0");
                }
            }
            else
            {
                Response.StatusCode = 400;
                return crearJson.CrearError("Internal Error", "400", "Datos introducidos erróneos");
            }
        }
        // Post a raiz cuadrada
        [HttpPost]
        public object Sqrt([FromBody]ObjSqr datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            return SqrModel.RaizCuadrada(datos, IdEvi);
        }
        // Post a journal
        [HttpPost]
        public object Journal([FromBody]ObjId EviId)
        {

            try
            {
                
                return JournalModel.PedirJournal(EviId.GetId());;
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
                return crearJson.CrearError("Internal Error", "400", "Datos introducidos erróneos");
            }

        }





    }
}