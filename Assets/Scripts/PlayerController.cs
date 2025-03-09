using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Movement related Variables
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 3.0f;

    //Health related variables
    public int maxHealth = 5;
    public int health { get { return currentHealth; }}
    int currentHealth;

    // Variables related to temporary invincibility
    public float timeInvincible = 0.5f;
    bool isInvincible;
    float damageCooldown;
    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
        Debug.Log(move);

        if (isInvincible)
{
    damageCooldown -= Time.deltaTime;
    if (damageCooldown < 0)
    {
       isInvincible = false;
    }
}
    }

    void FixedUpdate()
  {
    Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.deltaTime;
    rigidbody2d.MovePosition(position);
  }

  public void ChangeHealth (int amount)
  {
    if (amount < 0)
{
   if (isInvincible)
   {
     return;
   }
   isInvincible = true;
   damageCooldown = timeInvincible;
}

    currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth);
  }

}
