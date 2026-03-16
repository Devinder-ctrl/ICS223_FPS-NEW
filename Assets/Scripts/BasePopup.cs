using UnityEngine;

public class BasePopup : MonoBehaviour
{
    virtual public void Open()
    {
        gameObject.SetActive(true);
    }
    virtual public void Close()
    {
        gameObject.SetActive(false);

    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
