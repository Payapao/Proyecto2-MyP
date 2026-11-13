using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using proyecto2.Data;
using proyecto2.Models;
using proyecto2.Services;

namespace proyecto2.Controllers {

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
