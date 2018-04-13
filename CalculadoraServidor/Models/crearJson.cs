using System;
using System.Runtime.Serialization.Json;
using System.IO;
namespace CalculadoraServidor.Models
{
    public class crearJson
    {

        /*
        1:suma
        2:resta
        3:multiplicacion
        4:division
        5:raiz
         */
        public static string Crear(int tipo, double resultadoD, double resultadoD2=0)
        {
            
            MemoryStream streamS = new MemoryStream();  
            DataContractJsonSerializer conversor = null;
            switch(tipo)
            {
                case(1):
                {
                    
                    respSuma ResultadoObjeto = new respSuma(resultadoD);
                    conversor = new DataContractJsonSerializer(typeof(respSuma)); 
                    conversor.WriteObject(streamS, ResultadoObjeto); 
                    break;
                }
                case(2):
                {
                    
                    respResta ResultadoObjeto = new respResta(resultadoD);
                    conversor = new DataContractJsonSerializer(typeof(respResta)); 
                    conversor.WriteObject(streamS, ResultadoObjeto); 
                    break;
                }
                case(3):
                {
                    respMult ResultadoObjeto = new respMult(resultadoD);
                    conversor = new DataContractJsonSerializer(typeof(respMult)); 
                    conversor.WriteObject(streamS, ResultadoObjeto); 
                    break;
                }
                case(4):
                {
                    respDiv ResultadoObjeto = new respDiv(resultadoD,resultadoD2);
                    conversor = new DataContractJsonSerializer(typeof(respDiv)); 
                    conversor.WriteObject(streamS, ResultadoObjeto); 
                    break;
                }
                case(5):
                {
                    respSqr ResultadoObjeto = new respSqr(resultadoD);
                    conversor = new DataContractJsonSerializer(typeof(respSqr)); 
                    conversor.WriteObject(streamS, ResultadoObjeto); 
                    break;
                }
            }            
            streamS.Position = 0;  
            StreamReader sr = new StreamReader(streamS);  
            String JsonFinal = sr.ReadToEnd();                             
            sr.Close();
            return JsonFinal;
        }

        public static string CrearError(string Codigo, string estado, string mensaje)
        {

            MemoryStream streamS = new MemoryStream();  
            DataContractJsonSerializer conversor = null;
            ErrorObj ErrorDeDatos= new ErrorObj(Codigo,estado,mensaje); 
            conversor = new DataContractJsonSerializer(typeof(ErrorObj)); 
            conversor.WriteObject(streamS, ErrorDeDatos); 
            streamS.Position = 0;  
            StreamReader sr = new StreamReader(streamS);  
            String JsonFinal = sr.ReadToEnd();                             
            sr.Close();
            return JsonFinal;  
        }


    }
}  
       
