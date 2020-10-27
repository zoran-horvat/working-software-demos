namespace Demo.Scripting
{
    class EditFile : Instruction
    {
        public string FileName { get; }
     
        public EditFile(string fileName)
        {
            this.FileName = fileName;
        }

        public override void Execute(IEnvironment environment)
        {
            environment.FindFile(this.FileName);
        }

        public override string ToString() => $"{this.GetType().FullName} {this.FileName}";
    }
}
