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
        // --- PRODUCTOS EXISTENTES ---
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
            stock = 3, // Alerta stock bajo
            marca = "Bob's Red Mill",
            material = "Harina de almendras y gotas de chocolate oscuro",
            temporada = "Todo el año",
            descuento = 25,
            imagen = "https://www.ecotienda.pe/wp-content/uploads/2022/08/39978004673.jpg",
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
            stock = 2, // Alerta stock bajo
            marca = "Matcha Co",
            material = "Té Verde Matcha Grado Ceremonial",
            temporada = "Todo el año",
            descuento = 15,
            imagen = "https://images.unsplash.com/photo-1536256263959-770b48d82b0a?w=500",
            descripcion = "Té verde matcha ceremonial rico en antioxidantes para energía natural y concentración."
        },

        // --- NUEVOS PRODUCTOS DE MINIMARKET ---
        new {
            id = 6,
            codigo = "LAC-006",
            nombre = "Mantequilla GLORIA Pote",
            categoria = "Lácteos y Bebidas",
            genero = "Con Sal",
            talla = "390g",
            color = "Amarillo",
            precio = 16.50,
            stock = 25,
            marca = "Gloria",
            material = "Crema de leche pasteurizada y sal",
            temporada = "Todo el año",
            descuento = 7,
            imagen = "https://corporacionliderperu.com/52925-large_default/gloria-mantequilla-pote-x-390-gr.jpg",
            descripcion = "Mantequilla tradicional Gloria en pote, ideal para untar en desayunos y repostería."
        },
        new {
            id = 7,
            codigo = "LAC-007",
            nombre = "Mezcla Láctea IDEAL Amanecer",
            categoria = "Lácteos y Bebidas",
            genero = "Lata Pack 6",
            talla = "390g c/u",
            color = "Azul / Rojo",
            precio = 18.50,
            stock = 15,
            marca = "Ideal",
            material = "Leche evaporada concentrada y vitaminas A y D",
            temporada = "Todo el año",
            descuento = 0,
            imagen = "https://vegaperu.vtexassets.com/arquivos/ids/161725-1600-auto?v=638054217213030000&width=1600&height=auto&aspect=true",
            descripcion = "Paquete de 6 latas de mezcla láctea fortificada con hierro y vitaminas para la familia."
        },
        new {
            id = 8,
            codigo = "ABR-008",
            nombre = "Café Instantáneo NESCAFÉ Kirma",
            categoria = "Abarrotes",
            genero = "Instantáneo",
            talla = "180g",
            color = "Rojo",
            precio = 17.60,
            stock = 4, // Alerta stock bajo
            marca = "Kirma",
            material = "100% Café peruano tueste oscuro",
            temporada = "Todo el año",
            descuento = 26,
            imagen = "https://tiendanestle.pe/cdn/shop/files/4551_1.jpg?v=1692026792&width=990",
            descripcion = "Café instantáneo rendidor de sabor intenso y aroma tradicional, lata de 180 gramos."
        },
        new {
            id = 9,
            codigo = "CNG-009",
            nombre = "Nuggets de Pollo Precocido AVINKA",
            categoria = "Congelados",
            genero = "Empanizado",
            talla = "Bolsa 15un",
            color = "Verde",
            precio = 7.90,
            stock = 30,
            marca = "Avinka",
            material = "Pechuga de pollo seleccionada y empanizado crujiente",
            temporada = "Todo el año",
            descuento = 20,
            imagen = "https://avinkape.vtexassets.com/arquivos/ids/156438-1200-auto?v=638966799449600000&width=1200&height=auto&aspect=true",
            descripcion = "Nuggets de pollo crocantes precocidos listos para freír o hacer en airfryer en minutos."
        },
        new {
            id = 10,
            codigo = "FRE-010",
            nombre = "Huevos de Codorniz LA CALERA",
            categoria = "Abarrotes",
            genero = "Fresco",
            talla = "Paquete 18un",
            color = "Verde / Blanco",
            precio = 7.50,
            stock = 12,
            marca = "La Calera",
            material = "Huevos de codorniz seleccionados",
            temporada = "Todo el año",
            descuento = 0,
            imagen = "https://media.falabella.com/tottusPE/43392387_1/w=1200,h=1200,fit=pad",
            descripcion = "Huevos de codorniz frescos y nutritivos en empaque protegido de 18 unidades."
        },
        new {
            id = 11,
            codigo = "LAC-011",
            nombre = "Leche UHT GLORIA Zero Lacto Pack 3",
            categoria = "Lácteos y Bebidas",
            genero = "Sin Lactosa",
            talla = "Caja 946ml x 3",
            color = "Celeste",
            precio = 16.20,
            stock = 10,
            marca = "Gloria",
            material = "Leche descremada UHT digestiva",
            temporada = "Todo el año",
            descuento = 5,
            imagen = "https://plazavea.vteximg.com.br/arquivos/ids/35081609-465-465/20402671.jpg",
            descripcion = "Tripack de leche UHT ligera y fácil de digerir, baja en grasas y sin lactosa."
        },
        new {
            id = 12,
            codigo = "SNK-012",
            nombre = "Papas Nativas Chips con Sal de Mar",
            categoria = "Snacks",
            genero = "Crocante",
            talla = "140g",
            color = "Naranja",
            precio = 8.90,
            stock = 22,
            marca = "Inka Chips",
            material = "Papas nativas peruanas y aceite de girasol",
            temporada = "Todo el año",
            descuento = 10,
            imagen = "https://metroio.vtexassets.com/arquivos/ids/412538-800-auto?v=638279044334200000&width=800&height=auto&aspect=true",
            descripcion = "Snack de papas nativas crujientes con hojuelas de sal marina natural."
        },
        new {
            id = 13,
            codigo = "BEB-013",
            nombre = "Jugo Natural de Naranja Fresca del VALLE",
            categoria = "Lácteos y Bebidas",
            genero = "100% Fruta",
            talla = "1 Litro",
            color = "Naranja",
            precio = 12.50,
            stock = 5, // Alerta stock bajo
            marca = "BioFresh",
            material = "Jugo exprimido de naranjas seleccionadas",
            temporada = "Todo el año",
            descuento = 0,
            imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSWv9TqCM0FM--b2zTNvUZd7rBzcKo_P5XJoFcMj69oPC2evlgg_6VFW_A&s=10",
            descripcion = "Jugo natural sin conservantes ni azúcar añadida, prensado en frío."
        }
    });
});

// 5. Asignación dinámica de puerto para Render o entorno local
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");
