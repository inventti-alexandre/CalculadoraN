using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Calculadora
{
    public class menus
    {
        
        public static void menu()
            {
                Boolean salida = false;
                string eleccion;
                string IdSesion = PedirId();
                Console.Clear();
                while (!salida)
                {
                    
                    opciones();
                    eleccion = "0";
                    eleccion = seleccionar();
                    Console.WriteLine(eleccion);
                    switch(eleccion)
                    {
                        case ("1"):
                            {
                                Console.WriteLine("calculos");
                                menuCalc(IdSesion);
                                break;
                            }
                        case ("2"):
                            {
                                Console.WriteLine("consulta");
                                consulta(IdSesion);
                                break;
                            }
                        case ("3"):
                            {
                                Console.WriteLine("Saliendo");
                                salida = true;
                                break;
                            }
                        default :
                            {
                                Console.Clear();
                                Console.WriteLine("Opcion invalida");
                                break;
                            }
                    }
                }
            }

            public static void opciones()
                {
                    
                    Console.WriteLine("Bienvenido a la calculadora");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("1.Realizar cálculos");
                    Console.WriteLine("2.Consultar operaciones recientes");
                    Console.WriteLine("3.Salir");
            }

            public static string seleccionar()
            {
                Console.WriteLine("elije");
                string elec;
                elec = Console.ReadLine();
                return elec;
            }


            public static void opcionesCalcular()
            {
                Console.WriteLine("Elija el cálculo a realizar");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1.Suma");
                Console.WriteLine("2.Resta");
                Console.WriteLine("3.Multiplicacion");
                Console.WriteLine("4.Division");
                Console.WriteLine("5.Raiz cuadrada");
                Console.WriteLine("6.Salir");
            }

            public static void menuCalc(string IdSesion)
            {
                Console.Clear();
                Boolean salida2 = false;
                while (!salida2)
                {
                    opcionesCalcular();
                    switch(seleccionarCalculo())
                    {
                        case ("1"):
                            {
                                Console.Clear();
                                string sumadores = SolicitarValores("sumar");
                                try
                                {
                                    double[] sumadoresDoub = convertirDouble(sumadores);
                                    
                                    suma sumador = new suma(sumadoresDoub);
                                    

                                    MemoryStream streamS = new MemoryStream();  
                                    DataContractJsonSerializer conversor = new DataContractJsonSerializer(typeof(suma)); 
                                    conversor.WriteObject(streamS, sumador);  

                                    streamS.Position = 0;  
                                    StreamReader leido = new StreamReader(streamS);  
                                    String JsonFinal = leido.ReadToEnd();                             
                                    leido.Close();
                                    respuesta res = new respuesta();
                                    
                                    string salida = res.responder("http://localhost:5000/Calculator/Add", JsonFinal,IdSesion);
                                    Console.Clear();
                                    string Respuesta = deserializeResponse.DeserializeSuma(salida);
                                    Console.WriteLine(Respuesta);
                                    Console.WriteLine("Pulse una tecla para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                catch(Exception )
                                {
                                    
                                }
                                break;
                            }
                        case ("2"):
                            {
                                Console.Clear();
                                Console.WriteLine("Escriba el minuendo");
                                
                                try
                                {
                                    
                                    double minuendo = Convert.ToDouble(Console.ReadLine());    
                                    string sustraendos = SolicitarValores("restar");      
                                    double[] sustraendosDoub = convertirDouble(sustraendos);
                                    resta restador = new resta(minuendo,sustraendosDoub);

                                    MemoryStream streamS = new MemoryStream();  
                                    DataContractJsonSerializer conversor = new DataContractJsonSerializer(typeof(resta)); 
                                    conversor.WriteObject(streamS, restador);  

                                    streamS.Position = 0;  
                                    StreamReader leido = new StreamReader(streamS);  
                                    String JsonFinal = leido.ReadToEnd();                             
                                    leido.Close();
                                    respuesta res = new respuesta();
                                    Console.Clear();
                                    string salida = res.responder("http://localhost:5000/Calculator/Sub", JsonFinal,IdSesion);
                                    string Respuesta = deserializeResponse.DeserializeResta(salida);
                                    Console.WriteLine(Respuesta);
                                    Console.WriteLine("Pulse una tecla para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                                
                                break;
                            }
                        case ("3"):
                            {   
                                 Console.Clear();
                                 string multiplicadores = SolicitarValores("multiplicar");
                                 try{

                                    double[] multiplicadoresDoub = convertirDouble(multiplicadores);
                                    multiplicacion multiplicador = new multiplicacion(multiplicadoresDoub);

                                    MemoryStream streamS = new MemoryStream();  
                                    DataContractJsonSerializer conversor = new DataContractJsonSerializer(typeof(multiplicacion)); 
                                    conversor.WriteObject(streamS, multiplicador);  

                                    streamS.Position = 0;  
                                    StreamReader leido = new StreamReader(streamS);  
                                    String JsonFinal = leido.ReadToEnd();                             
                                    leido.Close();
                                    Console.Clear();
                                    respuesta res = new respuesta();
                                    string salida = res.responder("http://localhost:5000/Calculator/Mult", JsonFinal,IdSesion);
                                    string Respuesta = deserializeResponse.DeserializeMult(salida);
                                    Console.WriteLine(Respuesta);
                                    
                                    Console.WriteLine("Pulse una tecla para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();

                                 }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            }
                        case ("4"):
                            {   
                                    Console.Clear();
                                    Console.WriteLine("Escriba el dividendo");
                                    try{
                                    double dividendo = Convert.ToDouble(Console.ReadLine());
                                    double[] divisores = convertirDouble(SolicitarValores("dividir"));
                                    division dividir = new division(dividendo,divisores);

                                    MemoryStream streamS = new MemoryStream();  
                                    DataContractJsonSerializer conversor = new DataContractJsonSerializer(typeof(division)); 
                                    conversor.WriteObject(streamS, dividir);  

                                    streamS.Position = 0;  
                                    StreamReader leido = new StreamReader(streamS);  
                                    String JsonFinal = leido.ReadToEnd();                             
                                    leido.Close();
                                    respuesta res = new respuesta();
                                    Console.Clear();
                                    string salida = res.responder("http://localhost:5000/Calculator/Div", JsonFinal,IdSesion);
                                   string Respuesta = deserializeResponse.DeserializeDiv(salida);
                                    Console.WriteLine(Respuesta);
                                    Console.WriteLine("Pulse una tecla para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();

                                 }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                                break;
                            }
                        case ("5"):
                            {   
                                Console.Clear();
                                Console.WriteLine("Escriba el numero para realizar la raiz cuadrada");
                                try{
                                    double numeroRaiz =Convert.ToDouble(Console.ReadLine());
                                    raizCuadrada raiz = new raizCuadrada(numeroRaiz);

                                    MemoryStream streamS = new MemoryStream();  
                                    DataContractJsonSerializer conversor = new DataContractJsonSerializer(typeof(raizCuadrada)); 
                                    conversor.WriteObject(streamS, raiz);  

                                    streamS.Position = 0;  
                                    StreamReader leido = new StreamReader(streamS);  
                                    String JsonFinal = leido.ReadToEnd();                             
                                    leido.Close();
                                    respuesta res = new respuesta();
                                    string salida = res.responder("http://localhost:5000/Calculator/Sqrt", JsonFinal,IdSesion);
                                    if(salida!="")
                                    {
                                        respSqr ObjRes = deserializeResponse.DeserializeSqrt(salida);
                                        Console.Clear();
                                        Console.WriteLine("El resultado es : " + ObjRes.GetResultado());
                                    }
                                    Console.WriteLine("Pulse una tecla para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();

                                 }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                                break;
                            }
                        case ("6"):
                            {
                                salida2 = true;
                                break;
                            }
                        default :
                            {
                                Console.Clear();
                                Console.WriteLine("Opcion invalida");
                                break;
                            }
                    }
                }
            }
            public static string seleccionarCalculo()
            {
                string elec2;
                elec2 = Console.ReadLine();
                return elec2;
            }



            public static void consulta(string IdSesion)
            {
                Console.Clear();
                Console.WriteLine("Escriba el id sobre el que consultar las operaciones");
                string IdConsulta = Console.ReadLine();
                ObjId objetoId = new ObjId(IdConsulta);
                Console.Clear();
                MemoryStream streamS = new MemoryStream();  
                DataContractJsonSerializer conversor = new DataContractJsonSerializer(typeof(ObjId)); 
                conversor.WriteObject(streamS, objetoId);  

                streamS.Position = 0;  
                StreamReader leido = new StreamReader(streamS);  
                String JsonFinal = leido.ReadToEnd();                             
                leido.Close();
                respuesta res = new respuesta();
                string salida = res.responder("http://localhost:5000/Calculator/Journal", JsonFinal,IdSesion);
                string[] SalidaOperaciones = deserializeResponse.DeserializeResponseYConvertir(salida);
                Console.Clear();
                ImprimirDatos(SalidaOperaciones, IdConsulta);
                Console.WriteLine("Pulse una tecla para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
            

        public static string SolicitarValores(string texto)
        {
            string sumadores="";
            String Dato = null;
            Console.WriteLine("Introduzca valores para {0}, para acabar no introduzca nada",texto);
            Dato = Console.ReadLine();
            if(Dato != "") sumadores =Dato ;
            while(Dato!="")
            {
                Dato = Console.ReadLine();
            if(Dato != "") sumadores = sumadores + "," + Dato ;
            }
            return sumadores;
        }

        public static double[] convertirDouble(string numerosString)
        {
            string[] numerosStr = numerosString.Split(",");
            double[] numerosDoub = new double[numerosStr.Length];
            for(int a = 0; a < numerosDoub.Length; a++)
            {
                numerosDoub[a] = Convert.ToDouble(numerosStr[a]);
            }
            return numerosDoub;
        }

    
    public static string PedirId()
    {
        Console.WriteLine("Escriba su Id para la sesion");
        string Idevi= Console.ReadLine();
        return Idevi;
    }
     
     public static void ImprimirDatos(string[] DatosSt, string IdCons)
     {
        
         for (int a = 0; a < DatosSt.Length; a++)
                {
                    Console.WriteLine(DatosSt[a]);
                }
     }
    
     

    }
}