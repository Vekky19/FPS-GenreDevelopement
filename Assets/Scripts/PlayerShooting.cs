using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public float bulletDamage = 1f;
    public float bulletRange = 100f;
    public int ammoMax;
    public int currentAmmo = 30;
    int clipSize = 30;

    public Text ammoText;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public AudioSource gunSound;
    AudioSource noAmmoSound;

    private void Start()
    {
        noAmmoSound = GetComponent<AudioSource>();

        ammoMax = PlayerHandler.Instance.totalAmmo;
        UpdateAmmoText();
    }

    void ShootBullet()
    {
        muzzleFlash.Play();
        gunSound.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, bulletRange) && hit.collider.tag == "Zombie")
        {

            GameObject impactObject = Instantiate(impactEffect, hit.point, Quaternion.identity);
            Destroy(impactObject, 3f);

            hit.collider.GetComponent<ZombieHealth>().TakeDamage(bulletDamage);
        }
    }

    void AimDownSights()
    {
        Camera.main.fieldOfView = 30;
    }

    void ReloadGun()
    {
        PlayerHandler.Instance.UseAmmo(Mathf.RoundToInt(clipSize - currentAmmo));
        currentAmmo += clipSize - currentAmmo;

        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        ammoText.text = currentAmmo.ToString() + " / " + PlayerHandler.Instance.totalAmmo.ToString();
    }

    void Update()
    {
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * 10);

        //Zooms in when ads pressed
        if (Input.GetMouseButton(1))
        {
            AimDownSights();
        }
        else
        {
            Camera.main.fieldOfView = 60;
        }
        
        //Fire button pressed with ammo
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            ShootBullet();
            currentAmmo -= 1;
            UpdateAmmoText();
        }

        //Fire button pressed but no ammo
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo <= 0)
            {
                noAmmoSound.Play();
            }
        }

        //Reload pressed
        if (Input.GetKeyDown(KeyCode.R) && PlayerHandler.Instance.totalAmmo > 0)
        {
            ReloadGun();
        }
    }
}
