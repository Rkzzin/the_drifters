using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void StartGame()
    {
        GameController.Init();
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
