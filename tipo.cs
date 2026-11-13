using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace proyecto2.Models;

[Table("types")]
public class Types{

    private int id_type = -1;
    private string descripcion = "";

    [Key]
    [Column("id_type")]
    public int Id_type{
	get{return id_type;}
	set{id_type = value;}
    }

    [Column("description")]
    public string Description{
	get{return descripcion;}
	set{descripcion = value;}
    }
}
