class Person
{
    public string FirstName { get; }
    public string LastName { get; }
    public int BirthYear { get; }

    public Person(string firstName, string lastName, int birthYear)
    {
        if (birthYear < 0 || birthYear > DateTime.Now.Year)
            throw new ArgumentException("Invalid birthYear");
        FirstName = firstName;
        LastName = lastName;
        BirthYear = birthYear;
    }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    public int GetAge(int currentYear)
    {
        return currentYear - BirthYear;
    }

    public bool IsAdult()
    {
        return GetAge(DateTime.Now.Year) >= 18;
    }
}
