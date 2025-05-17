//create a custom attribute class to mark methods as teardown methods.
//after each test
[AttributeUsage(AttributeTargets.Method)]
internal class TeardownAttribute : Attribute
{
}