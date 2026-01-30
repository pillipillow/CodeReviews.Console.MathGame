using MathGame;

Menus menu = new Menus();
var name = menu.GetName();
var date = DateTime.Now;

menu.ShowMainMenu(name, date);