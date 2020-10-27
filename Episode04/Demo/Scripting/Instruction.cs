using System;

namespace Demo.Scripting
{
    abstract class Instruction
    {
        public static Instruction Empty => new EmptyInstruction();

        public virtual void Execute(IEnvironment environment)
        {
            Console.WriteLine($"Executing: {this}");
        }
    }
}
