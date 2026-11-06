namespace proyecto2.Models;

public class Performer{

    private int id_performer = 0;
    private int id_type = 2;
    private string name = "";

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
}
