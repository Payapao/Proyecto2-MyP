namespace proyecto2.Models;

public class Group{

    private int id_group = -1;
    private string name = "";
    private string start_date = "";
    private string end_date = "";

    public int Id_group{
	get{return id_group;}
	set{id_group = value;}
    }

    public string Name{
	get{return name;}
	set{name = value;}
    }

    public string Start_date{
	get{return start_date;}
	set{start_date = value;}
    }

    public string End_date{
	get{return end_date;}
	set{end_date = value;}
    }
}
