# 🔄 XML & JSON Serialization Practice in C#

This is a console application developed as part of a practical assignment for the *Web Application Development (DAW)* course. It demonstrates how to serialize and deserialize data using XML and JSON formats in C#.

---

## 📚 Description

The program works with a custom `Persona` class that includes personal data and a list of `Mascota` (pet) objects. It allows you to:

- Generate a sample `Persona` with predefined data
- Save the object to an XML file using `XmlSerializer`
- Save the object to a JSON file using `System.Text.Json`
- Load the object back from XML or JSON
- Print all loaded data to the console
- Choose file name dynamically via menu

It includes a simple text-based menu for interaction.

---

## 🧪 Features

✅ C# object serialization  
✅ Support for both XML and JSON formats  
✅ Console-based menu navigation  
✅ File operations with custom file names  
✅ Educational and easy to extend

---

## 📸 Demo

```plaintext
Menú:
0) Sortir
1) Desar persona com XML
2) Desar persona com JSON
3) Llegir persona des d'XML
4) Llegir persona des de JSON
5) Definir nom de fitxer
6) Pintar dades
Escull una opció: 3
Persona carregada des d'XML.
Persona: Alex Martínez, Edat: 25, Naixement: 20/10/1999
 - Mascota: Bobby, Tipus: Gos
 - Mascota: Miau, Tipus: Gat
