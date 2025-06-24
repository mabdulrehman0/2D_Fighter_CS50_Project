using UnityEngine;
using UnityEngine.SceneManagement;
public class WinUI : MonoBehaviour
{
    // referecing the winui and player 1 and player 2 ui section in unity
    public GameObject winui;
    public GameObject player1win;
    public GameObject player2win;

    // A function that shows who won according to the input, used character1 and 2 cs
    public void winplayer(int playerno)
    {
        winui.SetActive(true);
        if (playerno == 1)
        {
            player1win.SetActive(true);
        }
        else if (playerno == 2)
        {
            player2win.SetActive(true);
        }
    }
    // a button function to restart the game scene
    public void restartgame()
    {
        winui.SetActive(false);
        SceneManager.LoadScene("Scene demo");
    }
    // quits the game
    public void quit()
    {
        Application.Quit();
    }
    // sends the player to the main menu
    public void mainmenu()
    {
        winui.SetActive(false);
        SceneManager.LoadScene("UI menu");
    }
}
