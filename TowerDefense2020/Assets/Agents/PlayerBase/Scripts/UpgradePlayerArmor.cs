using UnityEngine;

[RequireComponent(typeof(PlayerArmor))]
public class UpgradePlayerArmor : MonoBehaviour, IUpgradePlayerArmor, IPriced, IDealWithResources
{
    [SerializeField] private float upgradeArmorModifier = 3.5f;
    [SerializeField] private float upgradeDMGReductionModifier = 2.5f;
    private bool maxedChanceToHit = false;
    private bool maxedDR = false;
    private PlayerArmor playerArmor;

    [SerializeField] private int goldCost = 5;
    [SerializeField] private int manaCost = 5;
    [SerializeField] private int frostCost = 5;
    [SerializeField] private int poisonCost = 5;
    [SerializeField] private int fireCost = 5;
    private _Resources resources;

    public int GoldCost { get => goldCost; set => goldCost = value; }
    public int ManaCost { get => manaCost; set => manaCost = value; }
    public int FrostCost { get => frostCost; set => frostCost = value; }
    public int PoisonCost { get => poisonCost; set => poisonCost = value; }
    public int FireCost { get => fireCost; set => fireCost = value; }

    public void Start()
    {
        playerArmor = this.GetComponent<PlayerArmor>();
    }
    public void UpgradeArmor()
    {
        if (!maxedChanceToHit && !maxedDR)
        {
            if (isAffordable())
            {
                UpgradeChanceToHit();
                UpgradeDamageReduction();
                SubtractCost();
            }
        }
    }
    private void UpgradeChanceToHit()
    {
        // Setting max chance to it 70%
        float maxValueChanceToHit = 70f;

        if (playerArmor.ChanceToHit + upgradeArmorModifier > maxValueChanceToHit)
        {
            playerArmor.ChanceToHit = maxValueChanceToHit;
            maxedChanceToHit = false;
        }
        else
        {
            playerArmor.ChanceToHit += upgradeArmorModifier;
        }
    }
    public void UpgradeDamageReduction()
    {
        if (upgradeDMGReductionModifier + playerArmor.DamageReduction >= 50.0f)
        {
            playerArmor.DamageReduction = 50.0f; //Maxing dmg reduction to 50%
            maxedDR = true;
        }
        else
        {
            playerArmor.DamageReduction += upgradeDMGReductionModifier;

        }
    }

    public bool isAffordable()
    {
        if (resources == null)
        {
            resources = GameObject.Find("UserInterface").GetComponent<ResourceManager>().GetResources();
        }
        if (resources.mainResource.value >= goldCost && resources.aoeResource.value >= fireCost &&
                resources.slowResource.value >= frostCost && resources.dotResource.value >= poisonCost &&
                resources.rangeResource.value >= manaCost)
        {
            return true;
        }
        return false;
    }

    public void SubtractCost()
    {
        if (resources == null)
        {
            resources = GameObject.Find("UserInterface").GetComponent<ResourceManager>().GetResources();
        }
        resources.mainResource.value -= goldCost;
        resources.aoeResource.value -= fireCost;
        resources.slowResource.value -= frostCost;
        resources.dotResource.value -= poisonCost;
        resources.rangeResource.value -= manaCost;
    }

    public void InjectResources(_Resources resources)
    {
        this.resources = resources;
    }
}