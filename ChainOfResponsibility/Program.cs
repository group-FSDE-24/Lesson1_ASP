// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using ChainOfResponsibility.DP_Builder.Concrete;
using ChainOfResponsibility.Models.Concretes;

var user = new User("Kamran123", "Kamran@gmail.com", "1234564");

var checkerDirector = new CheckerDirector();

checkerDirector.MakeBuilder(user);
