using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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

	//Si el archivo no existe
	if(archivo == "")
	    using ( var bd = new BaseDeDatos("base_de_datos.db")){
		bd.Database.EnsureCreated();
		Minero minero = new Minero(bd);
		minero.mina(ruta);
	    }
	else
	    using(var bd = new BaseDeDatos(archivo)){
		var canciones = bd.Rolas.Include(a => a.Album)
		                        .Include(p => p.Performer)
		                        .ThenInclude(t => t!.Tipo)
		                        .ToList();
	    }

	//Inicia la interfaz
	var ventana = new Window();
	ventana.Run();
    }
}
