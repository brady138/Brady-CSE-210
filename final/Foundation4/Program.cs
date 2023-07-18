using System;
using System.Collections.Generic;

abstract class Animal
{
    public abstract string GenerateName();
}

class Dog : Animal
{
    public override string GenerateName()
    {
        List<string> dogNames = new List<string>
        {
            "Rocky",
            "Moroni",
            "Ether",
            "Brutus",
            "Atlas",
            "Duke",
            "Hercules",
            "Demon",
            "Tom",
            "Winston"
        };

        Random random = new Random();
        int index = random.Next(dogNames.Count);
        return dogNames[index];
    }
}

class Cat : Animal
{
    public override string GenerateName()
    {
        List<string> catNames = new List<string>
        {
            "Whiskers",
            "Superbad",
            "Buzzsaw",
            "Buck",
            "Blade",
            "Samurai",
            "Jeff",
            "Razor",
            "Deisel",
            "Tom Celic"
        };

        Random random = new Random();
        int index = random.Next(catNames.Count);
        return catNames[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Animal Name Generator!");

        Console.Write("Is your animal a dog or a cat? ");
        string animalType = Console.ReadLine();

        Animal animal;
        if (animalType.ToLower() == "dog")
        {
            animal = new Dog();
        }
        else if (animalType.ToLower() == "cat")
        {
            animal = new Cat();
        }
        else
        {
            Console.WriteLine("Invalid animal type. Exiting the program.");
            return;
        }

        Console.WriteLine("Please answer the following questions (type 'yes' or 'no'):");

        Console.Write("Does your animal like to play fetch? ");
        bool likesFetch = Console.ReadLine().ToLower() == "yes";

        Console.Write("Does your animal purr? ");
        bool purrs = Console.ReadLine().ToLower() == "yes";

        Console.Write("Does your animal enjoy being around water? ");
        bool likesWater = Console.ReadLine().ToLower() == "yes";

        Console.Write("Does your animal have a loud bark or meow? ");
        bool hasLoudSound = Console.ReadLine().ToLower() == "yes";

        Console.Write("Does your animal have a fluffy tail? ");
        bool hasFluffyTail = Console.ReadLine().ToLower() == "yes";

        Console.WriteLine("Generating the animal's name...");

        string animalName = animal.GenerateName();

        if (likesFetch && purrs && !likesWater && !hasLoudSound && hasFluffyTail)
        {
            animalName += " Worm ";
        }
        else if (!likesFetch && purrs && !likesWater && hasLoudSound && !hasFluffyTail)
        {
            animalName += " Evil ";
        }
        else if (!likesFetch && !purrs && likesWater && hasLoudSound && !hasFluffyTail)
        {
            animalName += " The Barbarian ";
        }

        Console.WriteLine("Your animal's name is: " + animalName);
    }
}