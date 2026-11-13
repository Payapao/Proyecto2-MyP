using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto2.Models;

[Table("in_groups")]
[PrimaryKey(nameof(Id_person), nameof(Id_group))]
public class In_group{

    private int id_person= -1;
    private int id_group = -1;

    private Person? person;
    private Group? grupo;
    
    [Column("id_person")]    
    public int Id_person{
	get{return id_person;}
	set{id_person = value;}
    }

[Column("id_group")]    
    public int Id_group{
	get{return id_group;}
	set{id_group = value;}
    }

    [ForeignKey("Id_person")]
    public Person? Person{
	get{return person;}
	set{person = value;}
    }

    [ForeignKey("Id_group")]
    public Group? Grupo{
	get{return grupo;}
	set{grupo = value;}
    }    
}
