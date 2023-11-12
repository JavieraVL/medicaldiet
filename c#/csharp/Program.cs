
using csharp.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/app/ver/pacientes", () =>
{
    medicalContext db = new medicalContext();
    var lista = db.Pacientes.ToList();
    return Results.Ok(lista);
});
//añadir paciente
app.MapPost("/app/pacientes/add", (Paciente paciente) =>
{
    medicalContext db = new medicalContext();
    db.Pacientes.Add(paciente);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("paciente agregado");
    else
        return Results.Problem();
});

//eliminar paciente por rut
app.MapDelete("/app/pacientes/eliminar/{rut}", (string rut) =>
{
    medicalContext db = new medicalContext();
    var paciente = new Paciente { Rut = rut };
    db.Entry(paciente).State = EntityState.Deleted;
    int k = db.SaveChanges();
    return k == 0 ? Results.Problem() : Results.Ok("Paciente Eliminado");
});

//mostrar pacientes
app.MapGet("/app/pacientes", () =>
{
    medicalContext db = new medicalContext();
    var lista = db.Pacientes.ToList();
    return Results.Ok(lista);
});

//mostrar profesionales
app.MapGet("/app/profesionales", () =>
{
    medicalContext db = new medicalContext();
    var lista = db.Profesionals.ToList();
    return Results.Ok(lista);
});


//añadir especialista
app.MapPost("/app/profesional/add", (Profesional profesional) =>
{
    medicalContext db = new medicalContext();
    db.Profesionals.Add(profesional);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("profesional agregado");
    else
        return Results.Problem();
});

//editar perfiles pacientes 
app.MapPut("/app/pacientes/edit", (Paciente paciente) =>
{
    System.Console.WriteLine(paciente.Rut);
    //System.Console.WriteLine(paciente.Nombre);
    medicalContext db = new medicalContext();
    var pacientess2 = db.Pacientes.FirstOrDefault(p => p.Rut == paciente.Rut);
    System.Console.WriteLine(pacientess2);
    //pacientess2.Rut = paciente.Rut;
    pacientess2.Nombre = paciente.Nombre;
    pacientess2.FechaNac = paciente.FechaNac;
    pacientess2.Apellidos = paciente.Apellidos;
    pacientess2.Telefono = paciente.Telefono;
    pacientess2.Correo = paciente.Correo;
    pacientess2.Sexo = paciente.Sexo;
    pacientess2.Edad = paciente.Edad;
    pacientess2.Peso = paciente.Peso;
    pacientess2.Descripcion = paciente.Descripcion;
    db.Entry(pacientess2).State = EntityState.Modified;
    int element = db.SaveChanges();
    var lista = db.Pacientes.ToList();
    return Results.Ok(lista);
});

//editar la dieta
app.MapPut("/app/dieta/edit", (DietaOriginal dieta) =>
{
    {
        System.Console.WriteLine(dieta.Id);
        medicalContext db = new medicalContext();
        var dietaa2 = db.DietaOriginals.FirstOrDefault(p => p.Id == dieta.Id);
        System.Console.WriteLine(dietaa2);
        dietaa2.Nombre = dieta.Nombre;
        dietaa2.Descripcion = dieta.Descripcion;
        dietaa2.Categoria = dieta.Categoria;
        db.Entry(dietaa2).State = EntityState.Modified;
        int element = db.SaveChanges();
        var lista = db.DietaOriginals.ToList();
        return Results.Ok(lista);
    }
});

//añadir citas
app.MapPost("/app/citas/add", (Citum citum) =>
{
    medicalContext db = new medicalContext();
    db.Cita.Add(citum);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("cita agregada");
    else
        return Results.Problem();
});

//--------------------------------------------------------------------------------------------

//MODULO PROFESIONAL
//Crear dietas
app.MapPost("/app/dietas/add", (DietaOriginal dietaOriginal) =>
{
    medicalContext db = new medicalContext();
    db.DietaOriginals.Add(dietaOriginal);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("dieta agregada");
    else
        return Results.Problem();
});

//eliminar dieta x id
app.MapDelete("/app/dietas/eliminar/{id:int}", (int id) =>
{
    medicalContext db = new medicalContext();
    var dietas = new DietaOriginal { Id = id };
    db.Entry(dietas).State = EntityState.Deleted;
    int k = db.SaveChanges();
    return k == 0 ? Results.Problem() : Results.Ok("Dieta eliminada!");
});

