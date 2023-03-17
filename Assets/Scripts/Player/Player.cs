using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D MyRigidbody2D;
    public HealthBase healthBase;
    public int damage = 10;

    [Header("Setup")]
    public SOPlayer soPlayer;
    //public Animator animator;

    private float _currentSpeed;
    public int maxJumps = 2;
    private int jumps = 0;
    //private bool _isRunning = false;
    private Animator _currentPlayer;


    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.onKill += OnPlayerKill;
        }
       _currentPlayer = Instantiate(soPlayer.player, transform);
    }
    public void RestoreHealth(float amount)
    {
        // Verifica se a vida atual do jogador é menor que a vida máxima permitida
        if (healthBase.startLife < (int)healthBase._currentLife)
        {
            // Adiciona o valor de amount à vida atual do jogador
            healthBase.startLife += (int)amount;

            // Verifica se a vida atual do jogador ultrapassou a vida máxima permitida
            if (healthBase.startLife > healthBase._currentLife)
            {
                healthBase.startLife = (int)(healthBase.startLife - damage);
            }

            // Atualiza a barra de vida na tela
            healthBase.GainLife(healthBase._currentLife);
        }
    }

    private void OnPlayerKill()
    {
        healthBase.onKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayer.triggerDeath);
        if (healthBase != null)
        {
            healthBase.onKill -= OnPlayerKill;
        }
    }

    public void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    private void HandleMoviment()
    {
        if (_currentPlayer == null)
        {
            return;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = soPlayer.speedRun;
            _currentPlayer.speed = 2;
        }
        else
        {
            _currentSpeed = soPlayer.speed;
            _currentPlayer.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MyRigidbody2D.velocity = new Vector2(-_currentSpeed, MyRigidbody2D.velocity.y);
            if(MyRigidbody2D.transform.localScale.x != -1)
            {
                MyRigidbody2D.transform.DOScaleX(-1, soPlayer.playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayer.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {            
            MyRigidbody2D.velocity = new Vector2(_currentSpeed, MyRigidbody2D.velocity.y);
            if (MyRigidbody2D.transform.localScale.x != 1)
            {
                MyRigidbody2D.transform.DOScaleX(1, soPlayer.playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayer.boolRun, true);
        }
        else
        {
            _currentPlayer.SetBool(soPlayer.boolRun, false);
        }


        if (MyRigidbody2D.velocity.x > 0)
        {
            MyRigidbody2D.velocity += soPlayer.friction;
        }
        else if (MyRigidbody2D.velocity.x < 0)
        {
            MyRigidbody2D.velocity -= soPlayer.friction;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumps = 0;
        }
    }

    private void HandleJump()
    {
        if (jumps < maxJumps && Input.GetKeyDown(KeyCode.Space))
        {
            MyRigidbody2D.velocity = Vector2.up * soPlayer.forceJump;
            MyRigidbody2D.transform.localScale = Vector2.one;

            DOTween.Kill(MyRigidbody2D.transform);

            HandleScaleJump();
            HandleScaleSquat();

            jumps++;
        }
    }

    private void HandleScaleJump()
    {
        MyRigidbody2D.transform.DOScaleY(soPlayer.jumpScaleY, soPlayer.animatioDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer.ease);
        MyRigidbody2D.transform.DOScaleX(soPlayer.jumpScaleY, soPlayer.animatioDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer.ease);
    }

    private void HandleScaleSquat()
    {
        MyRigidbody2D.transform.DOScaleY(soPlayer.squatScaleY, soPlayer.animatioDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer.ease);
        MyRigidbody2D.transform.DOScaleX(soPlayer.squatScaleX, soPlayer.animatioDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
