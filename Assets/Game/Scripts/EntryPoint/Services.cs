public static class Services
{
    public static ISaveService SaveService { get; private set; }

    public static void Init()
    {
        RegisterSaveAndLoad();
    }

    private static void RegisterSaveAndLoad()
    {
        SaveService = new SaveService();
    }
}