

using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authors.Api.Models;

public class Author
{


    [Key]
    public string? Id { get; set; }

    public DateTime Birth { get; set; }
    public string? First { get; set; }
    public string? Last { get; set; }
    public string? Email { get; set; }
    public List<string>? Contents { get; set; }
    public Author()
    {

    }





}