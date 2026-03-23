using UnityEngine;

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
                break;
            case "Fuel":
                Debug.Log("Got some " + Fuel + ".");
                break;
            default:
                Debug.Log("You died!");
                break;
        }
    }
}
