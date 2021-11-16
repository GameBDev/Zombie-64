using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public bool weapon1Out;
    public bool weapon2Out;

    public GameObject weapon1;
    public GameObject weapon2;


    private void Start()
    {
        weapon1Out = true;
    }
    void Update()
    {
        if (!weapon1Out && weapon2Out && Input.GetKeyDown(KeyCode.Q)){
            SwitchWeapon1();
        }
        if (weapon1Out && !weapon2Out && Input.GetKeyDown(KeyCode.Q)){
            SwitchWeapon2();
        }
    }
    void SwitchWeapon1()
    {
        print("We Should Switch Weapons 1");
        weapon1Out = true;
        weapon2Out = false;
    }
    void SwitchWeapon2()
    {
        print("We Should Switch Weapons 2");
        weapon1Out = false;
        weapon2Out = true;
    }   
    
}
