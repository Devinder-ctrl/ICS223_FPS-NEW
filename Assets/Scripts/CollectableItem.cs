using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    private int value = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,180 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "Player")
        {
            Messenger<int>.Broadcast(GameEvent.PICKUP_HEALTH, value);
            Destroy(this.gameObject);
        }
    }
}
