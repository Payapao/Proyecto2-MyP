using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace proyecto2.Models;

[Table("persons")]
public class Person{

    private int id_person = -1;
    private string? stage_name = "";
    private string? real_name = "";
    private string? birth_date = "";
    private string? death_date = "";

    [Key]
    [Column("id_person")] 
    public int Id_person{
	get{return id_person;}
	set{id_person = value;}
    }

    [Column("stage_name")]        
    public string? Stage_name{
	get{return stage_name;}
	set{stage_name = value;}
    }

    [Column("real_name")]        
    public string? Real_name{
	get{return real_name;}
	set{real_name = value;}
    }

    [Column("birth_date")]
    public string? Birth_date{
	get{return birth_date;}
	set{birth_date = value;}
    }

    [Column("death_date")]    
    public string? Death_date{
	get{return death_date;}
	set{death_date = value;}
    }
}
