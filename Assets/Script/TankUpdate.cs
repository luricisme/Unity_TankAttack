using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/UpdateTank")]
public class TankUpdate : PowerUpEffect
{
    public Sprite newTank;
    public BulletData bulletTank;
    public TimeReloadData reloadTank;
    public override void Apply(GameObject target)
    {
        Debug.Log("HaveApply");
        target.GetComponentInChildren<SpriteRenderer>().sprite = newTank;
        target.GetComponentInChildren<Turret>().bulletData=bulletTank;
        target.GetComponentInChildren<Turret>().reloadData = reloadTank;
    }
}