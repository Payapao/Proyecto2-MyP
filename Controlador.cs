using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using proyecto2.Data;
using proyecto2.Models;
using proyecto2.Services;

namespace proyecto2.Controllers {

    public class PerformerDetalleDTO {
        public int Id_performer { get; set; }
        public int Id_type { get; set; } 
        public string Name { get; set; } = "";
        
        // Propiedades de Persona
        public string Stage_name { get; set; } = "";
        public string Real_name { get; set; } = "";
        public string Birth_date { get; set; } = "";
        public string Death_date { get; set; } = "";

        // Propiedades de Grupo
        public string Start_date { get; set; } = "";
        public string End_date { get; set; } = "";
    }
    
    public class Controlador {

        private BaseDeDatos bd;
        private Minero minero;

        public Controlador(BaseDeDatos b) {
            bd = b;
            minero = new Minero(bd);
        }

        public List<Album> ObtenerAlbumes() {
	    
            return bd.Albums
                     .AsNoTracking()
                     .OrderBy(n => n.Name)
                     .ToList();
        }


        public List<Rola> ObtenerCanciones(int id_Album) {
            return bd.Rolas
                     .AsNoTracking()
                     .Include(p => p.Performer)
                     .Where(i => i.Id_album == id_Album)
                     .OrderBy(t => t.Track)
                     .ToList();
        }

	public void DefinirTipoPerformer(int idPerformer, int nuevoTipo) {
	    
            var perf = bd.Performers.FirstOrDefault(p => p.Id_performer == idPerformer);
            if(perf == null)
		return;

            perf.Id_type = nuevoTipo;

            if(nuevoTipo == 0 && !bd.Persons.Any(p => p.Stage_name == perf.Name))
                bd.Persons.Add(new Person { Stage_name = perf.Name });
            else if(nuevoTipo == 1 && !bd.Groups.Any(g => g.Name == perf.Name)) 
                bd.Groups.Add(new Group {Name = perf.Name});

            bd.SaveChanges();
        }

	public PerformerDetalleDTO ObtenerInfoPerformer(int idPerformer) {
            var perf = bd.Performers.FirstOrDefault(p => p.Id_performer == idPerformer);
            if(perf == null)
		return new PerformerDetalleDTO();

            var dto = new PerformerDetalleDTO {
                Id_performer = perf.Id_performer,
                Id_type = perf.Id_type,
                Name = perf.Name ?? "" };

	    //Si es una persona
            if (perf.Id_type == 0) { 
                var persona = bd.Persons.FirstOrDefault(s => s.Stage_name == perf.Name);
                if (persona != null) {
                    dto.Stage_name = persona.Stage_name ?? "";
                    dto.Real_name = persona.Real_name ?? "";
                    dto.Birth_date = persona.Birth_date ?? "";
                    dto.Death_date = persona.Death_date ?? "";
                } else 
                    dto.Stage_name = perf.Name ?? "";
            }
	    //Si es un grupo
            else if (perf.Id_type == 1) { 
                var grupo = bd.Groups.FirstOrDefault(n => n.Name == perf.Name);
                if (grupo != null) {
                    dto.Start_date = grupo.Start_date ?? "";
                    dto.End_date = grupo.End_date ?? "";
                }
            }
            return dto;
        }

	public void GuardarPerformer(PerformerDetalleDTO dto) {
            var perf = bd.Performers.FirstOrDefault(i => i.Id_performer == dto.Id_performer);
            if(perf == null)
		return;

            string nombreAnterior = perf.Name ?? "";
            perf.Name = dto.Name;
            perf.Id_type = dto.Id_type;

	    //Si es persona
            if(dto.Id_type == 0){
                var persona = bd.Persons.FirstOrDefault(p => p.Stage_name == nombreAnterior);
                if (persona == null) {
                    persona = new Person();
                    bd.Persons.Add(persona);
                }
                persona.Stage_name = dto.Name;
                persona.Real_name = dto.Real_name;
                persona.Birth_date = dto.Birth_date;
                persona.Death_date = dto.Death_date;
            }
	    //Si es grupo
            else if(dto.Id_type == 1){
                var grupo = bd.Groups.FirstOrDefault(n => n.Name == nombreAnterior);
                if (grupo == null) {
                    grupo = new Group();
                    bd.Groups.Add(grupo);
                }
                grupo.Name = dto.Name;
                grupo.Start_date = dto.Start_date;
                grupo.End_date = dto.End_date;
            }

            bd.SaveChanges();
        }
	
        public List<Rola> BuscarCanciones(string texto) {
            return bd.Rolas
                     .AsNoTracking()
                     .Include(r => r.Performer)
                     .Where(r => r.Title != null &&
                                 r.Title.Contains(texto))
                     .ToList();
        }

	public List<Performer> BuscarPerformers(string texto) {
	    return bd.Performers
		.AsNoTracking()
		.Where(p => p.Name != null &&
		       p.Name.Contains(texto))
		.OrderBy(p => p.Name)
		.ToList();
	}

        public void Minar(string ruta) {
            minero.mina(ruta);
        }
    }
}
