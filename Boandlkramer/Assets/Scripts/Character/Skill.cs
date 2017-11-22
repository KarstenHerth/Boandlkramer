using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skills/Skill", order = 1)]
public class Skill : ScriptableObject {

    public Sprite icon;
    
    public string description;

    public int damage;
    public DamageType dmgType;
    public bool targetable;
    public bool hasProjectile;
    public bool isAOE;
    public bool isHoming;
    public bool isInstant;
    public float range = 1f;
    public float rangeAOE = 0.5f;

    public GameObject projectile;

    public Character character;

    public void Cast(Vector3 target, GameObject target_obj = null)
    {
        Vector3 _target = character.transform.position;
        if (targetable)
            _target = target;

        if (hasProjectile)
        {
            GameObject instance = Instantiate(projectile, character.transform.position, Quaternion.FromToRotation(Vector3.forward, target - character.transform.position));
            instance.GetComponent<Fireball>().Initialize(_target, 3f, damage, rangeAOE);
        }

        if (isAOE)
        {
            Collider[] colliders = Physics.OverlapSphere(_target, rangeAOE);
            foreach (Collider collider in colliders)
            {
                if (collider.GetComponent<Character> () != null)
                {
                    collider.GetComponent<Character>().TakeDamage(damage, dmgType);
                }
            }
        }
    }
}
