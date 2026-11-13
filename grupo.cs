using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto2.Models;

[Table("groups")]
public class Group{

    private int id_group = -1;
    private string? name = "";
    private string? start_date = "";
    private string? end_date = "";

    [Key]
    [Column("id_group")]
    public int Id_group{
	get{return id_group;}
	set{id_group = value;}
    }

    [Column("name")] 
    public string? Name{
	get{return name;}
	set{name = value;}
    }

    [Column("start_date")]    
    public string? Start_date{
	get{return start_date;}
	set{start_date = value;}
    }

    [Column("end_date")]    
    public string? End_date{
	get{return end_date;}
	set{end_date = value;}
    }
}
