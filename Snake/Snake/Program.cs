using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Point food = new Point();
            bool isFoodAvailable = false;
            int direction = 0; //0 sağ 1 sol 2 yukarı 3 aşağı
            int point = 0;
            int speed = 100;
            int[,] snakeArray;
            snakeArray = new int[28,60];
            Queue<Point> snakeQueue = new Queue<Point>();

            for (int counter = 1; counter <= 28; counter++)
            {
                
                    if(counter == 1 || counter == 28)
                    {
                    Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");//60
                    }
                    else
                    {
                    Console.WriteLine("x                                                          x");
                    }
                
            }

            snakeArray[13,30] = 1;
            snakeArray[13,31] = 1;
            snakeArray[13,32] = 1;
            snakeArray[13, 33] = 1;
            snakeArray[13, 34] = 1;
            snakeArray[13, 35] = 1;

            snakeQueue.Enqueue(new Point(13, 30));
            snakeQueue.Enqueue(new Point(13, 31));
            snakeQueue.Enqueue(new Point(13, 32));
            snakeQueue.Enqueue(new Point(13, 33));
            snakeQueue.Enqueue(new Point(13, 34));
            snakeQueue.Enqueue(new Point(13, 35));

            Console.SetCursorPosition(30, 13);
            Console.Write("O");
            Console.SetCursorPosition(31, 13);
            Console.Write("O");
            Console.SetCursorPosition(32, 13);
            Console.Write("O");
            Console.SetCursorPosition(33, 13);
            Console.Write("O");
            Console.SetCursorPosition(34, 13);
            Console.Write("O");
            Console.SetCursorPosition(35, 13);
            Console.Write("O");


            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey c = Console.ReadKey(true).Key;
                    if (c == ConsoleKey.UpArrow && direction != 3) { direction = 2; }
                    else if (c == ConsoleKey.DownArrow && direction != 2) { direction = 3; }
                    else if (c == ConsoleKey.RightArrow && direction != 1) { direction = 0; }
                    else if (c == ConsoleKey.LeftArrow && direction != 0) { direction = 1; }
                    else { }
                }

                if (isFoodAvailable == false)
                {
                    bool control = true;

                    while (control)
                    {
                        Random rnd = new Random();
                        int x = rnd.Next(1, 26);
                        int y = rnd.Next(1, 58);
                        if (snakeArray[x, y] == 0)
                        {
                            Console.SetCursorPosition(y, x);
                            Console.Write("F");
                            food.x = x;
                            food.y = y;
                            control = false;
                        }
                        
                    }

                    isFoodAvailable = true;

                }

                Point[] arr = snakeQueue.ToArray();

                if (direction == 1)//sol
                {
                    Thread.Sleep(speed);

                    if (arr[arr.Length - 1].y - 1 == 0 || snakeArray[arr[arr.Length - 1].x,arr[arr.Length - 1].y - 1]==1)
                        break;
                   
                    if(arr[arr.Length - 1].x == food.x && arr[arr.Length - 1].y - 1 == food.y)
                    {
                        isFoodAvailable = false;
                        point = point + 10;
                    }
                    else
                    {
                        Point p = snakeQueue.Dequeue();
                        snakeArray[p.x, p.y] = 0;
                        Console.SetCursorPosition(p.y, p.x);
                        Console.Write(" ");
                    }                    

                    Point p2 = new Point(arr[arr.Length - 1].x, arr[arr.Length - 1].y - 1);                    
                    Console.SetCursorPosition(arr[arr.Length - 1].y - 1, arr[arr.Length - 1].x);
                    
                    Console.Write("O");
                    snakeArray[arr[arr.Length - 1].x, arr[arr.Length - 1].y - 1] = 1;

                    snakeQueue.Enqueue(p2);
                }

                else if (direction == 0)//sağa
                {
                    Thread.Sleep(speed);

                    if (arr[arr.Length - 1].y + 1 == 59 || snakeArray[arr[arr.Length - 1].x, arr[arr.Length - 1].y + 1]==1)
                        break;

                    if(arr[arr.Length - 1].x == food.x && arr[arr.Length - 1].y + 1 == food.y)
                    {
                        isFoodAvailable = false;
                        point = point + 10;
                    }
                    else
                    {
                        Point p = snakeQueue.Dequeue();
                        snakeArray[p.x, p.y] = 0;
                        Console.SetCursorPosition(p.y, p.x);
                        Console.Write(" ");
                    }                    

                    Point p2 = new Point(arr[arr.Length - 1].x, arr[arr.Length - 1].y + 1);
                    Console.SetCursorPosition(arr[arr.Length - 1].y + 1, arr[arr.Length - 1].x );
                    if (arr[arr.Length - 1].y + 1 == 59)
                        break;
                    Console.Write("O");
                    snakeArray[arr[arr.Length - 1].x, arr[arr.Length - 1].y + 1] = 1;

                    snakeQueue.Enqueue(p2);
                }                

                else if (direction == 2)//yukarı
                {
                    Thread.Sleep(speed);

                    if (arr[arr.Length - 1].x - 1 == 0 || snakeArray[arr[arr.Length - 1].x - 1, arr[arr.Length - 1].y] == 1)
                        break;

                    if(arr[arr.Length - 1].x - 1 == food.x && arr[arr.Length - 1].y == food.y)
                    {
                        isFoodAvailable = false;
                        point = point + 10;
                    }
                    else
                    {
                        Point p = snakeQueue.Dequeue();
                        snakeArray[p.x, p.y] = 0;
                        Console.SetCursorPosition(p.y, p.x);
                        Console.Write(" ");
                    }                    

                    Point p2 = new Point(arr[arr.Length - 1].x - 1, arr[arr.Length - 1].y);
                    Console.SetCursorPosition(arr[arr.Length - 1].y, arr[arr.Length - 1].x - 1);
                    Console.Write("O");
                    snakeArray[arr[arr.Length - 1].x - 1, arr[arr.Length - 1].y] = 1;

                    snakeQueue.Enqueue(p2);
                }

                else if (direction == 3)//aşağı
                {
                    Thread.Sleep(speed);

                    if (arr[arr.Length - 1].x + 1 == 27 || snakeArray[arr[arr.Length - 1].x + 1, arr[arr.Length - 1].y]==1)
                        break;

                    if(arr[arr.Length - 1].x + 1 == food.x && arr[arr.Length - 1].y == food.y)
                    {
                        isFoodAvailable = false;
                        point = point + 10;
                    }
                    else
                    {
                        Point p = snakeQueue.Dequeue();
                        snakeArray[p.x, p.y] = 0;
                        Console.SetCursorPosition(p.y, p.x);
                        Console.Write(" ");
                    }                    

                    Point p2 = new Point(arr[arr.Length - 1].x + 1 , arr[arr.Length - 1].y);
                    Console.SetCursorPosition(arr[arr.Length - 1].y , arr[arr.Length - 1].x + 1);
                    Console.Write("O");
                    snakeArray[arr[arr.Length - 1].x + 1, arr[arr.Length - 1].y] = 1;

                    snakeQueue.Enqueue(p2);
                }                            

            }           

            Console.ReadLine();
        }
    }
}
