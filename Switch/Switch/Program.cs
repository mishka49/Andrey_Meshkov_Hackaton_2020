namespace Switch
{
    class Program
    {
        static string DefinesTypeOfVariable(object argument)
        {
            switch (argument.GetType().ToString())
            {
                case "System.Int32":
                    return $"{argument} is int";
                    break;
                case "System.Double":
                    return $"{argument} is double";
                    break;
                case "System.String":

                    if (argument == "")
                    {
                        return "An empty value was entered";
                    }
                    else
                    {
                        return $"{argument} is string";
                    }

                    break;
                case "System.Boolean":
                    return $"{argument} is bool";
                    break;
                default:
                    return "Type not defined";
                    break;
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
