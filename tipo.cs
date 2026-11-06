namespace proyecto2.Models;

public class Types{

    private int id_type = -1;
    private string descripcion = "";

    public int Id_type{
	get{return id_type;}
	set{id_type = value;}
    }

    public string Description{
	get{return descripcion;}
	set{descripcion = value;}
    }
}
