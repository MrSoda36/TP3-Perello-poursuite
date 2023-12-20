using System;
using UnityEngine;

/// <summary>
/// Ecoute les entrées utilisateurs et déplace le personnage du joueur
/// en fonction.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Composant Unity permettant de déplacer facilement un objet dans
    /// un niveau.
    /// </summary>
    CharacterController _characterController;

    /// <summary>
    /// Vitesse de déplacement (en m/s) du personnage.
    /// </summary>
    [SerializeField]
    float _moveSpeed;

    public event Action noiseMade;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            OnNoiseMade();
        }
        Vector3 inputDirection = new Vector3()
        {
            x = Input.GetAxis("Horizontal"),
            y = 0,
            z = Input.GetAxis("Vertical")
        };

        Vector3 velocity = inputDirection * _moveSpeed * Time.deltaTime;

        _characterController.Move(velocity);


    }

    void OnNoiseMade() {
        noiseMade?.Invoke();
    }

}
    
