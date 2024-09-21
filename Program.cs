using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Read file");
            Console.WriteLine("2. Write file");
            Console.WriteLine("3. Level up a character");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ReadFile();
                    break;
                case "2":
                    WriteFile();
                    break;
                case "3":
                    LevelUpCharacter();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void ReadFile()
    {
        using (StreamReader reader = new StreamReader("input.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }

    static void WriteFile()
    {
        Console.Write("Enter your character's name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your character's class: ");
        string characterClass = Console.ReadLine();

        Console.Write("Enter your character's level: ");
        int level = int.Parse(Console.ReadLine());

        Console.Write("Enter your character's equipment (separate items with a '|'): ");
        string[] equipment = Console.ReadLine().Split('|');

        using (StreamWriter writer = new StreamWriter("input.txt", true))
        {
            writer.WriteLine($"{name},{characterClass},{level},{string.Join("|", equipment)}");
        }
    }

    static void LevelUpCharacter()
    {
        var lines = File.ReadAllLines("input.txt").ToList();
        Console.Write("Enter the name of the character to level up: ");
        string name = Console.ReadLine();

        for (int i = 0; i < lines.Count; i++)
        {
            var parts = lines[i].Split(',');
            if (parts[0] == name)
            {
                int level = int.Parse(parts[2]);
                level++;
                parts[2] = level.ToString();
                lines[i] = string.Join(",", parts);
                Console.WriteLine($"{name} has leveled up to level {level}!");
                break;
            }
        }

        File.WriteAllLines("input.txt", lines);
    }
}