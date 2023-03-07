using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public bool PlayerIsClose;
    public GameObject door;
    public GameObject prompt;
    private bool hasPlayed = false;

    void Update()
    {
        if (PlayerIsClose && !hasPlayed)
        {
            prompt.SetActive(true);
        }
        else
        {
            prompt.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && PlayerIsClose && !hasPlayed)
        {
            hasPlayed = true;
            door.transform.Rotate(0f, 90f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsClose = false;
        }
    }
}





