
using Authors.Api.Models;
using Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
public class AuthorCrud
{

    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<Author> authors;

    public AuthorCrud(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

        authors = dbContext.Authors;
        if (authors == null)
        {
            Console.WriteLine("er crd");
        }
    }


    public Author createAuthor(Author author)
    {
        Author err = new Author();
        if (String.IsNullOrEmpty(author.Email) || !ValidationUtilites.IsEmailValid(author.Email) || author.First == null)
        {
            err.Id = "";
            return err;
        }
        if (authors.Find(author.Id) != null)
        {
            err.Id = "";
            return err;

        }
        this.authors.Add(author);
        _dbContext.SaveChanges();
        return author;
    }

    public List<AuthorBoundary> getAuthors(string type, string value)
    {
        switch (type.ToLower())
        {
            case "email":
                if (Utils.ValidationUtilites.IsEmailValid(value))
                {
                    throw new FormatException("EMAIL ERROR");
                }
                return authors.Where((author) => !string.IsNullOrEmpty(author.Email) && author.Email.ToLower().Equals(value)).Select((author)=>new AuthorBoundary(author)).ToList()
                ;
            case "first":
                return
                    authors.Where((author) => !string.IsNullOrEmpty(author.First) && author.First.ToLower().Equals(value)).Select((author)=>new AuthorBoundary(author)).ToList();
            case "last":
                return
                    authors.Where((author) => !string.IsNullOrEmpty(author.Last) && author.Last.ToLower().Equals(value)).Select((author)=>new AuthorBoundary(author)).ToList();
            case "birth":
                try
                {
                    DateTime dateval = Utils.ValidationUtilites.FromBirthdateFormat(value);
                    return authors.Where(author => !string.IsNullOrEmpty(author.Birth.ToString())  && author.Birth <= dateval).Select((author)=>new AuthorBoundary(author)).ToList();
                }
                catch ( InvalidOperationException ex)
                {
                 throw new FormatException("DATE ERROR");

                }
            default:
                return authors.Where(author => author.Id != null).Select((author)=>new AuthorBoundary(author)).ToList();


        }




    }


    public void deleteAuthors()
    {
        authors.ExecuteDelete();
        _dbContext.SaveChanges();
    }
}
