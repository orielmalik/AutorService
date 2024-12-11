using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Authors.Api.Models;

public class AuthorBoundary
{
    private string id;
    private string first, last; // Name
    private List<string> contents;
    private string birth;
    private string email;

  public AuthorBoundary() 
    {
        // Initialize default values if necessary
    }

    public AuthorBoundary(string birth, string first, string last, string email)
    {
        id = Guid.NewGuid().ToString();
        this.first = first;
        this.last = last;
        contents = new List<string>();
        this.email = email;
        this.birth = birth;
    }

    // Constructor to initialize AuthorBoundary from an Author object

    [JsonConstructor]
    public AuthorBoundary(Author author)
    {
        this.Id = author.Id;
        this.First = author.First;
        this.Last = author.Last;
        this.Email = author.Email;
        this.Birth = author.Birth.ToString("yyyy-MM-dd");
        this.Contents = author.Contents ?? new List<string>();
    }

    // Method to convert AuthorBoundary to Author
    public Author ToAuthor()

    {

        if(string.IsNullOrEmpty(this.id))
        {
         throw new Exception("NULL ONE OR MORE FIELDS");

        }
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

    public string? Id { get; set; }
    public string Birth { get => birth; set => birth = value; }
    public string? First { get; set; }
    public string? Last { get; set; }
    public string? Email { get; set; }
    public List<string>? Contents { get; set; }
}
