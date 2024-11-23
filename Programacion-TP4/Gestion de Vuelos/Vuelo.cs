using System;

public class Vuelo
{
    // Atributos
    public string Codigo { get; set; }
    public DateTime FechaSalida { get; set; }
    public DateTime FechaLlegada { get; set; }

    public string NombrePiloto { get; set; }
    public string NombreCoPiloto { get; set; }

    public int CapacidadMaxima { get; set; }
    public double PasajerosAbordo { get; set; }
    public double PorcentajeOcupacion { get; set; }

    //Constructor
    public Vuelo(string codigo,DateTime fechaSalida,
                 DateTime fechaLlegada,string nombrePiloto, string nombreCoPiloto,
                 int capacidadMaxima,double porcentajeOcupacion = 0)
    {


         Codigo = codigo;
         FechaSalida = fechaSalida;
         FechaLlegada = fechaLlegada;

         NombrePiloto = nombrePiloto;
         NombreCoPiloto = nombreCoPiloto;

         CapacidadMaxima = capacidadMaxima;

        PorcentajeOcupacion = porcentajeOcupacion;


}


    public void RegistrarPasajeros(double numPasajeros)
    {
        PasajerosAbordo = numPasajeros;
        PorcentajeOcupacion = (PasajerosAbordo / CapacidadMaxima) * 100;
    }


}
