using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPlayScene : MonoBehaviour
{
    private const string MenuScene = "1_MenuScene";
    private const string TutorialScene = "Tutorial";

    [SerializeField] private Image _loadingImage;
    [SerializeField] private TMP_Text _loadingProgress;

    private AsyncOperation _asyncOperation;
    private Coroutine _coroutine;

    public void StartLoadScene()
    {
        if(Services.SaveService.TryGetData(out GameInfo data))
            _asyncOperation = SceneManager.LoadSceneAsync(MenuScene);
        else
            _asyncOperation = SceneManager.LoadSceneAsync(TutorialScene);

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