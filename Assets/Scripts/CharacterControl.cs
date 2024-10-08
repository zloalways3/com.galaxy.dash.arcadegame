using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private float _interpolationFactor = 0.1f;
    private Vector3 _touchCoords;
    private bool _isSwipeDragging = false;
    
    private Camera _primaryCamera;
    
    private void Start()
    {
        _primaryCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isSwipeDragging = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isSwipeDragging = false;
        }

        if (_isSwipeDragging)
        {
            _touchCoords = _primaryCamera.ScreenToWorldPoint(Input.mousePosition);
            _touchCoords.z = 0;
            
            var boundedPosition = _touchCoords;
            boundedPosition.x = Mathf.Clamp(boundedPosition.x, -_primaryCamera.orthographicSize * _primaryCamera.aspect, _primaryCamera.orthographicSize * _primaryCamera.aspect);
            boundedPosition.y = Mathf.Clamp(boundedPosition.y, -_primaryCamera.orthographicSize, _primaryCamera.orthographicSize);
            
            transform.position = Vector3.Lerp(transform.position, boundedPosition, _interpolationFactor);
        }
    }
}