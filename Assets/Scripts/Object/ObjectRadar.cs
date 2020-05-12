using System;
using UnityEngine;

public class ObjectRadar : MonoBehaviour
{
    [Serializable]
    public struct WarningDistanceColor
    {
        public float distance;
        public Color color;
    }

    [SerializeField] private GameObject radarIconPrefab = null;
    [SerializeField] private float radarIconDistanceFromBound = 2f;
    [SerializeField] private WarningDistanceColor[] warningDistanceColor = { };

    private Vector3 _screenBounds;
    private GameObject _radarIconInstance;
    private bool _isInsideBounds = false;
    private SpriteRenderer _radarIconSprite;

    public GameObject RadarIconInstance => _radarIconInstance;

    private void Start()
    {
        _screenBounds = GetScreenBoundary();
        _radarIconInstance = Instantiate(radarIconPrefab, transform.position, Quaternion.identity);
        _radarIconSprite = _radarIconInstance.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isInsideBounds)
        {
            Destroy(_radarIconInstance);
            this.enabled = false;
            return;
        }

        UpdateRadarIconPosition(ref _radarIconInstance, _screenBounds);

        float distanceFromBound = Vector3.Distance(_radarIconInstance.transform.position, this.transform.position) - radarIconDistanceFromBound;
        UpdateRadarIconSprite(ref _radarIconSprite, distanceFromBound);

        _isInsideBounds = CheckIfInsideBounds(this.gameObject, _screenBounds);
    }

    private void UpdateRadarIconPosition(ref GameObject radarIconPrefab, Vector3 screenBounds)
    {
        Vector3 newIconPosition = Vector3.zero;
        newIconPosition.x = Mathf.Clamp(this.transform.position.x, screenBounds.x + radarIconDistanceFromBound, (screenBounds.x * -1) - radarIconDistanceFromBound);
        newIconPosition.y = Mathf.Clamp(this.transform.position.y, screenBounds.y + radarIconDistanceFromBound, (screenBounds.y * -1) - radarIconDistanceFromBound);

        radarIconPrefab.transform.position = newIconPosition;
    }

    private void UpdateRadarIconSprite(ref SpriteRenderer radarIconSprite, float distanceFromBound)
    {
        foreach (var _warningDistanceColor in warningDistanceColor)
        {
            if (distanceFromBound < _warningDistanceColor.distance)
            {
                radarIconSprite.color = _warningDistanceColor.color;
                return;
            }
        }
    }

    private bool CheckIfInsideBounds(GameObject _object, Vector3 screenBounds)
    {
        Vector3 _objectPosition = _object.transform.position;
        return _objectPosition.y > screenBounds.y && _objectPosition.y < screenBounds.y * -1 && _objectPosition.x > screenBounds.x && _objectPosition.x < screenBounds.x * -1;
    }

    private Vector3 GetScreenBoundary()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

}
