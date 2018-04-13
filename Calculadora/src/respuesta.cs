

using System;
using System.IO;
using System.Net;

public class respuesta{

public respuesta()
{

}
public  string responder (string uri, string json,string EviId)
    {
        string salida="";
        HttpWebResponse httpResponse;
        try
            {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType="application/json";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers["X-Evi-Tracking-Id"]=EviId;
            httpWebRequest.Timeout=5000;
            
            
        
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            
                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
               
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    salida = streamReader.ReadToEnd();
                }
                
            }
        }
        catch(WebException e)
        {
                try
                {
                salida = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();   
                }
                catch (Exception )
                {
                    Console.WriteLine("No se pudo conectar al servidor");
                }                                                 
        }
        return salida;
    }
}