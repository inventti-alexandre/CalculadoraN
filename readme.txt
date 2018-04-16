Calculadora cliente servidor.
Sobre .net Core 2.1.103


Build
Mediante comando dotnet msbuild sobre el cliente y sobre el servidor

Resumen de funcionamiento
El usuario podrá realizar 6 operaciones mediante el cliente
1.Suma
2.Resta
3.Multiplicación
4.División
5.Raiz cuadrada
6.Consulta de operaciones realizadas


Caso de uso de suma
Ejemplo de ejecución
#Cliente
-El usuario abre el cliente y escribe su Id
-Selecciona realizar calculos
-Cliente en el menú elije suma
-Introduce los sumandos 
-Al no introducir más sumandos acabala petición de sumandos
-Si los datos introducidos no son los correctos se vuelve al menú si son correctos se continua al siguiente paso
-El cliente serializa los sumandos
-Se crea una petición http a "servidor"/calculator/add y se inserta el json con los sumandos
-Se envía la petición
#Servidor
-La petición llega al controlador
-El controladorrecibe la petición, deserializa el json y comprueba que los datos recibidos se ajustan a lo que se requiere para la suma
-Si no son correctos crea un json del error y lo reenvía con un error 400 al cliente.
-Si los datos son correctos el controlador reenvía la información al modelo de la suma, el cual se encarga de realizar el cálculo.
-Una vez realizado el calculo se realiza el journal, el modelo busca si existe un archivo para esa Id si existe guarda al final la nueva operación, si no existe 
crea un archivo para ese usuario y guarda los datos ahí
-Una vez hecho el cálculo serializa los datos de la respuseta y se lo pasa al controlador
-El controlador devuelve esta información al cliente
#Cliente
-El cliente deserializa la respuesta de la suma
-Muestra la respuesta del error por pantalla, ya sea el resultado o el error
-Se solicita que se pulse una tacla al cliente y una vez se pulse se vuelve al menu
