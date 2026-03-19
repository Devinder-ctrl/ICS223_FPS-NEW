using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
public class UIManager : MonoBehaviour {


    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private SettingsPopup settingsPopup;
    [SerializeField] private GameOverPopup gameOverPopup;
    private int popupsActive = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //healthBar.fillAmount = 1;
        //healthBar.color = Color.green;
        UpdateHealth(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsPopup.IsActive() && popupsActive == 0)
        {
           
            optionsPopup.Open();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && optionsPopup.IsActive())
        {

        }
    }
    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.AddListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, OnPopupClosed);

    }
    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.RemoveListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, OnPopupClosed);

    }
    private void UpdateHealth(float healthPercent)
    {
        Debug.Log("health is " + healthPercent);
        healthBar.fillAmount = healthPercent;

        if (healthPercent > 0.5) {
            healthBar.color = Color.Lerp(Color.yellow, Color.green, (healthPercent - 0.5f) * 2);
        }
        else
        {
            healthBar.color = Color.Lerp(Color.red, Color.yellow, (healthPercent * 2));
        }
    }
    private void OnHealthChanged(float healthPercent)
    {

       UpdateHealth(healthPercent);
    }
    private void OnPopupOpened()
    {
        if (popupsActive == 0)
        {
            SetGameActive(false);
            
        }
        popupsActive++;
    }
    private void OnPopupClosed()
    {
        popupsActive--;
        if (popupsActive == 0){
            SetGameActive(true);
        }
    }
    public void UpdateScore(int newScore)
    {
        score.text = "Score: " + newScore.ToString();
    }
    public void SetGameActive(bool active)
    {
        if (active)
        {
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            crossHair.gameObject.SetActive(true);
        }
        else
        {
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            crossHair.gameObject.SetActive(false);
        
    }
    }
    public void ShowGameOverPopup()
    {
        gameOverPopup.Open();
    }
    }

