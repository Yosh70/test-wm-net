namespace WM_API.Modelos;

public class Terreno
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public string AlturaTerreno { get; set; }
    public string UnidadesTerreno { get; set; }
    public int LocalidadId { get; set; }
    public Localidad Localidad { get; set; }

}
