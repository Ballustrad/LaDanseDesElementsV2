using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.Events;

namespace KinematicCharacterController.Examples
{
    public class ExamplePlayer : MonoBehaviour
    {
        public int playerMaxHealth = 100;
        public int fireHealth;
        public int waterHealth;
        public int windHealth;
        public int earthHealth;
        public int playerCurrentHealth;

        public HealthBar playerHealthBar;
        public ExampleCharacterController Character;
        public ExampleCharacterCamera CharacterCamera;

        private const string MouseXInput = "Mouse X";
        private const string MouseYInput = "Mouse Y";
        private const string MouseScrollInput = "Mouse ScrollWheel";
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";
        public Transform bodyToTP;
        public GameObject Fire;
        public GameObject Water;
        public GameObject Wind;
        public GameObject Earth;        

        public int currentElement = 1;
        private void Start()
        {
            playerCurrentHealth = playerMaxHealth;
            playerHealthBar.SetMaxHealth(playerMaxHealth);
            Cursor.lockState = CursorLockMode.Locked;


            // Tell camera to follow transform
            CharacterCamera.SetFollowTransform(Character.CameraFollowPoint);

            // Ignore the character's collider(s) for camera obstruction checks
            CharacterCamera.IgnoredColliders.Clear();
            CharacterCamera.IgnoredColliders.AddRange(Character.GetComponentsInChildren<Collider>());
        }

        private void Update()
        {
            // Détecte la touche d'interaction ici
            
            if (playerCurrentHealth < 0) { playerCurrentHealth = 0; }
            //Pour que la vie n'aille pas au dessus de 100
            if (playerCurrentHealth > playerMaxHealth) { playerCurrentHealth = 100; }

            //Tue le joueur si sa vie atteint 0
            if (playerCurrentHealth == 0) { Death(); }

            if (fireIsOn == true )
            {
                currentElement = 1;
                currentEnergy = currentEnergyFire;
                playerCurrentHealth = fireHealth;
            }
            if (waterIsOn == true)
            {
                currentElement = 4;
                currentEnergy = currentEnergyWater;
                playerCurrentHealth = waterHealth;
            }
            if (windIsOn == true)
            {
                currentElement = 3;
                currentEnergy = currentEnergyWind;
                playerCurrentHealth = windHealth;
            }
            if (earthIsOn == true)
            {
                currentElement = 2;
                currentEnergy = currentEnergyEarth;
                playerCurrentHealth = earthHealth;
            }
            
            switch (currentElement)
            {
                case 1:
                    energyBar.gameObject.GetComponent<Slider>().value = currentEnergyFire; 
                    backgroundBar.GetComponent<Image>().color = new Color((float).77, 0, 0, 1);
                    playerHealthBar.fill.GetComponent<Image>().color = new Color((float).77, 0, 0, 1);
                        break;

                case 2:
                    energyBar.gameObject.GetComponent<Slider>().value = currentEnergyEarth; 
                    backgroundBar.GetComponent<Image>().color = new Color ((float).17,(float).45, (float).14, 1 );
                    playerHealthBar.fill.GetComponent<Image>().color = new Color((float).17, (float).45, (float).14, 1);
                        break;
                case 3:
                    energyBar.gameObject.GetComponent<Slider>().value = currentEnergyWind; 
                    backgroundBar.GetComponent<Image>().color = Color.white;
                    playerHealthBar.fill.GetComponent<Image>().color = Color.white;
                    break;
                case 4:
                    energyBar.gameObject.GetComponent<Slider>().value = currentEnergyWater;
                    backgroundBar.GetComponent<Image>().color = new Color((float).18, (float).66, 1,1);
                    playerHealthBar.fill.GetComponent<Image>().color = new Color((float).18, (float).66, 1, 1);
                    break;

                default: break; 
            }

            if (!isAvailable)
            {
                float timeSinceLastUsage = Time.time - lastUsageTime;

                // If the elapsed time is greater than or equal to cooldown time, the ability is ready
                if (timeSinceLastUsage >= cooldownTime)
                {
                    isAvailable = true;
                }
            }
            if (Input.GetMouseButtonDown(0) && !PauseMenu.gameIsPaused)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwapElement();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                PerformSpecialSkill();
            }
            HandleCharacterInput();
        }
        private void Death()
        {
            this.gameObject.SetActive(false);
        }

        private void LateUpdate()
        {
            // Handle rotating the camera along with physics movers
            if (CharacterCamera.RotateWithPhysicsMover && Character.Motor.AttachedRigidbody != null)
            {
                CharacterCamera.PlanarDirection = Character.Motor.AttachedRigidbody.GetComponent<PhysicsMover>().RotationDeltaFromInterpolation * CharacterCamera.PlanarDirection;
                CharacterCamera.PlanarDirection = Vector3.ProjectOnPlane(CharacterCamera.PlanarDirection, Character.Motor.CharacterUp).normalized;
            }

            HandleCameraInput();
        }
        private void HandleCameraInput()
        {
            // Create the look input vector for the camera
            float mouseLookAxisUp = Input.GetAxisRaw(MouseYInput);
            float mouseLookAxisRight = Input.GetAxisRaw(MouseXInput);
            Vector3 lookInputVector = new Vector3(mouseLookAxisRight, mouseLookAxisUp, 0f);

            // Prevent moving the camera while the cursor isn't locked
            if (Cursor.lockState != CursorLockMode.Locked)
            {
                lookInputVector = Vector3.zero;
            }

            // Input for zooming the camera (disabled in WebGL because it can cause problems)
            float scrollInput = -Input.GetAxis(MouseScrollInput);
#if UNITY_WEBGL
        scrollInput = 0f;
#endif

            // Apply inputs to the camera
            CharacterCamera.UpdateWithInput(Time.deltaTime, 0f, lookInputVector);

            // Handle toggling zoom level
           /* if (Input.GetMouseButtonDown(1))
            {
                CharacterCamera.TargetDistance = (CharacterCamera.TargetDistance == 0f) ? CharacterCamera.DefaultDistance : 0f;
            }*/
        }

