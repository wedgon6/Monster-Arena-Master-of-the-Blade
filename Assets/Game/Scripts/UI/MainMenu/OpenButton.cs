using UnityEngine;
using UnityEngine.UI;

public class OpenButton : MonoBehaviour
{
    [SerializeField] private GameObject _pabel;
    [SerializeField] private Button _openButton;

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
        _pabel.gameObject.SetActive(true);
    }
}