using UnityEngine;

public class UIManagerT1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UIPlayGame()
    {
        // Cambia "GameScene" por el nombre real de tu escena de juego
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}