using UnityEngine;

//declare enumeration to allow us to define a new custom variable type 
//it will be used in multiple classes so it is safe to use it outside a class declaration
public enum EnemyStates { alive, dead};

public class WanderingAI : MonoBehaviour
{
    private float enemySpeed = 1.75f;
    private float obstacleRange = 5.0f; //react to obstacles by turning away within that distance
    private float sphereRadius = 0.75f;
    public EnemyStates state;

    [SerializeField] private GameObject laserbeamPrefab;
    private GameObject laserbeam;
    public float fireRate = 2.0f;
    private float nextFire = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = EnemyStates.alive;

    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyStates.alive)
        {
            //move enemy 
            Vector3 movement = Vector3.forward * enemySpeed * Time.deltaTime; //move wnwmy forword along the z-axis, make movement frame rate independent
            transform.Translate(movement);

            //generate ray
            Ray ray = new Ray(transform.position, transform.forward); //cast array from origin of enemy into the forword direction towards the enemy


            // Spherecast and determine if Enemy needs to turn
            RaycastHit hit; //declare a raycasthit struct

            //RaycastHit hit;
            //if (Physics.SphereCast(ray, sphereRadius, out hit))
            //{
            //    if (hit.distance < obstacleRange)
            //    {
            //        float turnAngle = Random.Range(-110, 110);
            //        transform.Rotate(Vector3.up * turnAngle);
            //    }
            //}

            // sphere is cast along the array with radius of the sphere and out is taken as pass by reference to the hit
            if (Physics.SphereCast(ray, sphereRadius, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    // Spherecast hit Player, fire laser!
                    if (laserbeam == null && Time.time > nextFire)
                    {
                        nextFire = Time.time + fireRate;
                        laserbeam = Instantiate(laserbeamPrefab) as GameObject;
                        laserbeam.transform.position = transform.TransformPoint(0, 1.5f, 1.5f);
                        laserbeam.transform.rotation = transform.rotation;
                    }
                }
                //next check if anything is hit
                else if (hit.distance < obstacleRange)
                {
                    //then rotate the enemy on random angle upwords
                    float turnAngle = Random.Range(-110, 110);
                    transform.Rotate(0, turnAngle,0);
                 
                }
            }
        }
    }
    //draw our own gizmos
    //this will help in visualizing the ray and sphereCast taking place on the enemy

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //determine the range vector (starting at the enemy)
        Vector3 rangeTest = transform.position + transform.forward * obstacleRange;

        //draw a line to show the range vector
        Debug.DrawLine(transform.position, rangeTest);
        //draw a wire sphere at the point on the end of the range vector
        Gizmos.DrawWireSphere(rangeTest, sphereRadius);

    }

    //Change state method
    public void ChangeState(EnemyStates state)
    {
        this.state = state;
    }
  
}
