public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {   
        double[] values = new double[length]; //Creates an array with the results
        for( int i = 0; i < length; i++) // iterate through the length to ensure the loop stops at the right size
        {   
            values[i] = number * (i +1); //the logic itself
        }

        return values;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        int removedValue;
        for( int i = 0; i < amount; i++) // iterate through the length to ensure the loop stops at the right size
        {
            removedValue = data[data.Count - 1]; // Stores the last value of the list in a variable
            data.RemoveAt(data.Count - 1); // remove the value
            data.Insert(0, removedValue); //read the stored value and adds it to the front of the list
        }
    }
}
