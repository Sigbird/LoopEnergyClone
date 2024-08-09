using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages the main menu UI interactions.
/// </summary>
public class UIManagerMainMenu : MonoBehaviour
{
    [Tooltip("Button to start the game.")]
    [SerializeField] private Button _startButton;
    [Tooltip("Button to leave the game.")]
    [SerializeField] private Button _exitButton;
    [Tooltip("High score text element.")]
    [SerializeField] private TMP_Text _highScoreText;

    private void Start()
    {
        // Add button listeners
        _startButton.onClick.AddListener(OnStartButtonClicked);
        _exitButton.onClick.AddListener(OnExitButtonClicked);

        // Display the high score if it exists
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            _highScoreText.text = "High Score: 0";
        }
    }

    /// <summary>
    /// Called when the start button is clicked.
    /// </summary>
    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Gameplay");
    }

    /// <summary>
    /// Called when the exit button is clicked.
    /// </summary>
    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
}

