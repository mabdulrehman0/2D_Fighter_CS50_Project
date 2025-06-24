using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    // for referencing the option menu and main meun of the UI 
    public GameObject Optionsmenu;
    public GameObject mainmenu;

    // loading the game scene when player presses play
    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // quits the game when players presses the quit button
    public void quitgame()
    {
        Debug.Log("existed the game");
        Application.Quit();
    }

    // the function which enables the option menu and disables the main menu when option button is clicked
    public void OpenOptions()
    {
        mainmenu.SetActive(false);
        Optionsmenu.SetActive(true);
    }

    // back button function when players want to go back to main menu.
    public void backbutton()
    {
        Optionsmenu.SetActive(false);
        mainmenu.SetActive(true);
    }
}
