using NUnit.Framework;
using PragProg.Strings;
using System.Linq;

namespace PragProg.Tests;

public class StringExtractorTests
{
    [Test]
    public void ExtractsSimple()
    {
        var input = "hello \"world\" end";
        var outp = StringExtractor.Extract(input).ToList();
        Assert.That(outp, Is.EquivalentTo(new[] { "world" }));
    }

    [Test]
    public void HandlesEscapes()
    {
        var input = "\"baz \\\"bat\\\" \" and \"a\\b\"";
        var outp = StringExtractor.Extract(input).ToList();
        Assert.That(outp[0], Is.EqualTo("baz \"bat\" ")); // escaped quotes preserved
        Assert.That(outp[1], Is.EqualTo("ab")); // backslash escapes next char => "a\\b" -> "ab"
    }

    [Test]
    public void IgnoresUnterminated()
    {
        var input = "no strings here or \"unterminated";
        var outp = StringExtractor.Extract(input).ToList();
        Assert.That(outp.Count, Is.EqualTo(0));
    }
}
