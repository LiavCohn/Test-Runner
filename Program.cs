using System.Reflection;


//get the assembly,represents the compiled code 
var assembly = Assembly.GetExecutingAssembly();

var testResults = new List<TestResult>();

foreach (var type in assembly.GetTypes())
{

    var testMethods = type.GetMethods()
        .Where(m => m.GetCustomAttributes(typeof(TestAttribute)).Any())
        .ToList();

    if (testMethods.Count == 0)
        continue; // no test methods found -> can skip

    var setupMethods = type.GetMethods()
        .Where(m => m.GetCustomAttributes(typeof(SetupAttribute)).Any())
        .ToList();

    var teardownMethods = type.GetMethods()
        .Where(m => m.GetCustomAttributes(typeof(TeardownAttribute)).Any())
        .ToList();


    foreach (var method in testMethods)
    {
        //create instance of the current type
        var instance = Activator.CreateInstance(type);

        //run the setup, test and teardown methods.
        //for the simplicity of the task, i assumed that all methods
        //do not require any parameters.

        try
        {

            foreach (var setup in setupMethods)
                setup.Invoke(instance, null);


            method.Invoke(instance, null);

            // add the result to the summary list. mark it as passed.
            testResults.Add(new TestResult
            {
                MethodName = $"{type.Name}.{method.Name}",
                Passed = true
            });
        }
        catch (Exception ex)
        {
            //same here, mark it as failed.
            testResults.Add(new TestResult
            {
                MethodName = $"{type.Name}.{method.Name}",
                Passed = false,
                ErrorMessage = ex.InnerException?.Message ?? ex.Message
            });
        }
        finally
        {
            foreach (var teardown in teardownMethods)
                teardown.Invoke(instance, null);
        }
    }
}

// get how many passed/failed
int passed = testResults.Count(tr => tr.Passed);
int failed = testResults.Count(tr => !tr.Passed);

Console.WriteLine("\nTest Results:\n");
foreach (var result in testResults)
{
    Console.WriteLine($"{result.MethodName}: {(result.Passed ? "Passed" : $"Failed - {result.ErrorMessage}")}");
}

Console.WriteLine($"\nSummary: {passed} Passed, {failed} Failed, {testResults.Count} Total");

//write the results to .txt file.
File.WriteAllLines("TestResults.txt",
    testResults.Select(r => $"{r.MethodName}: {(r.Passed ? "Passed" : $"Failed - {r.ErrorMessage}")}")
    .Append($"Summary: {passed} Passed, {failed} Failed, {testResults.Count} Total"));


