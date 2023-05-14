using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    public GameObject objectToRemove; // Reference to the game object to remove

    private int collisionCount = 0; // Number of collisions

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == objectToRemove)
        {
            Destroy(objectToRemove);
            collisionCount++;
        }
    }
}
