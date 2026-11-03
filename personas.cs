class Persons{

    private int id_person = -1;
    private string stage_name = "";
    private string real_name = "";
    private string birth_date = "";
    private string death_date = "";

    public int Id_person{
	get{return id_person;}
	set{id_person = value;}
    }

    public string Stage_name{
	get{return stage_name;}
	set{stage_name = value;}
    }

    public string Real_name{
	get{return real_name;}
	set{real_name = value;}
    }

    public string Birth_date{
	get{return birth_date;}
	set{birth_date = value;}
    }

    public string Death_date{
	get{return death_date;}
	set{death_date = value;}
    }
}
