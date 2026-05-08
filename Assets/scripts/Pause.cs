using TMPro;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject hud;
    [SerializeField] private TMP_Text vida;
    [SerializeField] private TMP_Text puntos;
    bool paused;
    private void Awake()
    {
        pauseMenu.SetActive(false);
        hud.SetActive(true);
        paused = false;
        vida.text = "3 / 3";
        puntos.text = "0 XP";
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            paused = false;
            hud.SetActive(true);
            pauseMenu.SetActive(false);
        }else if(Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            paused = true;
            hud.SetActive(false);
            pauseMenu.SetActive(true);
        }
    }
    public void ExitToMenu()
    {
        // Cambia "GameScene" por el nombre real de tu escena de juego
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public void UnPause()
    {
        paused = false;
        hud.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
