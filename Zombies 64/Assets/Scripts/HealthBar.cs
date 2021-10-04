using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Slider slider;
	public Image fill;
	int Health;

    private void Update()
    {
		
	}
    public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;
		Health = health;
	}

	public void SetHealth(int health)
	{
		slider.value = health;		
	}

}
