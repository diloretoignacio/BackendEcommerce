# BackendEcommerce 📩

El presente proyecto es una **API** capaz de gestionar el **backend de un sistema Ecommerce**. Para el desarrollo de la misma se ha utilizando una **arquitectura Hexagonal** y **Entity Framework** como ORM.

A continuacion se demuestran los principales endopoints para realizar acciones sobre la informacion:
## Crear Cliente
### Request
```
POST /api/clientes
```
### Body
```
{
    "dni": "1234567892",
    "name": "Ignacio",
    "lastname": "Di Loreto",
    "address": "Calle 123",
    "phoneNumber": "123456789"
}
```

## Obtener Productos filtrados y/o ordenados
```
GET /api/productos?name=NombreProducto&sort=Sort
```
* NombreProducto = Nombre del producto que se desea buscar (si es vacio se listan TODOS)
* Sort = Indica el orden en el que se listan los productos segun el precio. True = orden ascendente. False = orden descendente

### Response
```
[
    {
        "productoId": 6,
        "nombre": "Auriculares Gamer",
        "descripcion": "A10 Ps4 gris y azul",
        "marca": "Astro",
        "codigo": "00000006",
        "precio": 9000.00,
        "image": "https://mexx-img-2019.s3.amazonaws.com/auricular-gamer_40531_1.jpeg"
    }
]
```

## Compras realizadas en un rango de fechas
### Request
```
POST /api/orden?from=2023-01-04&to=2023-01-05
```
### Response
```
{
    "from": "2023-01-04",
    "to": "2023-01-04",
    "recaudacion": 459000.00,
    "orders": [
        {
            "ordenId": "16517daa-ef89-4487-2960-08daee756810",
            "fecha": "2023-01-04T14:02:05.0736833",
            "total": 152500.00,
            "productos": [
                {
                    "cantidad": 1,
                    "producto": {
                        "productoId": 2,
                        "nombre": "Monitor Gamer",
                        "descripcion": "24'' Full HD 60Hz 4Ms",
                        "marca": "Samsung",
                        "codigo": "00000002",
                        "precio": 50000.00,
                        "image": "https://mexx-img-2019.s3.amazonaws.com/33741_1.jpeg"
                    }
                },
                {
                    "cantidad": 1,
                    "producto": {
                        "productoId": 4,
                        "nombre": "Camara Web",
                        "descripcion": "4K Rightlight 3",
                        "marca": "Logitech",
                        "codigo": "00000004",
                        "precio": 39000.00,
                        "image": "https://mexx-img-2019.s3.amazonaws.com/35036_2.jpeg"
                    }
                }
            ],
            "clienteId": 1
        },
        {
            "ordenId": "503c0cf7-6a38-4f8f-2961-08daee756810",
            "fecha": "2023-01-04T14:02:43.0099017",
            "total": 50000.00,
            "productos": [
                {
                    "cantidad": 1,
                    "producto": {
                        "productoId": 2,
                        "nombre": "Monitor Gamer",
                        "descripcion": "24'' Full HD 60Hz 4Ms",
                        "marca": "Samsung",
                        "codigo": "00000002",
                        "precio": 50000.00,
                        "image": "https://mexx-img-2019.s3.amazonaws.com/33741_1.jpeg"
                    }
                }
            ],
            "clienteId": 1
        }
    ]
}
```

Ademas se permite:

* Agregar productos al carrito
* Eliminar productos del carrito
* Realizar una compra

Todos los endpoints correspondientes se encuentran en el archivo **Collección Postman Ecommerce.json** que contiene la coleccion de Postamn utilizada
