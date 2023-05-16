using UnityEngine;
// Clase para guardar progresos
public class ProgressController : MonoBehaviour
{
    [SerializeField] float money;
    [SerializeField] float gym;
    [SerializeField] float travel;
    [SerializeField] float food;
    [SerializeField] float rent;
    [SerializeField] float services;
    [SerializeField] float enter;
    [SerializeField] float gas;
    [SerializeField] float vehicle;
    [SerializeField] float clothes;
 
   

    public float Money { get => money; set => money = value; }
    public float Gym { get => gym; set => gym = value;}
    public float Travel { get => travel; set => travel = value; }
    public float Food { get => food; set => food = value; }
    public float Rent { get => rent; set => rent = value; }
    public float Services { get => services; set => services = value; }
    public float Enter { get => enter; set => enter = value; }
    public float Gas { get => gas; set => gas = value; }
    public float Vehicle { get => vehicle; set => vehicle = value; }
    public float Clothes { get => clothes; set => clothes = value; }
}
