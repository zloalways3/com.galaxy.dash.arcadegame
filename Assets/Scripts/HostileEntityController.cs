using UnityEngine;

public class HostileEntityController: MonoBehaviour
{ 
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(AppGlobals.PLAYER_IDENTIFIER))
        {
            _audioSource.Play();
            GetComponent<Renderer>().enabled = false; 
            GetComponent<Collider2D>().enabled = false;
            MasterGameControl.singletonInstance.DeductLife(); 
            Destroy(gameObject, _audioSource.clip.length);
        }
    }
}