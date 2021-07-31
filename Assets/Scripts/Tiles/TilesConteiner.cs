using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using System.Linq;

public class TilesConteiner : MonoBehaviour
{
    [SerializeField]
    private List<TileScriptable> tileScriptables;

    private int currentIndex;

    public int CurrentIndex => currentIndex;

    [SerializeField]
    private List<Image> images;

    private int currentSpritesData;

    public int CurrentSpritesData => currentSpritesData;

    [SerializeField]
    private int countOfGameObjects;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private GameObject restartButton;

    [SerializeField]
    private float gridOffset;

    private string value;

    public string Value => value;

    List<string> values = new List<string>();

    public event System.Action OnComplete;

    private void OnEnable()
    {
        OnComplete += OncompleteTask;
    }
    private void OnDisable()
    {
        OnComplete -= OncompleteTask;
    }

    private void Awake()
    {
        CreateGameArea();
        InitSprite();
    }

    public void InitSprite()
    {
        var randomScriptable = Random.Range(0, tileScriptables.Count);

        var currentScriptable = tileScriptables[randomScriptable].TilesData;

        var currentTaskValue = tileScriptables[randomScriptable].ValueOfTask;

        for (int i = 0; i < images.Count; i++)
        {
            
            var randomIndex = Random.Range(0, currentScriptable.Count);

            values.Add(currentTaskValue[randomIndex]);

            images[i].sprite = currentScriptable[randomIndex];
            images[i].SetNativeSize();

            var scale = images[i].transform.localScale / 3;

            images[i].transform.localScale = scale;
            images[i].GetComponent<Tile>().TaskValue = currentTaskValue[randomIndex];
        }

        int index = Random.Range(0, values.Count);
        value = values[index];
    }

    public void CreateGameArea()
    {
        for (int i = 0; i < countOfGameObjects; i++)
        {
            var image = Instantiate(prefab, transform);
            images.Add(image.GetComponent<Image>()); 
        }
    }

    void OncompleteTask()
    {
        foreach (var item in images)
        {
            Destroy(item.gameObject);
        }
        images.Clear();

        countOfGameObjects += 3;

        if (countOfGameObjects > 9)
        {
            restartButton.SetActive(true);
            gameObject.SetActive(false);
        }
            

        values.Clear();
        CreateGameArea();
        InitSprite();
    }

    public void InvokeOnComplete()
    {
        OnComplete?.Invoke();
    }

}
