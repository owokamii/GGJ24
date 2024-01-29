using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator fadeAnimator;
    private int levelToLoad;

    public void LoadToNextLevel()
    {
        CalculateEnding.Poster = false;
        CalculateEnding.Poster2 = false;
        CalculateEnding.Manicure = false;
        CalculateEnding.BishoujoFigures = false;
        CalculateEnding.wigs = false;
        CalculateEnding.wigs2 = false;
        CalculateEnding.BedCleaning = false;
        CalculateEnding.Shoes = false;
        CalculateEnding.PlantsDrop = false;
        CalculateEnding.Water = false;
        CalculateEnding.dirt = false;
        CalculateEnding.Laundry = false;
        CalculateEnding.MaggiCups = false;
        CalculateEnding.Snacks = false;
        CalculateEnding.Socks = false;
        CalculateEnding.MakeUp = false;
        CalculateEnding.DirtyDish = false;
        CalculateEnding.Fridge = false;
        CalculateEnding.StudyTable = false;
        LoadToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        fadeAnimator.SetTrigger("Start");
    }

    public void OnLoadComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    /*public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }*/
}