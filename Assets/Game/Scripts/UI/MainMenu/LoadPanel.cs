using DG.Tweening;
using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadPanel : MonoBehaviour
{
    [SerializeField] private Image _loadingWheel;
    [SerializeField] private TMP_Text _loadingProgress;

    private string _sceneName;
    private AsyncOperation _asyncOperation;
    private Coroutine _coroutine;

    public void OpenLoadPanel(string sceneName)
    {
        gameObject.SetActive(true);
        _sceneName = sceneName;
        _asyncOperation = SceneManager.LoadSceneAsync(_sceneName);

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _loadingWheel.transform.DORotate(new Vector3(0, 0, 360f), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
        _coroutine = StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        while (!_asyncOperation.isDone)
        {
            float progress = _asyncOperation.progress / 0.9f;
            _loadingProgress.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }

       // Services.AdvertisemintService.ShowInterstitialAd();
    }
}