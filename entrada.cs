using System;
using System.IO;
using System.Text;

public class Entrada{

    private string a = "";
    private string r = "";
    private bool h = false;
    private static string mensaje = "";
    
    
    public Entrada(string[] args){

	for(int i = 0; i<args.Length; i++){
	    switch(args[i]){
		case "-h":
		    h = true;
		    return;
		case "-a":
		    if(i+1 >= args.Length){
			mensaje = "La bandera '-a' necesita un archivo .db";
			h = true;
			return;
		    }
		    if(!File.Exists(args[i+1])){
			mensaje = "El archivo "+args[i+1]+" no existe";
			h = true;
			return;
		    }
		    a = args[i+1];
		    i++;
		    break;
		case "-r":
		    if(i+1 >= args.Length){
			mensaje = "La bandera '-r' necesita una ruta";
			h = true;
			return;
		    }
		    if(!Directory.Exists(args[i+1])){
			mensaje = "El directorio no existe";
			h = true;
			return;
		    }
		    r = args[i+1];
		    i++;
		    break;
		default:
		    mensaje = "La bandera "+args[i]+" no es valida";
		    h = true;
		    return;
	    }
	}
	
	if(r == ""){
	    mensaje = "Es necesario ingresar una ruta";
	    h = true;
	    return;
	}

	//Verifica si el archivo es valido
	if(a != ""){
	    //si no es un archivo valido
	    if(!valida(a)){
		mensaje = "El archivo "+a+" no es valido";
			h = true;
	    }
	}else
	    a = "base_de_datos.db";
	
    }
    
    //Metodo para validar archivos
    private bool valida(string s){
	try{
	    byte[] encabezado = new byte[16];
	    //Se abre el archivo y lee los primeros 16 bytes
	    using(var file = new FileStream(a, FileMode.Open, FileAccess.Read)){
		file.Read(encabezado, 0, 16);
	    }
	    //Se decodifica
	    string cabeza = Encoding.UTF8.GetString(encabezado);
	    //Comprueba si es igual al formato de inicio de un archivo sqlite
	    return cabeza == "SQLite format 3\0";
	}catch(Exception){
	    return false;
	}
	
    }

   //Regresa el error junto a el mensaje de ayuda
    public static void uso(){
	if(mensaje != null)
	    Console.WriteLine(mensaje);
	Console.WriteLine("Uso de las banderas\n"  +
			  "'-h' muestra este mensaje de ayuda\n" +
                          "'-a' para agregar un archivo inicial para la base de datos\n" +
	                  "'-r' indica la ruta de los archivos");
	Environment.Exit(0);
    }

    public bool help(){
	return h;
    }

    public string ruta(){
	return r;
    }

    public string archivo(){
	return a;
    }
}
