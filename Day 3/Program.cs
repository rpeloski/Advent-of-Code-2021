try
{
    var binaryList = File.ReadAllLines("input.txt").ToList();
    var mostcommon = "";
    var gammarate = 0;
    var epsilonrate = 0;

    //Part 1
   for (int i = 0; i < binaryList[0].Length; i++) //For each digit position in the binary number, return the most common bit in that number
    {
        mostcommon += binaryList.GroupBy(x => x.Substring(i, 1)).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();

     
    }

    gammarate = Convert.ToInt32(mostcommon, 2); //Calculate gammarate (integer value of the above generated binary number)
    epsilonrate = Convert.ToInt32(mostcommon.Replace('0', '*').Replace('1', '0').Replace('*', '1'),2); //Calculate epsilonrate by bit flipping the bits in the generated binary number and converting to int


    //Display answer
    Console.WriteLine("Gamma Rate: " + gammarate);
    Console.WriteLine("Epsilon Rate: " + epsilonrate);
    Console.WriteLine("Power Consumption: " + gammarate * epsilonrate);

    Console.WriteLine("\n\n");


    //Part 2

    var oxygengenerator = 0;
    var co2scrubber = 0;
    var lifesupport=0;  
    
    //Part 2A

    for (var i = 0; i < binaryList[0].Length; i++) //For each digit position in the binary number
    {
               

        var ones = binaryList.Where(x => x.Substring(i, 1) == "1").Count(); //Counts ones
        var zeroes = binaryList.Where(x => x.Substring(i, 1) == "0").Count(); //Counts zeroes

        if (ones > zeroes) //If ones in that position are more significant, remove all numbers with zeroes in that position from the list
        {
            binaryList.RemoveAll(x => x.Substring(i, 1) == "0");
          

        }
        else if (ones < zeroes) //If zeroes in that position are more significant, remove all numbers with ones in that position from the list
        {
            binaryList.RemoveAll(x => x.Substring(i, 1) == "1");
            
        }
        else if (ones == zeroes) //If ones and zeroes are equal in significance, remove all numbers with zeroes in that position from the list
        {
            binaryList.RemoveAll(x => x.Substring(i, 1) == "0");
            
        }


        if (binaryList.Count() == 1) //Stop when only one number left and show result
        {
            oxygengenerator = Convert.ToInt32(binaryList[0], 2);
            Console.WriteLine("Oxygen Generator Rating Integer: " + oxygengenerator.ToString());
            break;
        }

    }

    //Part 2B

    binaryList = File.ReadAllLines("input.txt").ToList(); //Reloads input as above removes it.


    for (var i = 0; i < binaryList[0].Length; i++) //For each digit position in the binary number
    {


        var ones = binaryList.Where(x => x.Substring(i, 1) == "1").Count();  //Counts ones
        var zeroes = binaryList.Where(x => x.Substring(i, 1) == "0").Count(); //Counts zeroes

        if (ones > zeroes) //If ones in that position are more significant, remove all numbers with ones in that position from the list
        {
            binaryList.RemoveAll(x => x.Substring(i, 1) == "1");
            

        }
        else if (ones < zeroes) //If zeroes in that position are more significant, remove all numbers with zeroes in that position from the list
        {
            binaryList.RemoveAll(x => x.Substring(i, 1) == "0");
            
        }
        else if (ones == zeroes) //If ones and zeroes are equal in significance, remove all numbers with ones in that position from the list
        {
            binaryList.RemoveAll(x => x.Substring(i, 1) == "1");
            
        }
    
        if (binaryList.Count() == 1) //Stop when only one number left and print answer
        {
            co2scrubber = Convert.ToInt32(binaryList[0], 2);
            Console.WriteLine("CO2 Scrubber Rating Integer: " + co2scrubber.ToString());
            break;
        }

    }

    //Write final answer

    Console.WriteLine("Life Support Rating: " + (oxygengenerator * co2scrubber).ToString());




   
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

}