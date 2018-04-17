
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
public class deserializeResponse
{
    /*Deserializaciones para json */
    public static string DeserializeSuma(string JsEntrada)
    {

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
        respSqr ObjResult = JsonConvert.DeserializeObject<respSqr>(JsEntrada);
        return ObjResult;
    }

    /*Deserialización a la respuesta de la petición al journal*/
    public static string[] DeserializeResponseYConvertir(string JsEntrada)
    {
        try
        {
            respJournalConjunta RespuestaOperaciones = JsonConvert.DeserializeObject<respJournalConjunta>(JsEntrada);
            respJournal[] FilasOperaciones = RespuestaOperaciones.GetFilas();
            string[] OperacionesString = new string[FilasOperaciones.Length];
            for (int a = 0; a < FilasOperaciones.Length; a++)
            {
                OperacionesString[a] = FilasOperaciones[a].GetFecha() + " || " + FilasOperaciones[a].GetOperacion() + " || " + FilasOperaciones[a].GetCalculo();
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

    public static string CrearErrorMalDatos(string json)
    {
        ErrorObj ObjResult = JsonConvert.DeserializeObject<ErrorObj>(json);
        return $"Error: {ObjResult.GetErrorMessage()}";
    }
}