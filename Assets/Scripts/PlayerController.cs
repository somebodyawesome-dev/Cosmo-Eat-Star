using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Sprite openedSpaceShip;
    [SerializeField] Sprite closedSpaceShip;
    [SerializeField] public bool isSpaceshipOpen;
    private void Start()
    {
        isSpaceshipOpen = false;
    }
    void Update()
    {
        switchSprite();
    }
    public void switchSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (isSpaceshipOpen)
        {
            spriteRenderer.sprite = openedSpaceShip;
        }
        else
        {
            spriteRenderer.sprite = closedSpaceShip;
        }
    }

    public void setSpaceShipStat(bool value)
    {
        isSpaceshipOpen = value;
    }

}
