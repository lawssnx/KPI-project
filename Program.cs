using System;
using System.Linq;
using System.Text;
using static System.Console;
using System.Diagnostics;


DateTime startTime = DateTime.Now;
string results = @"C:\Users\nasti\OneDrive\Рабочий стол\Новая папка\123.txt";

void Start()
{
    Console.CursorVisible = false;
    Thread.Sleep(700);
    Console.ForegroundColor = ConsoleColor.Magenta;
    string[] s = new string[6];
    CursorVisible = false;
    s[0] = "██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗    ████████╗ ██████╗     ███╗   ███╗ █████╗ ███████╗███████╗";
    s[1] = "██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝    ╚══██╔══╝██╔═══██╗    ████╗ ████║██╔══██╗╚══███╔╝██╔════╝";
    s[2] = "██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗         ██║   ██║   ██║    ██╔████╔██║███████║  ███╔╝ █████╗  ";
    s[3] = "██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝         ██║   ██║   ██║    ██║╚██╔╝██║██╔══██║ ███╔╝  ██╔══╝  ";
    s[4] = "╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗       ██║   ╚██████╔╝    ██║ ╚═╝ ██║██║  ██║███████╗███████╗";
    s[5] = " ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝       ╚═╝    ╚═════╝     ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝╚══════╝";
    
    for (int i = 0; i < s.Length; i++)
        for (int j = 0; j < s[i].Length; j++)
        {
            Console.SetCursorPosition(j, i);
            Console.WriteLine(s[i][j]);

            System.Threading.Thread.Sleep(1);
        }

    Console.WriteLine("Press Enter to Start...");
    ConsoleKeyInfo key = Console.ReadKey(); 
    if(key.Key.Equals(ConsoleKey.Enter))
    {
        Console.Clear();
    }
    else
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("But I told Enter!");
        Console.ForegroundColor = ConsoleColor.White;
        Environment.Exit(0);
        
    }
}

Start();
CursorVisible = false;

int x = 25; int y = 25;
int[,] maze = new int[y, x];
int[] xpath = new int[x * y];
int[] ypath = new int[x * y];
xpath[0] = 2; // first point
ypath[0] = 2;
int userx = 2; // user point
int usery = 2;
int[,] walked = new int[y, x]; // user was here
walked[2, 2] = 1;
int numbused = 1;
int randomused = 0;

for (int i = 0; i < y; i++)
{
    for (int j = 0; j < x; j++)
    {
        maze[i, j] = 1;
    }    
}//walls 1
for (int i = 1; i < y - 1; i++)
{
    for (int j = 1; j < x - 1; j++)
    {
        maze[i, j] = 0;
    }
}// space 0
for (int i = 1; i < y - 1; i++)
{
    for (int j = 0; j < x - 1; j++) if (i % 2 == 1 || j % 2 == 1)
        {
            maze[i, j] = 1;
        }
}// walls xx space

for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < x; j++)
    {
        maze[i, j] = 2;
    }
}// up edge
for (int i = y - 2; i < y; i++)
{
    for (int j = 0; j < x; j++)
    {
        maze[i, j] = 2;
    }
}// down edge
for (int j = 0; j < 2; j++)
{
    for (int i = 0; i < y; i++)
    {
        maze[i, j] = 2;
    }
}//left edge
for (int j = x - 2; j < x; j++)
{
    for (int i = 0; i < y; i++)
    {
        maze[i, j] = 2;
    }
}//right edge


