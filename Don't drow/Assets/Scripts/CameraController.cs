using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float upLimit;

    private void Awake()
    {
        gameObject.transform.position = MoveCamera();
    }
    private Vector3 MoveCamera()
    {
        return new Vector3(
            Mathf.Clamp(player.position.x, leftLimit, rightLimit),
            Mathf.Clamp(player.position.y, bottomLimit, upLimit),
            player.position.z - 10
            );
    }
    private void FixedUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, MoveCamera(), speed * Time.deltaTime);
    }
}
