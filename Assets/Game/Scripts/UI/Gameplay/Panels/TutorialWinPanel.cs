public class TutorialWinPanel : ResultsPanel
{
    protected override void RelocateEarnedData()
    {
        Services.SaveService.RelocateData(_player.PlayerWallet, 0, _player.EarnedScore);
    }
}