public class Birth {
    public String Name { get; set; }
    public double? Age { get; set; }
    public bool IsValid()
    {
        return Name != null && Age != null && Age > 0;
    }

    public int Calculate()
    {
        return (int) (2024 - Age);
    }
}