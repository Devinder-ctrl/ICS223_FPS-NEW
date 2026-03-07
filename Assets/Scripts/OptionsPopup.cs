using UnityEngine;
using UnityEngine.UI;
public class OptionsPopup : MonoBehaviour
{
    [SerializeField] private UIManager manager;
    [SerializeField] private SettingsPopup settingsPopup;
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
      
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
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
        manager.SetGameActive(true);
        Close();
    }
}
