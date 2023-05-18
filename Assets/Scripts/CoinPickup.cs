using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1;

    private bool isPickedUp = false;
    [SerializeField]private ScoreManager scoreManager;

    private void Start(){
        scoreManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        if (!isPickedUp)
        {
            CheckPlayerCollision();
        }
    }

    private void CheckPlayerCollision()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("Player"));

        if (playerCollider != null)
        {
            isPickedUp = true;
            scoreManager.AddCoin(100);
            Destroy(gameObject);
        }
    }
}
