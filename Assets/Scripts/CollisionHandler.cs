using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private const string Friendly = "Friendly";
    private const string Finish = "Finish";
    private const string Fuel = "Fuel";

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Hey! Look where you are going! I am " + Friendly + ".");
                break;
            case "Finish":
                Debug.Log("Congrats. You made it to " + Finish + ".");
                LoadNextScene();
                break;
            case "Fuel":
                Debug.Log("Got some " + Fuel + ".");
                break;
            default:
                Debug.Log("You died!");
                ReloadLevel();
                break;
        }
    }

    private static void LoadNextScene()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        var nextScene = currentScene + 1;
        
        if (nextScene >= SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        
        SceneManager.LoadScene(nextScene);
    }

    private void ReloadLevel()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
