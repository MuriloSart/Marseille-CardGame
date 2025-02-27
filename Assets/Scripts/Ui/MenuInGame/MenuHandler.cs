using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject menu;

    private bool _isActived = false;

    private void Start()
    {
        menu.SetActive(_isActived);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) CloseOrOpen();
    }

    public void CloseOrOpen()
    {
        if (_isActived)
            _isActived = false;
        else
            _isActived = true;

        menu.SetActive(_isActived);
    }
}
