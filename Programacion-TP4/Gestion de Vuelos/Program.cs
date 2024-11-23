using System;
using System.Runtime.CompilerServices;
using System.Xml;
class Practica
{
    static List<Vuelo> listaVuelos = new List<Vuelo>();

    static void Main()
    {
        CargarDesdeXml("Vuelos.xml");
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("1_Agregar Vuelo");
            Console.WriteLine("2_Registrar Pasajeros en un vuelo");
            Console.WriteLine("3_Calcular Ocupacion de la Flota");
            Console.WriteLine("4_Vuelo con Mayor ocupacion");
            Console.WriteLine("5_Buscar Vuelo");
            Console.WriteLine("6_Listar Vuelo");
            Console.WriteLine("7_Cargar Datos");
            Console.WriteLine("8_Salir");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {

                case 1:
                    AgregarVuelo();
                    break;
                case 2:
                    CodigosVuelo();
                    RegistrarPasajero();
                    break;
                case 3:
                    OcupacionMedia();
                    Console.ReadKey();
                    break;
                case 4:
                    VueloMayorAMenor();
                    Vuelo mayorPorcentaje = listaVuelos[0];
                    MostrarVuelo(mayorPorcentaje);
                    Console.ReadKey();
                    break;
                case 5:
                    BuscarVuelo();
                    break;
                case 6:
                    VueloMayorAMenor();
                    MostrarListaVuelo();
                    Console.ReadKey();
                    break;
                case 7:
                    CargarDatos();
                    break;
                case 8:
                    Console.WriteLine("Adios");
                    break;

                default:
                    break;
            }

        } while (opcion != 8);

    }

    //1
    static void AgregarVuelo()
    {
        Console.WriteLine("Ingrese el código del vuelo:");
        string codigo = Console.ReadLine();
       
        Console.WriteLine("Ingrese la fecha y hora de salida (yyyy - MM - dd HH: mm)(2024-11-20 15:30):");
        DateTime fechaSalida = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese la fecha y hora de llegada (yyyy-MM-dd HH:mm)(2024-11-20 15:30):");
        DateTime fechaLlegada = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nombre del piloto:");
        string nombrePiloto = Console.ReadLine();

        Console.WriteLine("Ingrese el nombre del copiloto:");
        string nombreCoPiloto = Console.ReadLine();

        Console.WriteLine("Ingrese la capacidad máxima del avión:");
        int capacidadMaxima = int.Parse(Console.ReadLine());


    
        listaVuelos.Add(new Vuelo(codigo, fechaSalida, fechaLlegada, nombrePiloto, nombreCoPiloto, capacidadMaxima));

        Console.WriteLine("Vuelo agregado.");
        Thread.Sleep(2000);
    }

    //2
    static void RegistrarPasajero()
    {
        Console.WriteLine("Ingrese el codigo de vuelo:");
        string codigoVuelo = Console.ReadLine();

        Console.WriteLine("Ingrese la cantidad de pasajeros abordo:");
        double pasajerosAbordo = double.Parse(Console.ReadLine());


        foreach (var item in listaVuelos)
        {

            if (item.Codigo == codigoVuelo)
            {
                item.RegistrarPasajeros(pasajerosAbordo);
            }
        }

        Console.WriteLine("Pasajeros Registrados");
        Thread.Sleep(3000);
    }
    static void CodigosVuelo()
    {
        foreach (var item in listaVuelos)
        {
            Console.WriteLine(item.Codigo);
        }
    }

    //3
    static void OcupacionMedia(){
        int i = 0;
        double porcentajes = 0;
        foreach (var item in listaVuelos) {
            porcentajes += item.PorcentajeOcupacion;
            i++;
        }
        double OcupacionMedia = porcentajes / i;
        Console.WriteLine("La ocupacion Media de la flota es: "+OcupacionMedia+"%");
    
    }

    //5
    static void BuscarVuelo()
    {
        CodigosVuelo();
        Console.WriteLine("Ingrese el codigo de vuelo:");
        string codigoVuelo = Console.ReadLine();

      
        foreach (var item in listaVuelos)
        {

            if (item.Codigo == codigoVuelo)
            {
                MostrarVuelo(item);
                Console.ReadKey();
                break;
            }

        }

        
    }

    //4,6
    static void VueloMayorAMenor() 
    {
        for (int i = 0; i < listaVuelos.Count - 1; i++)
        {
            bool ordenado = true;

            for (int j = 0; j < listaVuelos.Count - i - 1; j++)
            {
                if (listaVuelos[j].PorcentajeOcupacion < listaVuelos[j + 1].PorcentajeOcupacion)
                {
                    ordenado = false;

                    Vuelo temp = listaVuelos[j];
                    listaVuelos[j] = listaVuelos[j + 1];
                    listaVuelos[j + 1] = temp;
                }
            }
            if (ordenado)
            {
                break;
            }
        }

    }
    static void MostrarListaVuelo()
    {
        foreach (var item in listaVuelos) {
            MostrarVuelo(item);
        }
    }
    static void MostrarVuelo(Vuelo item) {
        Console.WriteLine("Codigo: " + item.Codigo);
        Console.WriteLine("FechaSalida: " + item.FechaSalida);
        Console.WriteLine("FechaLlegada: " + item.FechaLlegada);
        Console.WriteLine("NombrePiloto: " + item.NombrePiloto);
        Console.WriteLine("NombreCoPiloto: " + item.NombreCoPiloto);
        Console.WriteLine("CapacidadMaxima: " + item.CapacidadMaxima);
        Console.WriteLine("PasajerosAbordo: " + item.PasajerosAbordo);
        Console.WriteLine("PorcentajeOcupacion: " + item.PorcentajeOcupacion+"%"+"\n");
       

    }
    //7
    static void CargarDatos()
    {
        using (var writer = XmlWriter.Create("Vuelos.xml", new XmlWriterSettings { Indent = true }))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Vuelos");

            foreach (var vuelo in listaVuelos)
            {
                writer.WriteStartElement("Vuelo");

                writer.WriteElementString("Codigo", vuelo.Codigo);
                writer.WriteElementString("FechaSalida", vuelo.FechaSalida.ToString("o"));
                writer.WriteElementString("FechaLlegada", vuelo.FechaLlegada.ToString("o"));
                writer.WriteElementString("NombrePiloto", vuelo.NombrePiloto);
                writer.WriteElementString("NombreCoPiloto", vuelo.NombreCoPiloto);
                writer.WriteElementString("CapacidadMaxima", vuelo.CapacidadMaxima.ToString());
                writer.WriteElementString("PasajerosAbordo", vuelo.PasajerosAbordo.ToString());
                writer.WriteElementString("PorcentajeOcupacion", vuelo.PorcentajeOcupacion.ToString("F2"));

                writer.WriteEndElement(); 
            }

            writer.WriteEndElement(); 
            writer.WriteEndDocument();
        }

        Console.WriteLine("Datos Cargados");
        Thread.Sleep(2000);
    }

    static void CargarDesdeXml(string rutaArchivo)
    {
        if (!File.Exists(rutaArchivo))
        {
            return;
        }

        var doc = new XmlDocument();
        doc.Load(rutaArchivo);

        var vuelos = doc.DocumentElement.SelectNodes("Vuelo");
        foreach (XmlNode nodo in vuelos)
        {
            var vuelo = new Vuelo(
                codigo: nodo["Codigo"]?.InnerText,
                fechaSalida: DateTime.Parse(nodo["FechaSalida"]?.InnerText ?? DateTime.MinValue.ToString()),
                fechaLlegada: DateTime.Parse(nodo["FechaLlegada"]?.InnerText ?? DateTime.MinValue.ToString()),
                nombrePiloto: nodo["NombrePiloto"]?.InnerText,
                nombreCoPiloto: nodo["NombreCoPiloto"]?.InnerText,
                capacidadMaxima: int.Parse(nodo["CapacidadMaxima"]?.InnerText ?? "0")
            )
            {
                PasajerosAbordo = double.Parse(nodo["PasajerosAbordo"]?.InnerText ?? "0"),
                PorcentajeOcupacion = double.Parse(nodo["PorcentajeOcupacion"]?.InnerText ?? "0.0")
            };

            listaVuelos.Add(vuelo);
        }

        Console.WriteLine($"Se cargaron {listaVuelos.Count} vuelos desde el archivo {rutaArchivo}.");
    }



}

