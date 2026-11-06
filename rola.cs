namespace proyecto2.Models;

public class Rola{

    private int id_rolas = -1;
    private int id_performer = -1;
    private int id_album = -1;
    private string path = "";
    private string title = "";
    private int track = -1;
    private int year = -1;
    private string genre = "";

    public int Id_rolas{
	get{return id_rolas;}
	set{id_rolas = value;}
    }
    
    public int Id_performer{
	get{return id_performer;}
	set{id_performer = value;}
    }
    
    public int Id_album{
	get{return id_album;}
	set{id_album = value;}
    }
    
    public string Path{
	get{return path;}
	set{path = value;}
    }

    public string Title{
	get{return title;}
	set{title = value;}
    }

    public int Track{
	get{return track;}
	set{track =  value;}
    }
    
    public int Year{
	get{return year;}
	set{year = value;}
    }
    
    public string Genre{
	get{return genre;}
	set{genre = value;}
    }
}