//mostrar dietas e imagenes
app.MapGet("/app/dietas", () =>
{
    medicalContext db = new medicalContext();
    var k = db.DietaOriginals.ToList();
    return Results.Ok(k);
});


//mostrar ingredientes
app.MapGet("/app/mostrarIngredientes", () =>
{
    medicalContext db = new medicalContext();
    var lista = db.Ingredientes.ToList();
    return Results.Ok(lista);
});

//editar ingrediente por id
app.MapPut("/app/ingre/edit", (Ingrediente ingrediente) =>
{
    System.Console.WriteLine(ingrediente.Id);
    medicalContext db = new medicalContext();
    var ingre1 = db.Ingredientes.FirstOrDefault(p => p.Id == ingrediente.Id);
    ingre1.Id = ingre1.Id;
    System.Console.WriteLine(ingre1);
    db.Entry(ingre1).State = EntityState.Modified;
    int element = db.SaveChanges();
    var lista = db.Pacientes.ToList();
    return Results.Ok(lista);
});

//editar estado de activo a bloquea y de bloqueado a activo
app.MapPut("/app/actEstado", (Paciente paciente) =>
{
    System.Console.WriteLine(paciente.Rut);
    medicalContext db = new medicalContext();
    //var pacientess = new Paciente {Rut = paciente.Rut};
    var pacientess = db.Pacientes.FirstOrDefault(p => p.Rut == paciente.Rut);
    pacientess.Estado = paciente.Estado;
    System.Console.WriteLine(pacientess);
    db.Entry(pacientess).State = EntityState.Modified;
    int element = db.SaveChanges();
    var lista = db.Pacientes.ToList();
    return Results.Ok(lista);
});

//editar estado de activo a blopqueado de profesional
app.MapPut("/app/actEstado/profesional", (Profesional profesional) =>
{
    System.Console.WriteLine(profesional.Rut);
    medicalContext db = new medicalContext();
    var profesionall = db.Profesionals.FirstOrDefault(p => p.Rut == profesional.Rut);
    profesionall.Estado = profesional.Estado;
    System.Console.WriteLine(profesionall);
    db.Entry(profesionall).State = EntityState.Modified;
    int element = db.SaveChanges();
    var lista = db.Profesionals.ToList();
    return Results.Ok(lista);
});

//add ingrea
app.MapPost("/app/ingrediente0/add", (Ingrediente ingrediente) =>
{
    medicalContext db = new medicalContext();
    db.Ingredientes.Add(ingrediente);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("ingrediente agregado");
    else
        return Results.Problem();
});


//crear informacion nutricional... tabla ingredientesa
app.MapPost("/app/infonutri/add", (IngredienteDietum infonutri) =>
{
    medicalContext db = new medicalContext();
    db.IngredienteDieta.Add(infonutri);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("Informacion nutricional agregada");
    else
        return Results.Problem();
});

//eliminar por id, informacion nutricional... tabla ingredientesa
app.MapDelete("/app/infonutri/eliminar/{id:int}", (int id) =>
{
    medicalContext db = new medicalContext();
    var infonutri = new IngredienteDietum { Id = id };
    db.Entry(infonutri).State = EntityState.Deleted;
    int k = db.SaveChanges();
    return k == 0 ? Results.Problem() : Results.Ok("Informacion Nutricional eliminada!");
});

//editar informacion nutriciconal
// app.MapPut("/app/infonutri/edit", (IngredienteDietum infonutri) =>
// {
//     System.Console.WriteLine(infonutri.Id);
//     medicalContext db = new medicalContext();
//     var infonutrii = db.IngredienteDieta.FirstOrDefault(p => p.Id == infonutri.Id);
//     infonutrii.Porciones = infonutri.Porciones;
//     System.Console.WriteLine(infonutrii);
//     db.Entry(infonutrii).State = EntityState.Modified;
//     int element = db.SaveChanges();
//     var lista = db.IngredienteDieta.ToList();
//     return Results.Ok(lista);
// });

//ver infonutri
app.MapGet("/app/ver/infonutri", () =>
{
    medicalContext db = new medicalContext();
    var k = db.IngredienteDieta.ToList();
    return Results.Ok(k);
});


app.Run();
