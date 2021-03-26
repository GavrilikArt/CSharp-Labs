using System;
using System.Drawing;

namespace Lab4.GDI
{
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Support such commands: fillellips:color:x:y:width:heigt, fillrectangle:x:y:width:height, drawBezier:color:startX:startY:endX:endY, drawClosedCurve:Color:CoordinatesOfPoint(Infinite)");
            Console.WriteLine("Support such colours: red, white, blue, green, magenta, olive, orange, yellow");
            bool wantToDraw = true;
            do {
                bool wasDrawn;
                do {
                    wasDrawn = false;
                    Console.WriteLine("Enter command, for instance fillellips:red:10:10:100:200");
                    string command = Console.ReadLine();
                    command = command.Replace(" ", "");
                    command = command.ToLower();
                    string[] parsedCommand = command.Split(':');
                    if (parsedCommand[0] == "fillellips") {
                        try {
                            Color color = StringToColor(parsedCommand[1]);
                            int x = Convert.ToInt32(parsedCommand[2]);
                            int y = Convert.ToInt32(parsedCommand[3]);
                            int width = Convert.ToInt32(parsedCommand[4]);
                            int height = Convert.ToInt32(parsedCommand[5]);  
                            Drawing.FillEllips(color, x, y, width, height);
                            wasDrawn = true;
                        }
                        catch (Exception ex) {
                            Console.WriteLine($"Can't work with such command: {ex.Message}");
                        }
                    }
                    else if (parsedCommand[0] == "fillrectangle") {
                        try {
                            Color color = StringToColor(parsedCommand[1]);
                            int x = Convert.ToInt32(parsedCommand[2]);
                            int y = Convert.ToInt32(parsedCommand[3]);
                            int width = Convert.ToInt32(parsedCommand[4]);
                            int height = Convert.ToInt32(parsedCommand[5]);
                            Drawing.FillRectangle(color, x, y, width, height);
                            wasDrawn = true;
                        }
                        catch (Exception ex) {
                            Console.WriteLine($"Can't work with such command: {ex.Message}");
                        }
                    } else if (parsedCommand[0] == "drawbezier")
                    {
                        int x = Convert.ToInt32(parsedCommand[2]);
                        int y = Convert.ToInt32(parsedCommand[3]);
                        int x1 = Convert.ToInt32(parsedCommand[4]);
                        int y1 = Convert.ToInt32(parsedCommand[5]);
                        Drawing.DrawBezier(color: parsedCommand[1], x, y, x1, y1);
                    } else if (parsedCommand[0] == "drawclosedcurve")
                    {
                        Color color = StringToColor(parsedCommand[1]);
                        int[] coords = new int[parsedCommand.Length - 2];
                        for (int i = 2; i < parsedCommand.Length; ++i)
                        {
                            coords[i - 2] = Convert.ToInt32(parsedCommand[i]);
                        }
                        Drawing.DrawClosedCurve(color, coords);
                    }
                    else {
                        Console.WriteLine($"There is no such command {parsedCommand[0]}");
                    }
                } while (!wasDrawn);
                Console.WriteLine("Want to continue? (hit escape to leave, any other - stay): ");
                ConsoleKeyInfo proposal = Console.ReadKey();
                if(proposal.Key == ConsoleKey.Escape) {
                    wantToDraw = false;
                }
            } while (wantToDraw);
        }
        static Color StringToColor(string colorStr) {
            Color color;
            if (colorStr == "red") {
                color = Color.Red;
            } else if (colorStr == "yellow") {
                color = Color.Yellow;
            } else if (colorStr == "blue") {
                color = Color.Blue;
            } else if (colorStr == "magenta") {
                color = Color.Magenta;
            } else if (colorStr == "white") {
                color = Color.White;
            } else if(colorStr == "green") {
                color = Color.Green;
            } else if(colorStr == "olive") {
                color = Color.Olive;
            } else if(colorStr == "orange") {
                color = Color.Orange;
            } 
            else {
                throw new Exception($"No existing color {colorStr}");
            }
            return color;
        }
    }
}