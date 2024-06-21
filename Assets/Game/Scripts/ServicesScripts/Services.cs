public static class Services
{
    public static ISaveService SaveService { get; private set; }
    public static IAdvertisemintServise AdvertisemintServise { get; private set; }

    public static void Init()
    {
        RegisterSaveAndLoad();
        RegisterAdvertisemint();
    }

    private static void RegisterSaveAndLoad()
    {
        SaveService = new SaveService();
    }
    
    private static void RegisterAdvertisemint()
    {
        AdvertisemintServise = new AdvertisemintServise();
    }
}