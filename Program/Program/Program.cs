class Program
{

	static void Main(string[] args){

		//I have created a recipe object out of the class recipe
		//The methods will be called from the recipe object class
		Recipe recipe = new Recipe();
		while (true){
			Console.WriteLine("===================================");
			Console.WriteLine("Enter '1' to enter recipe details");
			Console.WriteLine("Enter '2' to display recipe");
			Console.WriteLine("Enter '3' to scale recipe");
			Console.WriteLine("Enter '4' to reset quantities");
			Console.WriteLine("Enter '5' to clear recipe");
			Console.WriteLine("Enter '6' to exit");
			Console.WriteLine("===================================");
			//The following switch cases allow for the selection of each option
			string ans = Console.ReadLine();
			Console.WriteLine("                                     ");
			switch (ans){

				case "1":
					recipe.DetailEntry();
					break;
				case "2":
					recipe.DisplayRecipe();
					break;
				case "3":
					Console.Write("Enter scaling factor (0.5, 2, or 3): ");
					double scale1;
					if (double.TryParse(Console.ReadLine(), out scale1)){
						recipe.ScaleRecipe(scale1);
					}
					else{
						Console.WriteLine("\n+Please Enter a valid number+\n");
					}

					break;
				case "4":
					recipe.ResetQuantities();
					break;
				case "5":
					recipe.ClearRecipe();
					break;
				case "6":
					Environment.Exit(0);
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter a valid choice.");
					break;
			}
		}
	}
}

//The following class will calculate all of requirements with the use of different methods
//And then the methods will be called by the main statement
class Recipe{
	private string[] ingredients;
	private double[] amount;
	private string[] units;
	private string[] steps;

	public Recipe(){
		// Initialize empty arrays for ingredients, quantities, units, and steps
		ingredients = new string[0];
		amount = new double[0];
		units = new string[0];
		steps = new string[0];

	}

	public void DetailEntry(){
		// Prompt the user to enter the number of ingredients

		Console.Write("Enter the number of ingredients: ");
		//If statement for error handling that will force the user to restart the program
		int ingNum;
		if (int.TryParse(Console.ReadLine(), out ingNum)){
			// Initialize the arrays with the correct size
			ingredients = new string[ingNum];
			amount = new double[ingNum];
			units = new string[ingNum];

			// Prompt the user to enter the details for each ingredient
			for (int i = 0; i < ingNum; i++){
				Console.WriteLine($"Enter details for ingredient #{i + 1}:");
				Console.Write("Name: ");
				ingredients[i] = Console.ReadLine();
				Console.Write("Quantity: ");
				amount[i] = double.Parse(Console.ReadLine());
				Console.Write("Unit of measurement: ");
				units[i] = Console.ReadLine();
			}

			// Prompt the user to enter the number of steps
			Console.Write("Enter the number of steps: ");
			int Stnum = int.Parse(Console.ReadLine());

			// Initialize the steps array with the correct size
			steps = new string[Stnum];

			// Prompt the user to enter the details for each step
			for (int i = 0; i < Stnum; i++){
				Console.Write($"Enter step #{i + 1}: ");
				steps[i] = Console.ReadLine();
			}

		}
		else{
			Console.WriteLine("                                       ");
			Console.WriteLine("Please Enter a number+\n");
		}


	}

	public void DisplayRecipe(){
		//This code will display the ingredients and quantities
		Console.WriteLine("Ingredients:");
		for (int i = 0; i < ingredients.Length; i++){
			Console.WriteLine($"- {amount[i]} {units[i]} of {ingredients[i]}");
		}

		//This code will display the steps
		Console.WriteLine("Steps:");
		for (int i = 0; i < steps.Length; i++){
			Console.WriteLine($"- {steps[i]}");
		}
	}

	public void ScaleRecipe(double scale){
		//This code will scale all our recipes by the scale we have chosen
		for (int i = 0; i < amount.Length; i++){
			amount[i] *= scale;
		}
	}

	public void ResetQuantities(){
		//This code will reset all the amounts to their original values
		for (int i = 0; i < amount.Length; i++){
			amount[i] /= 2;
		}
	}

	public void ClearRecipe(){
		//This code will reset all the arrays to empty
		ingredients = new string[0];
		amount = new double[0];
		units = new string[0];
		steps = new string[0];
	}
}