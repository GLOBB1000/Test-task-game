using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameTask : MonoBehaviour
{
    [SerializeField]
    private Text text;

    [SerializeField]
    private GameObject level;

    private TilesConteiner currentConteiner;
    
    // Start is called before the first frame update
    void Start()
    {
        SetGameTask();
        currentConteiner.OnComplete += SetGameTask;
    }

    private void SetGameTask()
    {
        text.DOFade(1, 1);
        currentConteiner = level.GetComponentInChildren<TilesConteiner>();

        if (currentConteiner == null)
            text.DOFade(0, 1);
        else
            text.text = "Find  " + currentConteiner.Value;
        
            
    }

}
