using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public GameObject Optionsmenu;
    public GameObject mainmenu;

    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quitgame()
    {
        Debug.Log("existed the game");
        Application.Quit();
    }

    public void OpenOptions()
    {
        mainmenu.SetActive(false);
        Optionsmenu.SetActive(true);
    }
    public void backbutton()
    {
        Optionsmenu.SetActive(false);
        mainmenu.SetActive(true);
    }
}
