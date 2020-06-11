namespace MaterialInventoryImport
{
    internal interface IEntryParser
    {
        EntryInfoDto Parse(string inputLine);
    }
}