namespace MaterialInventoryImport
{
    public interface IConsole
    {
        string ReadLine();

        void WriteLine(string val = "");
    }
}