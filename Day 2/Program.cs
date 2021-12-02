try
{
    var commandList = new List<Tuple<string, int>>();

    commandList.Add(Tuple.Create("forward", 6));
    commandList.Add(Tuple.Create("down", 4));
    commandList.Add(Tuple.Create("forward", 6));
    commandList.Add(Tuple.Create("up", 4));

    int horizontalPosition = 0; 
    int verticalPosition = 0;


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
                verticalPosition += command.Item2;
                break;

            case "up":
                verticalPosition -= command.Item2;
                break;
         
        }
    }
    
    Console.WriteLine(horizontalPosition.ToString() + " " + verticalPosition.ToString()); 


}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

}