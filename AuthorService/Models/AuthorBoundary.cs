using System.Collections;
using System.ComponentModel.DataAnnotations;
namespace Authors.Api.Models;

public class AuthorBoundary
{
 public string? Id { get; set; }
    public string Birth { get ; set  ; }
    public string? First { get; set; }
    public string? Last { get; set; }
    public string? Email { get; set; }
    public List<string>? Contents { get; set; }

  public AuthorBoundary() 
    {
        // Initialize default values if necessary
    }

    public AuthorBoundary(string birth, string first, string last, string email)
    {
       this.Id = Guid.NewGuid().ToString();
        this.First = first;
        this.Last = last;
        this.Contents = new List<string>();
        this.Email = email;
        this.Birth = birth;
    }

    // Constructor to initialize AuthorBoundary from an Author object

    public AuthorBoundary(Author author)
    {
        this.Id = author.Id;
        this.First = author.First;
        this.Last = author.Last;
        this.Email = author.Email;
        this.Birth = author.Birth.ToString("dd-MM-yyyy");
        this.Contents = author.Contents ?? new List<string>();
    }

    // Method to convert AuthorBoundary to Author
    public Author ToAuthor()
    {

       
        DateTime parsedBirth;
        try
        {
            parsedBirth = Utils.ValidationUtilites.FromBirthdateFormat(this.Birth);

        }
        catch (FormatException f)
        {
            throw new Exception(f.Message);
        }
        return new Author
        {
            Id = this.Id,
            First = this.First,
            Last = this.Last,
            Email = this.Email,
            Birth = parsedBirth,
            Contents = this.Contents ?? new List<string>()
        };
    }


}
