using UnityEngine;

[RequireComponent(typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour {

    public float fuelMass;                  // [kg]
    public float maxThrust;                 // kN   [kg m s^-2] = [F = ma = kg(m/s^2)]

    [Range(0,1f)]   //slider in inspector
    public float thrustPercent;             // none
    public Vector3 thrustUnitVector;        // none (shows direction)

    private PhysicsEngine physicsEngine;    // none
    private float currentThrust;            // N
    private Vector3 thrustVector;        // N

    // Use this for initialization
    void Start ()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
        physicsEngine.mass += fuelMass;     //adding fuel mass to total rigidbody mass
    }

    private void FixedUpdate()
    {
        if (fuelMass > FuelThisUpdate())
        {
            fuelMass -= FuelThisUpdate();
            physicsEngine.mass -= FuelThisUpdate();
            ExertForce();
        }
        else
            Debug.LogWarning("Out of rocket fuel");
    }

    /// <summary>
    /// Amount of exerted force based on thrust % (percent).
    /// </summary>
    void ExertForce()
    {
        currentThrust = thrustPercent * maxThrust * 1000f;              // N (kN*1000=N)
        //normalized - ensures thrust unit vector only shows direction
        thrustVector = thrustUnitVector.normalized * currentThrust;  // N
        physicsEngine.AddForce(thrustVector);
    }

    /// <summary>
    /// Fuel we are going to burn this update.
    /// </summary>
    /// <returns></returns>
    float FuelThisUpdate()
    {
        //taken from wikipedia about rocket engines for liquid HO
        float effectiveExhaustVelocity = 4462f;                             // [m/s] = [m s^-1]

        // F = mV
        // thrust = massFlow * exhaustVelocity
        // massFlow = thrust / exhaustVelocity;
        float exhaustMassFlow = currentThrust / effectiveExhaustVelocity;   // [kg/s]

        return exhaustMassFlow * Time.deltaTime;                            // [kg]
    }

}
