using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using vista;
using proyecto2.Services;
using proyecto2.Data;
using proyecto2.Controllers;
using proyecto2.Models;

public class Salida{

    private string archivo;
    private string ruta;
    private BaseDeDatos bd;
    
    
    public Salida(string a, string r){
	archivo = a;
	ruta = r;
	bd = new BaseDeDatos(archivo);
    }
    
    //Metodo para crear o leer la base de datos
    public void inicia(){
	if(archivo == "base_de_datos.db"){
	    bd.Database.EnsureCreated();
	    Minero minero = new Minero(bd);
	    minero.mina(ruta);
	}else{
	    var canciones = bd.Rolas.Include(a => a.Album)
		.Include(p => p.Performer)
		.ThenInclude(t => t!.Tipo)
		.ToList();
	}
	interfaz();
    }

    //metodo para empezar el controlador e interfaz
    public void interfaz(){
		
	Controlador controlador = new Controlador(bd);
	var albums = controlador.ObtenerAlbumes();

	//Inicia la interfaz
	var ventana = new Window();

	ventana.albums.Init();
	ventana.albums_year.Init();
	ventana.rolas_rutas.Init();
	ventana.rolas_duracion.Init();
	ventana.lista_canciones.Init();
        ventana.rolas_nombres.Init();
        ventana.rolas_performers.Init();
	ventana.rolas_performers_ids.Init();

	foreach (var album in albums)
	{
	    ventana.albums.Add(album.Name ?? "Sin nombre");
	    ventana.albums_year.Add((album.Year.HasValue && album.Year > 0) ? album.Year.Value.ToString() : "");
	}

	ventana.SeleccionaAlbum = () => {
	    string textoIndice = ventana.indice_album_seleccionado.Trim('"', ' ', '\\');
            if (int.TryParse(textoIndice, out int index) && index >= 0 && index < albums.Count){
		
                int idAlbum = albums[index].Id_album;
                var canciones = controlador.ObtenerCanciones(idAlbum);

		ventana.rolas_rutas.Clear();
		ventana.rolas_duracion.Clear();
                ventana.lista_canciones.Clear();
                ventana.rolas_nombres.Clear();
                ventana.rolas_performers.Clear();
		ventana.rolas_performers_ids.Clear();

                int contador = 1;
                foreach (var rola in canciones)
                {
                    string track = (rola.Track.HasValue && rola.Track > 0)
                        ? rola.Track.Value.ToString() : contador.ToString();
		    int duracion = bd.Rolas.Local
			.FirstOrDefault(r => r.Path == rola.Path)?.Duracion ?? rola.Duracion;

		    ventana.rolas_rutas.Add(rola.Path);
		    ventana.rolas_duracion.Add(duracion.ToString());
                    ventana.lista_canciones.Add(track);
                    ventana.rolas_nombres.Add(rola.Title ?? "Sin título");
                    ventana.rolas_performers.Add(rola.Performer?.Name ?? "Desconocido");
		    ventana.rolas_performers_ids.Add(rola.Id_performer.ToString());
		    
		    contador++;
                }
            }
	};

	//Cargar Performers
	ventana.CargarPerformer = () => {
	    string textoId = ventana.perf_edit_id.Trim('"', ' ', '\\');
	    if (int.TryParse(textoId, out int idPerformer)) {
		var info = controlador.ObtenerInfoPerformer(idPerformer);
		ventana.perf_edit_tipo = info.Id_type;
		ventana.perf_edit_nombre = info.Name;
		// Persona
		ventana.perf_edit_real_name = info.Real_name;
		ventana.perf_edit_birth_date = info.Birth_date;
		ventana.perf_edit_death_date = info.Death_date;
		// Grupo
		ventana.perf_edit_start_date = info.Start_date;
		ventana.perf_edit_end_date = info.End_date;
	    }
	};

	//Definir
	ventana.DefinirTipoPerformer = () => {
	    string textoId = ventana.perf_edit_id.Trim('"', ' ', '\\');
	    if (int.TryParse(textoId, out int idPerformer)) {
		controlador.DefinirTipoPerformer(idPerformer, (int)ventana.perf_edit_tipo);
	    }
	};

	//Guardar
	ventana.GuardarPerformer = () => {
	    string textoId = ventana.perf_edit_id.Trim('"', ' ', '\\');
	    if (int.TryParse(textoId, out int idPerformer)) {
		var dto = new PerformerDetalleDTO {
		    Id_performer = idPerformer,
		    Id_type = (int)ventana.perf_edit_tipo,
		    Name = ventana.perf_edit_nombre,
		    Real_name = ventana.perf_edit_real_name,
		    Birth_date = ventana.perf_edit_birth_date,
		    Death_date = ventana.perf_edit_death_date,
		    Start_date = ventana.perf_edit_start_date,
		    End_date = ventana.perf_edit_end_date
		};
		controlador.GuardarPerformer(dto);
		ventana.SeleccionaAlbum();
	    }
	};
	ventana.Run();
    }
    
}
