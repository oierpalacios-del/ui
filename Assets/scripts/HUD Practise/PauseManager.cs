using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject HUDPanel;
    [SerializeField] private GameObject PausePanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        HUDPanel.SetActive(false);
        PausePanel.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        HUDPanel.SetActive(true);
        PausePanel.SetActive(false);
    }
}
