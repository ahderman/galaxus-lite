## How to run

dotnet run --launch-profile https

## Test the API

### POST /api/products

```sh
curl -i -k -X POST https://localhost:7140/api/products \
-H "Content-type: application/json" \
--data '
{
    "id": 1,
    "name": "Zeller Present Hai",
    "description": "Modern und gemütlicher Katzen-Korb mit Innenkissen",
    "imageUrl": "https://www.galaxus.ch/im/productimages/6/6/8/6/8/6/3/3/4/1/0/1/2/0/9/9/3/1/7/8952e623-3122-4a0d-b721-6bdbfbb35c01_cropped.jpg"
}'
```

### GET /api/products

```sh
curl -i -k https://localhost:7140/api/products
```

### GET /api/products/1

```sh
curl -i -k https://localhost:7140/api/products/1
```

## Resources

- https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio-code


## Questions

What does this do?

`dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 7.0.0`

## Process

- Add model
- Add controller
