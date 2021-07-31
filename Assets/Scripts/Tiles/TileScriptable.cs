using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New tiles data", menuName = "Tiles data", order = 10)]
public class TileScriptable : ScriptableObject
{
    [SerializeField]
    private List<Sprite> tilesData;

    public List<Sprite> TilesData => tilesData;

    [SerializeField]
    private List<string> valueOfTask;

    public List<string> ValueOfTask => valueOfTask;
}
