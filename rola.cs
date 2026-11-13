using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto2.Models;

[Table("rolas")]
public class Rola{

    private int id_rola = -1;
    private int id_performer = -1;
    private int id_album = -1;
    private string? path = "";
    private string? title = "";
    private int? track = -1;
    private int? year = -1;
    private string? genre = "";
    private int duracion = 0;

    private Performer? performer;
    private Album? album;

    [NotMapped] 
    public int Duracion{
        get {return duracion;}
        set {duracion = value;}
    }

    [Key]
    [Column("id_rola")]
     public int Id_rola{
	get{return id_rola;}
	set{id_rola = value;}
    }

    [Column("id_performer")]
    public int Id_performer{
	get{return id_performer;}
	set{id_performer = value;}
    }

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

    [Column("title")]    
    public string? Title{
	get{return title;}
	set{title = value;}
    }

    [Column("track")]    
    public int? Track{
	get{return track;}
	set{track =  value;}
    }

    [Column("year")]
    public int? Year{
	get{return year;}
	set{year = value;}
    }

    [Column("genre")]    
    public string? Genre{
	get{return genre;}
	set{genre = value;}
    }

    [ForeignKey("Id_performer")]
    public Performer? Performer{
	get{return performer;}
	set{performer = value;}
    }
    
    [ForeignKey("Id_album")]
    public Album? Album{
	get{return album;}
	set{album = value;}
    }
}

