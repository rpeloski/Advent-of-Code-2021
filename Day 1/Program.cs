try
{    
    var integerList = File.ReadAllLines("input.txt")
        .Select(s => Int32.Parse(s)).ToList();
 
    //Increase counter
    int increaseCounter = 0;

    //Part 1
    for (int i = 1; i < integerList.Count; i++)
    {
        
        if (integerList[i] > integerList[i-1])
            increaseCounter++;
    }

   
    Console.WriteLine("Part 1: " + increaseCounter.ToString());

    
    //Reset increase counter
    increaseCounter = 0;

    //Part 2
    for (int i = 1; i < integerList.Count; i++)
    { if (i + 2 < integerList.Count) 
            {
            int firstwindow = integerList[i - 1] + integerList[i] + integerList[i + 1];
            int secondwindow = integerList[i] + integerList[i+1] + integerList[i + 2];
            if (secondwindow > firstwindow)
                increaseCounter++;
        }

    }

    Console.WriteLine("Part 2: " + increaseCounter.ToString());

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

}