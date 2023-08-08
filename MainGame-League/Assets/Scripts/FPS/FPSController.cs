using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;
using UnityEngine.UI;

public class FPSController : MonoBehaviourPunCallbacks, IDamageable
{
    public GameObject cameraHolder;

    [SerializeField] float mouseSens, sprintSpeed, walkSpeed, jumpForce, smoothTime;

    [SerializeField] Image healthBarImage;

    [SerializeField] GameObject UI;

    float vertLookRotation;
    bool grounded;
    Vector3 smoothMoveVel;
    Vector3 moveAmount;

    Rigidbody rb;

    PhotonView PV;

    [SerializeField] Item[] items;

    int itemIndex;
    int previousItemIndex = -1;

    const float maxHealth = 100;
    float currentHealth = maxHealth;

    PlayerManager playerManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        PV = GetComponent<PhotonView>();

        playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();

        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        if (!PV.IsMine)
            return;

        Look();
        Move();
        Jump();

        for (int i = 0; i < items.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                EquiptItem(i);
                break;
            }
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            items[itemIndex].Use();
        }
    }

    private void Start()
    {
        if (PV.IsMine)
        {
            EquiptItem(0);
        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
            Destroy(UI);
        }
    }

    void EquiptItem(int _index)
    {
        if (_index == previousItemIndex)
            return;

        itemIndex = _index;
        items[itemIndex].itemGameObject.SetActive(true);

        if (previousItemIndex != -1)
        {
            items[previousItemIndex].itemGameObject.SetActive(false);
        }

        previousItemIndex = itemIndex;

        if (PV.IsMine)
        {
            Hashtable hash = new Hashtable();
            hash.Add("itemIndex", itemIndex);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
    }


    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (changedProps.ContainsKey("itemIndex") && !PV.IsMine && targetPlayer == PV.Owner)
        {
            EquiptItem((int)changedProps["itemIndex"]);
        }
    }

    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSens);

        vertLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSens;
        vertLookRotation = Mathf.Clamp(vertLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * vertLookRotation;
    }

    void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVel, smoothTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }

    }


    public void SetGrounded(bool _grounded)
    {
        grounded = _grounded;
    }


    private void FixedUpdate()
    {
        if (!PV.IsMine)
            return;
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        PV.RPC(nameof(RPC_TakeDamage), PV.Owner, damage); 
    }

    [PunRPC]
    void RPC_TakeDamage(float damage, PhotonMessageInfo info)
    {
        currentHealth -= damage;

        healthBarImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
            PlayerManager.Find(info.Sender).GetKill();
        }
    }

    void Die()
    {
        playerManager.Die();
    }
}
