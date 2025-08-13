using System;
using PragProg.Strings;

Console.WriteLine("Demo: Extracting string literals\n");

var input = "prefix \"foo\" mid \"baz \\\"bat\\\"\" end \"a\\b\"";

Console.WriteLine($"Input: {input}\n");
foreach (var s in StringExtractor.Extract(input))
{
    Console.WriteLine($"-> {s}");
}
