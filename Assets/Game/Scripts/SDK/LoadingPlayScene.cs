using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPlayScene : MonoBehaviour
{
    private const string MenuScene = "1_MenuScene";
    private const string TutorialScene = "Tutorial";

    [SerializeField] private Image _loadingImage;

    private AsyncOperation _asyncOperation;

    public void StartLoadScene()
    {
        if(Services.SaveService.TryGetData(out GameInfo data))
            _asyncOperation = SceneManager.LoadSceneAsync(MenuScene);
        else
            _asyncOperation = SceneManager.LoadSceneAsync(TutorialScene);

        _loadingImage.transform.DORotate(new Vector3(0, 0, 360f), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }
}