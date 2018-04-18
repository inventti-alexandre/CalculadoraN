using System;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Security.Cryptography;
namespace Calculadora
{
    public class menus
    {
        /*Dirección del servidor al que se quiere acceder */
        const string servidor = "http://localhost:5000";
        /*Menu 1
        1.Hacer calculos
        2.Consulta de Journal
        3.Salir 
        Default mensaje error y vuelta al menu1*/
        public static void menu()
        {
            var salida = false;
            var eleccion = "";
            /*Id para la sesion */
            var IdSesion = PedirId();
            IdSesion = conversion(IdSesion);
            Console.Clear();
            while (!salida)
            {

                opciones();
                eleccion = "0";
                eleccion = seleccionar();
                Console.WriteLine(eleccion);
                switch (eleccion)
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
                    default:
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
            var elec = Console.ReadLine();
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

        /*menu 2
        1.sumar
        2.restar
        3.multiplicar
        4.dividir
        5.raiz cuadrada 
        Default mensaje error y vuelta al menu2*/
        public static void menuCalc(string IdSesion)
        {
            Console.Clear();
            var salida2 = false;
            while (!salida2)
            {
                opcionesCalcular();
                switch (seleccionar())
                {
                    case ("1"):
                        {
                            Console.Clear();
                            var sumadores = SolicitarValores("sumar");
                            try
                            {
                                var sumadoresDoub = convertirDouble(sumadores);
                                var sumador = new suma(sumadoresDoub);
                                var streamS = new MemoryStream();
                                var conversor = new DataContractJsonSerializer(typeof(suma));
                                conversor.WriteObject(streamS, sumador);
                                var JsonFinal = serializador(conversor, streamS);
                                var res = new respuesta();
                                var salida = res.responder($"{servidor}/Calculator/Add", JsonFinal, IdSesion);
                                Console.Clear();
                                var Respuesta = deserializeResponse.DeserializeSuma(salida);
                                Console.WriteLine(Respuesta);
                                continuar();
                            }
                            catch (Exception)
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
                                var minuendo = Convert.ToDouble(Console.ReadLine());
                                var sustraendos = SolicitarValores("restar");
                                var sustraendosDoub = convertirDouble(sustraendos);
                                var restador = new resta(minuendo, sustraendosDoub);
                                var streamS = new MemoryStream();
                                var conversor = new DataContractJsonSerializer(typeof(resta));
                                conversor.WriteObject(streamS, restador);
                                var JsonFinal = serializador(conversor, streamS);
                                var res = new respuesta();
                                Console.Clear();
                                var salida = res.responder($"{servidor}/Calculator/Sub", JsonFinal, IdSesion);
                                var Respuesta = deserializeResponse.DeserializeResta(salida);
                                Console.WriteLine(Respuesta);
                                continuar();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }


                            break;
                        }
                    case ("3"):
                        {
                            Console.Clear();
                            var multiplicadores = SolicitarValores("multiplicar");
                            try
                            {

                                var multiplicadoresDoub = convertirDouble(multiplicadores);
                                var multiplicador = new multiplicacion(multiplicadoresDoub);
                                var streamS = new MemoryStream();
                                var conversor = new DataContractJsonSerializer(typeof(multiplicacion));
                                conversor.WriteObject(streamS, multiplicador);
                                var JsonFinal = serializador(conversor, streamS);
                                Console.Clear();
                                var res = new respuesta();
                                var salida = res.responder($"{servidor}/Calculator/Mult", JsonFinal, IdSesion);
                                var Respuesta = deserializeResponse.DeserializeMult(salida);
                                Console.WriteLine(Respuesta);
                                continuar();

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case ("4"):
                        {
                            Console.Clear();
                            Console.WriteLine("Escriba el dividendo");
                            try
                            {
                                var dividendo = Convert.ToDouble(Console.ReadLine());
                                var divisores = convertirDouble(SolicitarValores("dividir"));
                                var dividir = new division(dividendo, divisores);
                                var streamS = new MemoryStream();
                                var conversor = new DataContractJsonSerializer(typeof(division));
                                conversor.WriteObject(streamS, dividir);
                                var JsonFinal = serializador(conversor, streamS);
                                var res = new respuesta();
                                Console.Clear();
                                var salida = res.responder($"{servidor}/Calculator/Div", JsonFinal, IdSesion);
                                var Respuesta = deserializeResponse.DeserializeDiv(salida);
                                Console.WriteLine(Respuesta);
                                continuar();

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                            break;
                        }
                    case ("5"):
                        {
                            Console.Clear();
                            Console.WriteLine("Escriba el numero para realizar la raiz cuadrada");
                            try
                            {
                                var numeroRaiz = Convert.ToDouble(Console.ReadLine());
                                var raiz = new raizCuadrada(numeroRaiz);
                                var streamS = new MemoryStream();
                                var conversor = new DataContractJsonSerializer(typeof(raizCuadrada));
                                conversor.WriteObject(streamS, raiz);
                                var JsonFinal = serializador(conversor, streamS);
                                var res = new respuesta();
                                var salida = res.responder($"{servidor}/Calculator/Sqrt", JsonFinal, IdSesion);
                                if (salida != "")
                                {
                                    var ObjRes = deserializeResponse.DeserializeSqrt(salida);
                                    Console.Clear();
                                    Console.WriteLine($"El resultado es : {ObjRes.square}");
                                }
                                continuar();
                            }
                            catch (Exception e)
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
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Opcion invalida");
                            break;
                        }
                }
            }
        }

        public static string serializador(DataContractJsonSerializer dato, Stream streamS)
        {
            streamS.Position = 0;
            var leido = new StreamReader(streamS);
            var JsonFinal = leido.ReadToEnd();
            leido.Close();
            return JsonFinal;
        }

        public static void continuar()
        {
            Console.WriteLine("Pulse enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
        public static void consulta(string IdSesion)
        {
            Console.Clear();
            Console.WriteLine("Escriba el id sobre el que consultar las operaciones");
            var IdConsulta = Console.ReadLine();
            IdConsulta = conversion(IdConsulta);
            var objetoId = new ObjId(IdConsulta);
            Console.Clear();
            var streamS = new MemoryStream();
            var conversor = new DataContractJsonSerializer(typeof(ObjId));
            conversor.WriteObject(streamS, objetoId);
            streamS.Position = 0;
            var leido = new StreamReader(streamS);
            var JsonFinal = leido.ReadToEnd();
            leido.Close();
            var res = new respuesta();
            var salida = res.responder($"{servidor}/Calculator/Journal", JsonFinal, IdSesion);
            var SalidaOperaciones = deserializeResponse.DeserializeResponseYConvertir(salida);
            Console.Clear();
            ImprimirDatos(SalidaOperaciones);
            continuar();
        }

        public static string conversion(string Id)
        {
            using (var algorithm = SHA512.Create()) //or MD5 SHA256 etc.
            {
                var IdHash = algorithm.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Id));
                return BitConverter.ToString(IdHash).Replace("-", "").ToLower();
            }

        }
        public static string SolicitarValores(string texto)
        {
            var sumadores = "";
            String Dato = null;
            Console.WriteLine($"Introduzca valores para {texto}, para acabar no introduzca nada");
            Dato = Console.ReadLine();
            if (Dato != "") sumadores = Dato;
            while (Dato != "")
            {
                Dato = Console.ReadLine();
                if (Dato != "") sumadores = sumadores + "," + Dato;
            }
            return sumadores;
        }

        public static double[] convertirDouble(string numerosString)
        {
            var numerosStr = numerosString.Split(",");
            var numerosDoub = new double[numerosStr.Length];
            for (var a = 0; a < numerosDoub.Length; a++)
            {
                numerosDoub[a] = Convert.ToDouble(numerosStr[a]);
            }
            return numerosDoub;
        }

        public static string PedirId()
        {
            Console.WriteLine("Escriba su Id para la sesion");
            var Idevi = Console.ReadLine();
            return Idevi;
        }
        /*Imprimir datos de consulta a journal
         */
        public static void ImprimirDatos(string[] DatosSt)
        {

            for (var a = 0; a < DatosSt.Length; a++)
            {
                Console.WriteLine(DatosSt[a]);
            }
        }
    }
}