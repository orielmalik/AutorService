

using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Authors.Api.Models;

public class Author
{


    private string id;
    private string first, last;//Name
    private List<string> contents;

    private DateTime birth;
    private string email;
    public Author()
    {

    }

   
 [Key]
    public string? Id { get; set; }
    public DateTime Birth { get => birth; set => birth = value; }
  
    public string? First { get; set; }
    public string? Last { get; set; }
    public string? Email { get; set; }
    public List<string>? Contents { get; set; }

 
}