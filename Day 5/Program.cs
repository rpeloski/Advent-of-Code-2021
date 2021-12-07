using System.Text.RegularExpressions;

try
{
    var inputfile = File.ReadAllLines("input.txt");

    var map = new Dictionary<(int,int),int>();


    foreach (var line in inputfile)
    {
        int[] coords = Regex.Split(line, @"[^\d]+").Select(int.Parse).ToArray();
        int x1 = coords[0];
        int y1 = coords[1];
        int x2 = coords[2];
        int y2 = coords[3];

        


        
        int dx = Math.Abs(x2 - x1);
        int dy = Math.Abs(y2 - y1);

        if (x1 > x2) { (x1, x2) = (x2, x1); }
        if (y1 > y2) { (y1, y2) = (y2, y1); }

        if (dy==0)
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
        if (dx==0)
        {
            for (int y = y1; y < y2 + 1; y++)
            {
                if (!map.ContainsKey((x1, y)))
                {
                    map[(x1, y)] = 1;
                }
                else map[(x1, y)]++;
            }


        //foreach(KeyValuePair<(int,int), int> kvp in map)
            {
                //Console.WriteLine(kvp.Key.ToString() + kvp.Value);
            }

            
        }
        
    }

    Console.WriteLine("Answer: " + map.Count(p => p.Value > 1).ToString());



    //Console.ReadLine();

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

}