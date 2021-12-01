try
{
    var integerList = File.ReadAllLines("input.txt")
        .Select(s => Int32.Parse(s)).ToList();

    int increaseCounter = 0;

    for (int i = 0; i < integerList.Count - 1; i++)
    {
        if (integerList[i + 1] > integerList[i])
            increaseCounter++;
    }

    Console.WriteLine(increaseCounter.ToString());

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

}