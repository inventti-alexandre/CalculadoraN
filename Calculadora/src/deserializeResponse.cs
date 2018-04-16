
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
public class deserializeResponse
{

    /*Deserializaciones para json */
    public static string DeserializeSuma(string JsEntrada)
    {
        JsEntrada = quitarEscapes(JsEntrada);
        if (!JsEntrada.Contains("ErrorCode"))
        {
            respSuma ObjResult = JsonConvert.DeserializeObject<respSuma>(JsEntrada);
            return ($"El resultado es : {ObjResult.GetSum()}");
        }
        else
        {
            Console.WriteLine();
            return CrearErrorMalDatos(JsEntrada);
        }
    }

    public static string DeserializeResta(string JsEntrada)
    {
        if (!JsEntrada.Contains("ErrorCode"))
        {
            JsEntrada = quitarEscapes(JsEntrada);
            respResta ObjResult = JsonConvert.DeserializeObject<respResta>(JsEntrada);
            return ($"El resultado es : { ObjResult.GetDiferencia()}");
        }
        else
        {
            Console.WriteLine();
            return CrearErrorMalDatos(JsEntrada);
        }
    }

    public static string DeserializeMult(string JsEntrada)
    {
        if (!JsEntrada.Contains("ErrorCode"))
        {
            JsEntrada = quitarEscapes(JsEntrada);
            respMult ObjResult = JsonConvert.DeserializeObject<respMult>(JsEntrada);
            return ($"El resultado es : {ObjResult.GetMultip()}");
        }
        else
        {
            Console.WriteLine();
            return CrearErrorMalDatos(JsEntrada);
        }
    }

    public static string DeserializeDiv(string JsEntrada)
    {
        if (!JsEntrada.Contains("ErrorCode"))
        {
            JsEntrada = quitarEscapes(JsEntrada);
            respDiv ObjResult = JsonConvert.DeserializeObject<respDiv>(JsEntrada);
            return ($"El resultado es : {ObjResult.GetResultado()} Resto: {ObjResult.GetResto()}");
        }
        else
        {
            Console.WriteLine();
            return CrearErrorMalDatos(JsEntrada);
        }
    }


    public static respSqr DeserializeSqrt(string JsEntrada)
    {
        JsEntrada = quitarEscapes(JsEntrada);
        respSqr ObjResult = JsonConvert.DeserializeObject<respSqr>(JsEntrada);
        return ObjResult;
    }

    /*Deserialización a la respuesta de la petición al journal*/
    public static string[] DeserializeResponseYConvertir(string JsEntrada)
    {
        try
        {
            JsEntrada = quitarSaltos(JsEntrada);
            JsEntrada = quitarEscapes(JsEntrada);
            List<respJournal> RespuestaOperaciones = JsonConvert.DeserializeObject<List<respJournal>>(JsEntrada);
            string[] OperacionesString = new string[RespuestaOperaciones.Count];
            for (int a = 0; a < RespuestaOperaciones.Count; a++)
            {
                OperacionesString[a] = RespuestaOperaciones[a].GetFecha() + " || " + RespuestaOperaciones[a].GetOperacion() + " || " + RespuestaOperaciones[a].GetCalculo();
            }
            return OperacionesString;
        }
        catch (Exception)
        {
            string[] error = new string[3];
            try
            {
                ErrorObj ObjResult = JsonConvert.DeserializeObject<ErrorObj>(JsEntrada);
                error[0] = $"Code: {ObjResult.GetErrorCode()}";
                error[1] = $"Status: {ObjResult.GetErrorStatus()}";
                error[2] = $"Message: {ObjResult.GetErrorMessage()}";
            }
            catch (Exception)
            {
                error[0] = "Code: Not Found";
                error[1] = "Status: 404";
                error[2] = "Message: No se pudo contactar con el servidor";
            }
            return error;
        }
    }
    /*En caso de que el json venga con saltos de linea o comillas extra método para quitarlas */
    public static string quitarEscapes(string salida)
    {

        salida = salida.Replace("\\", string.Empty);
        salida = salida.Trim('"');
        return salida;
    }
    public static string quitarSaltos(string salida)
    {
        salida = salida.Replace("\\n", string.Empty);
        salida = salida.Replace("\\r", string.Empty);
        return salida;
    }

    public static string CrearErrorMalDatos(string json)
    {
        json = quitarEscapes(json);
        ErrorObj ObjResult = JsonConvert.DeserializeObject<ErrorObj>(json);
        return $"Error: {ObjResult.GetErrorMessage()}";
    }

}