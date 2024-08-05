using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPlayScene : MonoBehaviour
{
    private const string SceneName = "1_MenuScene";

    [SerializeField] private Image _loadingImage;
    [SerializeField] private TMP_Text _loadingProgress;

    private AsyncOperation _asyncOperation;
    private Coroutine _coroutine;

    public void StartLoadScene()
    {
        _asyncOperation = SceneManager.LoadSceneAsync(SceneName);

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        while (!_asyncOperation.isDone)
        {
            float progress = _asyncOperation.progress / 0.9f;
            _loadingImage.fillAmount = progress;
            _loadingProgress.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }
}