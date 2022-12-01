void MaxCalories()
{
    var caloriesSum = 0;
    var maxCalories = 0;

    foreach (var line in File.ReadLines(args[0]))
    {
        if (line.Length == 0)
        {
            maxCalories = caloriesSum > maxCalories ? caloriesSum : maxCalories;
            caloriesSum = 0;
        }
        else
            caloriesSum += Convert.ToInt32(line);
    }

    Console.WriteLine($"Max number of calories is {maxCalories}");
}

void MaxCaloriesOutOfThree()
{
    var caloriesSum = 0;
    int[] maxCalories = {0, 0, 0};

    foreach (var line in File.ReadLines(args[0]))
    {
        if (line.Length == 0)
        {
            maxCalories[0] = caloriesSum > maxCalories[0] ? caloriesSum : maxCalories[0];
            Array.Sort(maxCalories);
            caloriesSum = 0;
        }
        else
            caloriesSum += Convert.ToInt32(line);
    }

    Console.WriteLine($"Max number of calories from top three elves is {maxCalories[0] + maxCalories[1] + maxCalories[2]}");
}

MaxCalories();
MaxCaloriesOutOfThree();
