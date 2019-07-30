using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{

    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmmount;
        public Text ammoHUD;
    }

    void Awake()
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            slot.ammoHUD.text = slot.ammoAmmount.ToString();
        }
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmmount;   
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmmount--;
        SetAmmoHUDText(ammoType);
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }

        return null;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmmount += ammoAmount;
        SetAmmoHUDText(ammoType);
    }

    private void SetAmmoHUDText(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoHUD.text = (GetAmmoSlot(ammoType).ammoAmmount).ToString();
    }
}
