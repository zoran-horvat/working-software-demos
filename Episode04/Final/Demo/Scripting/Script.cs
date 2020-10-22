using System.Collections.Generic;
using System.Collections.Immutable;

namespace Demo.Scripting
{
    class Script
    {
        private ImmutableList<Instruction> Instructions { get; }

        public static Script Empty => new Script(ImmutableList<Instruction>.Empty);

        public Script(ImmutableList<Instruction> instructions)
        {
            this.Instructions = instructions;
        }

        public Script Append(Instruction instruction) =>
            instruction is EmptyInstruction ? this
            : new Script(this.Instructions.Add(instruction));

        public RunningScript Run(IEnvironment environment) =>
            new RunningScript(((IEnumerable<Instruction>)this.Instructions).GetEnumerator(), environment);
    }
}
