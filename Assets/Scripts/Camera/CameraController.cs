using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float translationSpeed = .5f;
    public AnimationCurve translationCurve;

    private Camera cam;
    private float targetPosition = -15f;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        targetPosition = transform.position.z;
    }

    private void Update()
    {
        float distance = transform.position.z - targetPosition;

        if (Mathf.Abs(distance) >= 0.05f)
        {
            float translation = translationCurve.Evaluate(1 / Mathf.Abs(distance)) * Time.deltaTime * translationSpeed;
            translation *= distance > 0 ? -1 : 1;
            cam.transform.position = new Vector3(0, 0, transform.position.z + translation);
        }
    }

    public void MoveCameraTo(float _targetPosition)
    {
        targetPosition = _targetPosition;
    }

}
