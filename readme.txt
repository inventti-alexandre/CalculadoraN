Calculadora cliente servidor.
Sobre .net Core 2.1.103


Build
Mediante comando dotnet msbuild sobre el cliente y sobre el servidor

Resumen de funcionamiento
El usuario podr� realizar 6 operaciones mediante el cliente
1.Suma
2.Resta
3.Multiplicaci�n
4.Divisi�n
5.Raiz cuadrada
6.Consulta de operaciones realizadas


Caso de uso de suma
Ejemplo de ejecuci�n
#Cliente
-El usuario abre el cliente y escribe su Id
-Selecciona realizar calculos
-Cliente en el men� elije suma
-Introduce los sumandos 
-Al no introducir m�s sumandos acabala petici�n de sumandos
-Si los datos introducidos no son los correctos se vuelve al men� si son correctos se continua al siguiente paso
-El cliente serializa los sumandos
-Se crea una petici�n http a "servidor"/calculator/add y se inserta el json con los sumandos
-Se env�a la petici�n
#Servidor
-La petici�n llega al controlador
-El controladorrecibe la petici�n, deserializa el json y comprueba que los datos recibidos se ajustan a lo que se requiere para la suma
-Si no son correctos crea un json del error y lo reenv�a con un error 400 al cliente.
-Si los datos son correctos el controlador reenv�a la informaci�n al modelo de la suma, el cual se encarga de realizar el c�lculo.
-Una vez realizado el calculo se realiza el journal, el modelo busca si existe un archivo para esa Id si existe guarda al final la nueva operaci�n, si no existe 
crea un archivo para ese usuario y guarda los datos ah�
-Una vez hecho el c�lculo serializa los datos de la respuseta y se lo pasa al controlador
-El controlador devuelve esta informaci�n al cliente
#Cliente
-El cliente deserializa la respuesta de la suma
-Muestra la respuesta del error por pantalla, ya sea el resultado o el error
-Se solicita que se pulse una tacla al cliente y una vez se pulse se vuelve al menu
