namespace Demo.Scripting
{
    interface IEnvironment
    {
        void FindFile(string partOfName);
        void FindLine(string containing);
    }
}
