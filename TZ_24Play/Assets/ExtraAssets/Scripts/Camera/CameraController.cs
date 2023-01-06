using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _followTarget;
    private Vector3 offset;
    private float _speed = 1f;

    private void Start()
    {
        offset = transform.position - _followTarget.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(0f, _followTarget.transform.position.y, _followTarget.transform.position.z) + offset, _speed * Time.deltaTime);
    }
}
