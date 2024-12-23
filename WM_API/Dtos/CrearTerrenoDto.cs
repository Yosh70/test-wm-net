namespace WM_API.Dtos;

public class CrearTerrenoDto
{
    public string Nombre { get; set; }
    public int IdLocalidad { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public AltoTerrenoDto AltoTerreno { get; set; }

}
