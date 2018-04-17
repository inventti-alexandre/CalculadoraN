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
        public static object Crear(int tipo, double resultadoD, double resultadoD2 = 0)
        {
            object ResultadoObjeto ="";
            switch (tipo)
            {
                case (1):
                    {

                        ResultadoObjeto = new respSuma(resultadoD);
                        break;
                    }
                case (2):
                    {

                        ResultadoObjeto = new respResta(resultadoD);
                        break;
                    }
                case (3):
                    {
                        ResultadoObjeto = new respMult(resultadoD);
                        break;
                    }
                case (4):
                    {
                        ResultadoObjeto = new respDiv(resultadoD, resultadoD2);
                        break;
                    }
                case (5):
                    {
                        ResultadoObjeto = new respSqr(resultadoD);
                        break;
                    }
            }
            return ResultadoObjeto;
        }
        /*Json devuelto en caso de error */
        public static object CrearError(string Codigo, string estado, string mensaje)
        {
            ErrorObj ErrorDeDatos = new ErrorObj(Codigo, estado, mensaje);                   
            return ErrorDeDatos;
        }
    }
}

