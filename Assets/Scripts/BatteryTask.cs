using UnityEngine;

public class BatteryTask : MonoBehaviour
{
    public PuzzleManager manager;
    public SwitchTask switchTask;

    public static int batteriesCollected = 0;
    public static int totalBatteries = 3;

    void OnTriggerEnter(Collider other)
    {
        // Only player can collect
        if (!other.CompareTag("Player"))
            return;

        // Lock batteries until power is on
        if (!switchTask.powerOn)
            return;

        batteriesCollected++;
        Debug.Log("Battery collected: " + batteriesCollected);

        Destroy(gameObject); // 💥 Battery disappears

        // When all batteries are collected
        if (batteriesCollected == totalBatteries)
        {
            manager.TaskCompleted();
        }
    }
}


