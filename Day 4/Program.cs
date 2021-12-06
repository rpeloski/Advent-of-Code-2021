try
{
    var inputfile = File.ReadAllLines("input.txt");
    var calledNumbers = inputfile[0].Split(',').Select(int.Parse).ToArray();
    var bingoboards = new List<int[]>();
    int width = 5;

    bool isBingo(int[] bingoboard, int width)
    {
        //Checking rows
        foreach (var row in bingoboard.Chunk(width))
        {
            if (row.Sum() == -width) { return true; }
        }

        //Checking columns
        for (int c=0; c<width; c++)
        {
            int sum = 0;
            for (int r=0; r<width; r++)
            {
                sum += bingoboard[r * width + c];
            }
            if (sum==-width) { return true; }

        }

        return false;
    }


    foreach (var board in inputfile.Skip(2).Chunk(width + 1))
    {
        var b = string.Join(" ", board.Take(width)).Trim().Replace("  ", " ").Split(' ').Select(n => int.Parse(n)).ToArray();

        bingoboards.Add(b);
    }



    int BingoCounter = 0; 
    bool[] boardHasBingo = new bool[bingoboards.Count]; //Tracks which board already has bingo
    
   
    
    foreach (int n in calledNumbers)
    {
        for (int b=0; b < bingoboards.Count; b++)
        {
            
            for (int x=0; x < bingoboards[b].Count(); x++)
            {
                if (bingoboards[b][x] == n) {bingoboards[b][x] = -1;}

                if (!isBingo(bingoboards[b], width) || boardHasBingo[b])
                    { continue; }
                boardHasBingo[b] = true;
                if (++BingoCounter == 1)
                {
                    Console.WriteLine("\n\nPart1: \n\nBoard " + (b + 1) + " is the first board that wins!");

                    int sum = 0;
                    foreach (int y in bingoboards[b])
                        if (y != -1)
                        {
                            sum += y;
                        }
                    Console.WriteLine("The sum of the unmarked numbers is: " + sum);
                    Console.WriteLine("The last number called was: " + n);
                    Console.WriteLine("The final score is: " +  sum * n);
                                
                }
                else if (BingoCounter == bingoboards.Count)
                {
                    Console.WriteLine("\n\nPart2: \n\nBoard " + (b + 1) + " is the last board that wins!");
                    int sum = 0;
                    foreach (int y in bingoboards[b])
                        if (y != -1)
                        {
                            sum += y;
                        }
                    Console.WriteLine("The sum of the unmarked numbers is: " + sum);
                    Console.WriteLine("The last number called was: " + n);
                    Console.WriteLine("The final score is: " + sum * n);
                }
                    

        



            }
        }
    }
    
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

} 