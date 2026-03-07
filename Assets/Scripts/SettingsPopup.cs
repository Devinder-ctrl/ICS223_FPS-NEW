using System.Reflection.Emit;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
public class SettingsPopup : MonoBehaviour
{
    [SerializeField] Button OKButton;
    [SerializeField] Button CancelButton;
    [SerializeField] Slider difficultySlider;
    [SerializeField] OptionsPopup optionsPopup;

    [SerializeField] TextMeshProUGUI difficultyLabel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

        public void OnOKButton()
    {
        gameObject.SetActive(false);
        optionsPopup.Open();
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
    }
    public void OnCancelButton()
    {
        gameObject.SetActive(false);
        optionsPopup.Open();

    }
    public void UpdateDifficulty(float difficulty)
    {
        difficultyLabel.text = "Difficulty: " + ((int) difficulty).ToString();
    }
    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }
    public void Open()
    { 

        //If the player changes the slider, and then hits cancel, we will need to reset the slider to its
        //current difficulty setting when we next open the panel.
        gameObject.SetActive(true);
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
