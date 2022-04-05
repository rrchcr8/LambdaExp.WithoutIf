
var data = new Beer() { Name = "Minerva" };
//Console.WriteLine(BeerValidations.NotNullName(data));
//Console.WriteLine(BeerValidations.NotNullCountry(data));

Console.WriteLine(Validator.Validate(data, BeerValidations.validations));
 

//CHECKOUT THE COMMITS


public class Globalvalidations<T>
{
    public static readonly Predicate<T> NotNull =
        (d) => d != null;
}

    public class BeerValidations
{
    public static readonly Predicate<Beer>[] validations =
    {
    (d) => Globalvalidations<string>.NotNull(d.Name),
    (d) => Globalvalidations<string>.NotNull(d.Country),
    (d) =>  d.Name != null && d.Name.Count() < 10,
    (d) =>  d.Country != null && d.Country.Count() < 100,
    };
                                                         
    //public static readonly Predicate<Beer> NotNullName = (d) => d.Name != null;
    //public static readonly Predicate<Beer> NotNullCountry = (d) => d.Country != null;
}

public class Validator
{
    public static bool Validate<T>(T beer, params Predicate<T>[] validations) =>
        validations.ToList().Where(d =>
        {
            return !d(beer);
        }).Count() == 0;

        }
public class Beer
{
    public string Name { get; set; }
    public string Country { get; set; }
}


