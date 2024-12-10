

using System.Collections;

namespace Authors.Api.Models;

public class Author
{


private string id;
private string first,last;//Name
private List<string>contents;

private DateTime birth; 
private string email;
public Author()
{
    
}

public Author(DateTime birth,string first,string last,string email)
{
    id=Guid.NewGuid().ToString();
    this.first=first;
    this.last=last;
    contents=new List<string>();
    this.email=email;
}


    public string Email{ get => email; set => email = value; }

    public string Id{ get => id; set => id = value; }
    public DateTime Birth { get => birth; set => birth = value; }
    public string First{ get => first; set => first = value; }
    public string Last{ get => last; set => last = value; }
}      