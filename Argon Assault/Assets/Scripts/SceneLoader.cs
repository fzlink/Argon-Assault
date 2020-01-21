using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float gameLoadDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadGame", gameLoadDelay);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
