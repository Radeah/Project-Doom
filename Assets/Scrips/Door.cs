using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public bool inReach;
    public AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    void Update()

    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            DoorOpens();
        }
        else
        {
            DoorClose();
        }
    }
    void DoorOpens ()
    {
        Debug.Log("It Openes");
        door.SetBool("open", true);
        door.SetBool("closed", false);
        doorSound.Play();
    }
    
    void DoorClose ()
    {
        Debug.Log("It Closes");
        door.SetBool("open", false);
        door.SetBool("closed", true);
    }
    
    
    
    
    
    
    
    
    
    
    
    
}


