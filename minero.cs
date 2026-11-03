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
		
		string[] artistas = archivo.Tag.Performers;
		Console.WriteLine("Artista: " + string.Join(", ", artistas));
		string titulo = archivo.Tag.Title;
		Console.WriteLine("Titulo: "+titulo);
		string album = archivo.Tag.Album;
		Console.WriteLine("Album: "+album);
		uint año = archivo.Tag.Year;
		Console.WriteLine("Año: "+año);
		uint pista = archivo.Tag.Track;
		uint totalPistas = archivo.Tag.TrackCount;
		Console.WriteLine("Pista: "+pista+ " of "+ totalPistas);
		uint disco = archivo.Tag.Disc;
		Console.WriteLine("Disco: "+disco);
		string[] genero = archivo.Tag.Genres;
		Console.WriteLine("Genero: " + string.Join(", ", genero));
		string comentario = archivo.Tag.Comment;
		Console.WriteLine("Comentario: "+comentario);
		string[] compositor = archivo.Tag.Composers;
		Console.WriteLine("Compositores: " + string.Join(", ", compositor));
		
		
		return s;
	    }
	}catch(Exception){
	    Console.WriteLine("No fue posible leer el archivo "+s+", ha sido ignorado");

	    return "";
	}
    }
}
