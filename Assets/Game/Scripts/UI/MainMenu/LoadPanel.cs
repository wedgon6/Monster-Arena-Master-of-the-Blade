using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MonsterArenaMasterOfTheBlade.UI
{
    public class LoadPanel : MonoBehaviour
    {
        [SerializeField] private Image _loadingWheel;

        private string _sceneName;
        private AsyncOperation _asyncOperation;

        public void OpenLoadPanel(string sceneName)
        {
            gameObject.SetActive(true);
            _sceneName = sceneName;
            _asyncOperation = SceneManager.LoadSceneAsync(_sceneName);

            _loadingWheel.transform.DORotate(new Vector3(0, 0, 360f), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
        }
    }
}