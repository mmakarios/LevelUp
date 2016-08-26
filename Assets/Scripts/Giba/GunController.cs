﻿using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    Gun equippedGun;
    public Transform weaponHold;
    public Gun startingGun;

    public void Start()
    {

        if (startingGun != null)
        {
            EquipGun(startingGun);
        }

    }

	public void EquipGun(Gun gunToEquip)
    {

        if (equippedGun != null)
        {
            Destroy(gunToEquip.gameObject);
        }
        equippedGun = gunToEquip;

        equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
        equippedGun.transform.parent = weaponHold;

    }

    public void Shoot()
    {

        if(equippedGun != null)
        {

            equippedGun.Shoot();

        }

    }

}
