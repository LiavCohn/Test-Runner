class PersonTests
{
    private Person person;

    [Setup]
    public void Init()
    {
        person = new Person("Alice", "Johnson", 2000);
    }

    [Test]
    public void TestFullName()
    {
        if (person.GetFullName() != "Alice Johnson")
            throw new Exception("Full name should be 'Alice Johnson'");
    }

    [Test]
    public void TestAge()
    {
        int currentYear = DateTime.Now.Year;
        int expectedAge = currentYear - person.BirthYear;
        if (person.GetAge(currentYear) != expectedAge)
            throw new Exception($"Expected age: {expectedAge}");
    }

    [Test]
    public void TestIsAdult()
    {
        if (!person.IsAdult())
            throw new Exception("Person should be an adult");
    }

    [Test]
    public void TestInvalidBirthYearThrows()
    {
        new Person("Failed", "Test", DateTime.Now.Year + 1);

    }

    [Teardown]
    public void Cleanup()
    {
        person = null;
    }
}