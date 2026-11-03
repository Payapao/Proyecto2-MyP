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
	    string identificador = extraerInformacion(s);
	    if(!archivos.Contains(identificador) && identificador != "")
		archivos.Add(identificador);
	}
    }

    private string extraerInformacion(string s){
	try{
	    Console.WriteLine(s);
	    using (var archivo = TagLib.File.Create(s)){
		
		string artista = archivo.Tag.FirstPerformer;
		if(string.IsNullOrEmpty(artista))
		    artista = "Desconocido";
		
		string titulo = archivo.Tag.Title;
		if(string.IsNullOrEmpty(titulo))
		    titulo = Path.GetFileNameWithoutExtension(s);

		string album = archivo.Tag.Album;
		if(string.IsNullOrEmpty(album))
		    album = "Desconocido";

		int año = (int)archivo.Tag.Year;

		int pista = (int)archivo.Tag.Track;
		int totalPistas = (int)archivo.Tag.TrackCount;

		int disco = (int)archivo.Tag.Disc;

		string genero = archivo.Tag.FirstGenre;
		if(string.IsNullOrEmpty(genero))
		    genero = "Desconocido";

		//Estos probablemente no sean necesarios
		string comentario = archivo.Tag.Comment;
		string[] compositor = archivo.Tag.Composers;

		//Aqui deberia leer las imagenes
		
		return s;
	    }
	}catch(Exception){
	    Console.WriteLine("No fue posible leer el archivo "+s+", ha sido ignorado");

	    return "";
	}
    }
}
