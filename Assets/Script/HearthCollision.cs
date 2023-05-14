using UnityEngine;

public class HeartsController : MonoBehaviour
{
    public GameObject[] hearts; // Array of heart GameObjects

    private int heartCount; // Total number of hearts

    private void Start()
    {
        heartCount = hearts.Length;
    }

    public int GetHeartCount()
    {
        return heartCount;
    }

    public void RemoveHeart(int index)
    {
        if (index >= 0 && index < heartCount)
        {
            GameObject heart = hearts[index];
            heart.SetActive(false);
        }
    }
}
