using System.Diagnostics.CodeAnalysis;
using System.Text;




List<First_Encja> newE_1 = new List<First_Encja>();
for(int i =0; i < 100; i++)
{
    newE_1.Add(new First_Encja());
}
List<Second_Encja> newE_2 = new List<Second_Encja>();
for (int i = 0; i < 100; i++)
{
    newE_2.Add(new Second_Encja());
}
List<Third_Encja> newE_3 = new List<Third_Encja>();
for (int i = 0; i < 100; i++)
{
    newE_3.Add(new Third_Encja());
}
//Joinujemy pierwszą i drugą, oznaczamy przez co je łączymy, przekazujemy obiekty do func => tworzymy nowy obiekt
var obj_enc = newE_1.Join(newE_2, first => first.Id, sec => sec.Id,
                         (first, sec) => 
                         new Model(first.Id, first.HASH, sec.HASH))
                    .Join(newE_3,first => first.Id,second => second.Id,
                        (first,second) => new {Id = first.Id,Name = first.Hashed + second.HASH}).ToList();

foreach(var obj in obj_enc)
{
    Console.Write("ID of object: " + obj.Id);
    Console.Write(Environment.NewLine);
    Console.Write("Name (3 combined Hashes) of object: " + obj.Name);
    Console.Write(Environment.NewLine);
}

public class First_Encja
{
    private static int numer=0;
    public int Id { get; set; }
    public string HASH { get; set; }
    public string innaUnikalnaWartosc { get; set; }
    private StringBuilder sb;
    Random rand;
    public First_Encja()
    {
        sb = new StringBuilder();
        rand= new Random();
        Id = numer++;
        HASH = sb.AppendJoin("",generateRandomCharacter(),
                                generateRandomCharacter(),
                                generateRandomCharacter(),
                                generateRandomCharacter(),
                                generateRandomCharacter()).ToString();

        sb.Clear();
        innaUnikalnaWartosc = sb.AppendJoin("","#", numer).ToString();
        //Console.WriteLine(innaUnikalnaWartosc);
        //Console.WriteLine(HASH);
    }

    private char generateRandomCharacter()
    {
        return (char)rand.Next(60, 120);
    }
}
public class Model
{
    public int Id;
    public string Hashed;
    public Model(int id,string H1, string H2)
    {
        this.Id = id;
        this.Hashed = H1 + H2;
    }
}


public class Second_Encja
{
    private static int numer = 0;
    public int Id { get; set; }
    public string HASH { get; set; }
    public string innaUnikalnaWartosc { get; set; }
    private StringBuilder sb;
    Random rand;
    public Second_Encja()
    {
        sb = new StringBuilder();
        rand = new Random();
        Id = numer++;
        HASH = sb.AppendJoin("", generateRandomCharacter(),
                                generateRandomCharacter(),
                                generateRandomCharacter(),
                                generateRandomCharacter(),
                                generateRandomCharacter()).ToString();

        sb.Clear();
        innaUnikalnaWartosc = sb.AppendJoin("", "#", numer,(char)rand.Next(60,120)).ToString();
        //Console.WriteLine(innaUnikalnaWartosc);
        //Console.WriteLine(HASH);
    }

    private char generateRandomCharacter()
    {
        return (char)rand.Next(60, 120);
    }
}
public class Third_Encja
{
    private static int numer = 0;
    public int Id { get; set; }
    public string HASH { get; set; }
    public string innaUnikalnaWartosc { get; set; }
    private StringBuilder sb;
    Random rand;
    public Third_Encja()
    {
        sb = new StringBuilder();
        rand = new Random();
        Id = numer++;
        HASH = sb.AppendJoin("", generateRandomCharacter(),
                                generateRandomCharacter(),
                                generateRandomCharacter(),
                                generateRandomCharacter(),
                                generateRandomCharacter()).ToString();

        sb.Clear();
        innaUnikalnaWartosc = sb.AppendJoin("", "#", numer, (char)rand.Next(60, 120), (char)rand.Next(60, 120)).ToString();
        //Console.WriteLine(innaUnikalnaWartosc);
        //Console.WriteLine(HASH);
    }

    private char generateRandomCharacter()
    {
        return (char)rand.Next(60, 120);
    }
}