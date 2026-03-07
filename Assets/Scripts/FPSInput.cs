using UnityEngine;


public class FPSInput : MonoBehaviour
{
    private float gravity = -9.8f;
    private float speed = 9.0f;
    [SerializeField] private CharacterController charController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horiInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horiInput, 0, vertInput);

        //Clamp  the magnitude to a limit diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        //take speed
        movement *= speed;

        //for pushing player to ground
        movement.y = gravity;
        //make movement processor indepenedent - so its not uneven
        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
