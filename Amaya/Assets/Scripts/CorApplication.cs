using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using Views;

public class CorApplication : MonoBehaviour
{
    private SystemController _systemController;
    [SerializeField] private World _world;

    private void Start()
    {
        _systemController = new SystemController(_world);
    }
}
