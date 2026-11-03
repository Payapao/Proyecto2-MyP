class Album{

    private int id_album = -1;
    private string path = "";
    private string name = "";
    private int year = -1;

    public int Id_album{
	get{return id_album;}
	set{id_album = value;}
    }

    public string Path{
	get{return path;}
	set{path = value;}
    }

    public string Name{
	get{return name;}
	set{name = value;}
    }

    public int Year{
	get{return year;}
	set{year = value;}
    }
}
