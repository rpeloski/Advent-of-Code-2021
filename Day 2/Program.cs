try
{
    var commandList = new List<Tuple<string, int>>();


   foreach (string line in File.ReadLines("input.txt"))
    {
        string direction = line.Split(' ')[0]; //Gets direction
        int units = Int32.Parse(line.Split(' ')[1]); //Gets units

        commandList.Add(Tuple.Create(direction, units));
    }

    int horizontalPosition = 0; 
    int depth = 0;
   


    //Part 1
   
    foreach (var command in commandList)
    {
        int units = command.Item2;
        string direction = command.Item1;

        switch (command.Item1)
        {
            case "forward":
                horizontalPosition += command.Item2;
                break;

            case "down":
                depth += command.Item2;
                break;

            case "up":
                depth -= command.Item2;
                break;
            default:
                throw new Exception("Invalid input");
        }
    }
   
    Console.WriteLine("Part 1: " + (horizontalPosition * depth).ToString());

    //Part 2

    int aim = 0;
    horizontalPosition = 0;
    depth = 0;

    foreach (var command in commandList)
    {
        int units = command.Item2;
        string direction = command.Item1;

        switch (command.Item1)
        {
            case "forward":
                horizontalPosition += command.Item2;
                depth += (aim * units);
                break;

            case "down":
                aim += command.Item2;
                break;

            case "up":
                aim -= command.Item2;
                break;
            default:
                throw new Exception("Invalid input");
        }
    }

    Console.WriteLine("Part 2: " + (horizontalPosition * depth).ToString());

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

}