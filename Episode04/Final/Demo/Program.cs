using System;
using System.IO;
using Demo.Scripting;
using EasyParse.Parsing;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Text:\n{string.Join("\n", lines)}");

            Parser parser = Parser.FromXmlResource(typeof(Program).Assembly, "Demo.Scripting.Grammar.xml");
            var result = parser.Parse(lines).Compile(new ScriptCompiler());

            if (result is Script script)
            {
                var run = script.Run(new Nothing());
                while (!run.IsOver)
                    run.Step();
            }
            else
            {
                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
    }

    class Nothing : IEnvironment
    {
        public void FindFile(string partOfName)
        {
            Console.WriteLine($"FINDING FILE ---- {partOfName}");
        }

        public void FindLine(string containing)
        {
        }
    }
}
