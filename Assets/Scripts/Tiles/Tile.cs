using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private string taskValue;

    [SerializeField]
    private Button button;

    [SerializeField]
    private TilesConteiner tilesConteiner;

    public string TaskValue { get { return taskValue; } set { taskValue = value; } }

    private Sequence sequence;
    private void Awake()
    {
        var scale = transform.localScale.x;
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0.1f, 2f));
        sequence.AppendInterval(0.05f);
        sequence.Append(transform.DOScale(scale, 0.5f));
        sequence.Pause();

        sequence.Play().SetEase(Ease.InBounce);
    }
    void Start()
    {
        
        button.onClick.AddListener(CheckAnswer);

        tilesConteiner = GetComponentInParent<TilesConteiner>();
    }

    public void CheckAnswer()
    {
        if(taskValue == tilesConteiner.Value)
        {
            StartCoroutine(waitForWinningEffects());
            transform.DOShakeScale(1, 0.5f, 5);
        }
        else
        {
            transform.DOShakeScale(0.3f, 0.3f, 5);
        }
    }

    IEnumerator waitForWinningEffects()
    {
        yield return new WaitForSeconds(2f);
        tilesConteiner.InvokeOnComplete();
    }

}
