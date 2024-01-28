using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float shootPower = 50;
    [SerializeField] private float cooldownMax = 3;
    [SerializeField] private AudioSource shotgunShoot;
    [SerializeField] private AudioSource shotgunReload;
    [SerializeField] private AudioSource[] screams;
    [SerializeField] private Image chargeUI;
    [SerializeField] private float maxShells;

    private InputAction shoot;
    private float shells;
    public PlayerInputs playerInputs;
    private Rigidbody2D rb;
    private float cooldown;
    private bool activationState = true;
    public ParticleSystem shootParticle1;
    public ParticleSystem shootParticle2;
    public ParticleSystem shootParticle3;
    public ParticleSystem shootParticle4;

    // Start is called before the first frame update
    private void Awake()
    {
        playerInputs = new PlayerInputs();
        rb = gameObject.GetComponent<Rigidbody2D>();
        shells = maxShells;
    }

    private void OnEnable()
    {
        shoot = playerInputs.Player.Shoot;
        shoot.Enable();
    }

    private void Update()
    {

        chargeUI.fillAmount = shells / maxShells;
        if(activationState)
        {
            if(shoot.WasPressedThisFrame() && shells > 0f)
            {
                shotgunShoot.Play();

                // if(chargePower >= minChargePower+((maxChargePower - minChargePower)/1.5))
                // {
                //     DelayedScream();
                //     Debug.Log("Scream maybe...");
                // }
                
                Vector3 mousePosition = Mouse.current.position.ReadValue();
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                
                Vector2 direction = new Vector2(transform.position.x - mousePosition.x , transform.position.y - mousePosition.y);
                Vector2 normalizedDirection = direction.normalized;

                rb.velocity = new Vector2(0f,0f);
                rb.AddForce(normalizedDirection * shootPower);

                shootParticle1.Play();
                shootParticle2.Play();
                shootParticle3.Play();
                shootParticle4.Play();

                shells -= 1f;

                cooldown = cooldownMax;
            }

            if(cooldown != 0f)
            {
                cooldown -= Time.deltaTime;
                cooldown = Mathf.Clamp(cooldown, 0f, cooldownMax);

                if(cooldown == 0f)
                {
                    shotgunReload.Play();
                    shells = maxShells;
                }
            }
        }
    }

    private void OnDisable()
    {
        shoot.Disable();
    }

    public void PublicActivate()
    {
        activationState = true;
    }

    public void PublicDeactivate()
    {
        activationState = false;
    }

    // private IEnumerator DelayedScream()
    // {
    //     yield return new WaitForSeconds(.05f);
    //     int random = Random.Range(0, 3);

    //     if(random == 1)
    //     {
    //         int randomSound = Random.Range(1, 4);
            
    //         Debug.Log("SCREAM!");
    //         screams[randomSound - 1].Play();
    //     }

    //     Debug.Log("End Scream");
    // }

    private void DelayedScream()
    {
        int random = Random.Range(0, 3);

        if(random == 1)
        {
            int randomSound = Random.Range(1, 4);
            
            Debug.Log(randomSound - 1);
            screams[randomSound - 1].Play();
        }
    }
}
