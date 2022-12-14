using System;
using Xunit;
namespace GradeBook.Tests;
public class BookTests
{
    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
   var book = new Book("");
   book.AddGrade(89.1);
   book.AddGrade(90.5);
   book.AddGrade(77.3);

var result = book.GetStats();

   Assert.Equal(85.6,result.Average, 1);
   Assert.Equal(90.5,result.High);
   Assert.Equal(result.letter, 'B');
    }
}