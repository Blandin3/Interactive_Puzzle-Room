using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    [Header("Puzzle Settings")]
    public int totalTasks = 5;
    public int completedTasks = 0;

    [Header("UI")]
    public TextMeshProUGUI progressText;
    public TextMeshProUGUI clueText;

    [Header("Room Lighting")]
    public Light roomLight;
    
    [Header("Clues")]
    public string[] clues = new string[]
    {
        "A lever awaits your touch to bring light",
        "Power lies hidden, seek the energy source",
        "Look for something that shines in the darkness...",
        "The floor holds secrets, tread carefully in order",
        "Ancient columns must face the same direction"
    };

    void Start()
    {
        UpdateProgress();
        UpdateRoomLight();
        UpdateClue();
    }

    public void TaskCompleted()
    {
        completedTasks++;
        UpdateProgress();
        UpdateRoomLight();
        UpdateClue();
    }

    void UpdateProgress()
    {
        if (progressText != null)
            progressText.text = "Puzzle Progress: " + completedTasks + " / " + totalTasks;
    }
    
    void UpdateClue()
    {
        if (clueText != null)
        {
            if (completedTasks < clues.Length)
                clueText.text = "Next Task: " + clues[completedTasks];
            else
                clueText.text = "All puzzles solved! Find the door!";
        }
    }

    void UpdateRoomLight()
    {
        if (roomLight != null)
        {
            float intensity = Mathf.Lerp(1f, 0.2f, (float)completedTasks / totalTasks);
            roomLight.intensity = intensity;
        }
    }
}


