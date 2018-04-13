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
        
        // 
        // GET: /HelloWorld/ 

        public string Index()
        {
            return "Código por defecto";
            
        }

        // 
        // POST: /Calculator/Add
        
        [HttpPost]
        public string Add([FromBody]Objsuma datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];   
            if(datos.GetSumandos().Length > 1)
            { 
            return AddModel.sumar(datos, IdEvi);
            }
            else
            { 
                Response.StatusCode=400;
                return crearJson.CrearError("Internal Error", "400","Datos introducidos erróneos");
            }
               
        }
        
        [HttpPost]
        public string Sub([FromBody]ObjResta datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if(datos.GetSubtrahend().Length > 0)
            { 
            return SubModel.restar(datos, IdEvi);     
            }
            else
            {
                Response.StatusCode=400;
                return crearJson.CrearError("Internal Error", "400","Datos introducidos erróneos");
            }       
        }

        [HttpPost]
        public string Mult([FromBody]ObjMult datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if(datos.GetFactors().Length > 1)
            {     
                return MultModel.multiplicar(datos, IdEvi);
            }
            else
            {
                Response.StatusCode=400;
                return crearJson.CrearError("Internal Error", "400","Datos introducidos erróneos");
            }  
           
        }

        [HttpPost]
        public string Div([FromBody]ObjDiv datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            if(datos.GetDivisor().Length > 0)
            {
            try
            {
            return DivModel.dividir(datos, IdEvi);    
            }
            catch(Exception)
            {
                Response.StatusCode=400;
                return crearJson.CrearError("Internal Error", "400","Division entre 0");
            }
            }
            else
            {
                Response.StatusCode=400;
                return crearJson.CrearError("Internal Error", "400","Datos introducidos erróneos");
            }
        }

        [HttpPost]
        public string Sqrt([FromBody]ObjSqr datos)
        {
            string IdEvi = Request.Headers[key: "X-Evi-Tracking-Id"];
            return SqrModel.RaizCuadrada(datos, IdEvi);         
        }

        [HttpPost]
        public string Journal([FromBody]ObjId EviId)
        {
            string journal =  JournalModel.PedirJournal(EviId.GetId());
            
            try
            {  
                JsonConvert.DeserializeObject<List<respJournal>>(journal);
                return journal;
            }
            catch(Exception)
            {
                Response.StatusCode=400;
                return journal;
            }

        }





    }
}