using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using static System.Console;


namespace SimpleProject
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int _identNumber;
    [NonSerialized]
        const string Planet = "Earth";
        public Person(int number)
        {
            _identNumber = number;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Identification number: { _identNumber}, Planet: { Planet}.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(346875)
            { Name = "Jack", Age = 34 };
            SoapFormatter soapFormat = new SoapFormatter();
            try
            {
                using (Stream fStream =
                File.Create("test.soap"))
                {
                    soapFormat.Serialize(fStream, person);
                }
                WriteLine("SoapSerialize OK!\n");
                Person p = null;
                using (Stream fStream =
                File.OpenRead("test.soap"))
                {
                    p = (Person)soapFormat.Deserialize(fStream);
                }
                WriteLine(p);
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }
        }
    }
}