Random rnd = new Random();
bool IsPostionWalkable = true; 
while (IsPostionWalkable == true)
{
    int path = rnd.Next(1, 5); // 1 - right, 2 - up, 3 - left, 4 - down

    if ((path == 1) && (maze[usery, userx + 2] == 0) && (walked[usery, userx + 2] != 1)) 
    {
        maze[usery, userx + 1] = 0; 
        userx += 2; 
        walked[usery, userx] = 1; 
        xpath[numbused] = userx;
        ypath[numbused] = usery; 
        numbused++; 
    } // right
    if ((path == 2) && (maze[usery - 2, userx] == 0) && (walked[usery - 2, userx] != 1)) 
    {
        maze[usery - 1, userx] = 0;
        usery -= 2;
        walked[usery, userx] = 1;
        xpath[numbused] = userx;
        ypath[numbused] = usery;
        numbused++;
    } // up
    if ((path == 3) && (maze[usery, userx - 2] == 0) && (walked[usery, userx - 2] != 1)) 
    {
        maze[usery, userx - 1] = 0;
        userx -= 2;
        walked[usery, userx] = 1;
        xpath[numbused] = userx;
        ypath[numbused] = usery;
        numbused++;
    } // left
    if ((path == 4) && (maze[usery + 2, userx] == 0) && (walked[usery + 2, userx] != 1)) 
    {
        maze[usery + 1, userx] = 0;
        usery += 2;
        walked[usery, userx] = 1;
        xpath[numbused] = userx;
        ypath[numbused] = usery;
        numbused++;
    } // down
    if ((maze[usery + 2, userx] == 2 || walked[usery + 2, userx] == 1) && (maze[usery - 2, userx] == 2 || walked[usery - 2, userx] == 1) && (maze[usery, userx + 2] == 2 || walked[usery, userx + 2] == 1) && (maze[usery, userx - 2] == 2 || walked[usery, userx - 2] == 1))
   
    {
        int rand = rnd.Next(1, numbused); 
        userx = xpath[rand]; 
        usery = ypath[rand]; 
        randomused++; 
      
    }
    if (randomused == x * y)
    {
        IsPostionWalkable = false;
    } 
        
}


int[,] maze2 = new int[y, x];
for (int i = 0; i < y; i++)
{
    for (int j = 0; j < x; j++)
    {
        maze2[i, j] = maze[i, j];
    }
}
userx = x - 3;
usery = y - 3;
bool go = true;
while (go == true)
{
    int way = rnd.Next(1, 5);
    if (way == 1 && maze2[usery, userx + 1] == 0)
    {
        maze2[usery, userx] = -1;
        userx++;
    } // go right
    else if (way == 2 && maze2[usery - 1, userx] == 0)
    {
        maze2[usery, userx] = -1;
        usery--;
    } // go up
    else if (way == 3 && maze2[usery, userx - 1] == 0)
    {
        maze2[usery, userx] = -1;
        userx--;
    } // go left
    else if (way == 4 && maze2[usery + 1, userx] == 0)
    {
        maze2[usery, userx] = -1;
        usery++;
    } // go down
    
    if (userx == 2 && usery == 2)
    {
        maze2[usery, userx] = -1;
        go = false;
    }
    else if (maze2[usery + 1, userx] != 0 && maze2[usery - 1, userx] != 0 && maze2[usery, userx + 1] != 0 && maze2[usery, userx - 1] != 0)
    {
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                maze2[i, j] = maze[i, j];
            }
        }
        userx = x - 3;
        usery = y - 3;
    }

}

int trap = Convert.ToInt32(Math.Sqrt(x * y));
while (trap > 0)
{
    int trapx = rnd.Next(2, x - 2);
    int miny = rnd.Next(2, x - 2);
    if (maze2[miny, trapx] == 0)
    {
        maze[miny, trapx] = -2;
        trap--;
    }
}

