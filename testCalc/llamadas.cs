using System;
using System.IO;
using System.Net;

/*Petición Http al servidor
No asíncrona ya que el cliente no puede continuar sin la respuesta*/
public class llamadas
{

    public llamadas()
    {

    }
    public void responder(string uri, string json, string EviId)
    {
        string salida = "";
        HttpWebResponse httpResponse;
        try
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "POST";
            /*Cabecera Id identificativa de usuario */
            httpWebRequest.Headers["X-Evi-Tracking-Id"] = EviId;
            /*Timeout 5s */
            httpWebRequest.Timeout = 5000;


            /*Escritura de json */
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                /*Lectura de json */
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    salida = streamReader.ReadToEnd();
                }

            }
        }
        catch (WebException e)
        {
            try
            {
                salida = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo conectar al servidor");
            }
        }
        Console.WriteLine(salida);
    }
}