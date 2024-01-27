using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _movingSpeed;

    private void Awake()
    {
        transform.position = CheckPosition();
    }

    private void Update()
    {
        Vector3 target = CheckPosition();

        Vector3 pos = Vector3.Lerp(transform.position, target, _movingSpeed * Time.deltaTime);

        transform.position = pos;
    }

    private Vector3 CheckPosition()
    {
        Vector3 position = new Vector3()
        {
            x = _player.position.x,
            y = _player.position.y,
            z = _player.position.z - 10,
        };

        return position;
    }
}
