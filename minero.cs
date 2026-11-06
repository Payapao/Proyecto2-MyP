using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using proyecto2.Models;
using proyecto2.Data;

namespace proyecto2.Services{
    
    public class Minero{
	
	private HashSet<string> archivos;
	private BaseDeDatos bd;
	
	//Getter y setter
	public HashSet<string> Archivos{
	    get{return archivos;}
	    set{archivos = value;}
	}
	
	//Constructor del minero
	public Minero(BaseDeDatos b){
	    archivos = new HashSet<string>();
	    bd = b;
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

		    var performer = bd.Performers.FirstOrDefault(i => i.Name == artista);
		    if(performer == null){
			performer = new Performer{
			    Name = artista,
			    Id_type = 2
			};
			bd.Performers.Add(performer);
			bd.SaveChanges();
		    }

		    var albums = bd.Albums.FirstOrDefault(i => i.Name == album);
		    if(albums == null){
			albums = new Album{
			    Name = album,
			    Path = Path.GetDirectoryName(s) ?? "",
			    Year = año
			};
			bd.Albums.Add(albums);
			bd.SaveChanges();
		    }

		    var rola = new Rola{
			Id_performer = performer.Id_performer,
			Id_album = albums.Id_album,
			Path = s,
			Title = titulo,
			Track = pista,
			Year = año,
			Genre = genero
		    };
		
		    return s;
		}
	    }catch(Exception e){
		Console.WriteLine(e.Message);
		Console.WriteLine("No fue posible leer el archivo "+s+", ha sido ignorado");

		return "";
	    }
	}
    }
}
