using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginButtonController : MonoBehaviour
{
    [SerializeField] private GameObject loginButton;
    [SerializeField] private GameObject logoutButton;
    [SerializeField] private GameObject backToPlayMenuButton;

    [SerializeField] private AuthService authService;
    // Start is called before the first frame update
    void Start()
    {
        var loggedIn = authService.loggedIn();
        loginButton.SetActive(!loggedIn);
        logoutButton.SetActive(loggedIn);
        backToPlayMenuButton.SetActive(false);
    }

    private void OnEnable()
    {
        Start();
    }
}
