using UnityEngine;

public class FireWoodOven : MonoBehaviour
{
    public float tempature;
    public int upperBoundTemp;
    public int lowerBoundTemp;
    public float tempatureDecreaseSpeed;
    public int logTempIncrease;
    public int CookTimer;

    private void Update()
    {
        tempature -= Time.deltaTime * tempatureDecreaseSpeed;

        if (tempature > upperBoundTemp)
        {

        }
        else if (tempature < lowerBoundTemp)
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WoodLog")
        {
            tempature += logTempIncrease;
            Destroy(collision.gameObject, 3f);
        }
        else if(collision.gameObject.GetComponent<Pizza_Controller>() != null)
        {
            /*
             * collision.gameObject.GetComponent<Pizza_Controller>().isCooked = true;
             * collision.gameObject.GetComponent<Pizza_Controller>().burnt = true;
             * 
            */
        }
        else
        {
            Destroy(collision.gameObject, 2f);
        }
    }


}
