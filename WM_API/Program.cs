var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    }));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("WMart");
builder.Services.AddDbContext<TestContext>(ServiceLifetime.Scoped);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

var resultado = app.MapGroup("/geografia").WithTags("Geografia");

resultado.MapPost("unidades", async ([FromBody] AltoTerrenoDto terreno) =>
{
    //int[] terreno = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
    int[,] matriz = Funcion.ObtenerMatriz(terreno.Datos);
    int unidades = Funcion.ObtenerTotalUnidades(matriz);
    return await Task.FromResult(unidades);
})
.WithName("PostUnidades")
.WithOpenApi();


resultado.MapPost("altaterreno", async ([FromBody] CrearTerrenoDto crearTerrenoDto) =>
    {

        var terreno = new Terreno();
        terreno.Nombre = crearTerrenoDto.Nombre;
        terreno.Latitud = crearTerrenoDto.Latitud;
        terreno.Longitud = crearTerrenoDto.Longitud;
        terreno.AlturaTerreno = string.Join(",", crearTerrenoDto.AltoTerreno.Datos);

        int[,] matriz = Funcion.ObtenerMatriz(crearTerrenoDto.AltoTerreno.Datos);
        terreno.UnidadesTerreno = string.Join(",", Funcion.ObtenerUnidadesTerreno(matriz));
        terreno.LocalidadId = crearTerrenoDto.IdLocalidad;

        using var context = new TestContext();
        var localidad = context.Localid.FirstOrDefault(x => x.Id == terreno.LocalidadId);

        if (localidad is null)
            return await Task.FromException<string>(
                new Exception($"No existe el LocalidadId: {terreno.LocalidadId}"));

        context.Add(terreno);
        await context.SaveChangesAsync();
        return await Task.FromResult("Se guardo con Exito");

    })
    .WithName("PostAltaTerreno")
    .WithOpenApi();


resultado.MapGet("terreno/{id}", async ([FromRoute] int id) =>
{
    using var context = new TestContext();
    var terreno = await context.Terreno.FirstOrDefaultAsync(x => x.Id == id);

    if (terreno is null)
        return await Task.FromException<Terreno>(new Exception($"No existe el id: {id}"));

    return await Task.FromResult(terreno);
})
.WithName("GetTerreno")
.WithOpenApi();


app.UseCors();
app.Run();




