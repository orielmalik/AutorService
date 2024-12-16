using NUnit.Framework;
using System.Net.Http;
using Assert = NUnit.Framework.Assert;

namespace AuthorServiceTests.Tests;
public class ServiceTestNunit()
{


HttpClient? thisService;


[SetUp]
public   void setup()
{
 thisService=new HttpClient
{
BaseAddress=new Uri("http://localhost:5002/author"),
};

}


[Test]
public async void getType()
{
   var l= await  thisService.GetAsync(thisService.BaseAddress);
Assert.That(l,!Is.Null,"NULL CHECK");
}









    
}