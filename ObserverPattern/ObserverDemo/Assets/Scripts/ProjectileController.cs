﻿using System;
using UnityEngine;

public delegate void OutOfBoundsHandler();

public class ProjectileController : MonoBehaviour
{
    #region Field Declarations

    public Vector2 projectileDirection;
    public float projectileSpeed;
    public bool isPlayers;
    internal OutOfBoundsHandler OutOfBounds;

    #endregion

    #region Movement

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.Translate(projectileDirection * Time.deltaTime * projectileSpeed, Space.World);

        if (ScreenBounds.OutOfBounds(transform.position))
        {
            if (isPlayers == true)
            {
                OutOfBounds?.Invoke();
            }

            Destroy(gameObject);
        }
    }

    #endregion
}
