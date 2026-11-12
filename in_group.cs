using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto2.Models;

public class In_group{

    private int id_person= -1;
    private int id_group = -1;

    private Person? person;
    private Group? grupo;

    [Key]
    public int Id_person{
	get{return id_person;}
	set{id_person = value;}
    }

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
