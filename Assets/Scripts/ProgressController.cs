using UnityEngine;

public class ProgressController : MonoBehaviour
{
    [SerializeField] float money;
    [SerializeField] float gym;
    [SerializeField] float travel;
    [SerializeField] float food;
    [SerializeField] float rent;
    [SerializeField] float services;
    [SerializeField] float cinema;
    [SerializeField] float gas;
    [SerializeField] float vehicle;
 
   

    public float Money { get => money; set => money = value; }
    public float Gym { get => gym; set => gym = value;}
    public float Travel { get => travel; set => travel = value; }
    public float Food { get => food; set => food = value; }
    public float Rent { get => rent; set => rent = value; }
    public float Services { get => services; set => services = value; }
    public float Cinema { get => cinema; set => cinema = value; }
    public float Gas { get => gas; set => gas = value; }
    public float Vehicle { get => vehicle; set => vehicle = value; }
}
