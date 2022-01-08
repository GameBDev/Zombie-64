using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;
    public GameObject warning;
    public GameObject mapSelect;

    private void Start()
    {
        menu.SetActive(false);
        credits.SetActive(false);
        mapSelect.SetActive(false);
        warning.SetActive(true);
    }
    public void EndWarning()
    {
        menu.SetActive(true);
        credits.SetActive(false);
        mapSelect.SetActive(false);
        warning.SetActive(false);
    }
    public void StartGame()
    {
        menu.SetActive(false);
        credits.SetActive(false);
        mapSelect.SetActive(true);
        warning.SetActive(false);
    }
    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
        mapSelect.SetActive(false);
        warning.SetActive(false);
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
    public void Secret()
    {
        SceneManager.LoadScene("Easter Egg");
    }
}
