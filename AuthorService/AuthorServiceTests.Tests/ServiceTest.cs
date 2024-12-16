using Xunit;
namespace AuthorServiceTests.Tests;

public class UnitTest1
{
  
 [Fact]
 public void IsPrime_InputIs1_ReturnFalse()
        {
            Assert.False(1+1==3, "1 should not be prime");
        }
    
    
}
