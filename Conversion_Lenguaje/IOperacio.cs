
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Conversion_Lenguaje;


public interface IOperacio
{
    /// <summary>
    /// Crea una persona, s'inventa les dades
    /// </summary>
    /// <returns>Una persona</returns>
    Persona GetPersonaFromRandom();

    /// <summary>
    /// Desar una persona a un fitxer XML
    /// </summary>
    /// <param name="fitxer">Nom del fitxer, sense extensió (la funció li posarà extensió XML)</param>
    /// <param name="persona">Dades a serialitzar</param>
    void DesarPersonaAsXml(string fitxer, Persona persona);

    /// <summary>
    /// Desar una persona a un fitxer JSON
    /// </summary>
    /// <param name="fitxer">Nom del fitxer, sense extensió (la funció li posarà extensió JSON)</param>
    /// <param name="persona">>Dades a serialitzar</param>
    void DesarPersonaAsJson(string fitxer, Persona persona);

    /// <summary>
    /// Obtenir una persona d'un fitxer XML
    /// </summary>
    /// <param name="fitxer">Nom del fitxer, sense extensió (la funció li posarà extensió XML)</param>
    /// <returns>Una persona</returns>
    Persona GetPersonaFromXml(string fitxer);

    /// <summary>
    ///  Obtenir una persona d'un fitxer JSON
    /// </summary>
    /// <param name="fitxer">>Nom del fitxer, sense extensió (la funció li posarà extensió JSON)</param>
    /// <returns>Una persona</returns>
    Persona GetPersonaFromJson(string fitxer);

    /// <summary>
    /// Imprimir per consola les dades d'una persona
    /// </summary>
    /// <param name="persona">>Persona a imprimir</param>
    void PintaPersonaPerConsola(Persona persona);
}