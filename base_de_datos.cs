using Microsoft.EntityFrameworkCore;
using proyecto2.Models;

namespace proyecto2.Data;

public class BaseDeDatos : DbContext{

    public DbSet<Types> Types {get; set;}
    public DbSet<Performer> Performers {get; set;}
    public DbSet<Person> Persons {get; set;}
    public DbSet<Group> Groups {get; set;}
    public DbSet<In_group> In_group {get; set;}
    public DbSet<Album> Albums {get; set;}
    public DbSet<Rola> Rolas {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder Builder){
	Builder.UseSqlite("Data Source=base_de_datos.db");
    }

    protected override void OnModelCreating(ModelBuilder Builder){
	Builder.Entity<Types>().ToTable("types").HasKey(i => i.Id_type);

	Builder.Entity<Performer>().ToTable("performers").HasKey(i => i.Id_performer);

	Builder.Entity<Person>().ToTable("persons").HasKey(i => i.Id_person);

	Builder.Entity<Group>().ToTable("groups").HasKey(i => i.Id_group);

	Builder.Entity<In_group>().ToTable("in_group").HasKey(i => new {i.Id_person, i.Id_group});
	
	Builder.Entity<Album>().ToTable("albums").HasKey(i => i.Id_album);

	Builder.Entity<Rola>().ToTable("rolas").HasKey(i => i.Id_rolas);

	Builder.Entity<Rola>().Property(i => i.Id_rolas).ValueGeneratedNever();
	//Datos predeterminados
	Builder.Entity<Types>(entity => {
	    entity.HasKey(i => i.Id_type);
	    entity.Property(i => i.Id_type).ValueGeneratedNever();
	    entity.HasData(
	    new Types {Id_type = 0, Description = "Person"},
	    new Types {Id_type = 1, Description = "Group"},
	    new Types {Id_type = 2, Description = "Unknown"});
	});

	Builder.Entity<Album>(entity => {
	    entity.HasKey(i => i.Id_album);
	    entity.Property(i => i.Id_album).ValueGeneratedNever();
	    entity.HasData(
		new Album{
		          Id_album = 0,
			  Path = "",
			  Name = "Unknown",
			  Year = 0 });
	});
    }
}
