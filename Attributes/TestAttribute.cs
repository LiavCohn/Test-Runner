//create a custom attribute class to mark methods as test methods.
[AttributeUsage(AttributeTargets.Method)]
internal class TestAttribute : Attribute
{
}