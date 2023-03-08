using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBase : MonoBehaviour
{
    public Action onKill;
    public Image healthBar;
    public int startLife = 50;
    public int maxLife = 50;
    public bool destroyOnKill = false;
    public float delayToKill = 0f;
  
    public float _currentLife;
    private bool _isDead = false;
    [SerializeField] FlashColor _flashColor;

    private void Awake()
    {
        Init();
        if(_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)_currentLife / (float)startLife;
        }
    }


    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;
        if (_currentLife <= 0)
        {
            Kill();
        }

        if (_flashColor != null)
        {
            _flashColor.Flash();
        }
        if (healthBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)_currentLife / (float)startLife);
            healthBar.fillAmount = fillAmount;
        }
    }

    public void GainLife(float Valor)
    {
        _currentLife += Valor;
        if (_currentLife > maxLife)
        {
            _currentLife = maxLife;
        }
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)_currentLife / (float)maxLife;
        }
    }


    public void LoseLife(float Valor)
    {
        healthBar.fillAmount = Valor / 10;
    }

    public void UpdateLife(float amount)
    {
        // Adiciona o valor de amount à vida atual do jogador
        _currentLife += amount;

        // Verifica se a vida atual do jogador ultrapassou a vida máxima permitida
        if (_currentLife > maxLife)
        {
            _currentLife = maxLife;
        }

        // Atualiza a barra de vida na tela
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)_currentLife / (float)maxLife;
        }
    }


    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
        //if(onKill != null) onKill.Invoke();
        onKill?.Invoke();
    }
}
