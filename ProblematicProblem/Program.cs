using System;
using System.Collections.Generic;
using System.Threading;

//ProblematicProblem
Random rng = null;
var activities = new List<string>()
    { "Movies", "Paintball", "Bowling", "Laser Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
            
//asking if they want to play
Console.WriteLine("Hello, welcome to the Random Activity Generator! \nWould you like to generate a random activity? yes/no: ");
var cont = Console.ReadLine();

//if they answer anything besides yes or no:
while (cont != "yes" && cont != "no")
{
    Console.WriteLine("Invalid entry. Please enter only yes or no.");
    cont = Console.ReadLine();
}
//if they answer yes, continue:
if (cont == "yes")
{
    //Get their name
    Console.WriteLine("We are going to need your information first! What is your name?");
    var userName = Console.ReadLine();
    Console.WriteLine($"Nice to meet you, {userName}!");

    //Get their age - we will use later to see if they can go wine tasting
    Console.WriteLine("What is your age?");
    var userAge = int.Parse(Console.ReadLine());

    //Ask to present list of activities
    Console.WriteLine("Would you like to see the current list of activities? Sure/No thanks:");
    var showList = Console.ReadLine();

    {
        while (showList != "sure" && showList != "no thanks")
        {
            Console.WriteLine("Invalid entry. Please enter only sure or no thanks.");
            Console.ReadLine();
        }

        if (showList == "sure")
        {
            foreach (var activity in activities)
            {
                Console.WriteLine(activity);
            }
        }
    }
    //Ask if they want to add any more to the list
    Console.WriteLine("Would you like to add any activities before we generate one? yes/no: ");
    var addActivity = Console.ReadLine();

    while (addActivity == "yes")
    {
        //let them add to the list
        Console.WriteLine("What would you like to add?");
        var newActivity = Console.ReadLine();
        activities.Add((newActivity));
        //present the list again
        Console.WriteLine($"Great. We've added {newActivity} to the list:");
        foreach (var activity in activities)
        {
            Console.WriteLine(activity);
        }

        //give another chance to add activities
        Console.WriteLine("Would you like to add any more? yes/no:");
        var addYes = Console.ReadLine();

        if (addYes == "yes")
        {
            Console.WriteLine("What else would you like to add?");
            var addMore = Console.ReadLine();
            activities.Add(addMore);
            Console.WriteLine($"Great idea. We've added {addMore} to the list as well:");
            foreach (var activity in activities)
            {
                Console.WriteLine(activity);
            }
        }
    }

    //if they don't want to add more, continue to choosing their random activity:

    {
        Console.WriteLine("Now let's choose your random activity from the list!");

        Console.WriteLine("Connecting to the database");
        for (int i = 0; i < 5; i++)
        {
            Console.Write(". ");
            Console.WriteLine();
            Thread.Sleep(500);
        }


        Console.WriteLine("Choosing your random activity...");
        rng = new Random();
        int randomNumber = rng.Next(activities.Count);
        string randomActivity = activities[randomNumber];

        //if user under 21 years old, do not let them have Wine Tasting
        if (userAge < 21 && randomActivity == "Wine Tasting")
        {
            Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
            Console.WriteLine("Picking another random activity...");
            activities.Remove(randomActivity);
            randomNumber = rng.Next(activities.Count);
            randomActivity = activities[randomNumber];
            Console.WriteLine($"Your random activity is {randomActivity}!");
        }
        else
        {
            Console.WriteLine(
                $"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
            var choice = Console.ReadLine();

            if (choice == "keep")
            {
                Console.WriteLine("Great, have fun doing your activity!");
            }

            //let user get a new activity
            else if (choice == "redo")
            {
                Console.WriteLine("Got it. Choosing another random activity for you...");
                activities.Remove(randomActivity);
                randomNumber = rng.Next(activities.Count);
                randomActivity = activities[randomNumber];
                Console.WriteLine($"Your NEW random activity is {randomActivity}! Have fun!");
            }
            else
            {
                Console.WriteLine("Please enter 'keep' to stick with your activity or 'redo' to select a new one.");
            }
        }

    }
}
    

