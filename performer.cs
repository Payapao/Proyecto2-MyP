using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto2.Models;

public class Performer{

    private int id_performer = 0;
    private int id_type = 2;
    private string name = "";
    private Types? tipo;

    [Key]
    public int Id_performer{
	get{return id_performer;}
	set{id_performer = value;}
    }

    public int Id_type{
	get{return id_type;}
	set{id_type = value;}
    }

    public string Name{
	get{return name;}
	set{name = value;}
    }

    [ForeignKey("Id_type")]
    public Types? Tipo{
	get{return tipo;}
	set{tipo = value;}
    }
}
