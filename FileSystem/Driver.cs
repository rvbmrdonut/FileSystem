﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    /// <summary>
    /// The Driver class reads input line by line and executes the correct function based on input.
    /// </summary>
    class Driver
    {
        static void Main(string[] args)
        {
            var fileSystem = FileSystem.Instance;

            var userEntry = "";
            int handle;

            while (true)
            {
                userEntry = Console.ReadLine();               
                var tokens = userEntry.Split(' ');

                switch (tokens[0].ToLower())
                {
                    case "cr":
                        try
                        {
                            if (fileSystem.Create(tokens[1] + "\0"))
                                Console.WriteLine(tokens[1] + " created");                         
                        }
                        catch (Exception e) { }
                        break;
                    case "de":
                        fileSystem.Destroy(tokens[1]);
                        break;
                    case "op":
                        handle = fileSystem.Open(tokens[1]);
                        break;
                    case "cl":
                        try
                        {
                            fileSystem.Close(Convert.ToInt32(tokens[1]));
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Parameter is not a valid integer");
                        }
                        
                        break;
                    case "rd":
                        try
                        {
                            fileSystem.Read(Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens[2]));
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Invalid read call: rd <index> <count>");
                        }
                        
                        break;
                    case "wr":
                        try
                        {
                            fileSystem.Write(Convert.ToInt32(tokens[1]), Convert.ToChar(tokens[2]), Convert.ToInt32(tokens[3]));
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Invalid read call: rd <index> <char> <count>");
                        }
                        break;
                    case "sk":
                        try
                        {
                            fileSystem.Lseek(Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens[2]));
                            Console.WriteLine("Position is " + Convert.ToInt32(tokens[2]));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error seeking");
                        }
                        break;
                    case "dr":
                        var files = fileSystem.Directories();

                        foreach (var file in files)
                        {
                            Console.WriteLine(file.ToString());
                        }
                        break;
                    case "in":
                        if (tokens.Count() == 2)
                        {
                            fileSystem.Init(tokens[1]);
                        }
                        else if (tokens.Count() == 1)
                        {
                            fileSystem.Init(null);
                        }
                        else
                        {
                            Console.WriteLine("Invalid init call: in <optional filename>");
                        }
                        break;
                    case "sv":
                        break;
                    default:
                        Console.WriteLine("Error: invalid operation");
                        break;
                }
            } 
        }
    }
}
