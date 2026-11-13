using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using proyecto2.Services;
using proyecto2.Data;
using proyecto2.Controllers;

class Proyecto2 {
    
    static void Main(string[] args){
	
	Entrada entrada = new Entrada(args);
	if(entrada.help()){
	    Entrada.uso();
	}

	string ruta = entrada.ruta();
	string archivo = entrada.archivo();
	
	Salida salida = new Salida(archivo, ruta);
	salida.inicia();
    }
}
