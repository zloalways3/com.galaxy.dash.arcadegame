using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _soundSource;
    
    private void Awake()
    {
        _soundSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(AppGlobals.PLAYER_IDENTIFIER))
        {
            _soundSource.Play();
            PointsTracker pointsController = collision.GetComponent<PointsTracker>();
            if (pointsController != null)
            {
                pointsController.IncreaseScore(1);
                GetComponent<Renderer>().enabled = false; 
                GetComponent<Collider2D>().enabled = false;
                Destroy(gameObject, _soundSource.clip.length);
            }
        }
    }
}