using UnityEngine;
using UnityEngine.UI;

public class BattleButton : MonoBehaviour
{
    [SerializeField] private ChoiceMap _choiceMap;
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
        _choiceMap.gameObject.SetActive(true);
    }
}