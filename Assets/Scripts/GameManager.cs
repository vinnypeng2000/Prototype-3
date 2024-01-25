using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Slider healthBar;
    // public Slider staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.gameObject.GetComponent<Slider>();
        // staminaBar.gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(float health) {
        if (health <= 0){
            healthBar.value = 0f;
            return;
        }
        Debug.Log("HERE");
        healthBar.value = health;
    }

    public void Win()
    {
        SceneManager.LoadScene("Victory", LoadSceneMode.Single);
    }

    public void Die()
    {
        SceneManager.LoadScene("Die", LoadSceneMode.Single);
    }

    // public void UpdateStamina(float stamina) {
    //     if (stamina <= 0) {
    //         staminaBar.value = 0f;
    //         return;
    //     }
    //     staminaBar.value = stamina;
    // }
}
