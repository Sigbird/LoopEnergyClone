using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    private Button _button;
    public GameObject inDevelopmentMessage;

    private void Start()
    {
        int progress = ProgressManager.Instance.LoadProgress();
        _button = GetComponent<Button>();

        Debug.Log("LEVEL: " + progress);

        if (levelIndex <= progress)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }

    public void OnClick()
    {
        // Load the corresponding level
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level" + levelIndex);
    }

    public void OnDevelopment()
    {
        // Load the corresponding level
        inDevelopmentMessage.SetActive(true);
    }
}
