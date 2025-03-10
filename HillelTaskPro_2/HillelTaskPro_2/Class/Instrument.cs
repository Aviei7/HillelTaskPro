using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelTaskPro_2.Instrument
{
    abstract class Instrument
    {
        protected string Name;
        protected string Description;
        protected string Music;
        protected string HistoryInstrument;

        public void Sound()
        {
            Console.WriteLine($"Назва: {Music}");
        }

        public void Show()
        {
            Console.WriteLine($"Музичний інструмент: {Name}");
        }

        public void Desc()
        {
            Console.WriteLine($"Опис: {Description}");
        }

        public void History()
        {
            Console.WriteLine($"Історія: {HistoryInstrument}");
        }

    }
    class Violin : Instrument
    {
        public Violin()
        {
            Name = "Скрипка";
            Music = "Ви-и-и-нь";
            Description = "Скрипка — струнно-смичковий музичний інструмент із чотирма струнами.";
            HistoryInstrument = "Скрипка появилась в XVI веке в Северной Италии и эволюционировала из более ранних струнных инструментов, таких как ребек, виола и лира да браччо.";
        }

    }

    class Trombone : Instrument
    {
        public Trombone()
        {
            Name = "Тромбон";
            Music = "Брум-брум";
            Description = "Тромбон - мідний духовий музичний інструмент, відмінною рисою якого є наявність пересувної куліси, що плавно змінює об'єм повітря в інструменті і відповідно висоту його звучання.";
            HistoryInstrument = "Поява тромбона відноситься до XV століття. Прийнято вважати, що безпосередніми попередниками цього інструменту були кулісні труби, при грі на яких музикант мав можливість пересувати трубку інструменту, таким чином отримуючи хроматичний звукоряд.";
        }

    }

    class Ukulele : Instrument
    {
        public Ukulele()
        {
            Name = "Укулеле";
            Music = "Дзынь-дзынь";
            Description = "Укуле́ле — чотириструнний різновид гітари, що використовується для акордового супроводу пісень та гри соло.";
            HistoryInstrument = "Укулеле з'явилася на Гавайських островах у другій половині XIX століття, куди її, під назвою машеті та браса (порт. machete da braça), завезли португальці з острова Мадейра.";
        }

    }

    class Cello : Instrument
    {
        public Cello()
        {
            Name = "Віолончель";
            Music = "Вууум";
            Description = "Віолонче́ль, також уживається віолонче́ля та віольонче́ля (італ. violoncello, зменш. від violone — контрабас, скор. че́льо cello; фр. violoncelle; англ. cello) — струнний смичковий музичний інструмент, родини скрипкових, басо-тенорового регістру.";
            HistoryInstrument = "Поява віолончелі сягає початку XVI століття. Спочатку її застосовували як басовий інструмент для супроводу співу або виконання на інструменті вищого регістру.";
        }

    }
}
