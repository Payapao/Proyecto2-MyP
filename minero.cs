using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using proyecto2.Models;
using proyecto2.Data;

namespace proyecto2.Services{
    
    public class Minero{
	
	private BaseDeDatos bd;
	
	//Constructor del minero
	public Minero(BaseDeDatos b){
	    bd = b;
	}
	
	public void mina(string ruta){
	    
	    //Aqui podria cambiarse para que unicamente regrese los archivos.mp3
	    string[] rutas = Directory.GetFiles(ruta, "*.mp3", SearchOption.AllDirectories);
	    
	    foreach(string s in rutas){
		bool existe = bd.Rolas.Any(p => p.Path == s);
		if(!existe)
		    extraerInformacion(s);
	    }
	}
	
	private void extraerInformacion(string s){
	    try{
		Console.WriteLine(s);
		using (var archivo = TagLib.File.Create(s)){
		
		    string artista = archivo.Tag.FirstPerformer;
		    if(string.IsNullOrEmpty(artista))
			artista = "Unknow";
		
		    string titulo = archivo.Tag.Title;
		    if(string.IsNullOrEmpty(titulo))
			titulo = Path.GetFileNameWithoutExtension(s);

		    string album = archivo.Tag.Album;
		    if(string.IsNullOrEmpty(album))
			album = "Unknow";

		    int año = (int)archivo.Tag.Year;

		    int pista = (int)archivo.Tag.Track;
		    int totalPistas = (int)archivo.Tag.TrackCount;

		    int disco = (int)archivo.Tag.Disc;

		    string genero = archivo.Tag.FirstGenre;
		    if(string.IsNullOrEmpty(genero))
			genero = "Unkown";

		    //Estos probablemente no sean necesarios
		    string comentario = archivo.Tag.Comment;
		    string[] compositor = archivo.Tag.Composers;

		    //Duracion de la cancion
		    TimeSpan duracion = archivo.Properties.Duration;
		    int segundos = (int)Math.Round(duracion.TotalSeconds);
		    
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
			int acc = bd.Albums.Any() ? bd.Albums.Max(i => i.Id_album)+1 : 1;
			albums = new Album{
			    Id_album = acc,
			    Name = album,
			    Path = Path.GetDirectoryName(s) ?? "",
			    Year = año
			};
			bd.Albums.Add(albums);
			bd.SaveChanges();
		    }

		    int max = bd.Rolas.Any() ? bd.Rolas.Max(i => i.Id_rola)+1 : 1;
		    var rola = new Rola{
			Id_rola = max,
			Id_performer = performer.Id_performer,
			Id_album = albums.Id_album,
			Path = s,
			Title = titulo,
			Track = pista,
			Year = año,
			Genre = genero,
			Duracion = segundos
		    };
		    bd.Rolas.Add(rola);
		    bd.SaveChanges();
		
		}
	    }catch(Exception e){
		Console.WriteLine(e.InnerException?.Message);
		Console.WriteLine("No fue posible leer el archivo "+s+", ha sido ignorado");

	    }
	}
    }
}
