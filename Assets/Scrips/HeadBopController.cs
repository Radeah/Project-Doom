using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBopController : MonoBehaviour
{

    [SerializeField] bool enable = true;

    [SerializeField, Range(0, 0.1f)] float amplitude = 0.015f;
    [SerializeField, Range(0, 30f)] float frequency = 10.0f;

    [SerializeField] Transform camera = null;
    [SerializeField] Transform cameraHolder = null;

    float toggleSpeed = 3.0f;
    Vector3 startPos;
    CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        startPos = camera.localPosition;
    }

    void PlayerMotion(Vector3 motion)
    {
        camera.localPosition += motion;
    }

    void CheckMotion()
    {
        float speed = new Vector3( controller.velocity.x, 0, controller.velocity.z).magnitude;
        if (speed < toggleSpeed) return;
        if (!controller.isGrounded) return;
        PlayerMotion(FootStepMotion());
    }


    Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency / 2 * amplitude * 2);
        return pos;
    }

    void ResetPosition()
    {
     if (camera.localPosition == startPos) return;
     camera.localPosition = Vector3.Lerp(camera.localPosition, startPos, 0 * Time.deltaTime);
        
    }


    Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.y + cameraHolder.localPosition.y, transform.position.z);
        pos += cameraHolder.forward * 15.0f;
        return pos;

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!enabled) return;

        CheckMotion();
        ResetPosition();
        camera.LookAt(FocusTarget());

    }
}
