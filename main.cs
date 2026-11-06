using System;
using System.Collections.Generic;
using Slint;
using vista;
using proyecto2.Services;
using proyecto2.Data;

class Proyecto2 {
    
    static void Main(string[] args){
	
	Entrada entrada = new Entrada(args);
	if(entrada.help()){
	    Entrada.uso();
	}

	string ruta = entrada.ruta();
	string archivo = entrada.archivo();
	HashSet<string> archivos = new HashSet<string>();
	//Si el archivo no existe
	if(archivo == ""){
	    using ( var bd = new BaseDeDatos()){
		bd.Database.EnsureCreated();
		
		Minero minero = new Minero(bd);
		minero.mina(ruta);
		archivos = minero.Archivos;
	    }
	    
	}

	//else{
	//  try{
	//	using var conxion = new SqliteConnection("Data Source" + archivo);
	//	conexion.Open();
	//  }  
	//}

	//Inicia la interfaz
	//	var ventana = new Window();

	//ventana.Run();
    }
}
