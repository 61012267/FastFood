var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de CORS
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

// 2. Middlewares para Servir Archivos Estáticos (wwwroot) y CORS
app.UseCors();
app.UseDefaultFiles();
app.UseStaticFiles();

// 3. Endpoint de verificación
app.MapGet("/", () => "🛍️ API MarketExpress 3D Fresh - Minimarket & Orgánicos v1.0");

// 4. Endpoint principal de Productos del Minimarket
app.MapGet("/api/productos", () =>
{
    return Results.Ok(new object[]
    {
        new {
            id = 1,
            codigo = "REP-001",
            nombre = "Polvo de Cacao Orgánico",
            categoria = "Repostería",
            genero = "Orgánico",
            talla = "250g",
            color = "Cacao Puro",
            precio = 19.50,
            stock = 20,
            marca = "Calypso",
            material = "100% Cacao Orgánico en Polvo",
            temporada = "Todo el año",
            descuento = 0,
            imagen = "https://images.unsplash.com/photo-1584308666744-24d5c474f2ae?w=500",
            descripcion = "Cacao puro en polvo de origen peruano, ideal para repostería saludable, batidos y avena."
        },
        new {
            id = 2,
            codigo = "REP-002",
            nombre = "Guar Gum Gluten Free",
            categoria = "Repostería",
            genero = "Sin Gluten",
            talla = "226g",
            color = "Polvo Fino",
            precio = 35.90,
            stock = 14,
            marca = "Bob's Red Mill",
            material = "Goma Guar Natural",
            temporada = "Todo el año",
            descuento = 20,
            imagen = "https://www.ecotienda.pe/wp-content/uploads/2022/08/039978025548-1.jpg",
            descripcion = "Espesante natural ideal para panadería y repostería libre de gluten. Mejora la textura y volumen."
        },
        new {
            id = 3,
            codigo = "REP-003",
            nombre = "Mezcla para Galletas Choco Chips",
            categoria = "Repostería",
            genero = "Keto/Healthy",
            talla = "624g",
            color = "Choco Chips",
            precio = 29.20,
            stock = 3, // ¡Dispara alerta de stock bajo!
            marca = "Bob's Red Mill",
            material = "Harina de almendras y gotas de chocolate oscuro",
            temporada = "Todo el año",
            descuento = 25,
            imagen = "https://images.unsplash.com/photo-1499636136210-6f4ee915583e?w=500",
            descripcion = "Mezcla lista para horneado rápido de galletas crocantes con chispas de chocolate artesanal."
        },
        new {
            id = 4,
            codigo = "BEB-004",
            nombre = "Leche de Almendras Original Unsweetened",
            categoria = "Lácteos y Bebidas",
            genero = "Plant-Based",
            talla = "1 Litro",
            color = "Natural",
            precio = 16.80,
            stock = 18,
            marca = "Silk",
            material = "Almendras tostadas, calcio y vitaminas",
            temporada = "Todo el año",
            descuento = 10,
            imagen = "https://images.unsplash.com/photo-1563636619-e9143da7973b?w=500",
            descripcion = "Bebida vegetal de almendras sin azúcar añadida, enriquecida con calcio y vitamina D."
        },
        new {
            id = 5,
            codigo = "SNK-005",
            nombre = "Matcha Latte Orgánico en Polvo",
            categoria = "Bebidas",
            genero = "Superfood",
            talla = "150g",
            color = "Verde Matcha",
            precio = 42.00,
            stock = 2, // ¡Dispara alerta de stock crítico!
            marca = "Matcha Co",
            material = "Té Verde Matcha Grado Ceremonial",
            temporada = "Todo el año",
            descuento = 15,
            imagen = "https://images.unsplash.com/photo-1536256263959-770b48d82b0a?w=500",
            descripcion = "Té verde matcha ceremonial rico en antioxidantes para energía natural y concentración."
        }
    });
});

// 5. Asignación dinámica de puerto para Render o entorno local
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");
