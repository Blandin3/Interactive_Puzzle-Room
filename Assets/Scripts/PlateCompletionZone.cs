using UnityEngine;

public class PlateCompletionZone : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    private bool taskCompleted = false;

    void OnTriggerExit(Collider other)
    {
        if (!taskCompleted && other.CompareTag("Player"))
        {
            taskCompleted = true;
            Debug.Log("Player left plate area - Task completed!");
            
            if (puzzleManager)
                puzzleManager.TaskCompleted();
        }
    }
}
