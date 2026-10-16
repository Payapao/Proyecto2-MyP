using System;
//using Microsoft.Data.Sqlite;

class Proyecto2 {
    
    static void Main(string[] args){
	
	Entrada entrada = new Entrada(args);
	if(entrada.help()){
	    Entrada.uso();
	}
	
	string ruta = entrada.ruta();
	string archivo = entrada.archivo();

	Console.Write(ruta);
	Console.Write(archivo);
	
	//if(archivo == null){
	//Inicia mineria
	//}
	//else{
	//  try{
	//	using var conxion = new SqliteConnection("Data Source" + archivo);
	//	conexion.Open();
	//  }  
	//}

	//Inicia la interfaz
    }
}
