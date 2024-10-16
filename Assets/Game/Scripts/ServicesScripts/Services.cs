using MonsterArenaMasterOfTheBlade.Audio;
using MonsterArenaMasterOfTheBlade.SaveSystem;
using MonsterArenaMasterOfTheBlade.SDK;

namespace MonsterArenaMasterOfTheBlade.ServicesScripts
{
    public static class Services
    {
        public static ISaveService SaveService { get; private set; }
        public static IAdvertisemintServise AdvertisemintService { get; private set; }
        public static IAudioServise AudioService { get; private set; }
        public static ILocalizationServise LocalizationService { get; private set; }
        public static IGameReadyService GameReadyService { get; private set; }
        public static IGamePhauseControl GameStopControl { get; private set; }

        public static void Init()
        {
            RegisterSaveAndLoad();
            RegisterAdvertisemint();
            RegisterAudio();
            RegisterLocalization();
            RegisterGameReady();
            RegisterGameStopControl();
        }

        private static void RegisterSaveAndLoad()
        {
            SaveService = new SaveService();
        }

        private static void RegisterAdvertisemint()
        {
            AdvertisemintService = new AdvertisemintServise();
        }

        private static void RegisterAudio()
        {
            AudioService = new AudioServise();
        }

        private static void RegisterLocalization()
        {
            LocalizationService = new LocalizationServise();
        }

        private static void RegisterGameReady()
        {
            GameReadyService = new GameReadyService();
        }

        private static void RegisterGameStopControl()
        {
            GameStopControl = new GamePhauseControl();
        }
    }
}