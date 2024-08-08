using UnityEngine;
using UnityEngine.UI;

public class DelSave : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(DeleteSave);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(DeleteSave);
    }

    private void DeleteSave()
    {
        Services.SaveService.RemoveData();
    }
}