using System.Text.RegularExpressions;
try
{
    var inputfile = File.ReadAllLines("testday4.txt");
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



    bool bingo = false;
    int sum = 0;
    
    foreach (int n in calledNumbers)
    {
        for (int b=0; b < bingoboards.Count; b++)
        {
            if (bingo == true) { break; }
            for (int x=0; x < bingoboards[b].Count(); x++)
            {
                if (bingoboards[b][x] == n) {bingoboards[b][x] = -1;}

                if (isBingo(bingoboards[b], width))
                {
                    Console.WriteLine("Board " + (b + 1) + " is the first board that wins!");


                    foreach (int y in bingoboards[b])
                        if (y != -1)
                        {
                            sum += y;
                        }
                    Console.WriteLine("The sum of the unmarked numbers is: " + sum);
                    Console.WriteLine("The last number called was: " + n);
                    Console.WriteLine("The final score is: " +  sum * n);
                    bingo = true;
                    break;


                
                }



            }
        }
    }
    
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

} 