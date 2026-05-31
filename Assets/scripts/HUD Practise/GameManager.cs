using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text scoreText;

    private int score;
    private void Start()
    {
        healthSlider.value = 1;
        healthSlider.enabled = false;

        scoreText.text = "Score: " + score;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            SliderUpdate();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ScoreUpdate();
        }
    }
    public void SliderUpdate()
    {
        healthSlider.value = healthSlider.value - 0.1f;
    }

    public void ScoreUpdate()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
