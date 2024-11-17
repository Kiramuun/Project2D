using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayersInputs : MonoBehaviour
{
    [SerializeField] private float _speed;
    public Animator _animRef;
    Vector2 _smoothMove;
    Vector2 _smoothVelocity;
    Rigidbody2D _rb2D;
    Vector2 mouvInput;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"),
              vertical = Input.GetAxisRaw("Vertical");

        mouvInput = new Vector2(horizontal, vertical).normalized;
        
        _smoothMove = Vector2.SmoothDamp(_smoothMove, mouvInput, ref _smoothVelocity, 0.1f);
        
        _rb2D.velocity = _smoothMove * _speed;
        
        _animRef.SetFloat("Speed", Mathf.Abs(_rb2D.velocity.magnitude));
        _animRef.SetFloat("Horizontal", horizontal);
        _animRef.SetFloat("Vertical", vertical);
    }

    public void Movements(InputAction.CallbackContext context)
    {
        mouvInput = context.ReadValue<Vector2>();
    }

    public void Pause (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        }
    }
}
