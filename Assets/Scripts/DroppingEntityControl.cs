using UnityEngine;

public class DroppingEntityControl : MonoBehaviour
{
    private float _descentSpeed = 3f;
    private float _xSpawnRange = 2.5f;

    void Start()
    {
        float rndPosX = Random.Range(-_xSpawnRange, _xSpawnRange);
        transform.position = new Vector3(rndPosX, Camera.main.orthographicSize + 1, 0);
    }

    void Update()
    {
        transform.Translate(Vector3.down * _descentSpeed * Time.deltaTime);
        
        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(gameObject);
        }
    }
}