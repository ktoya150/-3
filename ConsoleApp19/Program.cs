using System;
using System.Collections.Generic;
using System.Text; // Для роботи з кодуванням
// Базовий клас Recipe
class Recipe
{
    private string name;
    private List<string> ingredients;
    private int cookingTime;

    // Властивості
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<string> Ingredients
    {
        get { return ingredients; }
        set { ingredients = value; }
    }

    public int CookingTime
    {
        get { return cookingTime; }
        set { cookingTime = value; }
    }

    // Конструктор за замовчуванням
    public Recipe()
    {
        name = "Untitled Recipe";
        cookingTime = 30;
        ingredients = new List<string>();
    }
    public Recipe(string name, List<string> ingredients, int cookingTime)
    {
        this.name = name;
        this.ingredients = ingredients;
        this.cookingTime = cookingTime;
    }

    // Метод StartCooking
    public virtual void StartCooking()
    {
        Console.WriteLine($"Приготування рецепту {name} розпочато.");
    }

    // Метод GetRecipeDetails
    public void GetRecipeDetails()
    {
        Console.WriteLine($"Назва: {name}, Час приготування: {cookingTime} хвилин, Інгредієнти: {ingredients.Count}.");
    }
}

// Дочірній клас VegetarianRecipe
class VegetarianRecipe : Recipe
{
    public bool IsVegan { get; private set; }
    public VegetarianRecipe(string name, List<string> ingredients, int cookingTime, bool isVegan)
        : base(name, ingredients, cookingTime)
    {
        IsVegan = isVegan;
    }

    // Перевизначений метод StartCooking
    public override void StartCooking()
    {
        Console.WriteLine($"Приготування вегетаріанського рецепту {Name} розпочато.");
    }

    // Метод SetVeganOption
    public void SetVeganOption()
    {
        IsVegan = true;
        Console.WriteLine($"Рецепт {Name} тепер є веганським.");
    }
}

// Дочірній клас NonVegetarianRecipe
class NonVegetarianRecipe : Recipe
{
    public string MeatType { get; private set; }

    // Конструктор
    public NonVegetarianRecipe(string name, List<string> ingredients, int cookingTime, string meatType)
        : base(name, ingredients, cookingTime)
    {
        MeatType = meatType;
    }

    public override void StartCooking()
    {
        Console.WriteLine($"Приготування м'ясної страви {Name} розпочато.");
    }

    // Метод SetMeatType
    public void SetMeatType(string type)
    {
        MeatType = type;
        Console.WriteLine($"Тип м'яса для рецепту {Name} змінено на {type}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Створення вегетаріанського рецепту
        var vegIngredients = new List<string> { "Морква", "Картопля", "Цибуля" };
        var vegetarianRecipe = new VegetarianRecipe("Овочеве рагу", vegIngredients, 45, false);
        vegetarianRecipe.GetRecipeDetails();
        vegetarianRecipe.StartCooking();
        vegetarianRecipe.SetVeganOption();

        Console.WriteLine();

        // Створення м'ясного рецепту
        var nonVegIngredients = new List<string> { "Курка", "Цибуля", "Часник" };
        var nonVegetarianRecipe = new NonVegetarianRecipe("Курка з овочами", nonVegIngredients, 60, "Курка");
        nonVegetarianRecipe.GetRecipeDetails();
        nonVegetarianRecipe.StartCooking();
        nonVegetarianRecipe.SetMeatType("Свинина");
    }
}
