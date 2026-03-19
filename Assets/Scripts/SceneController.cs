using UnityEngine;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private UIManager manager;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject iguanaPrefab;
    [SerializeField] private Transform iguanaSpawnPt;
    [SerializeField] Slider difficultySlider;
    private GameObject enemy;
    private GameObject iguana;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);

    private int numberOfEnemies = 5;
    private int numberOfIguana = 7;
    public GameObject[] enemyInstantces;
    public GameObject[] iguanaInstantces;

 
    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.AddListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
        Messenger.AddListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
        Messenger.AddListener(GameEvent.RESTART_GAME, OnRestartGame);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.RemoveListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
        Messenger.RemoveListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
        Messenger.RemoveListener(GameEvent.RESTART_GAME, OnRestartGame);

    }
    private void OnPlayerDead()
    {
        manager.ShowGameOverPopup();
    }
    private void OnEnemyDead()
    {
        score++;
        manager.UpdateScore(score);
    }
    private void Start()
    {
        manager.UpdateScore(score);
            //instantiate array
            enemyInstantces = new GameObject[numberOfEnemies];
            iguanaInstantces = new GameObject[numberOfIguana];
            spawn();
            spawniguana();
            manager.UpdateScore(score);

    }
    private void Update()
    {
        for (int i = 0; i < enemyInstantces.Length; i++)
        {
            if (enemyInstantces[i] == null)
            {
                //it returns an type object like upcast and then we downcast it to original type which is done by 'as GameObject'
                enemy = Instantiate(enemyPrefab) as GameObject;
                //place the enemy in the scene
                enemy.transform.position = spawnPoint;
                //choose random angle 
                float angle = Random.Range(0, 360);
                //rotate the enemy to that angle
                enemy.transform.Rotate(0, angle, 0);


                enemyInstantces[i] = enemy;
               
                WanderingAI ai = enemyInstantces[i].GetComponent<WanderingAI>();
                ai.SetDifficulty((int)difficultySlider.value);
                
            }
        }
    }

    // Update is called once per frame
    void spawniguana()
    {
        for (int i = 0; i < numberOfIguana; i++)
        {
            iguana = Instantiate(iguanaPrefab) as GameObject;
            iguana.transform.position = iguanaSpawnPt.position;
            //choose random angle 
            float angle = Random.Range(0, 360);
            //rotate the enemy to that angle
            iguana.transform.Rotate(0, angle, 0);


            iguanaInstantces[i] = iguana;
        }
        }
    void spawn()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {

       
                    //used instantiate method to clone our prefab and create an object from it
                    //it returns an type object like upcast and then we downcast it to original type which is done by 'as GameObject'
                    enemy = Instantiate(enemyPrefab) as GameObject;
                    //place the enemy in the scene
                    enemy.transform.position = spawnPoint;
                    //choose random angle 
                    float angle = Random.Range(0, 360);
                    //rotate the enemy to that angle
                    enemy.transform.Rotate(0, angle, 0);

                   
                        enemyInstantces[i] = enemy;
                    }
    
    }
    private void OnDifficultyChanged(int newDifficulty)
    {
        Debug.Log("Scene.OnDifficultyChanged(" + newDifficulty + ")");
        for (int i = 0; i < enemyInstantces.Length; i++)
        {
            WanderingAI ai = enemyInstantces[i].GetComponent<WanderingAI>();
            ai.SetDifficulty(newDifficulty);
        }
    }
   public int GetDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty", 1);
    }
    public void OnRestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
