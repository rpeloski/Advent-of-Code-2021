try
{
    var binaryList = File.ReadAllLines("input.txt").ToList();
    var mostcommon = "";
    var gammarate = 0;
    var epsilonrate = 0;

    //Part 1
   for (int i = 0; i < binaryList[0].Length; i++)
    {
        mostcommon += binaryList.GroupBy(x => x.Substring(i, 1)).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();

     
    }

    gammarate = Convert.ToInt32(mostcommon, 2);
    epsilonrate = Convert.ToInt32(mostcommon.Replace('0', '*').Replace('1', '0').Replace('*', '1'),2);


    Console.WriteLine("Gamma Rate: " + gammarate);
    Console.WriteLine("Epsilon Rate: " + epsilonrate);
    Console.WriteLine("Power Consumption: " + gammarate * epsilonrate);

    Console.WriteLine("\n\n");


    //Part 2

    var oxygengenerator = 0;
    var co2scrubber = 0;
    var lifesupport=0;    

    for (var i = 0; i < binaryList[0].Length; i++)
    {
               

        var ones = binaryList.Where(x => x.Substring(i, 1) == "1").Count();
        var zeroes = binaryList.Where(x => x.Substring(i, 1) == "0").Count();

        if (ones > zeroes)
        {
            binaryList.RemoveAll(x => x.Substring(i, 1) == "0");
          

        }
        else if (ones < zeroes)
        {
            binaryList.RemoveAll(x => x.Substring(i, 1) == "1");
            
        }
        else if (ones == zeroes)
        {
            binaryList.RemoveAll(x => x.Substring(i, 1) == "0");
            
        }


        if (binaryList.Count() == 1)
        {
            oxygengenerator = Convert.ToInt32(binaryList[0], 2);
            Console.WriteLine("Oxygen Generator Rating Integer: " + oxygengenerator.ToString());
            break;
        }

    }

    binaryList = File.ReadAllLines("input.txt").ToList();


    for (var i = 0; i < binaryList[0].Length; i++)
    {


        var ones = binaryList.Where(x => x.Substring(i, 1) == "1").Count();
        var zeroes = binaryList.Where(x => x.Substring(i, 1) == "0").Count();

        if (ones > zeroes)
        {
            binaryList.RemoveAll(x => x.Substring(i, 1) == "1");
            

        }
        else if (ones < zeroes)
        {
            binaryList.RemoveAll(x => x.Substring(i, 1) == "0");
            
        }
        else if (ones == zeroes)
        {
            binaryList.RemoveAll(x => x.Substring(i, 1) == "1");
            
        }
    
        if (binaryList.Count() == 1)
        {
            co2scrubber = Convert.ToInt32(binaryList[0], 2);
            Console.WriteLine("CO2 Scrubber Rating Integer: " + co2scrubber.ToString());
            break;
        }

    }

    Console.WriteLine("Life Support Rating: " + (oxygengenerator * co2scrubber).ToString());




   
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

}