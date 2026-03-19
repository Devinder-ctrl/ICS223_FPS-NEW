using UnityEngine;


    public class PlayerCharacter : MonoBehaviour
    {
    [SerializeField] private UIManager UI;
    private int health;
    private int maxHealth = 5;
        // Use this for initialization
        void Start()
        {
            health = maxHealth;
        }
    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.PICKUP_HEALTH, this.OnPickupHealth);
    }
    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.PICKUP_HEALTH, this.OnPickupHealth);
    }
    public void OnPickupHealth(int healthAdded)
    {
        health += healthAdded;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        float healthPercent = ((float)health) / maxHealth;
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercent);
    }
    public void Hit()
        {
        if (health > 0)
            health -= 1;
            Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, (float)health);
            Debug.Log("Health: " + health);
            if (health == 0)
            {
            //Debug.Break();
            Messenger.Broadcast(GameEvent.PLAYER_DEAD);
            }
        }
    }

