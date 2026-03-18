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
        public void Hit()
        {
        if (health > 0)
            health -= 1;
            Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, (float)health);
            Debug.Log("Health: " + health);
            if (health == 0)
            {
                Debug.Break();
            }
        }
    }

