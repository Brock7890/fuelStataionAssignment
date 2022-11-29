Random rnd = new Random();

Processing vehProccess = new Processing();
Pumps foreCourt = new Pumps();

List<string> queue = new List<string>();
string[] fuelTypes = { "unleaded", "diesel", "LPG" };
string vehStats = "";
string vehType = "";
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
int vehServiced = 0;
int vehLeft = 0;
int clock = 0;
bool isQueueEmpty = true;
bool isQueueFull = false;

void clockIncrease(object o)
{
    clock += 50;
}

void addToQueue(object o)
{

    if (queue.Count() > 4)
    {
        isQueueFull = true;
    }

    else
    {
        isQueueFull = false;
        isQueueEmpty = false;
        queue.Add(vehCreator());
        userInterface("");
    }

}

void userInterface(object o)
{
    Console.Clear();
    foreCourt.displayForecourt();
    queueFull();
    queueEmpty();
    displayQueue();
    Console.WriteLine($"{vehLeft} vehicles have left.");
}

void queueToPumpCheck(object o)
{
    if (queue.Count() > 0)
    {
        queueToPump();
    }
}

void queueToPump()
{
    int pumpNum = foreCourt.getFreePump();
    if (queue.Count() != 0 && pumpNum != -1 && foreCourt.isForecourtAvailable())
    {

        isQueueEmpty = false;
        vehProccess.setVehStats(queue[0]);
        foreCourt.setPumpInfo(vehProccess.getVehType(), vehProccess.getCurFill(), vehProccess.getFuelType(), vehProccess.getJoinTime(), vehProccess.getLeaveTime(), pumpNum);
        queue.RemoveAt(0);

    }
    else if (queue.Count() == 0)
    {
        isQueueEmpty = true;

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

void queueFull()
{
    if (isQueueFull)
    {
        Console.WriteLine("Queue is full");
    }
}

void queueEmpty()
{
    if (isQueueEmpty)
    {
        Console.WriteLine("Queue is empty");
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


    vehStats = vehType.ToUpper() + " " + curFill + " " + fuelType + " " + clock + " " + (clock + rnd.Next(1000, 2000));

    return vehStats;
}

void leaveQueue(object o)
{
    for (int i = 0; i < queue.Count(); i++)
    {
        vehProccess.setVehStats(queue[0]);
        if (clock >= vehProccess.getLeaveTime())
        {
            queue.RemoveAt(0);
            vehLeft++;
            userInterface("");
        }
    }
}

Timer clockTimer = new Timer(clockIncrease, null, 0, 50);

Timer queueTimer = new Timer(addToQueue, null, (rnd.Next(1500, 2200)), (rnd.Next(1500, 2200)));

Timer UITimer = new Timer(userInterface, null, 0, 1500);

Timer queueToPumpTimer = new Timer(queueToPumpCheck, null, 0, 50);

Timer leaveQueueTimer = new Timer(leaveQueue, null, 0, 50);



Console.ReadKey();

