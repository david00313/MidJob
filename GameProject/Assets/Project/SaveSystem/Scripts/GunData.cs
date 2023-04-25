using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
public class GunData
{
    public int totalAmmo;
    public int usingAmmo;

        public GunData(GunFire gun)
    {
        totalAmmo = gun.totalAmmo;
        usingAmmo = gun.usingAmmo;

    }
}
