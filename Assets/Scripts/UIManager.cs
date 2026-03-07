using UnityEngine.UI;
using TMPro;
using UnityEngine;
public class UIManager: MonoBehaviour {

   
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private SettingsPopup settingsPopup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.fillAmount = 1;
        healthBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsPopup.IsActive())
        {
            SetGameActive(false);
            optionsPopup.Open();
        }
        else if (Input.GetKeyDown(KeyCode.Escape)  && optionsPopup.IsActive())
        {

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
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            crossHair.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            crossHair.gameObject.SetActive(false);
        
    }
    }
}
