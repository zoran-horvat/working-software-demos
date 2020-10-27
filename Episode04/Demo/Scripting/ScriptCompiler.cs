using EasyParse.Parsing;

namespace Demo.Scripting
{
    class ScriptCompiler : MethodMapCompiler
    {
        private Script Script(Instruction instruction) =>
            Scripting.Script.Empty.Append(instruction);

        private Script Script(Script script, Instruction instruction) =>
            script.Append(instruction);

        private Instruction Line(string newLine) => Instruction.Empty;

        private Instruction Line(string comment, string newLine) => Instruction.Empty;

        private Instruction Line(Instruction instruction, string newLine) => instruction;

        private Instruction Statement(Instruction instruction) => instruction;

        private Instruction Edit(string edit, string fileName) => 
            new EditFile(fileName);

        private Instruction LineContaining(string line, string containing, string colon, string content) =>
            new LineContaining(content);

        private Instruction Select(string select, string colon, string content) => 
            new SelectContent(content);

        private Instruction Delete(string delete) => 
            new Delete();
    }
}
