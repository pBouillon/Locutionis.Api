# 📚 Locutionis API

The Locutionis API is an API exposing informations and details about some
french figures of speech.

## Demo

You can freely play around with the API using the exposed [Swagger UI](https://locutionisapi-production.up.railway.app/swagger/index.html).

> 🛑 For now the API is hosted on [Railway](https://railway.app) under the [Trial plan](https://railway.app/pricing) so the service might not be available at the time you are querying it.

## Installation

In order to run the API you can either:

- Run it from a docker container using the `Dockerfile`
- Run it locally using .NET 7

## Contributing

All contributions are welcome

If you want to contribute to this project feel free to check the [available issues](https://github.com/pBouillon/Locutionis.Api/issues)!

---

## Usage

For now, two endpoints are available.

### Getting all figure of speech

#### Request endpoint

```url
/api/figures-of-speech
```

#### Returns

A JSON with an array of objects containing the name of the figure of speech along with a preview of its definition.

Example:

```curl
curl -X 'GET' \
  'https://localhost:7286/api/figures-of-speech' \
  -H 'accept: application/json'
```

```json
[
  {
    "name": "Alitération",
    "preview": "L'alitération est la répétition d'une ou de plusieurs consonnes ou plus généralement d'un même son c..."
  }
]
```

### Getting a specific figure of speech by its name

#### Request endpoint

```url
/api/figures-of-speech/{name}
```

#### Returns

A JSON object containing the details of the figure of speech whose name is the provided `name`.

> 🛑 The name is case and accent sensitive  
> Searching for "Alitération" will return a result but "**a**litération" and "Alit**e**ration" will not

The response will contain:

- The name of the figure of speech
- A description of it, how can someone qualify it
- The purpose of its usage, why would someone use it
- Some sources that can be consulted to dig the subject a little bit more
- Some usage examples along with the name of the work from which they are taken

Example:

```curl
curl -X 'GET' \
  'https://localhost:7286/api/figures-of-speech/Alitération' \
  -H 'accept: application/json'
```

```json
{
  "name": "Alitération",
  "description": "L'alitération est la répétition d'une ou de plusieurs consonnes ou plus généralement d'un même son consonne.",
  "purpose": "Le sens de la répétition du son se trouve dans le contexte dans lequel il est utilisé. Par exemple, pour décrire un éboulement, un son [r] répété rappellera les roulements des rochers qui tombent.",
  "sources": [
    {
      "displayName": "Wikipedia",
      "url": "https://fr.wikipedia.org/wiki/Alitération"
    }
  ],
  "usages": [
    {
      "example": "Pour qui sont ces serpents qui sifflent sur vos têtes ?",
      "source": "Racine, Andromaque, acte V, scène 5"
    },
    {
      "example": "(...) l'onde de choc fractura le fémur d'enceinte et le vent sabla cru le village à travers les jointures béantes du granit. Sous mon casque, le son atroce du roc poncé perce, mes dents vibrent - je plie contre Pietro, des aiguilles de quartz crissent sur son masque de contre.",
      "source": "La horde du contrevent, Alain Damasio"
    }
  ]
}
```

