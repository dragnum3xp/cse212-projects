/// <summary>
/// Maintain a Customer queue Queue.  Allows new customers to be 
/// added and allows customers to be queued.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer queue queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Add one customer and then serve it
        // Expected Result: Should display the customer added
        //Console.WriteLine("Test 1");

        var queue = new CustomerService(4);
        queue.AddNewCustomer();
        queue.ServeCustomer();

        // Defect(s) Found: ServeCustomer need to receive the customer before deleting it

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Can two customers be added and served the in the right order?
        // Expected Result: Should display the customers in the same order that they were 
        Console.WriteLine("Test 2");

        queue = new CustomerService(4);
        queue.AddNewCustomer();
        queue.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {queue}");
        queue.ServeCustomer();
        queue.ServeCustomer();
        Console.WriteLine($"After serving customers: {queue}");

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 3
        // Scenario: serve a customer if there is no customer?
        // Expected Result: display error
        Console.WriteLine("Test 3");
        queue = new CustomerService(4);
        queue.ServeCustomer();

        // Defect(s) Found: This found that I need to check the length in serve_customer and display an error message

        Console.WriteLine("=================");

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Max queue size get enforced?
        // Expected Result: This should display an error message when the 5th one is added
        Console.WriteLine("Test 4");
        queue = new CustomerService(4);
        queue.AddNewCustomer();
        queue.AddNewCustomer();
        queue.AddNewCustomer();
        queue.AddNewCustomer();
        queue.AddNewCustomer();
        Console.WriteLine($"queue Queue: {queue}");
        // Defect(s) Found: This found that Add customer needs >= instead of >

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Max size get defaulted to 10 if an invalid value is provided?
        // Expected Result: 10
        Console.WriteLine("Test 5");
        queue = new CustomerService(0);
        Console.WriteLine($"Size should be 10: {queue}");
        // Defect(s) Found: None 



        

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the queue queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the queue queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // Need to check if there are customers in our queue
        if (_queue.Count <= 0) // Defect 2 - Need to check queue length
        {
            Console.WriteLine("No Customers in the queue");
        }
        else {
            // Need to read and save the customer before it is deleted from the queue
            var customer = _queue[0];
            _queue.RemoveAt(0); // Defect 1 - Delete should be done after
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer queue queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}