public interface IHealth
{
    float StartHp { get; set; }
    float CurrentHp { get; set; }
    void LooseHP(float amount, float initDamage, IScore source);
    void LooseHpDOT(float amount, IScore source);
}