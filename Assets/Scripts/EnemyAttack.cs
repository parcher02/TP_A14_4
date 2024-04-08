using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject unit;
    public int damage;
  
    private void OnEnable()
    {
        //When enabled will do damage to selected unit
        unit.GetComponent<StandardPiece>().damageUnit(damage);
    }
}
