using System;
using System.IO;
using System.Collections.Generic;

class Minero{

    private HashSet<string> archivos;

    //Getter y setter
    public HashSet<string> Archivos{
	get{return archivos;}
	set{archivos = value;}
    }

    //Constructor del minero
    public Minero(){
	archivos = new HashSet<string>();
    }

    public void mina(string ruta){

	//Aqui podria cambiarse para que unicamente regrese los archivos.mp3
	string[] rutas = Directory.GetFiles(ruta, "*.*", SearchOption.AllDirectories);

	foreach(string s in rutas){
	    if(!archivos.Contains(s)){
		archivos.Add(s);
		//Aqui debe extraer la información para mandar la notificación a la interfaz
	    }
	}
    }
}
