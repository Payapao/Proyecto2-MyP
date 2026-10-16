using System;
using System.IO;
using System.Collections.Generic;

public class Entrada{

    private string a = null;
    private string r = null;
    private bool h = false;
    private static string mensaje = null;
    
    
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
	
	if(r == null){
	    mensaje = "Es necesario ingresar una ruta";
	    h = true;
	    return;
	}

    }

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
