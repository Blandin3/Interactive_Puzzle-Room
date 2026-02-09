using UnityEngine;

public class DebugTaskCompleter : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    
    void Update()
    {
        // Press 4 to complete task 4 (plates)
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Manually completing Task 4 (Plates)");
            if (puzzleManager)
                puzzleManager.TaskCompleted();
        }
        
        // Press 5 to complete task 5 (pillars)
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("Manually completing Task 5 (Pillars)");
            if (puzzleManager)
                puzzleManager.TaskCompleted();
        }
    }
}
