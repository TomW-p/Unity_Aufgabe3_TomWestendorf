using UnityEngine;
using UnityEngine.Rendering;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMainMenu;
    [SerializeField] private GameObject panelOptions;
    [SerializeField] private GameObject panelLevels;


    void Start()
    {
        OpenMainMenu();
    }
    public void PlayGame()
    {
        Application.LoadLevel(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        panelOptions.SetActive(true);
        panelMainMenu.SetActive(false);
        panelLevels.SetActive(false);
    }

    public void OpenMainMenu()
    {
        panelOptions.SetActive(false);
        panelMainMenu.SetActive(true);
        panelLevels.SetActive(false);
    }

    public void OpenLevels()
    {
        panelOptions.SetActive(false);
        panelMainMenu.SetActive(false);
        panelLevels.SetActive(true);
    }
}
