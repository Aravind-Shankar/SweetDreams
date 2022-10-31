using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public PlayerManager playerManager;
    public InputManager inputManager;

    public bool cupEquipped = false;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    public void EquipCup()
    {
        cupEquipped = true;
        Debug.Log("Cup equipped");
    }

}
