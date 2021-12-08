using System.Text.RegularExpressions;

try
{
    string filename = "input.txt";
    part1(filename);
    part2(filename);
   
}

catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

}
void part1(string filename)
{
    var inputfile = File.ReadAllLines(filename);
    var map = new Dictionary<(int, int), int>();

    foreach (var line in inputfile)
    {
        int[] coords = Regex.Split(line, @"[^\d]+").Select(int.Parse).ToArray();
        int x1 = coords[0];
        int y1 = coords[1];
        int x2 = coords[2];
        int y2 = coords[3];

        //Swap so x1 < x2 and y1 < y2
        if (x1 > x2) { (x1, x2) = (x2, x1); }
        if (y1 > y2) { (y1, y2) = (y2, y1); }

        //Part 1
        if (y1 == y2)
        {
            for (int x = x1; x < x2 + 1; x++)
            {
                if (!map.ContainsKey((x, y1)))
                {
                    map[(x, y1)] = 1;
                }
                else map[(x, y1)]++;
            }

        }
        if (x1 == x2)
        {
            for (int y = y1; y < y2 + 1; y++)
            {
                if (!map.ContainsKey((x1, y)))
                {
                    map[(x1, y)] = 1;
                }
                else map[(x1, y)]++;
            }

        }

        //foreach (KeyValuePair<(int, int), int> kvp in mapPart1)
        //{
        //    Console.WriteLine(kvp.Key.ToString() + kvp.Value);
        //}
        
    }
    Console.WriteLine("Answer to part 1: " + map.Count(p => p.Value > 1).ToString());

}

void part2(string filename)
{
    var inputfile = File.ReadAllLines(filename);
    var map = new Dictionary<(int, int), int>();

    foreach (var line in inputfile)
    {
        int[] coords = Regex.Split(line, @"[^\d]+").Select(int.Parse).ToArray();
        int x1 = coords[0];
        int y1 = coords[1];
        int x2 = coords[2];
        int y2 = coords[3];

        int xstep = 0;
        int ystep = 0;

        if (x1 > x2) xstep = -1;
        if (y1 > y2) ystep = -1;

        if (x1 < x2) xstep = 1;
        if (y1 < y2) ystep = 1;


        (int x, int y) = (x1, y1);
        do
        {


            if (!map.ContainsKey((x, y)))
            {
                map[(x, y)] = 0;
            }
            map[(x, y)]++; 

            if (x == x2 && y == y2) break;

            x += xstep;
            y += ystep;
            

        } while (true);

        //foreach (KeyValuePair<(int, int), int> kvp in mapPart1)
        //{
        //    Console.WriteLine(kvp.Key.ToString() + kvp.Value);
        //}

        
    }
    Console.WriteLine("Answer to part 2: " + map.Count(p => p.Value > 1).ToString());
}


        


