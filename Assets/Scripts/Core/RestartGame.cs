using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private Button button;
    void Start()
    {
        button.onClick.AddListener(RestartScene);
    }

    private void RestartScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
