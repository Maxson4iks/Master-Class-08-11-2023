internal class Program
{
    private static void Main(string[] args)
    {
        var massa = ReadFromConsole("Введите массу");
        var rost = ReadFromConsole("Введите рост");

        var index = GetBodyMassIndex(massa, rost);

        Console.WriteLine("Твой индекс: {0}", index);

        Console.WriteLine(GetBmiDescription(index));

    }
    /// <summary>
    /// Максимальное значение веса.
    /// </summary>
    private const int MaxWeightValue = 600;

    /// <summary>
    /// Минимальное значение веса.
    /// </summary>
    private const int MinWeightValue = 3;

    /// <summary>
    /// Минимальное значение роста.
    /// </summary>
    private const double MinHeightValue = 0.5;

    /// <summary>
    /// Максимальное значение роста.
    /// </summary>
    private const int MaxHeightValue = 3;

    /// <summary>
    /// Вычисляет индекс массы тела.
    /// </summary>
    /// <param name="weight">Масса тела, кг.</param>
    /// <param name="height">Рост, м.</param>
    /// <returns></returns>
    public static double GetBodyMassIndex(double weight, double height)
    {
        CheckRangeValue(weight, MinWeightValue, MaxWeightValue);
        CheckRangeValue(height, MinHeightValue, MaxHeightValue);

        return weight / (height * height);
    }

    /// <summary>
    /// Считать число с консоли.
    /// </summary>
    /// <param name="message">Сообщение для пользователя</param>
    /// <returns></returns>
    public static double ReadFromConsole(string message)
    {
        Console.WriteLine(message);
        return Convert.ToDouble(Console.ReadLine());
    }

    public static string GetBmiDescription(double index)
    {
        foreach (var item in BmiDescription)
        {
            if (index < item.Key) return item.Value;
        }
        return "Невозможное значение индекса";
    }
    public static Dictionary<double, string> BmiDescription = new()
    {
        {16, "Дефицит"},
        {18.5, "Недостаток"},
        {25, "Норма"},
        {30, "Предожирение"},
        {35, "Ожирение 1 степени"},
        {40, "Ожирение 2 степени"},
        {50, "Ожирение 3 степени"}
    };

    /// <summary>
    /// Проверяет значения в диапазоне.
    /// </summary>
    /// <param name="value">Входное значение</param>
    /// <param name="minValue">Минимальное значение диапазона</param>
    /// <param name="maxValue">Максимальное значение диапазона</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void CheckRangeValue(double value, double minValue, double maxValue)
    {
        if (value < minValue || value > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value),
                $"Ожидалось значение в диапазоне от {minValue} до {maxValue}");
        }
    }
}