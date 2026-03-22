using UnityEngine;
using UnityEngine.UI;
public class OptionsPopup : BasePopup
{
    [SerializeField] private SettingsPopup settingsPopup;
    
    public void OnSettingsButton()
    {
        Close();
        Debug.Log("settings clicked");
        settingsPopup.Open();
    }
    public void OnExitGameButton()
    {
        Debug.Log("exit game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        
        Debug.Log("return to game");
        Close();
    }
}
