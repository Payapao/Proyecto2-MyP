using System;
using System.Collections.Generic;
//using Microsoft.Data.Sqlite;
using Slint;
using vista;


class Proyecto2 {
    
    static void Main(string[] args){
	
	Entrada entrada = new Entrada(args);
	if(entrada.help()){
	    Entrada.uso();
	}
	
	string ruta = entrada.ruta();
	string archivo = entrada.archivo();

	HashSet<string> archivos = new HashSet<string>();
	if(archivo == null){
	    Minero minero = new Minero();
	    minero.mina(ruta);
	    archivos = minero.Archivos;
	    foreach(string s in archivos)
		Console.WriteLine(s);
	}
	//else{
	//  try{
	//	using var conxion = new SqliteConnection("Data Source" + archivo);
	//	conexion.Open();
	//  }  
	//}

	//Inicia la interfaz
	var ventana = new Window();

	ventana.Run();
    }
}
