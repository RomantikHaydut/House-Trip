using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;

    public GameObject pivot;

    public float RayDistance = 2f;
    private bool openedDoor = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CheckDoor()
    {
        if (!openedDoor)
        {
            RaycastHit hit;
            bool nearDoor = Physics.Raycast(transform.position, transform.forward, out hit, RayDistance, LayerMask.NameToLayer("Door"));

            if (nearDoor)
            {
                if (hit.transform != null)
                {
                    OpenDoora(hit.transform.gameObject);
                }
            }
        }
    }

    private void OpenDoora(GameObject door)
    {
        openedDoor = true;
        StartCoroutine(OpenDoor_Coroutine(door));

    }

    private IEnumerator OpenDoor_Coroutine(GameObject door)
    {
        float timer = 0;
        while (true)
        {
            timer += Time.deltaTime;
            print("Started");
            if (timer >= 1)
            {
                yield break;
            }
            yield return null;
            door.transform.RotateAround(pivot.transform.position, Vector3.up, 90f * Time.deltaTime);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!openedDoor)
        {
            if (collision.gameObject.tag == "Door")
            {
                OpenDoora(door);
            }
        }

    }
}
