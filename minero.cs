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
	string[] rutas = Directory.GetFiles(ruta, "*.mp3", SearchOption.AllDirectories);

	foreach(string s in rutas){
	    if(!archivos.Contains(s)){
		string identificador = extraerInformacion(s);
		archivos.Add(identificador);
	    }
	}
    }

    private string extraerInformacion(string s){
	try{

	    using (var archivo = TagLib.File.Create(s)){
		
		string[] artista = archivo.Tag.Performers;
		string titulo = archivo.Tag.Title;
		string album = archivo.Tag.Album;
		string[] artista_album = archivo.Tag.AlbumArtists;
		uint año = archivo.Tag.Year;
		uint pista = archivo.Tag.Track;
		uint disco = archivo.Tag.Disc;
		string[] genero = archivo.Tag.Genres;
		string comentario = archivo.Tag.Comment;

		return titulo;
	    }
	}catch(Exception){
	    Console.WriteLine("No fue posible leer el archivo "+s+", ha sido ignorado");

	    return "";
	}
    }
}
