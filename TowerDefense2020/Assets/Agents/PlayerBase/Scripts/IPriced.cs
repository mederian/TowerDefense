public interface IPriced
{
    int GoldCost { get; set; }
    int ManaCost { get; set; }
    int FrostCost { get; set; }
    int PoisonCost { get; set; }
    int FireCost { get; set; }

    bool isAffordable();
    void SubtractCost();
}