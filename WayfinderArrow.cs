using System.Runtime.CompilerServices;
using UnityEngine;

public class WayfinderArrow : MonoBehaviour

{
    public Transform player;
    public Transform keyTarget;// Target 1 , default 
    public Transform mansionTarget; // Target 2 , after finding key 


    private Transform currentTarget; //pointing to the current target
    private bool hasKey = false;
    private bool isVisible = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTarget = keyTarget;// defualt target
        
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform; // Find player by tag
        }
        // get players current postion and add 2 of y to make sure its infront of the player 



    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || currentTarget == null) return;
        //postion arrow infront of player 
        transform.position = new Vector3(player.position.x, player.position.y + 2f, player.position.z + 1.5f);


        // Point arrow toward target
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }

        // TAB toggle
        // ON <-> OFF
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isVisible = !isVisible; // Flip state
            //gameObject.SetActive(isVisible);
            GetComponentInChildren<Renderer>().enabled = isVisible;
            Debug.Log("Arrow visibility toggled: " + isVisible);
        }

        //Change Target when the player collects the key from key code 

        if (hasKey && currentTarget == keyTarget)
        {
            currentTarget = mansionTarget; // Switch to mansion target
            Debug.Log("Key picked up! Now heading to the mansion.");
        }

        // calls OnKeyPickedUp when the player collides with the key

        if (hasKey && currentTarget == mansionTarget)
        {
            // Here you can add logic to check if the player has reached the mansion target
            // For example, you can check distance or trigger an event
            // For now, we will just log a message
            float distanceToMansion = Vector3.Distance(player.position, mansionTarget.position);
            if (distanceToMansion < 3f)
            {
                Debug.Log("Player has reached the mansion with the key!");
            }
        }

    }
    public void OnKeyPickedUp()/// called in key code 
    {
        hasKey = true;
        currentTarget = mansionTarget;
    }
}

