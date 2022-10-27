Random rnd = new Random();


string x = ""; // temp - ignore
string vehType;
string[] fuelTypes = {"unleaded","diesel","LPG"};
string fuelType; // for current vehicle
int[] fuelPrices = {150,175,200};
int fuelPrice; // for current vehicle
int carCap = 50;
int vanCap = 80;
int HGVCap = 150;
int fuelCap = 0;
int curFill; // how full the vehicle is when it arrives
int randNum = 0;
int fuelTime = 0;



string fill()
{
    switch(vehType)
    {
        case "c":
        randNum = rnd.Next(0,3);
        fuelCap = carCap;
        break;

        case "v":
        randNum = rnd.Next(1,3);
        fuelCap = vanCap;
        break;

        case "h":
        randNum = 2;
        fuelCap = HGVCap;
        break;
    }
    curFill = rnd.Next(0,(fuelCap/2));
    fuelType = fuelTypes[randNum];
    fuelPrice = fuelPrices[randNum];
    
    x = curFill + " " + fuelType + " " + fuelPrice;

    return x;
}

for(int i = 0; i < 5; i++
){
Console.Write("Please enter vehicle type (c, v or h): ");
vehType = Console.ReadLine();
vehType = vehType.ToLower();

Console.WriteLine(fill());
}
Console.ReadKey();