using System;
using System.Collections.Generic;

namespace PragProg.Fsm;

/// <summary>
/// Minimal generic finite-state-machine runner that decouples mechanism from policy.
/// The transition function returns the next state and an optional effect object.
/// </summary>
public sealed class StateMachine<TState, TEvent>
    where TState : notnull
    where TEvent : notnull
{
    public delegate (TState Next, object? Effect) TransitionFn(TState state, TEvent ev);

    private readonly TState _initial;
    private readonly TransitionFn _transition;

    public StateMachine(TState initial, TransitionFn transition)
    {
        _initial = initial;
        _transition = transition;
    }

    public IEnumerable<(TState State, TEvent Event, object? Effect)> Run(IEnumerable<TEvent> events)
    {
        var state = _initial;
        foreach (var ev in events)
        {
            (state, var effect) = _transition(state, ev);
            yield return (state, ev, effect);
        }
    }
}
