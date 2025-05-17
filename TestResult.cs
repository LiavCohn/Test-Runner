//helper class, represents the output model for the tests results.
public class TestResult
{
    public string MethodName { get; set; }
    public bool Passed { get; set; }
    public string ErrorMessage { get; set; }
}