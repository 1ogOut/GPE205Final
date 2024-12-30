using System.Diagnostics;
using System.Runtime;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //create the hp as floats, public so we can get to them, and floats so we can save them as a percentage, We dont put our damage amount float here because then the character would take its own damage. 
    public float currentHealth;
    public float maxHealth; 
    public Image Healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set health to max
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    { 
    }
    //a function for taking damage, it has a float for the amount of damage to make it easier to change, as well as a pawn it sources frmo to help us later
    public void TakeDamage(float amount, Pawn source)
    {

        //subtracts the damage from health and puts it into the console
        currentHealth = currentHealth - amount; 
        UnityEngine.Debug.Log(source.name + " did " + amount + "damage to " + gameObject.name);
        //keeps our health from going over or under a limit
        currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
        //kills us if where under 0 hp.
        if (currentHealth <= 0) {
            Die (source);
        }
        Healthbar.fillAmount -= 0.3f;
    }
    public void Heal(float amount, Pawn source)
    {
        //adds the amount 
        currentHealth = currentHealth + amount; 
        UnityEngine.Debug.Log(source.name + " healed " + amount);
        currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
    }
    //kills whatever hits 0 hp.
    public void Die(Pawn source)
    {
        Destroy(gameObject);
    }
}
