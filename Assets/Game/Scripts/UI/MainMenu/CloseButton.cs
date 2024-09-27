using UnityEngine;
using UnityEngine.UI;

namespace MonsterArenaMasterOfTheBlade.UI
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private GameObject _panel;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(ClosePanel);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(ClosePanel);
        }

        private void ClosePanel()
        {
            _panel.SetActive(false);
        }
    }
}