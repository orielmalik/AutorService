
using Authors.Api.Models;
using Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;
using Microsoft.EntityFrameworkCore;
public class AuthorCrud
{

    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<Author> crud;

    public AuthorCrud(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        crud = dbContext.Authors;
    }


    public Author createAuthor(Author author)
    {
        Author err=new Author();
        if (!ValidationUtilites.IsEmailValid(author.Email) || author.First == null)
        {
            err.Id="ERREmail";
            return err ;
        }
        if (crud.Find(author.Id) != null)
        {
         err.Id="ERRNOTFOUND";
            return err;

        }
        this.crud.Add(author);
        _dbContext.SaveChanges();
        return author;
    }
}
