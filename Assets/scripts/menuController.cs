using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Controlador principal del menú UI.
/// Asigna todos los campos desde el Inspector en el GameObject UIManager.
/// </summary>
public class MenuController : MonoBehaviour
{
    // ─── Paneles ──────────────────────────────────────────────────────────────
    [Header("Paneles")]
    [Tooltip("Panel del menú principal (activo al inicio)")]
    [SerializeField] private GameObject mainMenuPanel;

    [Tooltip("Panel de opciones (desactivado al inicio)")]
    [SerializeField] private GameObject optionsPanel;

    // ─── Sonido ───────────────────────────────────────────────────────────────
    [Header("Sonido")]
    [Tooltip("AudioSource en este mismo GameObject")]
    [SerializeField] private AudioSource audioSource;

    [Tooltip("Sonido al pulsar cualquier botón de navegación")]
    [SerializeField] private AudioClip clickSound;

    [Tooltip("Sonido al volver al menú principal")]
    [SerializeField] private AudioClip backSound;

    // ─── Opciones ─────────────────────────────────────────────────────────────
    [Header("Opciones")]
    [Tooltip("Slider de volumen global")]
    [SerializeField] private Slider volumeSlider;

    [Tooltip("Etiqueta que muestra el porcentaje de volumen")]
    [SerializeField] private TMP_Text volumeLabel;

    [Tooltip("Toggle de pantalla completa")]
    [SerializeField] private Toggle fullscreenToggle;

    // ─────────────────────────────────────────────────────────────────────────

    void Start()
    {
        // Recuperar preferencias guardadas (o valores por defecto)
        float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        bool savedFullscreen = PlayerPrefs.GetInt("fullscreen", 1) == 1;

        // Aplicar volumen
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;
        UpdateVolumeLabel(savedVolume);

        // Aplicar pantalla completa
        if (fullscreenToggle != null)
            fullscreenToggle.isOn = savedFullscreen;

        Screen.fullScreen = savedFullscreen;

        // Suscribirse a cambios (alternativa a conectarlos desde el Inspector)
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        if (fullscreenToggle != null)
            fullscreenToggle.onValueChanged.AddListener(OnFullscreenChanged);
    }

    // ─── Navegación ──────────────────────────────────────────────────────────

    /// <summary>Conectar al botón "Opciones" → On Click ()</summary>
    public void OpenOptions()
    {
        PlaySound(clickSound);
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    /// <summary>Conectar al botón "Volver" → On Click ()</summary>
    public void BackToMain()
    {
        PlaySound(backSound);

        // Guardar preferencias al salir de Opciones
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        PlayerPrefs.SetInt("fullscreen", Screen.fullScreen ? 1 : 0);
        PlayerPrefs.Save();

        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    /// <summary>Conectar al botón "Jugar" → On Click ()</summary>
    public void PlayGame()
    {
        PlaySound(clickSound);
        // Cambia "GameScene" por el nombre real de tu escena de juego
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    /// <summary>Conectar al botón "Salir" → On Click ()</summary>
    public void QuitGame()
    {
        PlaySound(clickSound);
        Application.Quit();

        // Útil en el editor para probar el botón
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // ─── Eventos de los controles ─────────────────────────────────────────────

    /// <summary>
    /// Conectar al Slider → On Value Changed (Float) desde el Inspector,
    /// o se suscribe automáticamente en Start().
    /// </summary>
    public void OnVolumeChanged(float value)
    {
        AudioListener.volume = value;
        UpdateVolumeLabel(value);
    }

    /// <summary>Conectar al Toggle → On Value Changed (Boolean)</summary>
    public void OnFullscreenChanged(bool value)
    {
        Screen.fullScreen = value;
    }

    // ─── Helpers privados ────────────────────────────────────────────────────

    private void UpdateVolumeLabel(float value)
    {
        if (volumeLabel != null)
            volumeLabel.text = $"Volumen: {Mathf.RoundToInt(value * 100)}%";
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
            audioSource.PlayOneShot(clip);
    }
}