using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region Definitions
    [SerializeField] private float jumpForce = 10f; // zıplama kuvveti
    [SerializeField] private float extraGravityMultiplier = 0.6f;
    [SerializeField] private float runSpeed; // koşma hızı
    [SerializeField] private float gravityScale; //yerçekimi Büyüklüğü
    
    private bool isGrounded = true; // zemine temas halinde mi
    private float speedIncreaseRate = 0.005f; // hız artış oranı (saniyede %0.5)
    private float speedIncreaseTimer = 0f; // hız artışını sayacak zamanlayıcı
    private float lastMovedTime = 0f; // son hareket zamanı

    Animator animatorController; // animatör kontrollerının tanımlanması
    Rigidbody rb; // rigidbody Tanımlanması
    #endregion
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // performans için rigidbodynin get componenti oyunun başında alınır.
    }

    private void Start()
    {
        Time.timeScale = 1; //oyun başlarken önceki oyundan kalan durdurma işlemini tersine alır.
        animatorController = GetComponent<Animator>();
    }
    void Update()
    {   
        otonomMovement();
        MovementControl();
        IncreasedSpeed();
    }
    

#region Methods
private void otonomMovement()
{
        // İleri hareketi sağla
        Vector3 movement = transform.forward * runSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // Yerçekimi kuvvetini uygula
        rb.AddForce(Vector3.down * gravityScale * rb.mass * Time.deltaTime);

        // Yere doğru düşüyorsak, yerçekimi kuvvetini arttırarak daha hızlı düşmemizi sağla
        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector3.down * gravityScale * rb.mass * extraGravityMultiplier * Time.deltaTime);
        }
}
private void MovementControl()
{
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved && Time.time - lastMovedTime > 0.2f)
        {
            Vector2 deltaPosition = touch.deltaPosition;
            if (deltaPosition.y > 0f && Mathf.Abs(deltaPosition.y) > Mathf.Abs(deltaPosition.x))
            {
                //zıpla
                Jump();
            }
            else if (deltaPosition.x < 0f)
            {
                // Sola dön
                transform.Rotate(0f, -90f, 0f, Space.Self);
                lastMovedTime = Time.time;
                
            }
            else if (deltaPosition.x > 0f)
            {
                // sağa dön
                transform.Rotate(0f, 90f, 0f, Space.Self);
                lastMovedTime = Time.time;
            }
        }

    }
}
private void Jump()
{
    if (isGrounded)
    {   
        animatorController.SetTrigger("Jump");//animasyonu çalıştır
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);// zıplama kuvvetini objeye uygula
        isGrounded = false;
    }
}

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        // obje zemine temas etti, zıplama işlemi yapılabilir
        animatorController.SetBool("IsGrounded",true);//bu bool animasyonu iyi hale getirmek için.
        isGrounded = true;
    }
}

private void IncreasedSpeed() // oyundaki karakterin hızını gittikçe arttırmak için kod.
{
    // zamanlayıcıyı arttır
    speedIncreaseTimer += Time.deltaTime;

    // zamanlayıcı 1 saniyeyi geçtiyse hızı arttır
    if (speedIncreaseTimer >= 1f)
    {
        runSpeed += runSpeed * speedIncreaseRate;
        speedIncreaseTimer = 0f;
    }

}

#endregion
}
