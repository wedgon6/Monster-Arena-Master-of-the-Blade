using UnityEngine;
using UnityEngine.UI;

public class OpenButton : MonoBehaviour
{
    [SerializeField] private GameObject _pabel;
    [SerializeField] private Button _openButton;

    public void Initialaize(GameObject panel)
    {
        _pabel = panel;
    }

    private void OnEnable()
    {
        _openButton.onClick.AddListener(OpenPanel);
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(OpenPanel);
    }

    private void OpenPanel()
    {
        Services.AdvertisemintService.ShowInterstitialAd();
        _pabel.gameObject.SetActive(true);
    }
}