        private void HandleCharacterInput()
        {
            PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

            // Build the CharacterInputs struct
            characterInputs.MoveAxisForward = Input.GetAxisRaw(VerticalInput);
            characterInputs.MoveAxisRight = Input.GetAxisRaw(HorizontalInput);
            characterInputs.CameraRotation = CharacterCamera.Transform.rotation;
            characterInputs.JumpDown = Input.GetKeyDown(KeyCode.Space);
            //characterInputs.CrouchDown = Input.GetKeyDown(KeyCode.C);
            //characterInputs.CrouchUp = Input.GetKeyUp(KeyCode.C);

            // Apply inputs to character
            Character.SetInputs(ref characterInputs);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ennemy"))
            {
                PlayerTakeDamage(10);
            }
        }
        public void PlayerTakeDamage(int damage)
        {
            playerCurrentHealth -= damage;

            playerHealthBar.SetHealth(playerMaxHealth);
        }
        


        public bool fireIsOn = true;
        public bool waterIsOn = false;
        public bool windIsOn = false;
        public bool earthIsOn = false;

        public float cooldownTime = 2f; // Cooldown time in seconds
        private bool isAvailable = true;
        private float lastUsageTime;
        public GameObject petsFire;
        public GameObject petsWater;
        public GameObject petsWind;
        public GameObject petsEarth;
        
        public void SwapElement()
        {
            if (isAvailable)
            {
                if (fireIsOn == true)
                {
                    Fire.gameObject.SetActive(false);
                    Earth.gameObject.SetActive(true);
                    earthIsOn = true;
                    fireIsOn = false;
                    petsEarth.gameObject.SetActive(true);
                    petsFire.gameObject.SetActive(false);


                }
                else if (waterIsOn == true)
                {
                    Water.gameObject.SetActive(false);
                    waterIsOn = false;
                    Fire.gameObject.SetActive(true);
                    fireIsOn = true;
                    petsWater.gameObject.SetActive(false);
                    petsFire.gameObject.SetActive (true);
                }
                else if (earthIsOn == true)
                {
                    Earth.gameObject.SetActive(false);
                    earthIsOn = false;
                    Wind.gameObject.SetActive(true);
                    windIsOn = true;
                    petsEarth.gameObject.SetActive(false);
                    petsWind.gameObject.SetActive(true);

                }
                else if (windIsOn == true)
                {
                    Wind.gameObject.SetActive(false);
                    windIsOn = false;
                    Water.gameObject.SetActive(true);
                    waterIsOn = true;
                    petsWind.gameObject.SetActive(false);
                    petsWater.gameObject.SetActive(true) ;

                }
                lastUsageTime = Time.time;

                // Disable the ability during cooldown
                isAvailable = false;
            }
            else
            {
                // The ability is not available, you can add a sound or visual effect to indicate this to the player
                Debug.Log("Ability on cooldown...");
            }


        }



        public GameObject energyBar;
        public GameObject backgroundBar;
        public float currentEnergyWater = 3;
        public float currentEnergyFire = 3;
        public float currentEnergyEarth = 3;
        public float currentEnergyWind = 3;
        public float currentEnergy;
        public FireBallSkill fireballSkill;
        public StoneBridgeSkill stoneBridgeSkill;
        public PropulsionSkill propulsionSkill;

        public WaterFormSkill waterFormSkill;

        public float interactionDistance = 3f;

        public UnityAction<ExampleCharacterController> OnCharacterTeleport;
        public bool isBeingTeleportedTo { get; set; }

        public bool tpAuthorized = false;
        public void PerformSpecialSkill()
        {
            if (currentEnergy > 0)
            {
                energyBar.gameObject.GetComponent<Slider>().value = currentEnergy - 1;
                // Sélectionner l'attaque appropriée en fonction de l'élément actuel du joueur
                switch (currentElement)
                {
                    case 1:
                        currentEnergyFire = energyBar.GetComponent<Slider>().value;
                        fireballSkill.UseFireball();
                        break;
                    case 2:
                        currentEnergyEarth = energyBar.GetComponent<Slider>().value;
                        stoneBridgeSkill.CreateStoneBridge();
                        break;
                    case 3:
                        currentEnergyWind = energyBar.GetComponent<Slider>().value;
                        propulsionSkill.PropelInAir();
                        break;
                    case 4:
                        currentEnergyWater = energyBar.GetComponent<Slider>().value;
                        tpAuthorized = true;
                        break;
                    default:
                        break;

                        // Ajoutez d'autres cas pour les autres types d'attaque
                }
            }
        }
      
    }
}