using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _bulletSpawn;
    [SerializeField] GameObject _landminePrefab;
    [SerializeField] Transform _landmineSpawn;
    private GameObject bullet;
    private GameObject landmine;
    private bool _isFire;
    private bool _isLandmine;

    void Start()
    {
    }
    void Update()
    {
        if(Time.deltaTime != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isFire = true;
                MainFire();
            }
            if (Input.GetMouseButtonDown(1))
            {
                _isLandmine = true;
                SetLandmine();
            }
        }
    }

    private void SetLandmine()
    {
        landmine = Instantiate(_landminePrefab, _landmineSpawn.position, _landmineSpawn.rotation);
        _isLandmine = false;
    }

    void FixedUpdate()
    {
    }

    private void MainFire()
    {
        bullet = Instantiate(_bulletPrefab, _bulletSpawn.position, _bulletSpawn.rotation);
        _isFire = false;
    }
}
