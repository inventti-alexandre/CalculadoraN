
using System;

using Newtonsoft.Json;
public class deserializeResponse
{
    /*Deserializaciones para json */
    public static string DeserializeSuma(string JsEntrada)
    {

        if (!JsEntrada.Contains("errorCode"))
        {
            var objetoResultado = JsonConvert.DeserializeObject<respSuma>(JsEntrada);
            return ($"El resultado es : {objetoResultado.Sum}");
        }
        else
        {
            Console.WriteLine();
            return CrearErrorMalDatos(JsEntrada);
        }
    }
    public static string DeserializeResta(string JsEntrada)
    {
        if (!JsEntrada.Contains("errorCode"))
        {
            var objetoResultado = JsonConvert.DeserializeObject<respResta>(JsEntrada);
            return ($"El resultado es : { objetoResultado.difference}");
        }
        else
        {
            Console.WriteLine();
            return CrearErrorMalDatos(JsEntrada);
        }
    }

    public static string DeserializeMult(string JsEntrada)
    {
        if (!JsEntrada.Contains("errorCode"))
        {
            var objetoResultado = JsonConvert.DeserializeObject<respMult>(JsEntrada);
            return ($"El resultado es : {objetoResultado.product}");
        }
        else
        {
            Console.WriteLine();
            return CrearErrorMalDatos(JsEntrada);
        }
    }

    public static string DeserializeDiv(string JsEntrada)
    {
        if (!JsEntrada.Contains("errorCode"))
        {
            var objetoResultado = JsonConvert.DeserializeObject<respDiv>(JsEntrada);
            return ($"El resultado es : {objetoResultado.quotient} Resto: {objetoResultado.remainder}");
        }
        else
        {
            Console.WriteLine();
            return CrearErrorMalDatos(JsEntrada);
        }
    }


    public static respSqr DeserializeSqrt(string JsEntrada)
    {
        var objetoResultado = JsonConvert.DeserializeObject<respSqr>(JsEntrada);
        return objetoResultado;
    }

    /*Deserialización a la respuesta de la petición al journal*/
    public static string[] DeserializeResponseYConvertir(string JsEntrada)
    {
        try
        {
            var respuestaResultado = JsonConvert.DeserializeObject<respJournalConjunta>(JsEntrada);
            var filasDeOperaciones = respuestaResultado.operations;
            var OperacionesString = new string[filasDeOperaciones.Length];
            for (var a = 0; a < filasDeOperaciones.Length; a++)
            {
                OperacionesString[a] = filasDeOperaciones[a].ToString();
            }
            return OperacionesString;
        }
        catch (Exception)
        {
            var error = new string[3];
            try
            {
                var objetoResultado = JsonConvert.DeserializeObject<ErrorObj>(JsEntrada);
                error[0] = $"Code: {objetoResultado.errorCode}";
                error[1] = $"Status: {objetoResultado.errorStatus}";
                error[2] = $"Message: {objetoResultado.errorMessage}";
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
        
        var objetoResultado = JsonConvert.DeserializeObject<ErrorObj>(json);
        return $"Error: {objetoResultado.ToString()}";
    }
}