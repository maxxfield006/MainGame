using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotGun : GUn
{
    [SerializeField] Camera cam;

    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    public override void Use()
    {
        Shoot();
    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        ray.origin = cam.transform.position;

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            hit.collider.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
            PV.RPC("RPC_Shoot", RpcTarget.All, hit.point, hit.normal);
        }
    }

    [PunRPC]
    void RPC_Shoot(Vector3 hitPos, Vector3 hitNoraml)
    {
        Collider[] colliders = Physics.OverlapSphere(hitPos, 0.3f);

        if (colliders.Length != 0)
        {
            GameObject bulletImpactObj = Instantiate(bulletImpactPrefab, hitPos + hitNoraml * 0.001f, Quaternion.LookRotation(hitNoraml, Vector3.up) * bulletImpactPrefab.transform.rotation);
            Destroy(bulletImpactObj, 5f);
            bulletImpactObj.transform.SetParent(colliders[0].transform);
        }
    }
}
