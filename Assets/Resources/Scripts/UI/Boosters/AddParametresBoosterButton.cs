
public class AddParametresBoosterButton : BoosterButton
{


    protected override void UseButtonPersonal()
    {
       // Bank.MinusBooster1(1);

        library.carUserParametres.AddAllParametres();
        library.car.GetComponent<CarController>().UpdateMaxSpeed();
        library.energy.UpdateNitroCost();
    }


    protected override void UpdateCount()
    {
       // count.text = Bank.GetBooster1() + "";
    }
}