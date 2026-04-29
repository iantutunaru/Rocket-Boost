using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private float delayUntilNextLevel = 2f;
    
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
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Got some " + Fuel + ".");
                break;
            default:
                Debug.Log("You died!");
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        movement.enabled = false;
        Invoke(nameof(LoadNextScene), delayUntilNextLevel);
    }

    private void StartCrashSequence()
    {
        movement.enabled = false;
        Invoke(nameof(ReloadLevel), delayUntilNextLevel);
    }

    private void LoadNextScene()
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
