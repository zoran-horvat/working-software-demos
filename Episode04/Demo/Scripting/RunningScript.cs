using System.Collections.Generic;

namespace Demo.Scripting
{
    class RunningScript
    {
        private IEnumerator<Instruction> Enumerator { get; }
        public bool IsOver { get; private set; }
        private IEnvironment Environment { get; }

        public RunningScript(IEnumerator<Instruction> enumerator, IEnvironment environment)
        {
            this.Enumerator = enumerator;
            this.IsOver = !this.Enumerator.MoveNext();
            this.Environment = environment;
        }

        public void Step()
        {
            if (this.IsOver) return;

            this.Enumerator.Current?.Execute(this.Environment);
            this.IsOver = !this.Enumerator.MoveNext();
        }
    }
}