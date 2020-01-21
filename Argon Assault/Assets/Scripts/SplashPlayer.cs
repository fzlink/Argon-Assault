using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashPlayer : MonoBehaviour
{
    [SerializeField] private float gameLoadDelay = 3f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

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
