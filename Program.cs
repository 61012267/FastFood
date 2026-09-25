var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de CORS para permitir peticiones desde Vite / Frontend
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 2. Uso del Middleware de CORS
app.UseCors();

// 3. Endpoint de verificación
app.MapGet("/", () => "🍔 API Fast Food & Pizzería funcionando correctamente v1.0");

// 4. Endpoint principal del Menú / Productos
app.MapGet("/api/productos", () =>
{
    return Results.Ok(new object[]
    {
        new {
            id = 1,
            codigo = "CMB-001",
            nombre = "Combo Royale Burger",
            categoria = "Hamburguesas",
            genero = "Doble",
            talla = "Papas + Bebida",
            color = "Sin Picante",
            precio = 28.90,
            stock = 25,
            marca = "Angus",
            material = "Carne de res, Queso Cheddar, Tocino",
            temporada = "Todo el año",
            descuento = 10,
            imagen = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=500",
            descripcion = "Doble carne 100% Angus con queso cheddar fundido, tocino ahumado, papas fritas familiares y gaseosa de 500ml."
        },
        new {
            id = 2,
            codigo = "PIZ-002",
            nombre = "Pizza Pepperoni Suprema",
            categoria = "Pizzas",
            genero = "Familiar",
            talla = "12 Porciones",
            color = "Masa Tradicional",
            precio = 45.00,
            stock = 15,
            marca = "Artesanal",
            material = "Queso Mozzarella, Pepperoni, Salsa de tomate",
            temporada = "Todo el año",
            descuento = 15,
            imagen = "https://images.unsplash.com/photo-1628840042765-356cda07504e?w=500",
            descripcion = "Pizza gigante con abundante queso mozzarella, rodajas de pepperoni crujiente y orégano fresco."
        },
        new {
            id = 3,
            codigo = "BEB-003",
            nombre = "Inca Kola 1.5L",
            categoria = "Bebidas",
            genero = "1.5 Litros",
            talla = "Familiar",
            color = "Helada",
            precio = 9.50,
            stock = 4, // ¡Dispara la alerta de stock bajo!
            marca = "Coca-Cola Company",
            material = "Gaseosa con gas",
            temporada = "Todo el año",
            descuento = 0,
            imagen = "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?w=500",
            descripcion = "Bebida gaseosa helada de 1.5 litros ideal para acompañar combos familiares."
        },
        new {
            id = 4,
            codigo = "PST-004",
            nombre = "Volcán de Chocolate",
            categoria = "Postres",
            genero = "Personal",
            talla = "1 Unidad",
            color = "Caliente",
            precio = 14.00,
            stock = 12,
            marca = "Bakery Express",
            material = "Cacao 70%, Bola de helado de vainilla",
            temporada = "Todo el año",
            descuento = 5,
            imagen = "https://images.unsplash.com/photo-1606313564200-e75d5e30476c?w=500",
            descripcion = "Bizcocho tibio de chocolate relleno de fudge derretido, acompañado con una bola de helado de vainilla."
        }
    });
});

// 5. Configuración dinámica del puerto para Render o entorno local
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");