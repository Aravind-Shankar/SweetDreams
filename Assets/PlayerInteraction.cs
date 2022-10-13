using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public PlayerManager playerManager;
    public InputManager inputManager;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(inputManager.interactInputPressed);
    }
}
