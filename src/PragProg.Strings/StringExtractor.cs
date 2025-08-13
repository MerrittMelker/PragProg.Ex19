using System.Collections.Generic;
using System.Text;
using PragProg.Fsm;

namespace PragProg.Strings;

/// <summary>
/// Extracts double-quoted string literals from an input, handling C-style escapes (\x becomes x).
/// </summary>
public static class StringExtractor
{
    private enum S { LookForString, InString, Escape }

    private abstract record Effect;
    private sealed record Start : Effect;
    private sealed record Append(char Ch) : Effect;
    private sealed record Finish : Effect;

    public static IEnumerable<string> Extract(string input)
    {
        var fsm = new StateMachine<S, char>(
            initial: S.LookForString,
            transition: (state, ch) => state switch
            {
                S.LookForString => ch switch
                {
                    '"' => (S.InString, (object?)new Start()),
                    _    => (S.LookForString, null)
                },
                S.InString => ch switch
                {
                    '\\' => (S.Escape, null),
                    '"'   => (S.LookForString, (object?)new Finish()),
                    _      => (S.InString, (object?)new Append(ch))
                },
                S.Escape => (S.InString, (object?)new Append(ch)),
                _ => (S.LookForString, null)
            }
        );

        var buf = new StringBuilder();
        foreach (var (_, _, effect) in fsm.Run(input))
        {
            switch (effect)
            {
                case Start: buf.Clear(); break;
                case Append a: buf.Append(a.Ch); break;
                case Finish: yield return buf.ToString(); break;
            }
        }
    }
}
