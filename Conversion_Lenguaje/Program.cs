using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Conversion_Lenguaje;
using System.Text.Json.Serialization;


[XmlRoot("Persona")]
public class Persona
{
    [XmlAttribute("Id")]
    public int Id { get; set; }

    [XmlElement("Nom")]
    [JsonPropertyName("Nom")]
    public string NomCognoms { get; set; } = default!;


    [XmlElement("DataNaixement")]
    public DateTime DataNaixement { get; set; }

    [XmlElement("Edat")]
    public int Edat { get; set; }

    [XmlArray("Mascotes")]
    [XmlArrayItem("Mascota")]
    public List<Mascota> Mascotes { get; set; } = new();
}

public class Operacio : IOperacio
{
    public Persona GetPersonaFromRandom()
    {
        return new Persona
        {
            Id = 1,
            NomCognoms = "Alex Martínez",
            Edat = 25,
            DataNaixement = new DateTime(1999, 10, 20),
            Mascotes = new List<Mascota>
            {
                new() { Nom = "Bobby", Tipus = "Gos" },
                new() { Nom = "Miau", Tipus = "Gat" }
            }
        };
    }

    public void DesarPersonaAsXml(string fitxer, Persona persona)
    {
        XmlSerializer serializer = new(typeof(Persona));
        using (FileStream fs = new(fitxer + ".xml", FileMode.Create))
        {
            serializer.Serialize(fs, persona);
        }
    }

    public void DesarPersonaAsJson(string fitxer, Persona persona)
    {
        string json = JsonSerializer.Serialize(persona);
        File.WriteAllText(fitxer + ".json", json);
    }

    public Persona GetPersonaFromXml(string fitxer)
    {
        XmlSerializer serializer = new(typeof(Persona));
        using (FileStream fs = new(fitxer + ".xml", FileMode.Open))
        {
            return (Persona)(serializer.Deserialize(fs) ?? throw new InvalidOperationException("Error deserialitzant XML"));
        }
    }

    public Persona GetPersonaFromJson(string fitxer)
    {
        string json = File.ReadAllText(fitxer + ".json");
        return JsonSerializer.Deserialize<Persona>(json) ?? throw new InvalidOperationException("Error deserialitzant JSON");
    }

    public void PintaPersonaPerConsola(Persona persona)
    {
        Console.WriteLine($"Persona: {persona.NomCognoms}, Edat: {persona.Edat}, Naixement: {persona.DataNaixement.ToShortDateString()}");
        foreach (var mascota in persona.Mascotes)
        {
            Console.WriteLine($" - Mascota: {mascota.Nom}, Tipus: {mascota.Tipus}");
        }
    }
}


public class Mascota
{
    [XmlAttribute("Nom")]
    public string Nom { get; set; } = default!;

    [XmlElement("Tipus")]
    public string Tipus { get; set; } = default!;
}


class Programa
{
    static void Main(string[] args)
    {
        IOperacio operacio = new Operacio(); // Instanciem la classe que implementa IOperacio
        Persona persona = operacio.GetPersonaFromRandom(); // Obtenim una persona random
        string fitxer = "persona"; // Nom del fitxer per defecte

        int opcio;
        do
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("0) Sortir");
            Console.WriteLine("1) Desar persona com XML");
            Console.WriteLine("2) Desar persona com JSON");
            Console.WriteLine("3) Llegir persona des d'XML");
            Console.WriteLine("4) Llegir persona des de JSON");
            Console.WriteLine("5) Definir nom de fitxer");
            Console.WriteLine("6) Pintar dades");
            Console.Write("Escull una opció: ");

            if (!int.TryParse(Console.ReadLine(), out opcio))
            {
                Console.WriteLine("Opció no vàlida, torna a intentar-ho.");
                continue;
            }

            switch (opcio)
            {
                case 1:
                    operacio.DesarPersonaAsXml(fitxer, persona);
                    Console.WriteLine($"Persona desada a {fitxer}.xml");
                    break;
                case 2:
                    operacio.DesarPersonaAsJson(fitxer, persona);
                    Console.WriteLine($"Persona desada a {fitxer}.json");
                    break;
                case 3:
                    persona = operacio.GetPersonaFromXml(fitxer);
                    Console.WriteLine("Persona carregada des d'XML.");
                    break;
                case 4:
                    persona = operacio.GetPersonaFromJson(fitxer);
                    Console.WriteLine("Persona carregada des de JSON.");
                    break;
                case 5:
                    Console.Write("Introdueix el nou nom de fitxer (sense extensió): ");
                    fitxer = Console.ReadLine()?.Trim() ?? "persona";
                    Console.WriteLine($"Nom del fitxer actualitzat a: {fitxer}");
                    break;
                case 6:
                    operacio.PintaPersonaPerConsola(persona);
                    break;
                case 0:
                    Console.WriteLine("Sortint...");
                    break;
                default:
                    Console.WriteLine("Opció no vàlida, torna a intentar-ho.");
                    break;
            }
            
        } while (opcio != 0);
    }
}
