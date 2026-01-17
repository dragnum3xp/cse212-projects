using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adding Item to the back of queue
    // Expected Result: ("10" 10)
    // Defect(s) Found: none
    public void TestPriorityQueue_1()
    {
    var priorityQueue = new PriorityQueue();
    priorityQueue.Enqueue("10", 10);

    var actualResult = priorityQueue.Dequeue();

    Assert.AreEqual("10", actualResult);
    }

    [TestMethod]
    // Scenario: Returning the biggest value
    // Expected Result: ("12" 12)
    // Defect(s) Found: When searching  for the highest, the logic skipped the last element
    public void TestPriorityQueue_2()
    {
    var priorityQueue = new PriorityQueue();
    priorityQueue.Enqueue("9", 9);
    priorityQueue.Enqueue("8", 8);
    priorityQueue.Enqueue("12", 12);

    var actualResult = priorityQueue.Dequeue();

    Assert.AreEqual("12", actualResult);
    }

    [TestMethod]
    // Scenario: Returning the value closest to the front value if theres 2 or more values with the same highest priority priority
    // Expected Result: dozen
    // Defect(s) Found: the loop was searching for a priority equal or higher the previous highest priority
    // returning the last element high priority element in the queue instead of the closest to the begin. 
    public void TestPriorityQueue_3()
    {
    var priorityQueue = new PriorityQueue();
    priorityQueue.Enqueue("dozen", 12);
    priorityQueue.Enqueue("9", 9);
    priorityQueue.Enqueue("8", 8);
    priorityQueue.Enqueue("12", 12);
    priorityQueue.Enqueue("twelve", 12);

    var actualResult = priorityQueue.Dequeue();

    Assert.AreEqual("dozen", actualResult);
    }

    [TestMethod]
    // Scenario: Returning the biggest value
    // Expected Result: InvalidOperationException
    // Defect(s) Found: none
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
        } 
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }

    }
    // Add more test cases as needed below.
}