Random rnd = new Random();

Processing vehProccess = new Processing();

List<string> queue = new List<string>();
string vehStats = ""; // temp - ignore
string vehType = "";
string[] fuelTypes = { "unleaded", "diesel", "LPG" };
string fuelType; // for current vehicle
int[] fuelPrices = { 150, 175, 75 };
int fuelPrice; // for current vehicle
int carCap = 50;
int vanCap = 80;
int HGVCap = 150;
int fuelCap = 0;
int curFill; // how full the vehicle is when it arrives
int randNum = 0;
int vehTypeNum = 0;
int timerInterval = 0;
int vehServiced;
int vehLeft;
int clock = 0;

void clockIncrease(object o)
{
    clock += 10;
}

void addToQueue(object o)
{

    if (queue.Count() > 4)
    {
        Console.WriteLine("Queue is full");
    }

    else
    {
        queue.Add(vehCreator());
    }

}

void userInterface(object o)
{
    Console.Clear();
    displayQueue();
}

void queueToPump(object o)
{
    if (queue.Count() == 0)
    {Console.WriteLine("Queue is empty");}
    else
    {
    vehProccess.setVehStats(queue[0]);
    Console.WriteLine($"{vehProccess.getVehType()}\n{vehProccess.getCurFill()}\n{vehProccess.getFuelType()}\n{vehProccess.getFuelPrice()}\n{vehProccess.getJoinTime()}");
    queue.RemoveAt(0);
    }
}

void displayQueue()
{
    Console.WriteLine("Queue:");
    for (int i = 0; i < queue.Count(); i++)
    {
        Console.WriteLine($"{(i + 1)}: {queue[i]}");
    }
}

string vehCreator()
{


    vehTypeNum = rnd.Next(0, 3);
    switch (vehTypeNum)
    {
        case 0:
            vehType = "c";
            randNum = rnd.Next(0, 3);
            fuelCap = carCap;
            break;

        case 1:
            vehType = "v";
            randNum = rnd.Next(1, 3);
            fuelCap = vanCap;
            break;

        case 2:
            vehType = "h";
            randNum = 1;
            fuelCap = HGVCap;
            break;
    }
    curFill = rnd.Next(1, (fuelCap / 2));
    fuelType = fuelTypes[randNum];
    fuelPrice = fuelPrices[randNum];

    vehStats = vehType.ToUpper() + " " + curFill + " " + fuelType + " " + fuelPrice + " " + clock;

    return vehStats;
}

Timer clockTimer = new Timer(clockIncrease, null, 0, 10);
Timer queueTimer = new Timer(addToQueue, null, 0, (rnd.Next(1500, 2200)));
Timer UITimer = new Timer(userInterface, null, 0, 250);
//Timer queueToPumpTimer = new Timer(queueToPump, null, 0, 25);

Console.ReadKey();





/*while (true)
{
    Console.WriteLine("clock: "+clock);
    while (queue.Count() < 5)
    {
        Console.WriteLine("clock: "+clock);
        if (queue.Count() > 4)
        {
            Console.WriteLine("Queue is full");
        }

        else
        {
            queue.Add(vehCreator());
        }

        Console.WriteLine("Queue:");
        for (int i = 0; i < queue.Count(); i++)
        {
            Console.WriteLine($"{(i + 1)}: {queue[i]}");
        }

        timerInterval = rnd.Next(1500, 2200);
        Thread.Sleep(timerInterval);
        Console.Clear();

    }

    vehProccess.setVehStats(queue[0]);
    Console.WriteLine($"{vehProccess.getVehType()}\n{vehProccess.getCurFill()}\n{vehProccess.getFuelType()}\n{vehProccess.getFuelPrice()}");
    queue.RemoveAt(0);

}*/







