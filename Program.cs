using static System.Console;

int xball = 50;
int yball = 1;
int xballlast;
int yballlast;
int xplayer = 50;
int yplayer = 30;
int balldir = 9;
int speed = 50;
int rplatform = 2;
int r;



Random rn = new Random();
Console.SetWindowSize(100, 40);
Console.SetBufferSize(100, 40);
int[,] blocks = new int[30, 96];
//for(int i = 0; i < 30; i++)
//{
//    for (int j = 0; j < 96; j++) blocks[i, j] = 0;
//}
//for (int i = 0; i < 30; i++)
//{
//    for (int j = 2; j < 96; j++) Console.Write(blocks[i, j]);
//    Console.WriteLine();
//}
for (int i = 0; i < 100; i++)
{
    SetCursorPosition(i, 0);
    Console.Write("█");
}
for (int i = 0; i < 40; i++)
{
    SetCursorPosition(0, i);
    Console.Write("██");
}
for (int i = 0; i < 40; i++)
{
    SetCursorPosition(98, i);
    Console.Write("██");
}
void PlatformUpdate()
{
    Console.SetCursorPosition(xplayer, yplayer);
    for (int i = 0; i < rplatform; i++)
    {
        Console.SetCursorPosition(xplayer + i, yplayer);
        Console.Write("_");
        Console.SetCursorPosition(xplayer - i, yplayer);
        Console.Write("_");
    }

    Console.SetCursorPosition(xplayer + rplatform, yplayer);
    Console.Write(" ");
    Console.SetCursorPosition(xplayer - rplatform, yplayer);
    Console.Write(" ");
    if (xplayer + rplatform + 2 <= 96 && xplayer - rplatform - 2 >= 3)
    {
        Console.SetCursorPosition(xplayer + rplatform + 1, yplayer);
        Console.Write(" ");
        Console.SetCursorPosition(xplayer - rplatform - 1, yplayer);
        Console.Write(" ");
    }
}
PlatformUpdate();

CursorVisible = false;
while (true)
{
    void Ball()
    {
        while (true)
        {
            xballlast = xball;
            yballlast = yball;

            if (xball < 4 && balldir == 14) balldir = 4;
            if (xball < 4 && balldir == 15) balldir = 3;
            if (xball < 4 && balldir == 16) balldir = 2;
            if (xball < 4 && balldir == 12) balldir = 6;
            if (xball < 4 && balldir == 11) balldir = 7;
            if (xball < 4 && balldir == 10) balldir = 8;

            if (xball > 95 && balldir == 4) balldir = 14;
            if (xball > 95 && balldir == 3) balldir = 15;
            if (xball > 95 && balldir == 2) balldir = 16;
            if (xball > 95 && balldir == 6) balldir = 12;
            if (xball > 95 && balldir == 7) balldir = 11;
            if (xball > 95 && balldir == 8) balldir = 10;

            if (yball < 3 && balldir == 1) balldir = 9;
            if (yball < 3 && balldir == 2) balldir = 8;
            if (yball < 3 && balldir == 3) balldir = 7;
            if (yball < 3 && balldir == 4) balldir = 6;
            if (yball < 3 && balldir == 16) balldir = 10;
            if (yball < 3 && balldir == 15) balldir = 11;
            if (yball < 3 && balldir == 14) balldir = 12;

            if (yball > 35 && balldir == 9) balldir = 1;
            if (yball > 35 && balldir == 8) balldir = 2;
            if (yball > 35 && balldir == 7) balldir = 3;
            if (yball > 35 && balldir == 6) balldir = 4;
            if (yball > 35 && balldir == 10) balldir = 16;
            if (yball > 35 && balldir == 11) balldir = 15;
            if (yball > 35 && balldir == 12) balldir = 14;


            if (balldir == 1) yball--;
            if (balldir == 9) yball++;
            //
            if (balldir == 3)
            {
                yball--;
                xball++;
            }
            if (balldir == 15)
            {
                yball--;
                xball--;
            }
            if (balldir == 7)
            {
                yball++;
                xball++;
            }
            if (balldir == 11)
            {
                yball++;
                xball--;
            }
            //
            if (balldir == 2)
            {
                yball -= 2;
                xball++;
            }
            if (balldir == 4)
            {
                yball--;
                xball += 2;
            }
            if (balldir == 6)
            {
                yball++;
                xball += 2;
            }
            if (balldir == 8)
            {
                yball += 2;
                xball++;
            }
            if (balldir == 10)
            {
                yball += 2;
                xball--;
            }
            if (balldir == 12)
            {
                yball++;
                xball -= 2;
            }
            if (balldir == 14)
            {
                yball--;
                xball -= 2;
            }
            if (balldir == 16)
            {
                yball -= 2;
                xball--;
            }



            PlatformUpdate();
            Console.SetCursorPosition(xballlast, yballlast);
            Console.Write(" ");
            Console.SetCursorPosition(xball, yball);
            Console.WriteLine("o");
            if (balldir == 1 || balldir == 9) Thread.Sleep(Convert.ToInt32(speed / Math.Sqrt(5)));
            if (balldir == 15 || balldir == 3) Thread.Sleep(Convert.ToInt32(speed / Math.Sqrt(2)));
            else Thread.Sleep(speed);


            if (rplatform == 2)
            {
                if (yball == yplayer && xball == xplayer)
                {
                    r = rn.Next(0, 3);
                    if (r == 0) balldir = 16;
                    if (r == 1) balldir = 1;
                    if (r == 2) balldir = 2;
                }
                if (yball == yplayer && xball == xplayer + 1)
                {
                    r = rn.Next(0, 2);
                    if (r == 0) balldir = 3;
                    if (r == 1) balldir = 4;
                }
                if (yball == yplayer && xball == xplayer - 1)
                {
                    r = rn.Next(0, 2);
                    if (r == 0) balldir = 14;
                    if (r == 1) balldir = 15;
                }
            }

        }
    }
    Task.Run(() => Ball());
    while (true)
    {
        var x = Console.ReadKey(true).Key;
        switch (x)
        {
            case ConsoleKey.A: if (xplayer - rplatform >= 3) xplayer--; break;
            case ConsoleKey.D: if (xplayer + rplatform <= 96) xplayer++; break;
        }
    }
}