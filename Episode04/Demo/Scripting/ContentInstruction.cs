namespace Demo.Scripting
{
    abstract class ContentInstruction : Instruction
    {
        public string Content { get; }
     
        protected ContentInstruction(string content)
        {
            this.Content = content;
        }

        public override string ToString() => $"{this.GetType().FullName} {this.Content}";
    }
}
