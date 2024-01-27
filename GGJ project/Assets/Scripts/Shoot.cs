using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float minChargePower = 50;
    [SerializeField] private float maxChargePower = 250;
    [SerializeField] private float potency = 50;
    [SerializeField] private float cooldownMax = 3;
    [SerializeField] private AudioSource shotgunShoot;
    [SerializeField] private AudioSource shotgunReload;
    [SerializeField] private AudioSource[] screams;
    [SerializeField] private Image chargeUI;
    [SerializeField] private Image reloadUI;

    private InputAction shoot;
    private PlayerInputs playerInputs;
    private Rigidbody2D rb;
    private float chargePower;
    private float cooldown;
    private bool charging = false;
    private bool activationState = true;

    // Start is called before the first frame update
    private void Awake()
    {
        playerInputs= new PlayerInputs();
        rb = gameObject.GetComponent<Rigidbody2D>();
        chargePower = minChargePower;
    }

    private void OnEnable()
    {
        shoot = playerInputs.Player.Shoot;
        shoot.Enable();
    }

    private void Update()
    {

        chargeUI.fillAmount = (chargePower-minChargePower) / (maxChargePower-minChargePower);
        reloadUI.fillAmount = cooldown;
        if(activationState)
        {
            if (shoot.IsPressed() && cooldown == 0f)
            {
                chargePower += Time.deltaTime * potency;
                chargePower = Mathf.Clamp(chargePower, minChargePower, maxChargePower);
                charging = true;
            }
            else if(shoot.WasReleasedThisFrame() && charging)
            {
                shotgunShoot.Play();

                if(chargePower >= minChargePower+((maxChargePower - minChargePower)/1.5))
                {
                    DelayedScream();
                    Debug.Log("Scream maybe...");
                }
                
                Vector3 mousePosition = Mouse.current.position.ReadValue();
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                
                Vector2 direction = new Vector2(transform.position.x - mousePosition.x , transform.position.y - mousePosition.y);
                Vector2 normalizedDirection = direction.normalized;

                rb.AddForce(normalizedDirection * chargePower);

                chargePower = minChargePower;

                cooldown = cooldownMax;

                charging = false;
            }

            if(cooldown != 0f)
            {
                cooldown -= Time.deltaTime;
                cooldown = Mathf.Clamp(cooldown, 0f, cooldownMax);

                if(cooldown == 0f)
                {
                    shotgunReload.Play();
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
