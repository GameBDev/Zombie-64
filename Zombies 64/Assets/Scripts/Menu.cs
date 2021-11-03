using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MapSelect");
    }
    public void EndWarning()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("We Quit");
    }
    public void BackToMenu()
    {

        SceneManager.LoadScene("Main Menu");
    }
    public void Map1()
    {
        SceneManager.LoadScene("Map");
    }
    public void TestMsp()
    {
        SceneManager.LoadScene("Map 1");
    }
    public void Map2()
    {
        SceneManager.LoadScene("Map 2");
    }
}
