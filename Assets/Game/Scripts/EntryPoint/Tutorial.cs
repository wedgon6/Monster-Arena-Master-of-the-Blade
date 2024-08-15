using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<TutorialPhrase> _dialoguePhrases;
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private Image _icon;
    [SerializeField] private EnemySpawner _enemySpawner;

    private bool _isContinueDialog = false;
    private Coroutine _corontine;

    public void ContinueDialog()
    {
        _isContinueDialog = true;
    }

    public void SpotDialog()
    {
        if (_corontine != null)
            StopCoroutine(_corontine);

        EndDialogue();
    }

    private void Start()
    {
        _enemySpawner.PutEnemyToPool();

        if (_corontine != null)
            StopCoroutine(_corontine);

        _corontine = StartCoroutine(RunStudyDialog());
    }

    private IEnumerator RunStudyDialog()
    {
        for (int i = 0; i < _dialoguePhrases.Count; i++)
        {
            _isContinueDialog = false;
            _dialoguePhrases[i].UpdateLocalization();
            _lable.text = _dialoguePhrases[i].Phease.text;
            _icon.sprite = _dialoguePhrases[i].Icon;

            yield return new WaitUntil(() => _isContinueDialog);
        }

        EndDialogue();
    }

    private void EndDialogue()
    {
        _enemySpawner.RestSpawner(0);
        gameObject.SetActive(false);
    }
}