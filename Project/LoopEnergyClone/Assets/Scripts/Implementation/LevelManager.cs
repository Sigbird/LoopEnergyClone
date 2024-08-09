using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Node[] nodes;
    private bool _completed = false;
    public int _atualLevel;

    public GameObject continueButton;
    public GameObject particle;
    public TMP_Text textLevel;
    //public LineRenderer[] lines;

    private void Start()
    {
        //_atualLevel = ProgressManager.Instance.LoadProgress();
        textLevel.text = $"Level: {_atualLevel}";

    }

    private void Update()
    {
        if (AreAllNodesConnected())
        {
            OnLevelComplete();
        }
    }

    private bool AreAllNodesConnected()
    {
        bool allConnected = true;

        foreach (Node node in nodes)
        {
            if (!node.isConnected)
            {
                allConnected = false;
            }
        }

        if (allConnected)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private void OnLevelComplete()
    {
        // Illuminate lines or provide visual feedback
        /* foreach (LineRenderer line in lines)
         {
             line.startColor = Color.yellow;
             line.endColor = Color.yellow;
         }*/
        if (!_completed)
        {
            StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(1f, 0.2f));
            _completed = true;
            Debug.Log("Level Completed!");

            if (ProgressManager.Instance.LoadProgress() <= _atualLevel)
                ProgressManager.Instance.SaveProgress(_atualLevel + 1);

            continueButton.SetActive(true);

        }

        particle.SetActive(true);
        // Trigger particle effects or animations
        // Example: Play a particle system
        // ParticleSystem completeEffect = Instantiate(completeEffectPrefab, position, Quaternion.identity);
        // completeEffect.Play();
    }

    public void OnContinueClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
