﻿namespace WM_API.Modelos;

public class Estado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int PaisId { get; set; }
    public Pais Pais { get; set; }
}
