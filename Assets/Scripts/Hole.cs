using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    public LayerMask playerMask;
    public string looseSceneName = "GameOver";

    private void Update()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.up;
        float distance = 1f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, playerMask);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(looseSceneName);
        }
    }
}
