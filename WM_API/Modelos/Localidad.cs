namespace WM_API.Modelos;

public class Localidad
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int EstadoId { get; set; }
    public Estado Estado { get; set; }

}
