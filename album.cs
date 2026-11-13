using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto2.Models;

[Table("albums")]
public class Album{

    private int id_album = -1;
    private string? path = "";
    private string? name = "";
    private int? year = -1;

    [Key]
    [Column("id_album")] 
    public int Id_album{
	get{return id_album;}
	set{id_album = value;}
    }

    [Column("path")] 
    public string? Path{
	get{return path;}
	set{path = value;}
    }

    [Column("name")] 
    public string? Name{
	get{return name;}
	set{name = value;}
    }

    [Column("year")] 
    public int? Year{
	get{return year;}
	set{year = value;}
    }
}
