namespace PumpService
{
    internal interface IScriptService
    {
        bool Compile();
        void Run(int count);
    }
}
