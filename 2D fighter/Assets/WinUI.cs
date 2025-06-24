using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinUI : MonoBehaviour
{
    public GameObject winui;
    public GameObject player1win;
    public GameObject player2win;

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
    public void restartgame()
    {
        winui.SetActive(false);
        SceneManager.LoadScene("Scene demo");
    }

    public void quit()
    {
        Application.Quit();
    }
    
    public void mainmenu()
    {
        winui.SetActive(false);
        SceneManager.LoadScene("UI menu");
    }
}
