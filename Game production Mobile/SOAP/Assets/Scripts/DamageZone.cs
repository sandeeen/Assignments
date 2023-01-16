using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageZone : MonoBehaviour
{
    bool isAlive;
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI livesText;
    

    private void Start()
    {
        livesText.text = "LIVES : III";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") == true)
        {
            other.gameObject.GetComponent<Health>().RemoveScoreAddedWhenKilled();
            Destroy(other.gameObject);
            player.GetComponent<Health>().RemoveHP(1);
            livesText.text = livesText.text.Substring(0, livesText.text.Length - 1);
        }
    }

}
