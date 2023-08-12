using NUnit.Framework;
using ReadOnlySpanExtensions;

namespace ReadOnlySpanExtensionsTests;

public class ReadOnlySpanExtensionsTests
{
    [TestCase("Test1|Test2", "|", "Test1")]
    [TestCase("|Test1|Test2|", "|Test1", "")]
    [TestCase("|Test1|Test2|", "Test2|", "|Test1|")]
    [TestCase("Test", "|", "")]
    [TestCase("", "|", "")]
    [TestCase("Test", "", "")]
    public void ShouldReturnSpanBefore(string input, string text, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBefore(text);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }

    [TestCase("Test1|Test2|Test3", "Test", 1, "Test1|")]
    [TestCase("Test1|Test2|Test3", "Test", 12, "Test1|Test2|")]
    [TestCase("Test1|Test2|Test3", "Test", 17, "")]
    [TestCase("Test1|Test2|Test3", "Test", 0, "")]
    [TestCase("Test1|Test2|Test3", "Test", -1, "")]
    public void ShouldReturnSpanBeforeWithStartingPos(string input, string text, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBefore(text, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2", "|", "Test1|")]
    [TestCase("|Test1|Test2|", "|Test1", "|Test1")]
    [TestCase("|Test1|Test2|", "Test2|", "|Test1|Test2|")]
    [TestCase("Test", "|", "")]
    [TestCase("", "|", "")]
    [TestCase("Test", "", "")]
    public void ShouldReturnSpanBeforeIncluding(string input, string text, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBeforeIncluding(text);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 1, "Test1|Test")]
    [TestCase("Test1|Test2|Test3", "Test", 12, "Test1|Test2|Test")]
    [TestCase("Test1|Test2|Test3", "Test", 17, "")]
    [TestCase("Test1|Test2|Test3", "Test", 0, "Test")]
    [TestCase("Test1|Test2|Test3", "Test", -1, "")]
    public void ShouldReturnSpanBeforeIncludingWithStartingPos(string input, string text, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBeforeIncluding(text, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2", "Test", "Test1|")]
    [TestCase("|Test1|Test2|", "|Test", "|Test1")]
    [TestCase("|Test2|Test|", "Test|", "|Test2|")]
    [TestCase("|Test1|Test2|", "|Test1", "")]
    [TestCase("Test", "|", "")]
    [TestCase("", "|", "")]
    [TestCase("Test", "", "")]
    public void ShouldReturnSpanBeforeLast(string input, string text, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBeforeLast(text);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 1, "Test1|Test2|")]
    [TestCase("Test1|Test2|Test3", "Test", 12, "Test1|Test2|")]
    [TestCase("Test1|Test2|Test3", "Test", 17, "")]
    [TestCase("Test1|Test2|Test3", "Test", 0, "Test1|Test2|")]
    [TestCase("Test1|Test2|Test3", "Test", -1, "")]
    public void ShouldReturnSpanBeforeLastWithStartingPos(string input, string text, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBeforeLast(text, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }

    [TestCase("Test1|Test2", "Test", "Test1|Test")]
    [TestCase("|Test1|Test2|", "|Test", "|Test1|Test")]
    [TestCase("|Test2|Test|", "Test|", "|Test2|Test|")]
    [TestCase("|Test1|Test2|", "|Test1", "|Test1")]
    [TestCase("Test", "|", "")]
    [TestCase("", "|", "")]
    [TestCase("Test", "", "")]
    public void ShouldReturnSpanBeforeLastIncluding(string input, string text, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBeforeLastIncluding(text);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 1, "Test1|Test2|Test")]
    [TestCase("Test1|Test2|Test3", "Test", 12, "Test1|Test2|Test")]
    [TestCase("Test1|Test2|Test3", "Test", 17, "")]
    [TestCase("Test1|Test2|Test3", "Test", 0, "Test1|Test2|Test")]
    [TestCase("Test1|Test2|Test3", "Test", -1, "")]
    public void ShouldReturnSpanBeforeLastIncludingWithStartingPos(string input, string text, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBeforeLastIncluding(text, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 3, "Test1|Test2|")]
    [TestCase("Test1|Test2|Test3", "Test3", 1, "Test1|Test2|")]
    [TestCase("Test1|Test2|Test3", "Test3", 2, "")]
    [TestCase("Test1|Test2|Test3", "Test", 1, "")]
    [TestCase("Test1|Test2|Test3", "Test", 0, "")]
    [TestCase("Test1|Test2|Test3", "Test", -1, "")]
    [TestCase("", "Test", 1, "")]
    public void ShouldReturnSpanBeforeNth(string input, string text, int counter, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBeforeNth(text, counter);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 3, 0, "Test1|Test2|")]
    [TestCase("Test1|Test2|Test3", "Test", 2, 6, "Test1|Test2|")]
    [TestCase("Test1|Test2|Test3", "Test", 3, 1, "")]
    [TestCase("Test1|Test2|Test3", "Test", 2, 12, "")]
    [TestCase("Test1|Test2|Test3", "Test", 2, 17, "")]
    [TestCase("Test1|Test2|Test3", "Test", 1, 0, "")]
    [TestCase("Test1|Test2|Test3", "Test", 1, -1, "")]
    public void ShouldReturnSpanBeforeNthWithStartingPos(string input, string text, int counter, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBeforeNth(text, counter, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 3, "Test1|Test2|Test")]
    [TestCase("Test1|Test2|Test3", "Test3", 1, "Test1|Test2|Test3")]
    [TestCase("Test1|Test2|Test3", "Test3", 2, "")]
    [TestCase("Test1|Test2|Test3", "Test", 1, "Test")]
    [TestCase("Test1|Test2|Test3", "Test", 0, "")]
    [TestCase("Test1|Test2|Test3", "Test", -1, "")]
    [TestCase("", "Test", 1, "")]
    public void ShouldReturnSpanBeforeNthIncluding(string input, string text, int counter, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBeforeNthIncluding(text, counter);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 3, 0, "Test1|Test2|Test")]
    [TestCase("Test1|Test2|Test3", "Test", 2, 6, "Test1|Test2|Test")]
    [TestCase("Test1|Test2|Test3", "Test", 3, 1, "")]
    [TestCase("Test1|Test2|Test3", "Test", 2, 12, "")]
    [TestCase("Test1|Test2|Test3", "Test", 2, 17, "")]
    [TestCase("Test1|Test2|Test3", "Test", 1, 0, "Test")]
    [TestCase("Test1|Test2|Test3", "Test", 1, -1, "")]
    public void ShouldReturnSpanBeforeNthIncludingWithStartingPos(string input, string text, int counter, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBeforeNthIncluding(text, counter, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2", "|", "Test2")]
    [TestCase("|Test1|Test2|", "|Test1", "|Test2|")]
    [TestCase("|Test1|Test2|", "Test2|", "")]
    [TestCase("Test", "|", "")]
    [TestCase("", "|", "")]
    [TestCase("Test", "", "")]
    public void ShouldReturnSpanAfter(string input, string text, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanAfter(text);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 1, "2|Test3")]
    [TestCase("Test1|Test2|Test3", "Test", 12, "3")]
    [TestCase("Test1|Test2|Test3", "Test", 17, "")]
    [TestCase("Test1|Test2|Test3", "Test", 0, "1|Test2|Test3")]
    [TestCase("Test1|Test2|Test3", "Test", -1, "")]
    public void ShouldReturnSpanAfterWithStartingPos(string input, string text, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanAfter(text, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2", "|", "|Test2")]
    [TestCase("|Test1|Test2|", "|Test1", "|Test1|Test2|")]
    [TestCase("|Test1|Test2|", "Test2|", "Test2|")]
    [TestCase("Test", "|", "")]
    [TestCase("", "|", "")]
    [TestCase("Test", "", "")]
    public void ShouldReturnSpanAfterIncluding(string input, string text, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanAfterIncluding(text);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 1, "Test2|Test3")]
    [TestCase("Test1|Test2|Test3", "Test", 12, "Test3")]
    [TestCase("Test1|Test2|Test3", "Test", 17, "")]
    [TestCase("Test1|Test2|Test3", "Test", 0, "Test1|Test2|Test3")]
    [TestCase("Test1|Test2|Test3", "Test", -1, "")]
    public void ShouldReturnSpanAfterIncludingWithStartingPos(string input, string text, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanAfterIncluding(text, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2", "Test", "2")]
    [TestCase("|Test1|Test2|", "|Test", "2|")]
    [TestCase("|Test2|Test|", "Test|", "")]
    [TestCase("|Test1|Test2|", "|Test1", "|Test2|")]
    [TestCase("Test", "|", "")]
    [TestCase("", "|", "")]
    [TestCase("Test", "", "")]
    public void ShouldReturnSpanAfterLast(string input, string text, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanAfterLast(text);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 1, "3")]
    [TestCase("Test1|Test2|Test3", "Test", 12, "3")]
    [TestCase("Test1|Test2|Test3", "Test", 17, "")]
    [TestCase("Test1|Test2|Test3", "Test", 0, "3")]
    [TestCase("Test1|Test2|Test3", "Test", -1, "")]
    public void ShouldReturnSpanAfterLastWithStartingPos(string input, string text, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanAfterLast(text, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2", "Test", "Test2")]
    [TestCase("|Test1|Test2|", "|Test", "|Test2|")]
    [TestCase("|Test2|Test|", "Test|", "Test|")]
    [TestCase("|Test1|Test2|", "|Test1", "|Test1|Test2|")]
    [TestCase("Test", "|", "")]
    [TestCase("", "|", "")]
    [TestCase("Test", "", "")]
    public void ShouldReturnSpanAfterLastIncluding(string input, string text, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanAfterLastIncluding(text);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 1, "Test3")]
    [TestCase("Test1|Test2|Test3", "Test", 12, "Test3")]
    [TestCase("Test1|Test2|Test3", "Test", 17, "")]
    [TestCase("Test1|Test2|Test3", "Test", 0, "Test3")]
    [TestCase("Test1|Test2|Test3", "Test", -1, "")]
    public void ShouldReturnSpanAfterLastIncludingWithStartingPos(string input, string text, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanAfterLastIncluding(text, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 3, "3")]
    [TestCase("Test1|Test2|Test3", "Test3", 1, "")]
    [TestCase("Test1|Test2|Test3", "Test3", 2, "")]
    [TestCase("Test1|Test2|Test3", "Test", 1, "1|Test2|Test3")]
    [TestCase("Test1|Test2|Test3", "Test", 0, "")]
    [TestCase("Test1|Test2|Test3", "Test", -1, "")]
    [TestCase("", "Test", 1, "")]
    public void ShouldReturnSpanAfterNth(string input, string text, int counter, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanAfterNth(text, counter);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 3, 0, "3")]
    [TestCase("Test1|Test2|Test3", "Test", 2, 6, "3")]
    [TestCase("Test1|Test2|Test3", "Test", 3, 1, "")]
    [TestCase("Test1|Test2|Test3", "Test", 2, 12, "")]
    [TestCase("Test1|Test2|Test3", "Test", 2, 17, "")]
    [TestCase("Test1|Test2|Test3", "Test", 1, 0, "1|Test2|Test3")]
    [TestCase("Test1|Test2|Test3", "Test", 1, -1, "")]
    public void ShouldReturnSpanAfterNthWithStartingPos(string input, string text, int counter, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanAfterNth(text, counter, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 3, "Test3")]
    [TestCase("Test1|Test2|Test3", "Test3", 1, "Test3")]
    [TestCase("Test1|Test2|Test3", "Test3", 2, "")]
    [TestCase("Test1|Test2|Test3", "Test", 1, "Test1|Test2|Test3")]
    [TestCase("Test1|Test2|Test3", "Test", 0, "")]
    [TestCase("Test1|Test2|Test3", "Test", -1, "")]
    [TestCase("", "Test", 1, "")]
    public void ShouldReturnSpanAfterNthIncluding(string input, string text, int counter, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanAfterNthIncluding(text, counter);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("Test1|Test2|Test3", "Test", 3, 0, "Test3")]
    [TestCase("Test1|Test2|Test3", "Test", 2, 6, "Test3")]
    [TestCase("Test1|Test2|Test3", "Test", 3, 1, "")]
    [TestCase("Test1|Test2|Test3", "Test", 2, 12, "")]
    [TestCase("Test1|Test2|Test3", "Test", 2, 17, "")]
    [TestCase("Test1|Test2|Test3", "Test", 1, 0, "Test1|Test2|Test3")]
    [TestCase("Test1|Test2|Test3", "Test", 1, -1, "")]
    public void ShouldReturnSpanAfterNthIncludingWithStartingPos(string input, string text, int counter, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanAfterNthIncluding(text, counter, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("<td>Dummy</td>", "<td>", "</td>", "Dummy")]
    [TestCase("<td>Dummy</td>", "<td>", "</", "Dummy")]
    [TestCase("<td>Dummy</td>", "<td>", "<", "Dummy")]
    [TestCase("<td>Dummy</td>", ">", "</td>", "Dummy")]
    [TestCase("<td>Dummy</td>", ">", "<", "Dummy")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "</td>", "Dummy")]
    [TestCase("", "<td>", "</td>", "")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "", "</td>", "")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "", "")]
    [TestCase("<td>", "<td>", "</td>", "")]
    [TestCase("</td>", "<td>", "</td>", "")]
    [TestCase("<td></td>", "<td>", "</td>", "")]
    public void ShouldReturnSpanBetween(string input, string startText, string endText, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBetween(startText, endText);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("<td>Dummy</td>", "<td>", "</td>", 1, "")]
    [TestCase("<td>Dummy</td>", "<td>", "</", 0, "Dummy")]
    [TestCase("<td>Dummy</td>", "<td>", "<", 14, "")]
    [TestCase("<td>Dummy</td>", ">", "</td>", 0, "Dummy")]
    [TestCase("<td>Dummy</td>", ">", "<", 0, "Dummy")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "</td>", 11, "Dummy")]
    [TestCase("", "<td>", "</td>", 0, "")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "", "</td>", 0, "")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "", 0, "")]
    [TestCase("<td>", "<td>", "</td>", 0, "")]
    [TestCase("</td>", "<td>", "</td>", 0, "")]
    [TestCase("<td></td>", "<td>", "</td>", 0, "")]
    public void ShouldReturnSpanBetweenWithStartingPos(string input, string startText, string endText, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBetween(startText, endText, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("<td>Dummy</td>", "<td>", "</td>", "<td>Dummy</td>")]
    [TestCase("<td>Dummy</td>", "<td>", "</", "<td>Dummy</")]
    [TestCase("<td>Dummy</td>", "<td>", "<", "<td>Dummy<")]
    [TestCase("<td>Dummy</td>", ">", "</td>", ">Dummy</td>")]
    [TestCase("<td>Dummy</td>", ">", "<", ">Dummy<")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "</td>", "<td>Dummy</td>")]
    [TestCase("", "<td>", "</td>", "")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "", "</td>", "")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "", "")]
    [TestCase("<td>", "<td>", "</td>", "")]
    [TestCase("</td>", "<td>", "</td>", "")]
    [TestCase("<td></td>", "<td>", "</td>", "<td></td>")]
    public void ShouldReturnSpanBetweenIncluding(string input, string startText, string endText, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBetweenIncluding(startText, endText);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("<td>Dummy</td>", "<td>", "</td>", 1, "")]
    [TestCase("<td>Dummy</td>", "<td>", "</", 0, "<td>Dummy</")]
    [TestCase("<td>Dummy</td>", "<td>", "<", 14, "")]
    [TestCase("<td>Dummy</td>", ">", "</td>", 0, ">Dummy</td>")]
    [TestCase("<td>Dummy</td>", ">", "<", 0, ">Dummy<")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "</td>", 11, "<td>Dummy</td>")]
    [TestCase("", "<td>", "</td>", 0, "")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "", "</td>", 0, "")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "", 0, "")]
    [TestCase("<td>", "<td>", "</td>", 0, "")]
    [TestCase("</td>", "<td>", "</td>", 0, "")]
    [TestCase("<td></td>", "<td>", "</td>", 0, "<td></td>")]
    public void ShouldReturnSpanBetweenIncludingWithStartingPos(string input, string startText, string endText, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBetweenIncluding(startText, endText, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("<td>Dummy</td>", "<td>", "</td>", "Dummy")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", "Dummy</td><td>Dummy2</td><td>Dummy3")]
    public void ShouldReturnSpanBetweenOuter(string input, string startText, string endText, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBetweenOuter(startText, endText);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("<td>Dummy</td>", "<td>", "</td>", 1, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 14, "Dummy2</td><td>Dummy3")]
    public void ShouldReturnSpanBetweenOuterWithStartingPos(string input, string startText, string endText, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBetweenOuter(startText, endText, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("<td>Dummy</td>", "<td>", "</td>", "<td>Dummy</td>")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", "<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>")]
    public void ShouldReturnSpanBetweenOuterIncluding(string input, string startText, string endText, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBetweenOuterIncluding(startText, endText);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("<td>Dummy</td>", "<td>", "</td>", 1, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 14, "<td>Dummy2</td><td>Dummy3</td>")]
    public void ShouldReturnSpanBetweenOuterIncludingWithStartingPos(string input, string startText, string endText, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBetweenOuterIncluding(startText, endText, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 1, "Dummy")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 2, "Dummy2")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 3, "Dummy3")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 4, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 0, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<th>", "</th>", 1, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "", "</td>", 1, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "", 1, "")]
    public void ShouldReturnSpanBetweenNth(string input, string startText, string endText, int count, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBetweenNth(startText, endText, count);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 1, 14, "Dummy2")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 1, 29, "Dummy3")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 2, 14, "Dummy3")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 1, -1, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 1, 44, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 1, 45, "")]
    public void ShouldReturnSpanBetweenNthWithStartingPos(string input, string startText, string endText, int count, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBetweenNth(startText, endText, count, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 1, "<td>Dummy</td>")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 2, "<td>Dummy2</td>")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 3, "<td>Dummy3</td>")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 4, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 0, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<th>", "</th>", 1, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "", "</td>", 1, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "", 1, "")]
    public void ShouldReturnSpanBetweenNthIncluding(string input, string startText, string endText, int count, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBetweenNthIncluding(startText, endText, count);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
    
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 1, 14, "<td>Dummy2</td>")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 1, 29, "<td>Dummy3</td>")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 2, 14, "<td>Dummy3</td>")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 1, -1, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 1, 44, "")]
    [TestCase("<td>Dummy</td><td>Dummy2</td><td>Dummy3</td>", "<td>", "</td>", 1, 45, "")]
    public void ShouldReturnSpanBetweenNthIncludingWithStartingPos(string input, string startText, string endText, int count, int startingPos, string expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanBetweenNthIncluding(startText, endText, count, startingPos);
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void ShouldOptionallyIgnoreCase()
    {
        var inputSpan = "Test1|Test2".AsSpan();
        var result = inputSpan.SpanBefore("tEsT2", stringComparison: StringComparison.OrdinalIgnoreCase);
        Assert.That(result.ToString(), Is.EqualTo("Test1|"));
    }

    [TestCase("Test1/Test2/Test3", "/", 2)]
    [TestCase("Test1/Test2/Test3", "Test", 3)]
    [TestCase("Test1/Test2/Test3", "Dummy", 0)]
    public void ShouldReturnSpanCount(string input, string text, int expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanCount(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Test1/Test2/Test3", "/", 5, 2)]
    [TestCase("Test1/Test2/", "/", 11, 1)]
    [TestCase("Test1/Test2/", "/", 12, 0)]
    public void ShouldReturnSpanCountWithStartingPos(string input, string text, int startingPos, int expected)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanCount(text, startingPos);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Test1|Test2", "|", "Test1", "Test2")]
    [TestCase("|Test1|Test2|", "|", "", "Test1|Test2|")]
    [TestCase("Test/", "/", "Test", "")]
    [TestCase("Test1|Test2", "", "", "")]
    [TestCase("", "|", "", "")]
    public void ShouldReturnSpanPairSurrounding(string input, string text, string expectedFirst, string expectedSecond)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanPairSurrounding(text);
        Assert.That(result.First.ToString(), Is.EqualTo(expectedFirst));
        Assert.That(result.Second.ToString(), Is.EqualTo(expectedSecond));
    }
    
    [TestCase("<table><tr><td>Dummy</td><td>Dummy2</td></tr></table>", "<td>", "</td>", "<table><tr>", "<td>Dummy2</td></tr></table>")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "</td>", "<table><tr>", "</tr></table>")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "", "", "")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "", "</td>", "", "")]
    [TestCase("<td>Dummy</td>", "<td>", "</td>", "", "")]
    [TestCase("", "<td>", "</td>", "", "")]
    public void ShouldReturnSpanPairSurrounding(string input, string startText, string endText, string expectedFirst, string expectedSecond)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanPairSurrounding(startText, endText);
        Assert.That(result.First.ToString(), Is.EqualTo(expectedFirst));
        Assert.That(result.Second.ToString(), Is.EqualTo(expectedSecond));
    }

    [TestCase("<table><tr><td>Dummy</td><td>Dummy2</td></tr></table>", "<td>", "</td>", 25, "<table><tr><td>Dummy</td>", "</tr></table>")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "</td>", 12, "", "")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "", 39, "", "")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "", "</td>", 0, "", "")]
    [TestCase("<td>Dummy</td>", "<td>", "</td>", -1, "", "")]
    [TestCase("", "<td>", "</td>", 100, "", "")]
    public void ShouldReturnSpanPairSurroundingWithStartingPos(string input, string startText, string endText, int startingPos, string expectedFirst, string expectedSecond)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanPairSurrounding(startText, endText, startingPos);
        Assert.That(result.First.ToString(), Is.EqualTo(expectedFirst));
        Assert.That(result.Second.ToString(), Is.EqualTo(expectedSecond));
    }

    [TestCase("<table><tr><td>Dummy</td><td>Dummy2</td></tr></table>", "<td>", "</td>", "<table><tr><td>", "</td><td>Dummy2</td></tr></table>")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "</td>", "<table><tr><td>", "</td></tr></table>")]
    public void ShouldReturnSpanPairSurroundingIncluding(string input, string startText, string endText, string expectedFirst, string expectedSecond)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanPairSurroundingIncluding(startText, endText);
        Assert.That(result.First.ToString(), Is.EqualTo(expectedFirst));
        Assert.That(result.Second.ToString(), Is.EqualTo(expectedSecond));
    }

    [TestCase("<table><tr><td>Dummy</td><td>Dummy2</td></tr></table>", "<td>", "</td>", 25, "<table><tr><td>Dummy</td><td>", "</td></tr></table>")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "</td>", 12, "", "")]
    public void ShouldReturnSpanPairSurroundingIncludingWithStartingPos(string input, string startText, string endText, int startingPos, string expectedFirst, string expectedSecond)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanPairSurroundingIncluding(startText, endText, startingPos);
        Assert.That(result.First.ToString(), Is.EqualTo(expectedFirst));
        Assert.That(result.Second.ToString(), Is.EqualTo(expectedSecond));
    }

    [TestCase("<table><tr><td>Dummy</td><td>Dummy2</td></tr></table>", "<td>", "</td>", "<table><tr>", "</tr></table>")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "</td>", "<table><tr>", "</tr></table>")]
    public void ShouldReturnSpanPairSurroundingOuter(string input, string startText, string endText, string expectedFirst, string expectedSecond)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanPairSurroundingOuter(startText, endText);
        Assert.That(result.First.ToString(), Is.EqualTo(expectedFirst));
        Assert.That(result.Second.ToString(), Is.EqualTo(expectedSecond));
    }

    [TestCase("<table><tr><td>Dummy</td><td>Dummy2</td></tr></table>", "<td>", "</td>", 25, "<table><tr><td>Dummy</td>", "</tr></table>")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "</td>", 12, "", "")]
    public void ShouldReturnSpanPairSurroundingOuterWithStartingPos(string input, string startText, string endText, int startingPos, string expectedFirst, string expectedSecond)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanPairSurroundingOuter(startText, endText, startingPos);
        Assert.That(result.First.ToString(), Is.EqualTo(expectedFirst));
        Assert.That(result.Second.ToString(), Is.EqualTo(expectedSecond));
    }

    [TestCase("<table><tr><td>Dummy</td><td>Dummy2</td></tr></table>", "<td>", "</td>", "<table><tr><td>", "</td></tr></table>")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "</td>", "<table><tr><td>", "</td></tr></table>")]
    public void ShouldReturnSpanPairSurroundingOuterIncluding(string input, string startText, string endText, string expectedFirst, string expectedSecond)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanPairSurroundingOuterIncluding(startText, endText);
        Assert.That(result.First.ToString(), Is.EqualTo(expectedFirst));
        Assert.That(result.Second.ToString(), Is.EqualTo(expectedSecond));
    }

    [TestCase("<table><tr><td>Dummy</td><td>Dummy2</td></tr></table>", "<td>", "</td>", 25, "<table><tr><td>Dummy</td><td>", "</td></tr></table>")]
    [TestCase("<table><tr><td>Dummy</td></tr></table>", "<td>", "</td>", 12, "", "")]
    public void ShouldReturnSpanPairSurroundingOuterIncludingWithStartingPos(string input, string startText, string endText, int startingPos, string expectedFirst, string expectedSecond)
    {
        var inputSpan = input.AsSpan();
        var result = inputSpan.SpanPairSurroundingOuterIncluding(startText, endText, startingPos);
        Assert.That(result.First.ToString(), Is.EqualTo(expectedFirst));
        Assert.That(result.Second.ToString(), Is.EqualTo(expectedSecond));
    }
}