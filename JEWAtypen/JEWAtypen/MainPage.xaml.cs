
using System.Timers;
using JEWAtypen.Models;

namespace JEWAtypen;

public partial class MainPage : ContentPage
{
    private static System.Timers.Timer _timer;
    JEWATypenModel model;

    public MainPage()
	{
		InitializeComponent();
        /*
         * TODO: het programma starten
         * -> de timer configureren
         * -> het model klaarmaken
         * --> artikel ophalen -> met WikiInterface
         * --> tekst opschonen -> functie op het ressultaat uitvoeren
         * --> tekst toevoegen aan model
         */
	}

    private void OnTimerTick(Object source, ElapsedEventArgs e)
    {
        // TODO: wat moet er gebeuren bij iedere timer-tick?
    }

    private void editor_TextChanged(object sender, TextChangedEventArgs e)
    {
        /*
         * TODO: wat moet er gebeuren als de inhoud van het tekstvak wijzigt
         * -> de timer starten als we beginnen met typen
         * -> De timer stoppen als de tekst overgetyped is
         * -> Fouten tellen
         */
    }
}

