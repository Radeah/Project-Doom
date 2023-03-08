using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public float bobFrequency = 5f;
    public float bobAmplitude = 0.05f;
    public HeadBob headBob;


    public CharacterController controller;
    float timeOffset = 0f;

    void Start()
    {
        void Start()
        {
            controller = GetComponentInParent<CharacterController>();
            headBob.SetTimeOffset(controller.transform.localPosition.magnitude);

        }

    }

    private void Update()
    {
        // Calculate the new position for the camera
        float x = Mathf.Sin((Time.time + timeOffset) * bobFrequency) * bobAmplitude;
        float y = Mathf.Cos((Time.time + timeOffset) * bobFrequency * 2f) * bobAmplitude * 0.5f;
        Vector3 newPosition = controller.transform.localPosition + new Vector3(x, y, 0f);


        // Move the camera to the new position using a lerp function
        transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, Time.deltaTime * 10f);
    }

    public void SetTimeOffset(float offset)
    {
        // Use this method to synchronize the head bob effect across the network
        timeOffset = offset;
    }
}



