using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public ParticleSystem HealEffect;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    public float MaxValue = 100;
    public Slider HealthBar;

   public float _currentValue;

    void Start()
    {
        
        _currentValue = MaxValue;
        UpdateHealthBar();
    }

    public void TakeDamage(float Damage)
    {
        
        _currentValue -= Damage;
        if (_currentValue <= 0)
        {
            PlyerDead();
        }
        UpdateHealthBar();
    }

    public void PlyerDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        gameOverScreen.GetComponent<Animator>().SetTrigger("show");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 1;       
        GetComponent<FireballCaster>().enabled = false;
    }
    public void AddHealth(float amount)
    {
        _currentValue += amount;
        if (_currentValue > MaxValue) 
        {
            _currentValue = MaxValue;
        }
        UpdateHealthBar();
        HealEffect.GetComponent<ParticleSystem>().Play();
    }
    public void UpdateHealthBar()
    {
        HealthBar.value = _currentValue/ MaxValue;
    }

}
