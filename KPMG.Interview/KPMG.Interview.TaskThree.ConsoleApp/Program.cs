// See https://aka.ms/new-console-template for more information
using KPMG.Interview.TaskThree;

Console.WriteLine("Enter Object");
var obj = Console.ReadLine(); //Sample inputs : {"a":{"b":{"c":"d"}}} {"x":{"y":{"z":"a"}}}
Console.WriteLine("Enter Key");
var key = Console.ReadLine();

var value = new ChallengeThree().GetValue(obj, key);

Console.WriteLine(String.Format("Value : {0}", value));


