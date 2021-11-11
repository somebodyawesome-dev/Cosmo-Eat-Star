using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameManager : MonoBehaviour
{
    public float force = 0.2f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager audioManager=FindObjectOfType<AudioManager>();
        if (!collision.collider.gameObject.GetComponent<TargetShip>().touchedSpaceship)
        {
            if (collision.collider.tag == "Bomb" && GetComponent<PlayerController>().isSpaceshipOpen)
            {

                Destroy(collision.collider.gameObject);

                FindObjectOfType<GameOver>().enabled = true;
            }
            else
            {
                if (collision.collider.tag == "Star" && !GetComponent<PlayerController>().isSpaceshipOpen)
                {
                    FindObjectOfType<GameOver>().enabled = true;

                }
                else
                {
                    if (collision.collider.tag == "Star" && GetComponent<PlayerController>().isSpaceshipOpen)
                    {
                        audioManager.play("CatchStar");
                        PlayerDataContainer.currScore++;
                        Destroy(collision.collider.gameObject);
                    }
                    else
                    {
                        audioManager.play("HitHatch");
                        TargetShip targership = collision.collider.gameObject.GetComponent<TargetShip>();
                        targership.touchedSpaceship = true;
                        int sign = (targership.isRight) ? -1 : 1;
                        targership.enabled = false;
                        collision.collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        collision.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(sign, 1) * force, ForceMode2D.Impulse);
                        collision.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
                        collision.collider.gameObject.GetComponent<DestroyTimer>().enabled = true;
                    }
                }
                
            }
           
            
            


        }
       
        
    }
}
