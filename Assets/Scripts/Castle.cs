using UnityEngine;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    public LayerMask playerMask;
    public string winSceneName = "Win";

    private void Update()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, playerMask);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(winSceneName);
        }
    }
}