maze[2, 2] = 6;
maze[y - 3, x - 3] = 9;
for (int i = 0; i < y; i++) //print
{
    for (int j = 0; j < x; j++)
    {
        if (maze[i, j] == 1)
        {
            Console.ForegroundColor = ConsoleColor.Black;
        } // Wall 
        if (maze[i, j] == 0)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        } // Space
        if (maze[i, j] == 2)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
        } // edge
        if (maze[i, j] == -1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        } // end
        if (maze[i, j] == -2)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        } // trap
        if (maze[i, j] == 6)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        } // guy
        if (maze[i, j] == 9)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        } // win
        Console.Write("██");
       
    }
    Console.WriteLine();
}
userx = 2;
usery = 2;
int cursy = 2;
int cursx = 4;
bool win = false;
while (win == false)
{
    var ch = Console.ReadKey(true).Key;
    switch (ch)
    {
        case ConsoleKey.D:
            if (maze[usery, userx + 1] == 0)
            {
                maze[usery, userx] = 0;
                userx++;
                maze[usery, userx] = 6;
                Console.SetCursorPosition(cursx, cursy);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("██");
                cursx += 2;
                Console.SetCursorPosition(cursx, cursy);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("██");
            }
            else if (maze[usery, userx + 1] == -2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"
 ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄       ▄            ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄      
▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌     ▐░▌          ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     
▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌     ▐░▌          ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀      
▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌▐░▌          ▐░▌               
▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄      
▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     
 ▀▀▀▀█░█▀▀▀▀ ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌ ▀▀▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀      
     ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌          ▐░▌▐░▌               
     ▐░▌     ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌ ▄▄▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄      
     ▐░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     
      ▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀      
                                                                                                     
");
                Console.WriteLine("It happens, don't worry)");
                win = false;
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
            else if (maze[usery, userx + 1] == 9)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"
 ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄       ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄  ▄ 
▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌     ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░▌      ▐░▌▐░▌
▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌     ▐░▌       ▐░▌ ▀▀▀▀█░█▀▀▀▀ ▐░▌░▌     ▐░▌▐░▌
▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌       ▐░▌     ▐░▌     ▐░▌▐░▌    ▐░▌▐░▌
▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌   ▄   ▐░▌     ▐░▌     ▐░▌ ▐░▌   ▐░▌▐░▌
▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌  ▐░▌  ▐░▌     ▐░▌     ▐░▌  ▐░▌  ▐░▌▐░▌
 ▀▀▀▀█░█▀▀▀▀ ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌ ▐░▌░▌ ▐░▌     ▐░▌     ▐░▌   ▐░▌ ▐░▌▐░▌
     ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌▐░▌ ▐░▌▐░▌     ▐░▌     ▐░▌    ▐░▌▐░▌ ▀ 
     ▐░▌     ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░▌░▌   ▐░▐░▌ ▄▄▄▄█░█▄▄▄▄ ▐░▌     ▐░▐░▌ ▄ 
     ▐░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░▌     ▐░░▌▐░░░░░░░░░░░▌▐░▌      ▐░░▌▐░▌
      ▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀       ▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀        ▀▀  ▀ 
                                                                                      
");
                win = true;
            }
            break;
        case ConsoleKey.A:
            if (maze[usery, userx - 1] == 0)
            {
                maze[usery, userx] = 0;
                userx--;
                maze[usery, userx] = 6;
                Console.SetCursorPosition(cursx, cursy);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("██");
                cursx -= 2;
                Console.SetCursorPosition(cursx, cursy);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("██");
            }
            else if (maze[usery, userx - 1] == -2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"
 ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄       ▄            ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄      
▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌     ▐░▌          ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     
▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌     ▐░▌          ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀      
▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌▐░▌          ▐░▌               
▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄      
▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     
 ▀▀▀▀█░█▀▀▀▀ ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌ ▀▀▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀      
     ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌          ▐░▌▐░▌               
     ▐░▌     ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌ ▄▄▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄      
     ▐░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     
      ▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀      
                                                                                                     
");
                Console.WriteLine("It happens, don't worry)");
                win = false;
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
            else if (maze[usery, userx - 1] == 9)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"
 ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄       ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄  ▄ 
▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌     ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░▌      ▐░▌▐░▌
▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌     ▐░▌       ▐░▌ ▀▀▀▀█░█▀▀▀▀ ▐░▌░▌     ▐░▌▐░▌
▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌       ▐░▌     ▐░▌     ▐░▌▐░▌    ▐░▌▐░▌
▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌   ▄   ▐░▌     ▐░▌     ▐░▌ ▐░▌   ▐░▌▐░▌
▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌  ▐░▌  ▐░▌     ▐░▌     ▐░▌  ▐░▌  ▐░▌▐░▌
 ▀▀▀▀█░█▀▀▀▀ ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌ ▐░▌░▌ ▐░▌     ▐░▌     ▐░▌   ▐░▌ ▐░▌▐░▌
     ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌▐░▌ ▐░▌▐░▌     ▐░▌     ▐░▌    ▐░▌▐░▌ ▀ 
     ▐░▌     ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░▌░▌   ▐░▐░▌ ▄▄▄▄█░█▄▄▄▄ ▐░▌     ▐░▐░▌ ▄ 
     ▐░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░▌     ▐░░▌▐░░░░░░░░░░░▌▐░▌      ▐░░▌▐░▌
      ▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀       ▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀        ▀▀  ▀ 
                                                                                      
");
                win = true;
            }
            break;
        case ConsoleKey.W:
            if (maze[usery - 1, userx] == 0)
            {
                maze[usery, userx] = 0;
                usery--;
                maze[usery, userx] = 6;
                Console.SetCursorPosition(cursx, cursy);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("██");
                cursy--;
                Console.SetCursorPosition(cursx, cursy);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("██");
            }
            else if (maze[usery - 1, userx] == -2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"
 ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄       ▄            ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄      
▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌     ▐░▌          ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     
▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌     ▐░▌          ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀      
▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌▐░▌          ▐░▌               
▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄      
▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     
 ▀▀▀▀█░█▀▀▀▀ ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌ ▀▀▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀      
     ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌          ▐░▌▐░▌               
     ▐░▌     ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌ ▄▄▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄      
     ▐░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     
      ▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀      
                                                                                                     
");
                Console.WriteLine("It happens, don't worry)");
                win = false;
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
            else if (maze[usery - 1, userx] == 9)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"
 ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄       ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄  ▄ 
▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌     ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░▌      ▐░▌▐░▌
▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌     ▐░▌       ▐░▌ ▀▀▀▀█░█▀▀▀▀ ▐░▌░▌     ▐░▌▐░▌
▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌       ▐░▌     ▐░▌     ▐░▌▐░▌    ▐░▌▐░▌
▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌   ▄   ▐░▌     ▐░▌     ▐░▌ ▐░▌   ▐░▌▐░▌
▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌  ▐░▌  ▐░▌     ▐░▌     ▐░▌  ▐░▌  ▐░▌▐░▌
 ▀▀▀▀█░█▀▀▀▀ ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌ ▐░▌░▌ ▐░▌     ▐░▌     ▐░▌   ▐░▌ ▐░▌▐░▌
     ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌▐░▌ ▐░▌▐░▌     ▐░▌     ▐░▌    ▐░▌▐░▌ ▀ 
     ▐░▌     ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░▌░▌   ▐░▐░▌ ▄▄▄▄█░█▄▄▄▄ ▐░▌     ▐░▐░▌ ▄ 
     ▐░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░▌     ▐░░▌▐░░░░░░░░░░░▌▐░▌      ▐░░▌▐░▌
      ▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀       ▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀        ▀▀  ▀ 
                                                                                      
");
                win = true;
            }
            break;
        case ConsoleKey.S:
            if (maze[usery + 1, userx] == 0)
            {
                maze[usery, userx] = 0;
                usery++;
                maze[usery, userx] = 6;
                Console.SetCursorPosition(cursx, cursy);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("██");
                cursy++;
                Console.SetCursorPosition(cursx, cursy);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("██");
            }
            else if (maze[usery + 1, userx] == -2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"
 ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄       ▄            ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄      
▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌     ▐░▌          ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     
▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌     ▐░▌          ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀      
▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌▐░▌          ▐░▌               
▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄      
▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     
 ▀▀▀▀█░█▀▀▀▀ ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌ ▀▀▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀      
     ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌       ▐░▌          ▐░▌▐░▌               
     ▐░▌     ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌ ▄▄▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄      
     ▐░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     
      ▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀      
                                                                                                     
");
                Console.WriteLine("It happens, don't worry)");
                win = false;
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
            else if (maze[usery + 1, userx] == 9)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"
 ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄       ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄  ▄ 
▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌     ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░▌      ▐░▌▐░▌
▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌     ▐░▌       ▐░▌ ▀▀▀▀█░█▀▀▀▀ ▐░▌░▌     ▐░▌▐░▌
▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌       ▐░▌     ▐░▌     ▐░▌▐░▌    ▐░▌▐░▌
▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌   ▄   ▐░▌     ▐░▌     ▐░▌ ▐░▌   ▐░▌▐░▌
▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌  ▐░▌  ▐░▌     ▐░▌     ▐░▌  ▐░▌  ▐░▌▐░▌
 ▀▀▀▀█░█▀▀▀▀ ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌ ▐░▌░▌ ▐░▌     ▐░▌     ▐░▌   ▐░▌ ▐░▌▐░▌
     ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌▐░▌ ▐░▌▐░▌     ▐░▌     ▐░▌    ▐░▌▐░▌ ▀ 
     ▐░▌     ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░▌░▌   ▐░▐░▌ ▄▄▄▄█░█▄▄▄▄ ▐░▌     ▐░▐░▌ ▄ 
     ▐░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░▌     ▐░░▌▐░░░░░░░░░░░▌▐░▌      ▐░░▌▐░▌
      ▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀       ▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀        ▀▀  ▀ 
                                                                                      
");
                win = true;
            }
            break;
    }
}


void Results()
{
    DateTime exitTime = DateTime.Now;
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Blue;
    TimeSpan time = exitTime - startTime;
    Console.Write($"Time you've spent: {time}");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.White;
    string tab = File.ReadAllText(results);
    Console.WriteLine();
    Console.WriteLine("Previous results:");
    Console.WriteLine();
    foreach (char s in tab)
    {
        if (s != ' ') Console.Write(s);
        else Console.WriteLine();
    }

    if (win == true)
    {
        File.AppendAllText(results, Convert.ToString(time));
        File.AppendAllText(results, " ");
    }
    
}
Results();
Console.ReadKey();  

