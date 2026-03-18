using UnityEngine;

public class ActiveDuringGameplay : MonoBehaviour
{
    public void OnGameActive()
    {
        this.enabled = true;
    }
    public void OnGameInActive()
    {
        this.enabled = false;
    }
}
