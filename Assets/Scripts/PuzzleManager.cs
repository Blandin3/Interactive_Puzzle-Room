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
        "Something nearby still remembers how to wake the darkness",
        "Scattered energy must be reclaimed before light can endure",
        "With power restored, something begins to shine above",
        "The floor remembers every step—not all paths forgive mistakes",
        "Only harmony opens the way; let all face the same truth"
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


