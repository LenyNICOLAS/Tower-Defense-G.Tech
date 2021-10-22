using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerTurret : MonoBehaviour
{
    // ennemi cible
    Transform enemy = null;

    // stats de la tour de ralentissement
    public float range = 10f;
    public float intensity = 2.0f;
    public float duration = 1.0f;
    public float Cooldown = 3.0f;

    // parametre gerant le comportement de la tour de ralentissement
    private float lastSlowCast = -0.5f;
    private int count = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.time - lastSlowCast;

        if (dt > Cooldown)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);

            // ralentissement des ennemis dans la zone d'action de la tour de ralentissement
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Enemy"))
                {
                    enemy = hitCollider.transform;
                    if (!enemy.GetComponent<Enemy>().IsSlowed())
                    {
                        enemy.GetComponent<Enemy>().Slow(intensity, duration);
                        count++;
                    }
                }
            }

            // VFX et SFX declanche si au moins un ennemi a ete ralenti
            if (count > 0)
            {
                transform.GetComponent<SlowerTurret_VFX>().Cast();
                transform.GetComponent<SlowerTurret_SFX>().Cast();

                lastSlowCast = Time.time;
                count = 0;
            }
        }
    }
}
