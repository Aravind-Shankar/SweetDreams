using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSubmitter : MonoBehaviour
{
    //public GameObject cupPrefab;
    private Inventory inventory;
    public ItemType itemSubmissionType;

    private CustomerQueue customerQueue;

    private AudioSource audioSource;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        customerQueue = FindObjectOfType<CustomerQueue>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SubmitOrder()
    {
        if (customerQueue.TryCompleteOrder())
        {
            inventory.RemoveItem();
            audioSource.Play();
        }
    }
}
